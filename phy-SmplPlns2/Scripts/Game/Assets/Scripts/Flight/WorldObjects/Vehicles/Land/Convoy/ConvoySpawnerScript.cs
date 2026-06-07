using System.Collections.Generic;
using Assets.Scripts.Levels;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Convoy
{
	public class ConvoySpawnerScript : MonoBehaviour
	{
		[SerializeField]
		private int _numberToSpawn = 1;

		protected virtual void Start()
		{
			if (!Game.Instance.Settings.Gameplay.Flight.GroundTrafficEnabled)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			LevelInfo currentLevel = Game.Instance.CurrentLevel;
			if (!currentLevel.IsSandbox && string.IsNullOrEmpty(currentLevel.ModName))
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			int childCount = base.transform.childCount;
			List<int> list = new List<int>(_numberToSpawn);
			while (list.Count < childCount && list.Count < _numberToSpawn)
			{
				int item = Random.Range(0, childCount);
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}
			for (int i = 0; i < childCount; i++)
			{
				base.transform.GetChild(i).gameObject.SetActive(list.Contains(i));
			}
		}
	}
}
