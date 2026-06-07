using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.UI;

namespace Gh
{
	[Serializable]
	public class ImageColorVisualizer : BaseStateVisualizer2D
	{
		public Color ColorMultiplier;

		public Color EnabledColor;

		public Color DisabledColor;

		public Color PressedColor;

		public Color SelectedColor;

		public Color SelectedHoverColor;

		public Color HoverColor;

		public float transitionDuration;

		public Ease transitionEase;

		private List<TweenerCore<Color, Color, ColorOptions>> _visualTweens;

		[field: SerializeField]
		public List<Image> Visuals { get; set; }

		private void ApplyToRenderers(Color color)
		{
		}

		public override void VisualizeState(Interactable2DUIView view)
		{
		}

		public override void CleanUp()
		{
		}
	}
}
