using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_TowerDefaultPriorityEntry : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private TMP_Text text_TowerName;

	[SerializeField]
	private TMP_Text text_TowerPriority;

	[SerializeField]
	private Image image_TowerIcon;

	[SerializeField]
	private Image image_TowerIconBG;

	[SerializeField]
	private Image image_TowerIconBG_Outer;

	[SerializeField]
	private Image image_TowerNameBG;

	[SerializeField]
	private Image image_TowerPriorityBG;

	[SerializeField]
	private CanvasGroup canvasGroup_Content;

	[SerializeField]
	private Image image_BG_Empty;

	[SerializeField]
	private TwoMouseButtonButton button_TargetPriority;

	private Color fadeBGColor;

	private TowerSettingData currentData;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void Initialize(eItemType towerType)
	{
	}

	public void SetDisabled()
	{
	}

	public void Toggle(bool isOn)
	{
	}

	public void ForceHide()
	{
	}

	private void OnClickTargetPriority_LeftClick()
	{
	}

	private void OnClickTargetPriority_RightClick()
	{
	}

	private void UpdatePriorityUIContent()
	{
	}
}
