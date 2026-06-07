using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.UI
{
	public class CardInfoUI : MonoBehaviour
	{
		[Serializable]
		public class CardEntry
		{
			public GameObject Root;

			public Image Image;

			public TextMeshProUGUI Text;

			public GameObject DecreaseImage;
		}

		private class EveryXDataHolder
		{
			public PowerUpType Type;

			public float Value;

			public int EveryXLevels;

			public int Count;

			public EveryXDataHolder(PowerUpType type, float value, int everyXLevels, int count)
			{
			}
		}

		[SerializeField]
		private TextMeshProUGUI Title;

		[SerializeField]
		private TextMeshProUGUI LevelText;

		[SerializeField]
		private Image Edition;

		[SerializeField]
		private List<CardEntry> _oneColumnEntries;

		[SerializeField]
		private List<CardEntry> _twoColumnEntries;

		private DataManager _dataManager;

		[Inject]
		private void Construct(DataManager dataManager)
		{
		}

		public void SetData(CharacterSkillCard_Base card, ArcanaData data)
		{
		}

		public static void RefreshLayoutGroupsImmediateAndRecursive(GameObject root)
		{
		}

		private string ReplaceDescriptionTextPlaceholder(string descriptionTextString, EveryXDataHolder stat, bool addStatsText)
		{
			return null;
		}

		private string GetTextForEntry(PowerUpType powerUpType, float value, bool addStatText = true)
		{
			return null;
		}

		private string GetSign(float value)
		{
			return null;
		}

		private List<Tuple<PowerUpType, float>> GetPowerUpTypesFromModifierStats(ModifierStats stats)
		{
			return null;
		}

		public static Sprite GetSubSkillIcon(ArcanaType? type)
		{
			return null;
		}
	}
}
