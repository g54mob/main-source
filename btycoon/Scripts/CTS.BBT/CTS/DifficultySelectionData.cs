using CTS.Core;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Difficulty Choice")]
	public class DifficultySelectionData : ScriptableObject
	{
		[field: SerializeField]
		public Sprite ForegroundImage { get; private set; }

		[field: SerializeField]
		public Sprite BackgroundImage { get; private set; }

		[field: SerializeField]
		public LocalizedString Title { get; private set; }

		[field: SerializeField]
		public LocalizedString Description { get; private set; }

		[field: SerializeField]
		public StringKey DifficultyPreset { get; private set; }
	}
}
