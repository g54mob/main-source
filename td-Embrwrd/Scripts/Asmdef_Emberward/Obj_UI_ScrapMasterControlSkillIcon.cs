using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Obj_UI_ScrapMasterControlSkillIcon : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private eScrapMasterSkillType skillType;

	[SerializeField]
	private Image image_BlackTint;

	[SerializeField]
	private TMP_Text text_Level;

	private ScrapMasterSettingAssetData settingData;

	private int curLevel;

	public eScrapMasterSkillType SkillType => default(eScrapMasterSkillType);

	public void Setup(ScrapMasterSettingAssetData data)
	{
	}

	public void UpdateIconContent()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
