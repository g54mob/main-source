using FractureField.Achievements;
using FractureField.Assets;
using FractureField.Prestige.RealityShatter.UI;
using UnityEngine;

namespace FractureField
{
	public class AHub : Singleton<AHub>
	{
		[SerializeField]
		private MaterialAssets _materialAssets;

		[SerializeField]
		private SpriteAssets _spriteAssets;

		[SerializeField]
		private SoundAssets _soundAssets;

		[SerializeField]
		private RockAssets _rockAssets;

		[SerializeField]
		private AchievementAssets _achievementAssets;

		[SerializeField]
		private RealityShatterAssets _realityShatterAssets;

		public static MaterialAssets Materials => null;

		public static SpriteAssets Sprites => null;

		public static SoundAssets Sound => null;

		public static RockAssets Rocks => null;

		public static AchievementAssets Achievements => null;

		public static RealityShatterAssets RealityShatter => null;

		protected override void Awake()
		{
		}
	}
}
