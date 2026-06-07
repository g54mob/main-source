using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Gh.Tk;
using UnityEngine;

namespace Gh
{
	[Serializable]
	public class SpriteColorVisualizer : BaseStateVisualizer3D
	{
		[Header("Color multiplier is the color that will be multiplied by the state color")]
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
		public List<SpriteRenderer> Visuals { get; set; }

		private void ApplyToRenderers(Color color, bool skipTransition)
		{
		}

		public override void VisualizeState(BaseInteractable3DUIView view)
		{
		}

		public override void CleanUp()
		{
		}
	}
}
