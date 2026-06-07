using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Loot;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.VFX;

namespace VampireSurvivors.Framework
{
	public class ArcanaManager_Support
	{
		private const float goldenRatio = 1.618034f;

		private static int _foodSfxIndex;

		private static float[] _foodDetunes;

		private List<float> _sapphireMistChances;

		private int _sapphireMistIndex;

		private float _sapphireMistBaseChance;

		private float _baseCandyboxChance;

		private float _foundCandyboxes;

		private float _baseArmadioChance;

		private float _foundArmadios;

		private List<float> _hailFromFutureChances;

		private int _hailFromFutureIndex;

		private Dictionary<WeaponType, List<float>> _breadBonusList;

		private Dictionary<WeaponType, int> _bonusTimes;

		private Timer _food_sequentialTimer;

		private float _food_angleInc;

		private float _food_angleMul;

		private float _food_BonusTimer;

		private float _food_BonusDelay;

		private List<VampireSurvivors.Objects.Characters.CharacterController> _food_CharacterBonuses;

		public WeightedStore HailFromTheFutureWeightedStore { get; set; }

		private static float GetDetune()
		{
			return 0f;
		}

		public void Initialize()
		{
		}

		public void MakeHailFromTheFutureWeightedStore(bool force = false)
		{
		}

		public bool IsSapphireMistSuccessful(VampireSurvivors.Objects.Characters.CharacterController character)
		{
			return false;
		}

		public void SendHailFromTheFutureGift(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}

		public void SendGift(Vector2 startPosition, Vector2 endPosition, ItemType itemType, WeaponType weaponType)
		{
		}

		private void OnGiftLanded(SpinningIcosahedron gift, ItemType itemToSpawn, WeaponType weaponType, float x, float y)
		{
		}

		public void OnFoodPickedUp(VampireSurvivors.Objects.Characters.CharacterController character, ItemType itemType, float value)
		{
		}

		public void Update()
		{
		}

		private void AddAttribute(VampireSurvivors.Objects.Characters.CharacterController character, WeaponType weaponType, float value)
		{
		}
	}
}
