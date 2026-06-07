using UnityEngine;

namespace Brewery.EmoteSystem
{
	[CreateAssetMenu(menuName = "Brewery/Emote Category", order = 101)]
	public class EmoteCategory : ScriptableObject
	{
		public string categoryName;

		[SerializeField]
		private string categoryNameKey;

		public Sprite icon;

		public EmoteDefinition[] emotes;

		[Header("Theming")]
		public Color accentColor;

		public string GetLocalizedName()
		{
			return null;
		}
	}
}
