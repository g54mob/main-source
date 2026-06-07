using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProductWindowButton : UIBehaviour
{
	public bool PlayerOnly;

	public bool MultiSelect;

	public bool DevOnly;

	public bool NeedsSelection;

	public bool Product;

	public bool AddOn;

	public bool Framework;

	public bool NoPublisher;

	public bool Archived = true;

	public bool SoftwareOnly;

	public string MissionUnlock;

	public Text Label;

	public RectTransform Thumbnail;

	public float Index;

	protected override void OnRectTransformDimensionsChange()
	{
		if (Label != null)
		{
			OnLocalized();
		}
	}

	public void OnLocalized()
	{
		Thumbnail.anchoredPosition = new Vector2((0f - Mathf.Min(Label.GetLineWidth(Label.text), Label.rectTransform.rect.width - 8f)) / 2f + 12f, 0f);
	}

	public bool Check(bool notMe, bool publisher, bool archived, int selected, int type, bool anySoftware)
	{
		if (DevOnly)
		{
			return false;
		}
		if (NoPublisher && publisher)
		{
			return false;
		}
		if (NoPublisher && GameSettings.Instance.Difficulty.Publisher < 0.5f)
		{
			return false;
		}
		if (GameSettings.Instance.CampaignMode && !string.IsNullOrEmpty(MissionUnlock) && !GameSettings.HasCompletedOrInMission(MissionUnlock))
		{
			return false;
		}
		if (selected == 0 && NeedsSelection)
		{
			return false;
		}
		if (PlayerOnly && notMe)
		{
			return false;
		}
		if (NeedsSelection && !MultiSelect && selected > 1)
		{
			return false;
		}
		if (archived && !Archived)
		{
			return false;
		}
		if (SoftwareOnly && !anySoftware)
		{
			return false;
		}
		switch (type)
		{
		case 0:
			if (!Product)
			{
				return false;
			}
			break;
		case 1:
			if (!AddOn)
			{
				return false;
			}
			break;
		case 2:
			if (!Framework)
			{
				return false;
			}
			break;
		}
		return true;
	}
}
