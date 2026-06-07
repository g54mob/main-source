using System;
using UnityEngine;

namespace Linework.EdgeDetection
{
	[Serializable]
	public class SectionPass
	{
		public RenderingLayerMask RenderingLayer = RenderingLayerMask.defaultRenderingLayerMask;

		public Material customSectionMaterial;
	}
}
