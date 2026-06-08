using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CPlayerColour : IComponentData
	{
		public Color Color;

		public static implicit operator Color(CPlayerColour c)
		{
			return c.Color;
		}
	}
}
