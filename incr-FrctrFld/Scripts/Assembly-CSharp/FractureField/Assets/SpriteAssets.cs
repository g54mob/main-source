using System;
using UnityEngine;

namespace FractureField.Assets
{
	[Serializable]
	public class SpriteAssets
	{
		[SerializeField]
		private IconAssets _icons;

		[SerializeField]
		private CurrencyAssets _currencies;

		[SerializeField]
		private ChestAssets _chests;

		[SerializeField]
		private QuestAssets _quests;

		[SerializeField]
		private AvatarAssets _avatars;

		public static IconAssets Icons => null;

		public static CurrencyAssets Currencies => null;

		public static ChestAssets Chests => null;

		public static QuestAssets Quests => null;

		public static AvatarAssets Avatars => null;
	}
}
