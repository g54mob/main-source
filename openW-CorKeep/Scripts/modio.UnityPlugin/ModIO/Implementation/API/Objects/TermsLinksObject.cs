using System;

namespace ModIO.Implementation.API.Objects
{
	[Serializable]
	internal struct TermsLinksObject
	{
		public TermsLinkObject website;

		public TermsLinkObject terms;

		public TermsLinkObject privacy;

		public TermsLinkObject manage;
	}
}
