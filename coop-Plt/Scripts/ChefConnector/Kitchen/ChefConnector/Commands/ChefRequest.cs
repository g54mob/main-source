using System;

namespace Kitchen.ChefConnector.Commands
{
	[Serializable]
	public struct ChefRequest
	{
		public string Type;

		public string Instruction;
	}
}
