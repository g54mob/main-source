using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Has Save at Slot")]
	[Description("Returns true if there is a saved game at the specified slot")]
	[Category("Storage/Has Save at Slot")]
	[Keywords(new string[] { "Game", "Load", "Continue", "Resume", "Can", "Is" })]
	[Image(typeof(IconDiskSolid), ColorTheme.Type.Green, typeof(OverlayDot))]
	public class ConditionHasSaveAtSlot : Condition
	{
		[SerializeField]
		private PropertyGetInteger m_Slot = GetDecimalInteger.Create(1);

		protected override string Summary => $"has Saved Game at {m_Slot}";

		protected override bool Run(Args args)
		{
			int slot = (int)m_Slot.Get(args);
			return Singleton<SaveLoadManager>.Instance.HasSaveAt(slot);
		}
	}
}
