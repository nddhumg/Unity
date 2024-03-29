﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CapsuleCollider2D))]
public class ColliderBullet : NddBehaviour {
	[Header("ColliderBullet")]

	[SerializeField] protected BulletCtrl bulletCtrl;
	[SerializeField] protected CapsuleCollider2D capsuleCollider2D;

	protected override void LoadComponent(){
		this.LoadBulletCtrl ();
		base.LoadComponent ();
		this.LoadCapsuleCollider2D ();
	}
	protected virtual void LoadBulletCtrl(){
		if (this.bulletCtrl != null)
			return;
		this.bulletCtrl= transform.parent.GetComponent<BulletCtrl>();
		Debug.Log ("Add  BulletCtrl", gameObject);
	}
	protected virtual void LoadCapsuleCollider2D(){
		if(this.capsuleCollider2D != null)
			return;
		this.capsuleCollider2D = GetComponent<CapsuleCollider2D> ();
		this.capsuleCollider2D.isTrigger = true;
		capsuleCollider2D.size = bulletCtrl.BulletSO.sizeCapsule.sizeCollider;
		capsuleCollider2D.offset = bulletCtrl.BulletSO.sizeCapsule.offsetCollider;
		Debug.Log("Add CapsuleCollider2D",gameObject);
	}
	void OnTriggerEnter2D(Collider2D col){
		if (col.transform.name == transform.name )
			return;
		if (col.transform.parent.tag == bulletCtrl.BulletSO.tagShooter) {
			return;
		}
		bulletCtrl.DamageSender.Send (col.transform.parent);
	}
}
