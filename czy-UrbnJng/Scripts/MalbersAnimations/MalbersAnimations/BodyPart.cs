using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations
{
	[Serializable]
	public class BodyPart
	{
		public string name = "member";

		public bool Instantiate = true;

		public float life = 10f;

		public Limb member;

		public bool dismembered;

		public GameObject AttachedLimb;

		public List<Transform> AttachedLimbBones;

		public UnityEvent OnDismember = new UnityEvent();

		public BodyPart()
		{
			name = "member";
			Instantiate = true;
			dismembered = false;
			life = 10f;
		}
	}
}
