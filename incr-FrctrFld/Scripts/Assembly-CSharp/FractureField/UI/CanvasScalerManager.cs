using System.Collections.Generic;
using UnityEngine;

namespace FractureField.UI
{
	[ExecuteInEditMode]
	public class CanvasScalerManager : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _rect;

		public List<CanvasScalerHandler> Handlers;

		public float Scale { get; set; }

		private void Start()
		{
		}

		private void OnRectTransformDimensionsChange()
		{
		}

		private void Handler()
		{
		}
	}
}
