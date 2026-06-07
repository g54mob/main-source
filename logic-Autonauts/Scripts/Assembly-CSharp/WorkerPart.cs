public class WorkerPart : Holdable
{
	public enum Type
	{
		Drive = 0,
		Frame = 1,
		Head = 2,
		Total = 3
	}

	public static bool GetIsTypePart(ObjectType NewType)
	{
		if (WorkerDrive.GetIsTypeDrive(NewType) || WorkerFrame.GetIsTypeFrame(NewType) || WorkerHead.GetIsTypeHead(NewType))
		{
			return true;
		}
		return false;
	}

	public virtual Type GetPartType()
	{
		return Type.Total;
	}
}
