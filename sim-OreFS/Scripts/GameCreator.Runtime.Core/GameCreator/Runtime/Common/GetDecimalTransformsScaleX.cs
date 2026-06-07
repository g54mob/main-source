using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Scale X")]
	[Category("Transforms/Scale X")]
	[Image(typeof(IconVector3), ColorTheme.Type.Red)]
	[Description("The X component of a Vector3 that represents a scale")]
	[Keywords(new string[] { "Position", "Vector3", "Right", "Left" })]
	public class GetDecimalTransformsScaleX : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected PropertyGetScale m_Scale = GetScaleSelf.Create;

		public override string String => $"{m_Scale}.X";

		public override double Get(Args args)
		{
			return m_Scale.Get(args).x;
		}

		public override double Get(GameObject gameObject)
		{
			return m_Scale.Get(gameObject).x;
		}
	}
}
