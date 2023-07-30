﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAbleExp : PickUpAbleItem {
	[SerializeField]protected ExpCtrl expCtrl;
	protected override void LoadItemCtrl(){
		base.LoadItemCtrl ();
		expCtrl = itemCtrl as ExpCtrl;
	}
	protected override void	 ActiveItemWhenPickUp ()
	{
		LevelPlayer.Instance.IncreaseExp (expCtrl.ExpSO.experience);
	}
}