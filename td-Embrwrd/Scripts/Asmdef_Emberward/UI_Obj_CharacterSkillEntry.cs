using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_CharacterSkillEntry : MonoBehaviour
{
	[SerializeField]
	private TMP_Text text_SkillName;

	[SerializeField]
	private TMP_Text text_SkillDescription;

	[SerializeField]
	private Image image_SkillIcon;

	[SerializeField]
	private Image image_SkillIconBG;

	[SerializeField]
	private Image image_BG;

	[SerializeField]
	private Image image_SkillIconOutlineBG;

	[SerializeField]
	private UI_Obj_ShopCard shopCard;

	public void Setup(string skillName, string skillDescription, CharacterSkillData skillData)
	{
	}
}
