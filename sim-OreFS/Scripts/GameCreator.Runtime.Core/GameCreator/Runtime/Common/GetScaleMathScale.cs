using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Scale Number")]
	[Category("Math/Scale Number")]
	[Image(typeof(IconMultiplyCircle), ColorTheme.Type.Yellow)]
	[Description("Scale a Scale property uniformly by a certain value")]
	public class GetScaleMathScale : PropertyTypeGetScale
	{
		[SerializeField]
		private PropertyGetScale m_Scale = GetScalePlayer.Create;

		[SerializeField]
		private PropertyGetDecimal m_Amount = GetDecimalConstantOne.Create;

		public static PropertyGetScale Create => new PropertyGetScale(new GetScaleMathScale());

		public override string String => $"({m_Scale} * {m_Amount})";

		public override Vector3 Get(Args args)
		{
			return m_Scale.Get(args) * (float)m_Amount.Get(args);
		}
	}
}
