using System;
using UnityEngine;

namespace Rewired.UI.ControlMapper
{
	[RequireComponent(typeof(CanvasScalerExt))]
	public class CanvasScalerFitter : MonoBehaviour
	{
		[Serializable]
		private class BreakPoint
		{
			[SerializeField]
			public string name;

			[SerializeField]
			public float screenAspectRatio;

			[SerializeField]
			public Vector2 referenceResolution;
		}

		[SerializeField]
		private BreakPoint[] breakPoints;

		private CanvasScalerExt canvasScaler;

		private int screenWidth;

		private int screenHeight;

		private Action ScreenSizeChanged;

		private void OnEnable()
		{
		}

		private void Update()
		{
		}

		private void UpdateSize()
		{
		}
	}
}
