﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCtrl : NddBehaviour {
	[SerializeField]protected BoxCollider2D box2D;
	[SerializeField]protected Rigidbody2D rig2D;
	[SerializeField]protected SkillSurfPlayer skillSurfPlayer;
	[SerializeField]protected AnimationPlayer animationPlayer;

	public AnimationPlayer AnimationPlayer{
		get{
			return animationPlayer;
		}
	}
	public SkillSurfPlayer SkillSurfPlayer{
		get{
			return skillSurfPlayer;
		}
	}
	public BoxCollider2D Box2D{
		get{
			return box2D;
		}
	}
	public Rigidbody2D Rig2D{
		get{
			return rig2D;
		}
	}

	private static PlayerCtrl instance;
	public static PlayerCtrl Instance{
		get{
			return instance;
		}
	}
	protected override void LoadSingleton() {
		if (PlayerCtrl.instance != null) {
			Debug.LogError("Only 1 PlayerCtrl allow to exist");

		}
		PlayerCtrl.instance = this;
	}


	protected override void LoadComponent(){
		this.LoadBoxCollider2D ();
		this.LoadRigidbody2D ();
		this.LoadSkillSurfPlayer ();
		this.LoadAnimationPlayer ();

	}
	protected virtual void LoadAnimationPlayer(){
		if (this.animationPlayer != null)
			return;
		this.animationPlayer= GetComponentInChildren<AnimationPlayer>();
		Debug.Log ("Add AnimationPlayer", gameObject);
	}
	protected virtual void LoadSkillSurfPlayer(){
		if (this.skillSurfPlayer != null)
			return;
		this.skillSurfPlayer= GetComponentInChildren<SkillSurfPlayer>();
		Debug.Log ("Add SkillSurfPlayer", gameObject);
	}
	protected virtual void LoadBoxCollider2D(){
		if (this.box2D != null)
			return;
		this.box2D= GetComponentInChildren<BoxCollider2D>();
		Debug.Log ("Add BoxCollider2D", gameObject);
	}
	protected virtual void LoadRigidbody2D(){
		if (this.rig2D != null)
			return;
		this.rig2D= GetComponent<Rigidbody2D>();
		this.SetRigidbody2D ();
		Debug.Log ("Add LoadRigidbody2D", gameObject);
	}
	protected virtual void SetRigidbody2D(){
		this.rig2D.gravityScale = 0; 
	}
}