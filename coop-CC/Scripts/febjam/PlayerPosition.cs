using Aggro.Core;
using Aggro.Core.Networking;

public class PlayerPosition : EntityBehaviourBase
{
	public enum PositionSubType
	{
		RunStart = 0,
		BackFromShift = 1
	}

	public RoomType roomType;

	public PositionSubType subType;

	public bool Evaluate(RoomType type)
	{
		if (roomType != type)
		{
			return false;
		}
		switch (roomType)
		{
		case RoomType.Warehouse:
			return true;
		case RoomType.BreakRoom:
			switch (subType)
			{
			case PositionSubType.RunStart:
				if (NetworkAggroManagerBase<ShiftManager>.instance != null && NetworkAggroManagerBase<ShiftManager>.instance.GetCurrentShift() <= 1)
				{
					return true;
				}
				return false;
			case PositionSubType.BackFromShift:
				if (NetworkAggroManagerBase<ShiftManager>.instance != null && NetworkAggroManagerBase<ShiftManager>.instance.GetCurrentShift() >= 2)
				{
					return true;
				}
				return false;
			default:
				throw new InvalidEnumException();
			}
		default:
			throw new InvalidEnumException();
		}
	}
}
