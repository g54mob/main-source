using System;
using AeLa.EasyFeedback.APIs;

namespace AeLa.EasyFeedback
{
	[Serializable]
	public class FeedbackBoard
	{
		public string Id;

		public string[] ListNames;

		public string[] ListIds;

		public string[] CategoryNames;

		public string[] CategoryIds;

		public Label[] Labels;
	}
}
