using DG.Tweening;
using UnityEngine;

namespace Gh.Tk
{
	public class EventCameraSwitcherButton3DUIView : Button3DUIView
	{
		[SerializeField]
		private Renderer _outputRenderer;

		private float _previewTextureScale;

		private bool _isPreviewZoomOn;

		private Vector3 _clickRotation;

		private Vector3 _startRotation;

		private Tween _pressedTween;

		private Tween _releasedTween;

		protected override void Start()
		{
		}

		public void SetOuputTexture(RenderTexture outputTexture)
		{
		}

		public void SetOuputTexture(Texture2D outputTexture)
		{
		}

		public void PreviewZoomIn()
		{
		}

		public void PreviewZoomOut()
		{
		}

		protected override void UpdateIsPressed()
		{
		}
	}
}
