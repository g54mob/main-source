using System;
using System.Collections.Generic;

namespace Kitchen.ChefConnector.Commands
{
	[Serializable]
	public struct ChefPollUpdate
	{
		public string Type;

		public List<int> Choices;

		public bool IsComplete;

		public bool IsForced;

		public float Progress;
	}
}
