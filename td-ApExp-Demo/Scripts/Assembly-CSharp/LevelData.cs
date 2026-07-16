using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelData
{
	public int index;

	public string name;

	public Vector2 position;

	public List<int> connectivity;

	public LevelType levelType;

	public LevelDifficulty difficulty;

	public LootType lootType;

	public int column;

	public List<float> savedModifiers;

	public ScriptedLevel scriptedLevel;
}
