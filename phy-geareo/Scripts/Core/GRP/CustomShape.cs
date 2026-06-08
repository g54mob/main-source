using System;
using UnityEngine;

namespace GRP
{
	public class CustomShape : SimShape
	{
		public Func<Collider> getShapeSettings;

		public Func<float> getVolume;

		public void Use(SimShape shape)
		{
		}

		public override Collider GetShapeCollider()
		{
			return null;
		}

		public override float GetVolume()
		{
			return 0f;
		}
	}
}
