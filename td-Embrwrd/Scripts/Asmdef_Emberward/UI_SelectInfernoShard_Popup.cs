using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_SelectInfernoShard_Popup : MonoBehaviour
{
	[SerializeField]
	private TMP_Text text_DifficultyLevel;

	[SerializeField]
	private TMP_Text text_MonsterHP;

	[SerializeField]
	private TMP_Text text_BossHP;

	[SerializeField]
	private List<UI_Obj_HardModeShard> list_ActiveShards;

	[SerializeField]
	private List<UI_Obj_HardModeShard> list_SelectableShards;

	private List<int> list_SelectedLevel;

	private void Awake()
	{
	}

	public void Setup(List<int> list_shardLevel)
	{
	}

	private void UpdateDifficultyLevel()
	{
	}

	private void OnClickShard(eHardModeShardType shardType, int level, UI_Obj_HardModeShard shard)
	{
	}
}
