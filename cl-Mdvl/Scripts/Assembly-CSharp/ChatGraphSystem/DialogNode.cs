using System;
using System.Collections.Generic;

namespace ChatGraphSystem
{
	[Serializable]
	public class DialogNode : BaseNode
	{
		public string Name = "";

		public string WindowTitle = "";

		public string ContentTitle = "";

		public string ContentText = "";

		public string ContentImageName = "";

		public List<string> ChoiceIds => NextNodeIds;

		public DialogNode()
			: base(NodeType.Dialog)
		{
		}
	}
}
