using System;
using UnityEngine;

namespace Battle
{
	[Serializable]
	public class BoundaryReflection
	{
		[Label("有効：反射")]
		public bool enabledBoundaryReflection;

		[Label("入射角に反射")]
		public bool isRelectionComeFrom;

		public Vector3 LastReflectPos { get; private set; }

		public void InitParameter(BoundaryReflection boundaryReflection)
		{
		}

		public Vector2 Reflection(Vector2 direction, Vector2 hitPos)
		{
			return default(Vector2);
		}
	}
}
