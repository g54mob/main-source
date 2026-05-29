using System;
using UnityEngine;

namespace Libs
{
	public class RectIntValueAttribute : Attribute
	{
		public RectInt RectIntValue { get; protected set; }

		public RectIntValueAttribute(int xMin, int yMin, int width, int height)
		{
		}
	}
}
