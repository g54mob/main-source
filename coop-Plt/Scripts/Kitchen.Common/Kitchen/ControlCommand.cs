using System;
using Controllers;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct ControlCommand : ICommandUpdate
	{
		[Key(1)]
		public CommandType Type;

		[Key(2)]
		public ICommandData Data;

		[Key(0)]
		public SourceIdentifier SourceIdentifier { get; set; }
	}
}
