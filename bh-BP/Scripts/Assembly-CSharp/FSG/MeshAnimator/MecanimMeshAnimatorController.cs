using System.Collections.Generic;
using UnityEngine;

namespace FSG.MeshAnimator
{
	public class MecanimMeshAnimatorController : MonoBehaviour
	{
		public Animator animator;

		public MeshAnimatorBase meshAnimator;

		private Dictionary<int, string> _animationHashes;

		private string _currentAnimationName;

		protected virtual void Awake()
		{
		}

		protected virtual void LateUpdate()
		{
		}
	}
}
