using System;

namespace ModIO
{
	[Serializable]
	public struct TermsOfUse
	{
		public string termsOfUse;

		public TermsOfUseLink[] links;

		public TermsHash hash;
	}
}
