using System;

namespace AeLa.EasyFeedback.APIs
{
	[Serializable]
	public struct Label
	{
		public string id;

		public string idBoard;

		public string name;

		public string color;

		public int uses;

		public int order;

		public Label(string id = null, string idBoard = null, string name = null, string color = null, int uses = 0, int order = 0)
		{
			this.id = null;
			this.idBoard = null;
			this.name = null;
			this.color = null;
			this.uses = 0;
			this.order = 0;
		}
	}
}
