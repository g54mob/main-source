using System;
using MessagePack;

namespace Kitchen
{
	[Serializable]
	[MessagePackObject(false)]
	public struct EntityUpdate : INetworkData
	{
		[Key(0)]
		public ViewIdentifier Identifier;

		[Key(1)]
		public IViewData Data;

		[Key(2)]
		public MessageType Type;

		public bool GetRollUp(out MessageIdentifier identifier, out IRollUp roll_up)
		{
			identifier = new MessageIdentifier
			{
				Identifier = Identifier,
				Type = Type
			};
			if (Data is IRollUp rollUp)
			{
				roll_up = rollUp;
				return true;
			}
			roll_up = null;
			return false;
		}

		public void SetRollUp(IRollUp roll_up)
		{
			Data = (IViewData)roll_up;
		}
	}
}
