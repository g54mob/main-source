using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/開局的Tetris組合設定 (TetrisStarterSetData)", order = 1)]
public class TetrisStarterSetData : ScriptableObject
{
	[SerializeField]
	private List<TetrisStarterSet> list_TetrisStarterSet;

	[SerializeField]
	private List<TetrisStarterSet> list_TetrisStarterSet_Tiny;

	public TetrisStarterSet GetWeightedRandomStarterSet(bool isTutorialFinished)
	{
		return null;
	}

	public TetrisStarterSet GetRandomStarterSet_Tiny()
	{
		return null;
	}

	public TetrisStarterSet GetRandomStarterSet_Joker()
	{
		return null;
	}
}
