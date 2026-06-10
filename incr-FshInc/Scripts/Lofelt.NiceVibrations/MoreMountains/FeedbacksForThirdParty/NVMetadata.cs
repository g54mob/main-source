using System;
using System.Collections.Generic;

namespace MoreMountains.FeedbacksForThirdParty
{
	[Serializable]
	public class NVMetadata
	{
		public string editor;

		public string author;

		public string source;

		public string project;

		public List<string> tags;

		public string description;
	}
}
