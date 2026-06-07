using DG.Tweening;
using UnityEngine;

namespace Battle
{
	public class CameraShake : MonoBehaviour
	{
		[SerializeField]
		[Label("X軸揺れ幅")]
		private float yShakePower;

		[SerializeField]
		[Label("Y軸揺れ幅")]
		private float xShakePower;

		[SerializeField]
		[Label("Z軸揺れ幅")]
		private float zShakePower;

		[SerializeField]
		[Label("ランダム揺れ幅")]
		private Vector3 randomShakePower;

		private Tween _shakeTween;

		public void CompleteShake()
		{
		}

		public bool CameraShakeOk()
		{
			return false;
		}

		public void XShake(float duration, float? power = null)
		{
		}

		public void YShake(float duration, float? power = null)
		{
		}

		public void ZShake(float duration, float? power = null)
		{
		}

		public void RandomShake(float duration, Vector3? power = null, bool fadeOut = true)
		{
		}
	}
}
