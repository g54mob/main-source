using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MonsterInfo : MonoBehaviour
{
	[SerializeField]
	private Animator animator;

	[SerializeField]
	private TMP_Text text_MonsterName;

	[SerializeField]
	private TMP_Text text_MonsterHP;

	[SerializeField]
	private TMP_Text text_MonsterInfo;

	[SerializeField]
	private Image image_Frame_LV1;

	[SerializeField]
	private Image image_Frame_LV2;

	[SerializeField]
	private Image image_Frame_LV3;

	[SerializeField]
	private Image image_HPBar;

	[SerializeField]
	private AMonsterBase curMonster;

	private Vector3 localOffset;

	private bool isOn;

	private bool isFirstFrameOn;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void OnToggleMonsterInfo(AMonsterBase monster, bool isOn)
	{
	}

	private void Toggle(bool isOn)
	{
	}

	private void OnMonsterKilledOrDespawn(AMonsterBase monster)
	{
	}

	private void OnMonsterHPChange()
	{
	}

	private void UpdateMonsterStatus(AMonsterBase monster)
	{
	}

	private string FormatNumber(int num)
	{
		return null;
	}
}
