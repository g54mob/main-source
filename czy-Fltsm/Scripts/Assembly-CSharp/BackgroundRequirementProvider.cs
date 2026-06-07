using UnityEngine;

[CreateAssetMenu(fileName = "Background Requirement Provider", menuName = "Flotsam/Tech Tree/Background Requirement Provider")]
public class BackgroundRequirementProvider : TechTreeRequirementProvider
{
	public override TechTreeRequirement CreateRequirementInstance()
	{
		BackgroundRequirement backgroundRequirement = ScriptableObject.CreateInstance<BackgroundRequirement>();
		backgroundRequirement.SetProvider(this);
		return backgroundRequirement;
	}

	public override bool IsProviderFor(TechTreeRequirement techTreeRequirement)
	{
		return techTreeRequirement is BackgroundRequirement;
	}

	public override Sprite GetIcon(TechTreeRequirement techTreeRequirement)
	{
		if (techTreeRequirement is BackgroundRequirement backgroundRequirement && (bool)backgroundRequirement.Background)
		{
			return backgroundRequirement.Background.IconProperties.Sprite;
		}
		return null;
	}
}
