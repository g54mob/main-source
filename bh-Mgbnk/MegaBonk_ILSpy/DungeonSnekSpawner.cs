using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using UnityEngine;

public class DungeonSnekSpawner : MonoBehaviour
{
	public GameObject snek;

	public GameObject chest;

	private void Start()
	{
		bool flag = MyAchievements.IsAchievementDone("a_snek");
		if (!RsgController.isCurrentMapRandomSeed || flag)
		{
			snek.SetActive(value: false);
			chest.SetActive(value: true);
		}
		else
		{
			snek.SetActive(value: true);
			chest.SetActive(value: false);
		}
	}
}
