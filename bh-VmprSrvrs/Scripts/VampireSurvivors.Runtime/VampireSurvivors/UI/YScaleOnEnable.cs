using DG.Tweening;
using UnityEngine;

namespace VampireSurvivors.UI
{
	public class YScaleOnEnable : MonoBehaviour
	{
		[SerializeField]
		private float _Duration;

		private Tween _scaleTween;

		private Vector3 _scale;

		private bool _hasInitialized;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
