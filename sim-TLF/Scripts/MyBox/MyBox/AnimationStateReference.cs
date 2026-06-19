using System;
using UnityEngine;

namespace MyBox
{
	[Serializable]
	public class AnimationStateReference
	{
		[SerializeField]
		private string _stateName = string.Empty;

		[SerializeField]
		private bool _assigned;

		[SerializeField]
		private Animator _linkedAnimator;

		public string StateName => _stateName;

		public bool Assigned => _assigned;

		public Animator Animator => _linkedAnimator;
	}
}
