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
	public class CheckBoxVisualizer : BaseStateVisualizer3D
	{
		public List<Renderer> offsetRenderers;

		public Vector2 uncheckedMaterialOffset;

		public Vector2 selectedMaterialOffset;

		public float transitionSpeed;

		public Ease transitionEase;

		private List<TweenerCore<Vector4, Vector4, VectorOptions>> _offsetTweens;

		private Dictionary<Renderer, MaterialPropertyBlock> _mpbs;

		private Vector2? _targetOffset;

		private void SetOffset(Vector2 offset, bool skipTransition)
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
