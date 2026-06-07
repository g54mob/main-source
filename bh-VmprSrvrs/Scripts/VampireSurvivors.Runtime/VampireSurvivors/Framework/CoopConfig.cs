using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.UI;
using VampireSurvivors.UI.Player;

namespace VampireSurvivors.Framework
{
	[CreateAssetMenu(fileName = "CoopConfig", menuName = "VampireSurvivors/New Coop Config")]
	public class CoopConfig : ScriptableObject
	{
		public enum CameraMode
		{
			AveragePosition = 0,
			PositionExtentsCenter = 1,
			VisualBoundsExtentsCenter = 2
		}

		public enum AccessoryBonusMode
		{
			OwnerOnly = 0,
			MatchingDescription = 1,
			AllPlayers = 2
		}

		[Tooltip("Can be set to 0 to disable enemy coffin-chomp behaviour")]
		public int _enemyChompMaxCount;

		public float _enemyChompHPGainProportionPerChomp;

		public float _enemyChompScaleGainProportionPerChomp;

		public HitVfxType _enemyChompEffect;

		public float _levelupVibrationMilliseconds;

		public float _chestRandomisationSpeedMultiplier;

		public float _chestRandomisationLength;

		public AnimationCurve _chestRandomisationSpinPositionCurve;

		public bool _spawningEnemiesTargetDeadPlayersAlso;

		public bool _globalLevelNumber;

		public float _screenBoundsTopOffsetPixels;

		public float _screenBoundsBottomOffsetPixels;

		public float _fixedCameraOffsetPixels;

		public bool _blockWeaponsOwnedByOtherPlayers;

		public bool _blockAccessoriesOwnedByOtherPlayers;

		public bool _limitAccessoriesLikeWeapons;

		public float _revivalSpeedWithRevive;

		public float _revivalSpeedWithoutRevive;

		public float _revivalLossSpeed;

		public float _revivalRange;

		public bool _reviveAllRatherThanClosest;

		public float _multiplayerIndicatorDuration;

		[Tooltip("How many repeats of the players do we include in the random that determines who wins a chest.  The longer the set, the longer it takes for even distribution to happen, but the less predictable it is.")]
		public int _chestRandomnessSetSize;

		public bool _chestRandomPrioritiseEvolvablePlayers;

		public bool _removeDeadPlayersFromCamera;

		public float _removeDeadPlayerFromCameraDuration;

		public bool _immediateRevivalUsage;

		public float _decompositionTimeSeconds;

		public bool _ghostUsesCharacterSprite;

		public float _physicalScreenBoundsTopOffsetPixels;

		public MultiplayerRevivalUI _multiplayerRevivalUIPrefab;

		public PlayerIndicator _playerIndicatorUIPrefab;

		public Material _navigationUIMaterial;

		public int _amuletsInAmuletBag;

		public int _amuletBagSize;

		public CameraMode _cameraMode;

		public AccessoryBonusMode _accessoryBonusMode;

		public bool _shareEvolutionPassives;

		public float _goldBonusForNotSharingPassives;
	}
}
