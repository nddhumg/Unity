﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : AnimationAbstract {
	public virtual void SetAnimationRuning(bool isRuning){
		ani.SetBool ("IsRuning", isRuning);
	}
}
