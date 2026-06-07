using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Any Global List Variable")]
	[Category("Variables/Any Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	[Description("Returns true if the Global List Variable has at least one element")]
	public class GetBoolGlobalListAny : PropertyTypeGetBool
	{
		[SerializeField]
		private GlobalListVariables m_List;

		public override string String => string.Format("Any in {0}", (m_List != null) ? m_List.name : "(none)");

		public override bool Get(Args args)
		{
			return ((m_List != null && m_List.Count != 0) ? 1 : 0) > (false ? 1 : 0);
		}

		public override bool Get(GameObject gameObject)
		{
			return ((m_List != null && m_List.Count != 0) ? 1 : 0) > (false ? 1 : 0);
		}
	}
}
