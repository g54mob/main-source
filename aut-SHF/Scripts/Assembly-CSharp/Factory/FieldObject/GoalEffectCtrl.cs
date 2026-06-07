using DG.Tweening;
using UnityEngine;

namespace Factory.FieldObject
{
	public class GoalEffectCtrl : MonoBehaviour
	{
		public GameObject particlePrefab;

		private Vector3 _toPos;

		private Vector3 _fromScale;

		private ParticleSystem _particleSystem;

		private float _duration;

		private Ease _moveEase;

		private Ease _scaleEase;

		public void Init(float duration, Ease moveEase, Ease scaleEase)
		{
		}

		private void OnEnable()
		{
		}
	}
}
