using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace FluffyUnderware.Curvy.Generator
{
	[Serializable]
	public class CGModuleOutputSlot : CGModuleSlot
	{
		[NotNull]
		[ItemNotNull]
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

		[UsedImplicitly]
		[Obsolete("Use Data instead")]
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

		[Obsolete("Use SetDataToElement or SetDataToCollection instead.")]
		[UsedImplicitly]
		public void SetData<T>([CanBeNull][ItemNotNull] List<T> newData) where T : CGData
		{
		}

		[Obsolete("Use SetDataToElement or SetDataToCollection instead.")]
		[UsedImplicitly]
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

		[CanBeNull]
		[UsedImplicitly]
		[Obsolete("Use Data instead")]
		public T[] GetAllData<T>() where T : CGData
		{
			return null;
		}

		private void AssignNewData([ItemNotNull][NotNull] CGData[] newData)
		{
		}
	}
}
