using UnityEngine;

namespace Gh.Tk
{
	public class ChildParticleScaler : MonoBehaviour
	{
		private ParticleSystem.EmissionModule emissionModule;

		private ParticleSystem ps;

		public AnimationCurve size3DCurve;

		public Vector3 sizeSmallest3DMin;

		public Vector3 sizeSmallest3DMax;

		public Vector3 sizeLargest3DMin;

		public Vector3 sizeLargest3DMax;

		public float parentScaleZeroPointOffset;

		private float _parentScale;

		private float _lastParentScale;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
