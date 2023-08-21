﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancementSelectManager : NddBehaviour {
	[SerializeField] protected List<EnhancementSelectProperties> listSelectProperties;
	[SerializeField] protected Transform enhancementSelect;
	private static EnhancementSelectManager instance;
	public static EnhancementSelectManager Instance{
		get{
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (EnhancementSelectManager.instance != null) {
			Debug.LogError("Only 1 EnhancementSelectManager allow to exist");

		}
		EnhancementSelectManager.instance = this;
	}
//	protected override void Start ()
//	{
//		base.Start ();
//		this.SetActiveEnhancementSelect (false);
//	}
	protected override void LoadComponent ()
	{
		base.LoadComponent ();
		this.LoadEnhancementSelect ();
		this.LoadListSelectProperties ();
	}
	protected virtual void LoadEnhancementSelect(){
		if (this.enhancementSelect)
			return;
		this.enhancementSelect = transform.Find ("EnhancementSelect");
		enhancementSelect.gameObject.SetActive (false);
		Debug.LogWarning ("Add EnhancementSelect");
	}
	protected virtual void LoadListSelectProperties(){
		if (listSelectProperties.Count > 0)
			return;
		if (enhancementSelect == null)
			this.LoadEnhancementSelect ();
		foreach (Transform tf in enhancementSelect) {
			EnhancementSelectProperties enhancementSelectProperties = tf.GetComponentInChildren<EnhancementSelectProperties>();
			if (enhancementSelectProperties == null)
				continue;
			listSelectProperties.Add (enhancementSelectProperties);
		}
		Debug.LogWarning ("Add List Properties Enhancement");
	}
	public virtual void SetProperties(EnhancementCode[] arrEnhancementCode){
		int i = 0;
		foreach (EnhancementSelectProperties properties in listSelectProperties) {
			properties.LoadInfoEnhancementSelect (arrEnhancementCode[i]);
			i++;
		}	
	}
	public virtual void SetActiveEnhancementSelect(bool active){
		enhancementSelect.gameObject.SetActive (active);
		if (active)
			MainPlay.Instance.PauseGame ();
		else
			MainPlay.Instance.ResumeGame ();
	}


}