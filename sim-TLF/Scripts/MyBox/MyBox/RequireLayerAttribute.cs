using System;
using JetBrains.Annotations;
using UnityEngine;

namespace MyBox
{
	[AttributeUsage(AttributeTargets.Class)]
	[PublicAPI]
	public class RequireLayerAttribute : Attribute
	{
		public readonly string LayerName;

		public readonly int LayerIndex = -1;

		public int RequiredLayerIndex
		{
			get
			{
				if (LayerName == null)
				{
					return LayerIndex;
				}
				return LayerMask.NameToLayer(LayerName);
			}
		}

		public RequireLayerAttribute(string layer)
		{
			LayerName = layer;
		}

		public RequireLayerAttribute(int layer)
		{
			LayerIndex = layer;
		}
	}
}
