using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Obj_UI_PerkIcon : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[SerializeField]
	private Image image_Frame;

	[SerializeField]
	private Image image_Icon;

	[SerializeField]
	private TMP_Text text_Number;

	[SerializeField]
	private Color color_Buff;

	[SerializeField]
	private Color color_Debuff;

	private APerkBase perk;

	protected PerkSettingData settingData;

	protected bool isTooltipOn;

	public APerkBase Perk => null;

	public PerkSettingData SettingData => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnPerkChanged(APerkBase changedPerk)
	{
	}

	public void Setup(APerkBase perk, PerkSettingData settingData)
	{
	}

	public void OverrideNumberDisplay(int value)
	{
	}

	public virtual void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
