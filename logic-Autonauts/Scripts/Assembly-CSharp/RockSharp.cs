using SimpleJSON;
using UnityEngine;

public class RockSharp : Holdable
{
	public override void PostCreate()
	{
		base.PostCreate();
		Vector3 localScale = base.transform.localScale;
		localScale = localScale * 0.75f + localScale * Random.Range(0f, 0.5f);
		base.transform.localScale = localScale;
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
}
