using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Algorithm
{
	public class CharacterADControl
	{
		private AIType _currentType;

		private VampireSurvivors.Objects.Characters.CharacterController _controlledPlayer;

		private VampireSurvivors.Objects.Characters.CharacterController _followedCharacter;

		private int _levelupLoadoutIndex;

		private List<WeaponType> _loadout;

		private WeaponType _lasLevelledUpWeaponType;

		private float2 _angleDistance;

		private float _congaMaxDistance;

		private float _congaMinDistance;

		private float _congaYOffset;

		private bool _initialPositionReached;

		public bool ShouldOverrideFollowDelay;

		private Queue<Vector2> _followedCharacterHistory;

		private Vector2 _followedCharacterLastPosition;

		private Unity.Mathematics.Random _loadoutShuffler;

		public LevelupType LevelupType { get; set; }

		public VampireSurvivors.Objects.Characters.CharacterController FollowedCharacter
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void SetAIType(AIType type, VampireSurvivors.Objects.Characters.CharacterController controlledPlayer, VampireSurvivors.Objects.Characters.CharacterController followedCharacter = null)
		{
		}

		public void InitLoadoutShuffler(uint seed)
		{
		}

		public void SetAIToAngleDistance(float angleDegrees, float distance, bool mirrorInput = false)
		{
		}

		public void SetAIToConga(float maxDistance, float minDistance, float yOffset = 0f)
		{
		}

		public Vector2 CalculateMovement()
		{
			return default(Vector2);
		}

		private Vector2 GetDelayedInputCopyVector()
		{
			return default(Vector2);
		}

		public void Update()
		{
		}

		private float2 CombineWithStandardRepulsionAndDeadZone(float2 input, float repulsionScale = 0.001f)
		{
			return default(float2);
		}

		private float2 CalculateStandardRepulsionVector()
		{
			return default(float2);
		}

		public void HandleWeaponLevelling()
		{
		}

		public void HandleOnLevelUpCompleted()
		{
		}

		private void GiveNextLoadoutWeapon()
		{
		}

		private void GiveNextShowcaseWeapon()
		{
		}

		private void GiveNextLevelupPresetWeapon(int presetIndex)
		{
		}
	}
}
