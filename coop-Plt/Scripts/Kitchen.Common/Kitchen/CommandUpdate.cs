using System;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct CommandUpdate : INetworkData
	{
		[Key(0)]
		public ICommandUpdate Command;

		public bool GetRollUp(out MessageIdentifier identifier, out IRollUp roll_up)
		{
			if (Command is ResponseUpdateCommand { Data: IRollUp data } responseUpdateCommand)
			{
				roll_up = data;
				identifier = new MessageIdentifier
				{
					Identifier = responseUpdateCommand.ViewSourceIdentifier,
					ResponseType = responseUpdateCommand.HandleType
				};
				return true;
			}
			identifier = default(MessageIdentifier);
			roll_up = null;
			return false;
		}

		public void SetRollUp(IRollUp roll_up)
		{
			if (Command is ResponseUpdateCommand responseUpdateCommand)
			{
				responseUpdateCommand.Data = (IResponseData)roll_up;
				Command = responseUpdateCommand;
			}
		}
	}
}
