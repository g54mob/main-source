using UnityEngine;

public class FolkProgressBar : StandardProgressBar
{
	public enum Type
	{
		Food = 0,
		Housing = 1,
		Clothing = 2,
		Toy = 3,
		Medicine = 4,
		Education = 5,
		Art = 6,
		Total = 7
	}

	public Type m_Type;

	private static string[] m_TypeImages = new string[7] { "IconFood", "IconHousing", "IconTop", "IconToy", "IconMedicine", "IconEducation", "IconArt" };

	private Folk m_Target;

	private bool m_ProgressDisabled;

	private bool m_PreviousTier;

	private BaseImage m_TierImage;

	private BaseText m_TierText;

	private BaseText m_RepairText;

	private BaseImage m_RepairImage;

	private bool m_Lowest;

	public void SetType(Type NewType)
	{
		m_Type = NewType;
		m_TierImage = base.transform.Find("TierImage").GetComponent<BaseImage>();
		m_TierText = m_TierImage.transform.Find("TierText").GetComponent<BaseText>();
		base.transform.Find("RequirementImage").GetComponent<BaseImage>().SetSprite("Icons/" + m_TypeImages[(int)NewType]);
		m_RepairText = base.transform.Find("RepairText").GetComponent<BaseText>();
		m_RepairImage = base.transform.Find("RepairImage").GetComponent<BaseImage>();
	}

	public void SetTarget(Folk NewTarget, bool ProgressDisabled = false, bool PreviousTier = false)
	{
		m_Target = NewTarget;
		m_ProgressDisabled = ProgressDisabled;
		m_PreviousTier = PreviousTier;
		if ((bool)m_Target)
		{
			UpdateBar(0f);
		}
	}

	public float GetProgress()
	{
		if (m_ProgressDisabled)
		{
			return 1f;
		}
		switch (m_Type)
		{
		case Type.Food:
			return m_Target.GetFood();
		case Type.Housing:
			return m_Target.GetHousing();
		case Type.Clothing:
			return m_Target.GetClothing();
		case Type.Toy:
			return m_Target.GetToy();
		case Type.Medicine:
			return m_Target.GetMedicine();
		case Type.Education:
			return m_Target.GetEducation();
		case Type.Art:
			return m_Target.GetArt();
		default:
			return 0f;
		}
	}

	public int GetTier()
	{
		if (m_ProgressDisabled)
		{
			return m_Target.GetTier();
		}
		switch (m_Type)
		{
		case Type.Food:
			return m_Target.GetFoodTier();
		case Type.Housing:
			return m_Target.GetHousingTier();
		case Type.Clothing:
			return m_Target.GetClothingTier();
		case Type.Toy:
			return m_Target.GetToyTier();
		case Type.Medicine:
			return m_Target.GetMedicineTier();
		case Type.Education:
			return m_Target.GetEducationTier();
		case Type.Art:
			return m_Target.GetArtTier();
		default:
			return 0;
		}
	}

	private bool GetRequired()
	{
		switch (m_Type)
		{
		case Type.Food:
			return m_Target.GetIsFoodRequirement();
		case Type.Housing:
			return m_Target.GetIsHousingRequirement();
		case Type.Clothing:
			return m_Target.GetIsClothingRequirement();
		case Type.Toy:
			return m_Target.GetIsToyRequirement();
		case Type.Medicine:
			return m_Target.GetIsMedicineRequirement();
		case Type.Education:
			return m_Target.GetIsEducationRequirement();
		case Type.Art:
			return m_Target.GetIsArtRequirement();
		default:
			return false;
		}
	}

	public bool GetRequirementLow()
	{
		if (GetTier() < m_Target.GetTier() && GetRequired() && GetProgress() > 0f)
		{
			return true;
		}
		return false;
	}

	private void UpdateTier(float Progress, float Timer)
	{
		int tier = GetTier();
		int tier2 = m_Target.GetTier();
		if (tier < tier2 && Progress > 0f)
		{
			Color color = new Color(1f, 1f, 1f, 1f);
			Color colour = new Color(0f, 0f, 0f, 1f);
			if (tier > tier2)
			{
				m_TierImage.SetSprite("FolkRollover/TierUp");
				color = new Color(1f, 1f, 1f, 1f);
			}
			else
			{
				m_TierImage.SetSprite("FolkRollover/TierDown");
				color = (((int)(Timer * 60f) % 16 >= 8) ? new Color(1f, 1f, 1f, 1f) : new Color(1f, 0f, 0f, 1f));
			}
			if (!m_Lowest)
			{
				color.a = 0.5f;
				colour.a = 0.5f;
			}
			m_TierImage.SetColour(color);
			m_TierImage.SetActive(true);
			m_TierText.SetColour(colour);
			m_TierText.SetText((tier + 1).ToString());
		}
		else
		{
			m_TierImage.SetActive(false);
		}
	}

	private void UpdateVisibility()
	{
		SetActive(GetRequired());
	}

	private void UpdateRepairText()
	{
		if (m_Type != Type.Housing)
		{
			m_RepairText.SetActive(false);
			m_RepairImage.SetActive(false);
			return;
		}
		Housing housing = m_Target.m_Housing;
		if ((bool)housing && housing.m_UsageCount == housing.m_MaxUsageCount)
		{
			m_RepairText.SetActive(true);
			ObjectType repairTypeRequired = housing.GetRepairTypeRequired();
			string humanReadableNameFromIdentifier = ObjectTypeList.Instance.GetHumanReadableNameFromIdentifier(repairTypeRequired);
			int repairCountAdded = housing.m_RepairCountAdded;
			int repairAmountRequired = housing.GetRepairAmountRequired();
			string text = TextManager.Instance.Get("FolkRolloverRepair", humanReadableNameFromIdentifier, repairCountAdded.ToString(), repairAmountRequired.ToString());
			m_RepairText.SetText(text);
			Sprite icon = IconManager.Instance.GetIcon(repairTypeRequired);
			m_RepairImage.SetSprite(icon);
			m_RepairImage.SetActive(true);
		}
		else
		{
			m_RepairText.SetActive(false);
			m_RepairImage.SetActive(false);
		}
	}

	public void SetLowest(bool Lowest)
	{
		m_Lowest = Lowest;
	}

	public void UpdateBar(float Timer)
	{
		UpdateVisibility();
		UpdateRepairText();
		float progress = GetProgress();
		SetValue(progress);
		UpdateTier(progress, Timer);
		if (progress == 0f)
		{
			if ((int)(Timer * 60f) % 30 < 15)
			{
				SetBackgroundColour(new Color(1f, 0f, 0f, 1f));
			}
			else
			{
				SetBackgroundColour(new Color(1f, 1f, 1f, 1f));
			}
		}
		else
		{
			SetBackgroundColour(new Color32(99, 99, 99, byte.MaxValue));
		}
	}
}
