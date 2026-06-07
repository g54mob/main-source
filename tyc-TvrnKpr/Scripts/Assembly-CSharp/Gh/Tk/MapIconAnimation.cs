using DG.Tweening;
using UnityEngine;

namespace Gh.Tk
{
	public class MapIconAnimation : MonoBehaviour
	{
		public float height;

		public float heightTime;

		public float yRot;

		public float rotTime;

		private Transform _ourTransform;

		private Tweener _moveTween;

		private Tweener _rotationTween;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
