using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI
{
	[ExecuteInEditMode]
	public class RelativeScaler3DUIView : MonoBehaviour
	{
		[SerializeField]
		private Transform _relativeTransform;

		private RectTransform _relativeRectTransform;

		private Container3DUIView _container3DUIView;

		public float minHeight;

		public float maxHeight;

		public float minWidth;

		public float maxWidth;

		public Vector2 padding;

		private float _errorMargin;

		[Header("Editor Tools")]
		public bool showBoundingBox;

		[SerializeField]
		private Vector2 _previousContainerSize;

		[HideInInspector]
		[SerializeField]
		private Vector2 _previousPreferredSize;

		[HideInInspector]
		[SerializeField]
		private float _previousHeight;

		[HideInInspector]
		[SerializeField]
		private Bounds _previousBounds;

		public List<Renderer> ignoreRenderersForBounds;

		private float GetDifferencePercentage(float difference, float previousSize)
		{
			return 0f;
		}

		public void ResetRelativeScale()
		{
		}

		public void ResetToDefaultScale()
		{
		}

		public void UpdateSize()
		{
		}

		private void UpdateContainer3DUIViewScaler()
		{
		}

		private void UpdatePreferredSizeScaler()
		{
		}

		private void UpdateHeightScaler()
		{
		}

		private Bounds? CalculateBounds()
		{
			return null;
		}

		private void UpdateBoundsScaler()
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
