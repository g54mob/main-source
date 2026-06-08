using System;

namespace Kitchen.ChefConnector.Commands
{
	[Serializable]
	public struct ChefNamedRequest
	{
		public string Type;

		public string Instruction;

		public string Name;
	}
}
