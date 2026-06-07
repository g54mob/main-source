using DG.Tweening;
using UnityEngine;

namespace VampireSurvivors.Tools
{
	public class XScaleOnEnable : MonoBehaviour
	{
		[SerializeField]
		private float _Duration;

		private Vector3 _scale;

		private Tween _scaleTween;

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
