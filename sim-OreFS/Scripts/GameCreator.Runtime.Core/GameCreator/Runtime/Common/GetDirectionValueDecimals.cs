using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Vector Components")]
	[Category("Values/Vector Components")]
	[Image(typeof(IconVector3), ColorTheme.Type.Yellow)]
	[Description("A vector with each component as a dynamic property")]
	public class GetDirectionValueDecimals : PropertyTypeGetDirection
	{
		[SerializeField]
		private PropertyGetDecimal m_X = GetDecimalConstantZero.Create;

		[SerializeField]
		private PropertyGetDecimal m_Y = GetDecimalConstantZero.Create;

		[SerializeField]
		private PropertyGetDecimal m_Z = GetDecimalConstantZero.Create;

		public static PropertyGetDirection Create => new PropertyGetDirection(new GetDirectionValueDecimals());

		public override string String => $"({m_X}, {m_Y}, {m_Z})";

		public override Vector3 EditorValue => new Vector3((float)m_X.EditorValue, (float)m_Y.EditorValue, (float)m_Z.EditorValue);

		public override Vector3 Get(Args args)
		{
			return new Vector3((float)m_X.Get(args), (float)m_Y.Get(args), (float)m_Z.Get(args));
		}
	}
}
