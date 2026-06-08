using System;
using Controllers;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct UserInputUpdate : ICommandUpdate
	{
		[Key(1)]
		public InputUpdateEvent Data;

		[Key(0)]
		public SourceIdentifier SourceIdentifier { get; set; }

		public static implicit operator InputUpdateEvent(UserInputUpdate u)
		{
			return u.Data;
		}

		public static implicit operator UserInputUpdate(InputUpdateEvent e)
		{
			return new UserInputUpdate
			{
				Data = e,
				SourceIdentifier = InputSourceIdentifier.Identifier
			};
		}
	}
}
