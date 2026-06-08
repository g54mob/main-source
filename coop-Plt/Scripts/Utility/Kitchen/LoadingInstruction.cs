using System;
using System.Threading.Tasks;

namespace Kitchen
{
	public struct LoadingInstruction
	{
		public InstructionGroup Group;

		public Func<Task> Initialise;

		public string DebuggingIdentifier;

		public LoadingInstruction(InstructionGroup group, Func<Task> init, string id)
		{
			Group = group;
			Initialise = init;
			DebuggingIdentifier = id;
		}
	}
}
