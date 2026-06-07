using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_EndlessModePerkDetail : MonoBehaviour
{
	[SerializeField]
	private Obj_UI_PerkIcon perkIcon;

	[SerializeField]
	private TMP_Text text_Description;

	[SerializeField]
	private Image image_Background;

	[SerializeField]
	private Color color_Buff;

	[SerializeField]
	private Color color_Debuff;

	public void Setup(PerkSettingData perkData)
	{
	}
}
