using System.Collections.Generic;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using UnityEngine;

namespace Assets.Scripts.UI.HUD
{
	public class ScoreUi : MonoBehaviour
	{
		public RandomSfx scoreSound;

		public RandomSfx negativeSound;

		private bool moveDesc;

		private Queue<ScoreContainer> scoreQueue;

		private List<ScoreUiPrefab> prefabs;

		public GameObject prefab;

		private bool isActive;

		private float readyTime;

		public void AddScore(string description, string header, bool isPositive = true, bool useSfx = true, float sizeMultiplier = 1f)
		{
		}

		public void AddScore(StatModifier statModifier, bool isPositive, bool useSfx = true, float sizeMultiplier = 1f)
		{
		}

		private void Update()
		{
		}

		private void SetScore()
		{
		}

		public int GetQueueCount()
		{
			return 0;
		}
	}
}
