using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class FrameLocker : MonoBehaviour
	{
		public bool handleAnimators;

		public bool handleParticleSystems;

		[SerializeField]
		private List<Animator> _animators;

		[SerializeField]
		private List<ParticleSystem> _particleSystems;

		[ContextMenu("FrameLockChildren")]
		public void FrameLockChildren()
		{
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}
	}
}
