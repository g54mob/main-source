using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace FluffyUnderware.Curvy.Generator
{
	[Serializable]
	public class CGModuleInputSlot : CGModuleSlot
	{
		public InputSlotInfo InputInfo => null;

		protected override void LoadLinkedSlots()
		{
		}

		public override void LinkTo(CGModuleSlot outputSlot)
		{
		}

		public override void UnlinkFrom(CGModuleSlot outputSlot)
		{
		}

		public CGModuleOutputSlot SourceSlot(int index = 0)
		{
			return null;
		}

		public bool CanLinkTo(CGModuleOutputSlot source)
		{
			return false;
		}

		public static bool AreInputAndOutputSlotsCompatible(InputSlotInfo inputSlotInfo, bool inputSlotModuleIsOnRequest, OutputSlotInfo outputSlotInfo, bool outputSlotModuleIsOnRequest)
		{
			return false;
		}

		private CGModule SourceModule(int index)
		{
			return null;
		}

		[CanBeNull]
		public T GetData<T>(params CGDataRequestParameter[] requests) where T : CGData
		{
			return null;
		}

		[CanBeNull]
		public T GetData<T>(out bool isDataDisposable, params CGDataRequestParameter[] requests) where T : CGData
		{
			isDataDisposable = default(bool);
			return null;
		}

		[NotNull]
		public List<T> GetAllData<T>(params CGDataRequestParameter[] requests) where T : CGData
		{
			return null;
		}

		[NotNull]
		public List<T> GetAllData<T>(out bool isDataDisposable, params CGDataRequestParameter[] requests) where T : CGData
		{
			isDataDisposable = default(bool);
			return null;
		}

		[NotNull]
		private CGData[] GetData<T>(int slotIndex, out bool isDataDisposable, params CGDataRequestParameter[] requests) where T : CGData
		{
			isDataDisposable = default(bool);
			return null;
		}

		[NotNull]
		private static CGData[] CloneData<T>([NotNull] CGData[] source) where T : CGData
		{
			return null;
		}
	}
}
