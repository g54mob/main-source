using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	[CreateAssetMenu(fileName = "CrossGameSO", menuName = "CrossGame")]
	public class GamesSO : ScriptableObject
	{
		[field: SerializeField]
		public Sprite MainImage { get; private set; }

		[field: SerializeField]
		public Sprite Separator { get; private set; }

		[field: SerializeField]
		public Color ThemeColor { get; private set; }

		[field: SerializeField]
		public string CurrentStateOfTheGame { get; private set; }

		[field: SerializeField]
		public string Title { get; private set; }

		[field: SerializeField]
		public string UnderTitle { get; private set; }

		[field: SerializeField]
		public LocalizedString Description { get; private set; }

		[field: SerializeField]
		public string URL { get; private set; }
	}
}
