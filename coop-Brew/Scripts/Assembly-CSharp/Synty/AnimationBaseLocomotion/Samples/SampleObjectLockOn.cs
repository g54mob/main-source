using UnityEngine;

namespace Synty.AnimationBaseLocomotion.Samples
{
	public class SampleObjectLockOn : MonoBehaviour
	{
		public Material _highlightMat;

		public Material _targetMat;

		private Transform _highlightOrb;

		private MeshRenderer _meshRenderer;

		private void Start()
		{
		}

		private void OnTriggerEnter(Collider otherCollider)
		{
		}

		private void OnTriggerExit(Collider otherCollider)
		{
		}

		public void Highlight(bool enable, bool targetLock)
		{
		}
	}
}
