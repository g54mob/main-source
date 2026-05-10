using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace FluffyUnderware.Curvy.Generator
{
	[Serializable]
	public class CGModuleOutputSlot : CGModuleSlot
	{
		[ItemNotNull]
		[NotNull]
		private CGData[] data;

		[CanBeNull]
		public CGDataRequestParameter[] LastRequestParameters;

		[NotNull]
		[ItemNotNull]
		public CGData[] Data
		{
			get
			{
				return null;
			}
			[Obsolete("Use ClearData, SetDataToElement or SetDataToCollection instead.")]
			[UsedImplicitly]
			set
			{
			}
		}

		[CanBeNull]
		public OutputSlotInfo OutputInfo => null;

		[Obsolete("Use Data instead")]
		[UsedImplicitly]
		public bool HasData => false;

		protected override void LoadLinkedSlots()
		{
		}

		public override void LinkTo(CGModuleSlot inputSlot)
		{
		}

		public override void UnlinkFrom(CGModuleSlot inputSlot)
		{
		}

		public void ClearData()
		{
		}

		public void SetDataToElement<T>([NotNull] T element) where T : CGData
		{
		}

		public void SetDataToCollection<T>([ItemNotNull][NotNull] T[] elements) where T : CGData
		{
		}

		[UsedImplicitly]
		[Obsolete("Use SetDataToElement or SetDataToCollection instead.")]
		public void SetData<T>([CanBeNull][ItemNotNull] List<T> newData) where T : CGData
		{
		}

		[UsedImplicitly]
		[Obsolete("Use SetDataToElement or SetDataToCollection instead.")]
		public void SetData([CanBeNull] params CGData[] newData)
		{
		}

		[CanBeNull]
		[UsedImplicitly]
		[Obsolete("Use Data instead")]
		public T GetData<T>() where T : CGData
		{
			return null;
		}

		[Obsolete("Use Data instead")]
		[CanBeNull]
		[UsedImplicitly]
		public T[] GetAllData<T>() where T : CGData
		{
			return null;
		}

		private void AssignNewData([ItemNotNull][NotNull] CGData[] newData)
		{
		}
	}
}
