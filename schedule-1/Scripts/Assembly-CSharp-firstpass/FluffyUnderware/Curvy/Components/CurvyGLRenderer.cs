using System;
using System.Collections.Generic;
using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Components
{
	[AddComponentMenu("Curvy/Misc/Curvy GL Renderer")]
	[HelpURL("https://curvyeditor.com/doclink/curvyglrenderer")]
	public class CurvyGLRenderer : DTVersionedMonoBehaviour
	{
		[ArrayEx(ShowAdd = false, Draggable = false)]
		public List<GLSlotData> Splines;

		private readonly Lazy<Material> lineMaterial;

		protected override void OnValidate()
		{
		}

		protected override void OnEnable()
		{
		}

		[UsedImplicitly]
		private void OnPostRender()
		{
		}

		private void sanitize()
		{
		}

		private void OnSplineRefresh(CurvySplineEventArgs e)
		{
		}

		private GLSlotData getSlot(CurvySpline spline)
		{
			return null;
		}

		public void Add(CurvySpline spline)
		{
		}

		[UsedImplicitly]
		[Obsolete("No more used in Curvy. Will get removed. Copy it if you still need it")]
		public void Remove(CurvySpline spline)
		{
		}
	}
}
