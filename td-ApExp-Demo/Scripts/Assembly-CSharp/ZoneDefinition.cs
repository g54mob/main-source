using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Zone", menuName = "Zone")]
public class ZoneDefinition : ScriptableObject
{
	public string ZoneName;

	public string DisplayName;

	public Sprite Icon;

	public Color BgColor;

	public Vector2Int MapSize;

	[Header("Difficulty Curves")]
	public AnimationCurve DifficultyCurveEasy;

	public AnimationCurve DifficultyCurveMed;

	public AnimationCurve DifficultyCurveHard;

	[Header("Boss")]
	[SerializeField]
	public GameObject bossPrefab;

	[Header("Optional Scripted Levels")]
	[SerializeField]
	public List<ScriptedLevel> PreGridScriptedLevels;

	[SerializeField]
	public List<ScriptedLevel> PostGridScriptedLevels;

	[NonSerialized]
	public EnemyWave[] Waves;

	public void LoadWavesRuntime()
	{
		string path = "Zones/Definitions/" + ZoneName + "/Waves";
		Waves = Resources.LoadAll<EnemyWave>(path);
	}
}
