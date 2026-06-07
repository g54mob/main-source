using System;
using System.Collections.Generic;

[Serializable]
public class WaveMonsterData
{
	public List<eMonsterType> list_SmallMonsters;

	public List<eMonsterType> list_MediumMonsters;

	public List<eMonsterType> list_LargeMonsters;

	public List<eMonsterType> list_BossMonsters;

	public void Shuffle()
	{
	}
}
