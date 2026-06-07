using System;
using UnityEngine;

namespace FluffyUnderware.Curvy.Generator
{
	[Serializable]
	public class CGDataReference
	{
		[SerializeField]
		private CGModule m_Module;

		[SerializeField]
		private string m_SlotName;

		private CGModuleOutputSlot mSlot;

		public CGData[] Data => null;

		public CGModuleOutputSlot Slot => null;

		public bool HasValue => false;

		public bool IsEmpty => false;

		public CGModule Module => null;

		public string SlotName => null;

		public CGDataReference()
		{
		}

		public CGDataReference(CGModule module, string slotName)
		{
		}

		public CGDataReference(CurvyGenerator generator, string moduleName, string slotName)
		{
		}

		public void Clear()
		{
		}

		public T GetData<T>() where T : CGData
		{
			return null;
		}

		public T[] GetAllData<T>() where T : CGData
		{
			return null;
		}

		public void setINTERNAL(CGModule module, string slotName)
		{
		}

		public void setINTERNAL(CurvyGenerator generator, string moduleName, string slotName)
		{
		}
	}
}
