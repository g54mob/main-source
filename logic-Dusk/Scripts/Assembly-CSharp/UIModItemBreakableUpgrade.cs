using UnityEngine;
using UnityEngine.UI;

public class UIModItemBreakableUpgrade : UIModItem
{
	public Text breakProbabilityField;

	public Image scrapIcon;

	protected override void OnDestroy()
	{
		breakProbabilityField = null;
		base.OnDestroy();
	}

	public override void Dim(bool includeExtraFields)
	{
		Color white = Color.white;
		white = ((!IsActive) ? ModificationUI.Instance.disabeledItemTextColor : ((base.overrideActiveColor.a != 0f) ? base.overrideActiveColor : ModificationUI.Instance.enabledItemTextColor));
		white.a = 0.5f;
		breakProbabilityField.color = white;
		if (includeExtraFields && scrapIcon != null)
		{
			scrapIcon.color = white;
		}
		base.Dim(includeExtraFields);
	}

	public override void UnDim(bool includeExtraFields)
	{
		Color white = Color.white;
		white = ((!IsActive) ? ModificationUI.Instance.disabeledItemTextColor : ((base.overrideActiveColor.a != 0f) ? base.overrideActiveColor : ModificationUI.Instance.enabledItemTextColor));
		breakProbabilityField.color = white;
		if (includeExtraFields && scrapIcon != null)
		{
			scrapIcon.color = white;
		}
		base.UnDim(includeExtraFields);
	}
}
