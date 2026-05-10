using System;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class AnimationStateReference
	{
		[SerializeField]
		private string _stateName;

		[SerializeField]
		private bool _assigned;

		[SerializeField]
		private Animator _linkedAnimator;

		public string StateName => null;

		public bool Assigned => false;

		public Animator Animator => null;
	}
}
