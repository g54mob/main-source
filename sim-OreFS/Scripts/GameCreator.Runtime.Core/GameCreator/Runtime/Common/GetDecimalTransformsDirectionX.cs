using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Direction X")]
	[Category("Transforms/Direction X")]
	[Image(typeof(IconVector3), ColorTheme.Type.Red)]
	[Description("The X component of a Vector3 that represents a direction")]
	[Keywords(new string[] { "Position", "Vector3", "Right", "Left" })]
	public class GetDecimalTransformsDirectionX : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetDirection m_Direction = GetDirectionSelf.Create;

		public override string String => $"{m_Direction}.X";

		public override double Get(Args args)
		{
			return m_Direction.Get(args).x;
		}

		public override double Get(GameObject gameObject)
		{
			return m_Direction.Get(gameObject).x;
		}
	}
}
