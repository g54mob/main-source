using System;
using Controllers;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct ResponseUpdateCommand : ICommandUpdate
	{
		[Key(1)]
		public IResponseData Data;

		[Key(2)]
		public Type HandleType;

		[Key(3)]
		public ViewIdentifier ViewSourceIdentifier;

		[Key(0)]
		public SourceIdentifier SourceIdentifier { get; }

		public ResponseUpdateCommand(IResponseData data, Type handle_type, ViewIdentifier view_source_identifier)
		{
			Data = data;
			HandleType = handle_type;
			ViewSourceIdentifier = view_source_identifier;
			SourceIdentifier = InputSourceIdentifier.Identifier;
		}

		public ResponseUpdateCommand(SourceIdentifier source_id, IResponseData data, Type handle_type, ViewIdentifier view_source_identifier)
		{
			Data = data;
			HandleType = handle_type;
			ViewSourceIdentifier = view_source_identifier;
			SourceIdentifier = source_id;
		}
	}
}
