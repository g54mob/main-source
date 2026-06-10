using System;
using System.Collections.Generic;

namespace PlayEveryWare.EpicOnlineServices
{
	[Serializable]
	public class EOSSteamConfig : ICloneableGeneric<EOSSteamConfig>, IEmpty
	{
		public List<string> flags;

		public string overrideLibraryPath;

		public EOSSteamConfig Clone()
		{
			return (EOSSteamConfig)MemberwiseClone();
		}

		public bool IsEmpty()
		{
			if (EmptyPredicates.IsEmptyOrNullOrContainsOnlyEmpty(flags))
			{
				return EmptyPredicates.IsEmptyOrNull(overrideLibraryPath);
			}
			return false;
		}
	}
}
