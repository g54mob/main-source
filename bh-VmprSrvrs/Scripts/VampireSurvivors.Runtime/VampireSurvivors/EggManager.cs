using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors
{
	public class EggManager : IInitializable, IDisposable
	{
		private Dictionary<string, float> _attributes;

		private List<string> _attributeKeys;

		[Inject]
		private SignalBus _signalBus;

		[Inject]
		private PlayerOptions _playerOptions;

		[Inject]
		private GameSessionData _session;

		public const string MAX_HP_PROPNAME = "maxHp";

		public const string ARMOR_PROPNAME = "armor";

		public const string REGEN_PROPNAME = "regen";

		public const string MOVESPEED_PROPNAME = "moveSpeed";

		public const string POWER_PROPNAME = "power";

		public const string COOLDOWN_PROPNAME = "cooldown";

		public const string AREA_PROPNAME = "area";

		public const string SPEED_PROPNAME = "speed";

		public const string DURATION_PROPNAME = "duration";

		public const string AMOUNT_PROPNAME = "amount";

		public const string LUCK_PROPNAME = "luck";

		public const string GROWTH_PROPNAME = "growth";

		public const string GREED_PROPNAME = "greed";

		public const string CURSE_PROPNAME = "curse";

		public const string MAGNET_PROPNAME = "magnet";

		public const string REVIVALS_PROPNAME = "revivals";

		public const string REROLLS_PROPNAME = "rerolls";

		public const string SKIPS_PROPNAME = "skips";

		public const string BANISH_PROPNAME = "banish";

		public void Initialize()
		{
		}

		public void Dispose()
		{
		}

		public KeyValuePair<string, float> AddGoldenEgg(CharacterType t, Unity.Mathematics.Random? rng = null)
		{
			return default(KeyValuePair<string, float>);
		}

		public string PickRandomAttribute()
		{
			return null;
		}

		public void LightEgg(float amount)
		{
		}

		public float GetCharacterEggStat(CharacterType t, PowerUpType p)
		{
			return 0f;
		}

		public string GetTypeString(PowerUpType type)
		{
			return null;
		}

		public void ApplyBonuses(VampireSurvivors.Objects.Characters.CharacterController player)
		{
		}

		public float RemoveBonuses()
		{
			return 0f;
		}

		public void ShowResultAt(Vector2 target, KeyValuePair<string, float> result, float offsetX = -16f, float offsetY = 16f)
		{
		}

		public void RemoveAllEggs()
		{
		}

		public KeyValuePair<string, float> RemoveAllSpecificEggs(string attributeName)
		{
			return default(KeyValuePair<string, float>);
		}

		public KeyValuePair<string, float> RemoveRandomEgg()
		{
			return default(KeyValuePair<string, float>);
		}

		public static string GetFormattedEggCount(float eggCount)
		{
			return null;
		}

		private void InitializeAttributes()
		{
		}

		private string LookUpFrame(string frameName)
		{
			return null;
		}
	}
}
