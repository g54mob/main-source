using System;
using UnityEngine;

namespace CTS
{
	public class N_Poser : MonoBehaviour
	{
		public bool mirror;

		public float s;

		public Animator ac;

		public AnimationClip a;

		private void Update()
		{
			if (!TryGetComponent<Animator>(out ac))
			{
				MonoBehaviour.print("No animator found on " + base.transform.parent.gameObject.name);
			}
			float length = a.length;
			if (s >= 0f && s <= length)
			{
				float normalizedTime = s / length;
				ac.Play(a.name, 0, normalizedTime);
				ac.speed = 0f;
				return;
			}
			throw new Exception(base.name + ": Nop");
		}
	}
}
