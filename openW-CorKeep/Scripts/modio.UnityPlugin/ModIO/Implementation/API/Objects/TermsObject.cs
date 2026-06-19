using System;

namespace ModIO.Implementation.API.Objects
{
	[Serializable]
	internal struct TermsObject
	{
		public string plaintext;

		public string html;

		public TermsButtonObject buttons;

		public TermsLinksObject links;
	}
}
