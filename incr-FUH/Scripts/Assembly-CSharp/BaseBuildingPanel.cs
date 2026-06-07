using DG.Tweening;
using TMPro;
using UnityEngine;

public class BaseBuildingPanel : MonoBehaviour
{
	public bool FreezeScale;

	protected TMP_Text _deleteButtonText;

	private bool _confirmDelete;

	public void DoShowAnimation()
	{
		FreezeScale = true;
		GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ui_ba_upgrade_pop);
		Vector3 localScale = base.transform.localScale;
		base.transform.localScale = new Vector3(0f, 0f, localScale.z);
		base.transform.DOScale(new Vector2(localScale.x, localScale.y), 0.1f).OnComplete(delegate
		{
			FreezeScale = false;
		});
		_confirmDelete = false;
		if (_deleteButtonText != null)
		{
			_deleteButtonText.text = LanguageText.GetText("Destroy");
		}
	}

	public static string FormatPercentage(float p)
	{
		p *= 100f;
		return p.ToString("0.#") + "%";
	}

	protected bool TryIncreaseLevel(BaseBuilding building)
	{
		if (building.TryIncreaseLevel())
		{
			int level = building.GetLevel();
			if (level == 3 || level == 5 || level == 7 || level == 9)
			{
				GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ba_build);
			}
			else
			{
				GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ba_upgrade);
			}
			if (building.BuildingType == BaseBuilding.BuildingTypeEnum.Temple)
			{
				GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ga_signing);
			}
			return true;
		}
		return false;
	}

	protected bool TryEnableAttribute(BaseBuilding building, BaseMoneyAttribute attribute)
	{
		if (attribute.TryToEnable())
		{
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ba_upgrade);
			return true;
		}
		return false;
	}

	protected bool TryEnableAttribute(BaseBuilding building, BaseMoneyLevelAttribute attribute)
	{
		int newMoney = building.ReduceWithTrainingPeon(attribute.GetCost());
		if (attribute.TryToEnable(building))
		{
			building.AddSpentMoney(newMoney);
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ba_upgrade);
			return true;
		}
		return false;
	}

	protected bool TryEnableAttribute(BaseResearchAttribute attribute)
	{
		if (attribute.TryToEnable())
		{
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ba_upgrade);
			return true;
		}
		return false;
	}

	protected bool TryEnableAttribute(BaseMoneyAttribute attribute)
	{
		if (attribute.TryToEnable())
		{
			GlobalSfx2Controller.Instance.PlayOne(SoundManager.SoundTypeEnum.ba_upgrade);
			return true;
		}
		return false;
	}

	protected bool ProcessDestroyColumn()
	{
		if (!_confirmDelete)
		{
			_deleteButtonText.text = LanguageText.GetText("Really") + "?";
			_confirmDelete = true;
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ui_button1_click);
			return false;
		}
		return true;
	}

	protected void SetPanelHeight()
	{
		int rowCount = GetRowCount();
		float num = 70f;
		num += (float)rowCount * 17f;
		if (num < 168f)
		{
			num = 168f;
		}
		RectTransform component = GetComponent<RectTransform>();
		if (component.sizeDelta.y != num)
		{
			component.sizeDelta = new Vector2(component.sizeDelta.x, num);
		}
	}

	protected virtual int GetRowCount()
	{
		return 0;
	}
}
