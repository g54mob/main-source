using FMODUnity;
using Restory.Data.InteractiveObjects;
using UnityEngine;

namespace Restory.Data.Equipment
{
	public class ToolInfo : InteractiveObjectInfo
	{
		[SerializeField]
		private string nameLocalizationKey;

		[SerializeField]
		private string descriptionLocalizationKey;

		[SerializeField]
		private ToolsCategory toolsCategory;

		[SerializeField]
		private GameObject viewPrefab;

		[SerializeField]
		[Min(0f)]
		private int toolLevel;

		[SerializeField]
		[Tooltip("If enabled, player can own more than one copy of this tool and each copy can be consumed separately.")]
		private bool canStoreMultipleCopies;

		[SerializeField]
		[Tooltip("If enabled, this tool has limited uses and is consumed when uses run out.")]
		private bool isConsumable;

		[SerializeField]
		[Min(1f)]
		[Tooltip("How many uses one copy of this tool provides.")]
		private float maxUses = 1f;

		[SerializeField]
		[Min(0.01f)]
		[Tooltip("How many uses are consumed per second.")]
		private float usesPerSecond = 0.1f;

		[SerializeField]
		private EventReference removeToolSound;

		public string NameLocalizationKey => nameLocalizationKey;

		public string DescriptionLocalizationKey => descriptionLocalizationKey;

		public ToolsCategory ToolsCategory => toolsCategory;

		public GameObject ViewPrefab => viewPrefab;

		public int ToolLevel => toolLevel;

		public bool CanStoreMultipleCopies => canStoreMultipleCopies;

		public bool IsConsumable => isConsumable;

		public float MaxUses
		{
			get
			{
				if (!isConsumable)
				{
					return float.MaxValue;
				}
				return maxUses;
			}
		}

		public float UsesPerSecond
		{
			get
			{
				if (!isConsumable)
				{
					return 0f;
				}
				return usesPerSecond;
			}
		}

		public EventReference RemoveToolSound => removeToolSound;
	}
}
