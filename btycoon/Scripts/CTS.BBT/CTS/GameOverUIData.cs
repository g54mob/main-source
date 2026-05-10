using CTS.Core;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Game Over/UI Data")]
	public class GameOverUIData : ScriptableStringKey
	{
		[field: SerializeField]
		public Sprite BackgroundImage { get; private set; }

		[field: SerializeField]
		public Sprite FrontImage { get; private set; }

		[field: SerializeField]
		public LocalizedString Description { get; private set; }

		[field: SerializeField]
		public string AnalyticsEvent { get; private set; }

		[field: SerializeField]
		public UIMessageSO PopupMessage { get; private set; }
	}
}
