using System;
using System.Collections.Generic;

namespace Kitchen.ChefConnector.Commands
{
	[Serializable]
	public struct ChefPollRequest
	{
		public string Type;

		public string Instruction;

		public List<string> Cards;
	}
}
