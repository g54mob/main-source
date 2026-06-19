using System;
using UnityEngine;

namespace TH20.UI
{
	[DisallowMultipleComponent]
	[AddComponentMenu("Layout/RectTransform Reparenter", 107)]
	public class RectTransformReparenter : MonoBehaviour
	{
		[Serializable]
		private struct TransformToReparent
		{
			public RectTransform Transform;

			public RectTransform Parent;
		}

		[SerializeField]
		private TransformToReparent[] _transformsToReparent;

		[SerializeField]
		private RectTransform[] _transformsToDeactivate;

		public void ReparentTransforms()
		{
			for (int i = 0; i < _transformsToReparent.Length; i++)
			{
				TransformToReparent transformToReparent = _transformsToReparent[i];
				transformToReparent.Transform.SetParent(transformToReparent.Parent, worldPositionStays: false);
				transformToReparent.Transform.gameObject.SetActive(value: true);
			}
			for (int j = 0; j < _transformsToDeactivate.Length; j++)
			{
				_transformsToDeactivate[j].gameObject.SetActive(value: false);
			}
		}
	}
}
