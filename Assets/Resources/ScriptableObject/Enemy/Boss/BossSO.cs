﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Boss", menuName = "SOCollider/Enemy/Boss")]
public class BossSO : EnemySO {
	[Header("Boss")]
	public Vector2 offsetZoneAttack;
	BossSO(){
		this.classify = ClassifyEnemy.Boss;
	}
}
	