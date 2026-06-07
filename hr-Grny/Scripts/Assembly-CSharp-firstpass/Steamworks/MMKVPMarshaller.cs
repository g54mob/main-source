using System;

namespace Steamworks
{
	public class MMKVPMarshaller
	{
		private IntPtr m_pNativeArray;

		private IntPtr m_pArrayEntries;

		public MMKVPMarshaller(MatchMakingKeyValuePair_t[] filters)
		{
		}

		~MMKVPMarshaller()
		{
		}

		public static implicit operator IntPtr(MMKVPMarshaller that)
		{
			return (IntPtr)0;
		}
	}
}
