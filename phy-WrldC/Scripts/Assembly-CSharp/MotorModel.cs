using System.Collections.Generic;

public class MotorModel
{
	public static readonly string Name = typeof(MotorModel).Name;

	private List<HingeJointModel> hingeJointModels;

	public MotorModel()
	{
		hingeJointModels = new List<HingeJointModel>();
	}

	public void AddHingeJointModel(HingeJointModel hingeJointModel)
	{
		if (!hingeJointModels.Contains(hingeJointModel))
		{
			hingeJointModels.Add(hingeJointModel);
		}
	}

	public void RemoveHingeJointModel(HingeJointModel hingeJointModel)
	{
		if (hingeJointModels.Contains(hingeJointModel))
		{
			hingeJointModels.Remove(hingeJointModel);
		}
	}

	public ICollection<HingeJointModel> GetAllHingeJointModels()
	{
		return hingeJointModels.ToArray();
	}

	public int HingeJointsCount()
	{
		return hingeJointModels.Count;
	}
}
