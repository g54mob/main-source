using System;
using UnityEngine;

namespace ScriptableObjects.ScriptableObjectScripts.Tile
{
	public class PivotValueAttribute : Attribute
	{
		public Vector2 PivotValue { get; protected set; }

		public PivotValueAttribute(float x, float y)
		{
		}
	}
}
