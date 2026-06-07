using System;
using Dhs5.Utility.Databases;

namespace Dhs5.Utility.Updates
{
	[Serializable]
	public class UpdatePicker : DataPicker<UpdaterDatabase>
	{
		public bool TryGetUpdaterElement(out UpdaterDatabaseElement element)
		{
			return TryGetData<UpdaterDatabaseElement>(out element);
		}

		public bool TryGetUpdateKey(out int updateKey)
		{
			if (TryGetUpdaterElement(out var element))
			{
				updateKey = element.EnumIndex;
				return true;
			}
			updateKey = -1;
			return false;
		}
	}
}
