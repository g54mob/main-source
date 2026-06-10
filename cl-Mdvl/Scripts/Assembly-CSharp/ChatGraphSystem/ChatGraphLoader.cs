using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ChatGraphSystem
{
	public static class ChatGraphLoader
	{
		[Serializable]
		private class GraphJson
		{
			public List<DialogNode> DialogNodes;

			public List<ChoiceNode> ChoiceNodes;
		}

		public static ChatGraphInstance Load(string filePath, string id)
		{
			GraphJson graphJson = JsonConvert.DeserializeObject<GraphJson>(File.ReadAllText(filePath));
			return new ChatGraphInstance(graphJson.DialogNodes, graphJson.ChoiceNodes, id);
		}
	}
}
