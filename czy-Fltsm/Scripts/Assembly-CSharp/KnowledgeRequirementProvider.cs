using UnityEngine;

[CreateAssetMenu(fileName = "Knowledge Requirement Provider", menuName = "Flotsam/Tech Tree/Knowledge Requirement Provider")]
public class KnowledgeRequirementProvider : TechTreeRequirementProvider
{
	[SerializeField]
	private Sprite _icon;

	public override TechTreeRequirement CreateRequirementInstance()
	{
		KnowledgeRequirement knowledgeRequirement = ScriptableObject.CreateInstance<KnowledgeRequirement>();
		knowledgeRequirement.SetProvider(this);
		return knowledgeRequirement;
	}

	public override bool IsProviderFor(TechTreeRequirement techTreeRequirement)
	{
		return techTreeRequirement is KnowledgeRequirement;
	}

	public override Sprite GetIcon(TechTreeRequirement techTreeRequirement)
	{
		return _icon;
	}
}
