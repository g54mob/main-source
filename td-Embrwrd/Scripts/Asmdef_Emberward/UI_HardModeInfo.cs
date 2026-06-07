using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_HardModeInfo : MonoBehaviour
{
	[SerializeField]
	private List<UI_Obj_HardModeShard> list_Shards;

	[SerializeField]
	private TMP_Text text_InfernoShardInfo;

	[SerializeField]
	private TMP_Text text_DifficultyLevel;

	[SerializeField]
	private TMP_Text text_MonsterHP;

	[SerializeField]
	private TMP_Text text_BossHP;

	[SerializeField]
	private TMP_Text text_BestRecord;

	[SerializeField]
	private Transform node_PerkIconLayout;

	[SerializeField]
	private Gradient gradient_DifficultyLevel;

	[SerializeField]
	private GameObject prefab_PerkIcon;

	public void Setup(HardModeSetting hardModeData, int bestRecord)
	{
	}

	public void UpdateContent(List<int> list_shardLevel)
	{
	}

	private List<int> SplitDigits(int number)
	{
		return null;
	}
}
