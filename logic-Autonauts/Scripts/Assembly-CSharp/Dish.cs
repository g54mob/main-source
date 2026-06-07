using SimpleJSON;
using UnityEngine;

public class Dish : Holdable
{
	public static bool GetIsTypeDish(ObjectType NewType)
	{
		if (NewType == ObjectType.PotClay || NewType == ObjectType.LargeBowlClay || NewType == ObjectType.JarClay)
		{
			return true;
		}
		return false;
	}

	public override void PostCreate()
	{
		base.PostCreate();
		m_MaxUsageCount = VariableManager.Instance.GetVariableAsInt(m_TypeIdentifier, "MaxUsage");
	}

	public override void Save(JSONNode Node)
	{
		base.Save(Node);
		JSONUtils.Set(Node, "Used", m_UsageCount);
	}

	public override void Load(JSONNode Node)
	{
		base.Load(Node);
		m_UsageCount = JSONUtils.GetAsInt(Node, "Used", 0);
	}

	protected override void ActionBeingHeld(Actionable Holder)
	{
		base.ActionBeingHeld(Holder);
		base.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
	}
}
