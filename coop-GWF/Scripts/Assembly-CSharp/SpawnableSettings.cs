using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Settings/Spawnable Settings", fileName = "SpawnableSettings")]
public class SpawnableSettings : ScriptableObject
{
	[Header("Settings")]
	public bool isEnabled = true;

	[Header("Spawnable Prefabs")]
	public List<SpawnableSO> spawnables = new List<SpawnableSO>();

	public static event Action<SpawnableSettings> SettingsChanged;

	public static SpawnableSO GetSpawnableSoById(int id)
	{
		return Resources.Load<SpawnableSettings>("SpawnableSettings").spawnables.FirstOrDefault((SpawnableSO s) => s.spawnableID == id);
	}

	public void NotifyChanged()
	{
		SpawnableSettings.SettingsChanged?.Invoke(this);
	}
}
