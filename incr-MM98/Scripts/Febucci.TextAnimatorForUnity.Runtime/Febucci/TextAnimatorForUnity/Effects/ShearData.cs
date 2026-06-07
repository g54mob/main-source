using System;
using Febucci.TextAnimatorCore.BuiltIn;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	internal class ShearData
	{
		public HorizontalShearType horizontal;

		public VerticalShearType vertical = VerticalShearType.AllSides;

		public float amplitude = 1f;
	}
}
