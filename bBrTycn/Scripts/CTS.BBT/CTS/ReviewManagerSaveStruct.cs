using System;

namespace CTS
{
	[Serializable]
	public struct ReviewManagerSaveStruct
	{
		public ReviewMounthSaveStruct CurrentMounth;

		public ReviewMounthSaveStruct LastMounth;
	}
}
