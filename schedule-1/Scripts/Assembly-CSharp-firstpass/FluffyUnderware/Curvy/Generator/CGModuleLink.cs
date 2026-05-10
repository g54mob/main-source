using System;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	[Serializable]
	public class CGModuleLink
	{
		[SerializeField]
		private int m_ModuleID;

		[SerializeField]
		private string m_SlotName;

		[SerializeField]
		private int m_TargetModuleID;

		[SerializeField]
		private string m_TargetSlotName;

		public int ModuleID => 0;

		public string SlotName => null;

		public int TargetModuleID => 0;

		public string TargetSlotName => null;

		public CGModuleLink(int sourceID, string sourceSlotName, int targetID, string targetSlotName)
		{
		}

		public CGModuleLink(CGModuleSlot source, CGModuleSlot target)
		{
		}

		public bool IsSame(CGModuleLink o)
		{
			return false;
		}

		public bool IsSame(CGModuleSlot source, CGModuleSlot target)
		{
			return false;
		}

		public bool IsTo(CGModuleSlot s)
		{
			return false;
		}

		public bool IsFrom(CGModuleSlot s)
		{
			return false;
		}

		public bool IsUsing(CGModule module)
		{
			return false;
		}

		public bool IsBetween(CGModuleSlot one, CGModuleSlot another)
		{
			return false;
		}

		public void SetModuleIDIINTERNAL(int moduleID, int targetModuleID)
		{
		}

		public static implicit operator bool(CGModuleLink a)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
