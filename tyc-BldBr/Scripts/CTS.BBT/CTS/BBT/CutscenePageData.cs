using CTS.Core;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS.BBT
{
	[CreateAssetMenu(menuName = "BBT/Cutscene Page")]
	public class CutscenePageData : ScriptableObject
	{
		[field: SerializeField]
		public MainCharacterData MainCharacter { get; private set; }

		[field: SerializeField]
		public MapInfoSO Neighbourhood { get; private set; }

		[field: SerializeField]
		public LocalizedString Headline { get; private set; }

		[field: SerializeField]
		public LocalizedString[] News { get; private set; }

		[field: SerializeField]
		public StringKey DisplayMode { get; private set; }
	}
}
