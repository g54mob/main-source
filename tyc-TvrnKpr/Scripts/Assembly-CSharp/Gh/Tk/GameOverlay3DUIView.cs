using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Gh.Tk
{
	public class GameOverlay3DUIView : Button3DUIView
	{
		public float endAlphaValue;

		public float duration;

		public Ease ease;

		private Tween _tween;

		private List<MaterialPropertyBlock> _mpbs;

		[SerializeField]
		private List<Renderer> _overlayRenderers;

		private float _currentAlpha;

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}
	}
}
