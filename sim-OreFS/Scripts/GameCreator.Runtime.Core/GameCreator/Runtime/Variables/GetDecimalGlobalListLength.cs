using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Count of Global List Variable")]
	[Category("Variables/Count of Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	[Description("Returns the amount of elements of a Global List Variable")]
	public class GetDecimalGlobalListLength : PropertyTypeGetDecimal
	{
		[SerializeField]
		protected GlobalListVariables m_Variable;

		public override string String
		{
			get
			{
				if (!(m_Variable != null))
				{
					return "(none)";
				}
				return m_Variable.name + " Length";
			}
		}

		public override double Get(Args args)
		{
			return (m_Variable != null) ? m_Variable.Count : 0;
		}

		public override double Get(GameObject gameObject)
		{
			return (m_Variable != null) ? m_Variable.Count : 0;
		}
	}
}
