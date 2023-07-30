﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnEnemy : SpawnsPoolOgj {
	[SerializeField] protected bool isSpawnEnemy = true;
	[SerializeField] protected int numberOfEnemy = 0;
	[SerializeField] protected int maxNumberSpawn = 200;
	private static SpawnEnemy instance;
	public static SpawnEnemy Instance{
		get{
			return instance;
		}
	}

	protected override void LoadSingleton() {
		if (SpawnEnemy.instance != null) {
			Debug.LogError ("Only 1 SpawnFx allow to exist");
		}
		SpawnEnemy.instance = this;
	}
	public  bool IsSpawnEnemy{
		get{
			return isSpawnEnemy;
		}
	}
	public  int NumberOfEnemy{
		get{
			return numberOfEnemy;
		}
	}
	public  int MaxNumberSpawn{
		get{
			return maxNumberSpawn;
		}
	}

	protected override void Start(){
		base.Start ();
		StartCoroutine (CheckIsSpawnEnemy ());
	}

	public override void DesTroyPrefabs(Transform obj){
		ReductTheNumberofEnemy ();
		base.DesTroyPrefabs (obj);
	}
	IEnumerator CheckIsSpawnEnemy(){
		while (true) {
			CheckCoditionSpawn ();
			yield return new WaitForSeconds (1f);
		}
	}

	public virtual void ReductTheNumberofEnemy(){
		if (numberOfEnemy <= 0) {
			numberOfEnemy = 0;
			return;
		}
		numberOfEnemy--;
	}
	public virtual void IncreaseTheNumberofEnemy(){
		numberOfEnemy++;
	}
	protected virtual void CheckCoditionSpawn(){
		if (numberOfEnemy >= maxNumberSpawn)
			isSpawnEnemy = false;
		else {
			isSpawnEnemy = true;
		}
	}
}
