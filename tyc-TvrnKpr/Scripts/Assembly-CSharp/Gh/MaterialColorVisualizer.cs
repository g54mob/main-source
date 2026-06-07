using System;
using System.Collections.Generic;
using DG.Tweening;
using Gh.Tk;
using UnityEngine;

namespace Gh
{
	[Serializable]
	public class MaterialColorVisualizer : BaseStateVisualizer3D
	{
		public Color ColorMultiplier;

		public Color EnabledColor;

		public float metallicEnabledOverride;

		public float smoothnessEnabledOverride;

		public Color DisabledColor;

		public float metallicDisabledOverride;

		public float smoothnessDisabledOverride;

		public Color PressedColor;

		public Color SelectedColor;

		public Color SelectedHoverColor;

		public Color HoverColor;

		private List<MaterialPropertyBlock> _mpbs;

		public float transitionDuration;

		public Ease transitionEase;

		private List<Tweener> _visualTweens;

		public static readonly int BaseColor;

		public static readonly int Metallic;

		public static readonly int Smoothness;

		[field: SerializeField]
		public List<Renderer> Visuals { get; set; }

		public void ApplyToRenderers(Color color, float smoothness, float metallic, bool skipTransition)
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
