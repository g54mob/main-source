using System;
using System.Collections.Generic;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Gh.Tk;
using UnityEngine;

namespace Gh
{
	[Serializable]
	public class ScalingVisualizer : BaseStateVisualizer3D
	{
		public List<Transform> scaledObjects;

		public Vector3 enabledScale;

		public Vector3 disabledScale;

		public Vector3 pressedScale;

		public Vector3 hoveredScale;

		public Vector3 selectedScale;

		public Vector3 selectedHoverScale;

		public float transitionSpeed;

		private List<TweenerCore<Vector3, Vector3, VectorOptions>> _scaleTweens;

		private void ApplyScale(Vector3 scale, bool skipTransition)
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
