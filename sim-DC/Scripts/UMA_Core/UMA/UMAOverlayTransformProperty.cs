using System;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class UMAOverlayTransformProperty : UMAProperty
	{
		public Vector2 Translate;

		public float Rotate;

		public Vector2 Scale;

		public UMAOverlayTransformProperty()
		{
		}

		public UMAOverlayTransformProperty(Vector2 translate, float rotate, Vector2 scale)
		{
		}

		public override void Apply(Material mpb, int overlayNumber)
		{
		}

		public override UMAProperty Clone()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
