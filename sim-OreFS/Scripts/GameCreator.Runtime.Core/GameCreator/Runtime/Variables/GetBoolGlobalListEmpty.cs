using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Variables
{
	[Serializable]
	[Title("Empty Global List Variable")]
	[Category("Variables/Empty Global List Variable")]
	[Image(typeof(IconListVariable), ColorTheme.Type.Teal, typeof(OverlayDot))]
	[Description("Returns true if the Global List Variable is empty")]
	public class GetBoolGlobalListEmpty : PropertyTypeGetBool
	{
		[SerializeField]
		private GlobalListVariables m_List;

		public override string String => string.Format("{0} is Empty", (m_List != null) ? m_List.name : "(none)");

		public override bool Get(Args args)
		{
			return !(m_List != null) || m_List.Count == 0;
		}

		public override bool Get(GameObject gameObject)
		{
			return !(m_List != null) || m_List.Count == 0;
		}
	}
}
