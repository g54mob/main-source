namespace Steamworks
{
	public struct MatchMakingKeyValuePair_t
	{
		public string m_szKey;

		public string m_szValue;

		private MatchMakingKeyValuePair_t(string strKey, string strValue)
		{
			m_szKey = null;
			m_szValue = null;
		}
	}
}
