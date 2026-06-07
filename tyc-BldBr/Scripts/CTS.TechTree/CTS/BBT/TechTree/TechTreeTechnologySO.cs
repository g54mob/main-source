using CTS.Core;
using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS.BBT.TechTree
{
	[CreateAssetMenu(fileName = "New Technology", menuName = "CTS/Tech Tree/New Technology", order = 1)]
	public class TechTreeTechnologySO : ScriptableObject
	{
		private const string GROUP_BASESETTING = "Base Settings";

		[SerializeField]
		[Space(10f)]
		[BoxGroup("Localization")]
		public LocalizedString LocalizationTechnologySONameKey;

		[SerializeField]
		[BoxGroup("Localization")]
		public LocalizedString LocalizationTechnologySODescriptionKey;

		[Space(10f)]
		[SerializeField]
		[BoxGroup("Base Settings")]
		public Sprite TechnologyIcon;

		[SerializeField]
		[BoxGroup("Base Settings")]
		public TechTreeCategoriesSO TechTreeCategorySO;

		[SerializeField]
		[BoxGroup("Base Settings")]
		public bool IncludeInDEMO;

		[SerializeField]
		[BoxGroup("Base Settings")]
		public ETechTreeTechnologyLevel DefaultLevel;

		[SerializeField]
		[BoxGroup("Base Settings")]
		public SerializableDictionary<ETechTreeTechnologyLevel, int> ResearchPointsLevels;

		[SerializeField]
		[BoxGroup("Base Settings")]
		public SerializableDictionary<TechTreeTechnologySO, ETechTreeTechnologyLevel> RequiredTechnologies;

		[field: SerializeField]
		[field: BoxGroup("Base Settings")]
		public ScriptableCondition UnlockCondition { get; private set; }
	}
}
