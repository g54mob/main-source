using UnityEngine;

public class SkillTreeOptionButton : MonoBehaviour
{
	public GameObject Tooltip;

	private void Start()
	{
		if (Tooltip != null)
		{
			Tooltip.gameObject.SetActive(value: false);
		}
	}

	public void OnMouseEnter()
	{
		GlobalSfx2Controller.Instance.PlayOneWithPitch(SoundManager.SoundTypeEnum.ui_nodepanel_option_hover);
	}

	public void OnMouseExit()
	{
	}
}
