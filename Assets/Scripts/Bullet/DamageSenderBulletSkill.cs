﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSenderBulletSkill : DamageSender {
	[SerializeField] protected BulletCtrl bulletCtrl;
	protected override void LoadComponent(){
		base.LoadComponent ();
		this.LoadBulletCtrl ();
	}
	protected virtual void LoadBulletCtrl(){
		if (this.bulletCtrl != null)
			return;
		this.bulletCtrl= transform.parent.GetComponent<BulletCtrl>();
		Debug.Log ("Add  BulletCtrl", gameObject);
	}
//	protected override void Send(DamageReceiver recever) {
//		bulletCtrl.DestroyBullet.DestroyObj ();
//		base.Send (recever);
//	}
	protected override void ResetValue ()
	{
		base.ResetValue ();
		this.damage = bulletCtrl.BulletSO.damage;
	}
}