using DG.Tweening;
using QFSW.MOP2;
using UnityEngine;

namespace VampireSurvivors.Objects.VFX
{
	public class SpinningIcosahedron : PoolableMonoBehaviour
	{
		[SerializeField]
		private Transform _icosahedronTransform;

		[SerializeField]
		private Transform _trailRendererTransform;

		private Tween rotationTween;

		private void Awake()
		{
		}

		public void Reset()
		{
		}

		public void ShrinkAndRecycle(float durationInSeconds = 0.25f)
		{
		}

		private void Cleanup()
		{
		}
	}
}
