using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.UI;
using VampireSurvivors.UI.Player;

namespace VampireSurvivors.Framework;

public class CoopConfig : ScriptableObject
{
	public enum CameraMode
	{
		AveragePosition,
		PositionExtentsCenter,
		VisualBoundsExtentsCenter
	}

	public enum AccessoryBonusMode
	{
		OwnerOnly,
		MatchingDescription,
		AllPlayers
	}

	public int _enemyChompMaxCount = 5;

	public float _enemyChompHPGainProportionPerChomp = 0.2f;

	public float _enemyChompScaleGainProportionPerChomp = 0.1f;

	public HitVfxType _enemyChompEffect = HitVfxType.Wind;

	public float _levelupVibrationMilliseconds = 200f;

	public float _chestRandomisationSpeedMultiplier = 1f;

	public float _chestRandomisationLength = 4f;

	public AnimationCurve _chestRandomisationSpinPositionCurve;

	public bool _spawningEnemiesTargetDeadPlayersAlso;

	public bool _globalLevelNumber = true;

	public float _screenBoundsTopOffsetPixels = 20f;

	public float _screenBoundsBottomOffsetPixels = 4f;

	public float _fixedCameraOffsetPixels;

	public bool _blockWeaponsOwnedByOtherPlayers = true;

	public bool _blockAccessoriesOwnedByOtherPlayers;

	public bool _limitAccessoriesLikeWeapons = true;

	public float _revivalSpeedWithRevive = 1f;

	public float _revivalSpeedWithoutRevive = 0.1f;

	public float _revivalLossSpeed = 0.25f;

	public float _revivalRange = 1f;

	public bool _reviveAllRatherThanClosest = true;

	public float _multiplayerIndicatorDuration = 2f;

	public int _chestRandomnessSetSize = 4;

	public bool _chestRandomPrioritiseEvolvablePlayers = true;

	public bool _removeDeadPlayersFromCamera;

	public float _removeDeadPlayerFromCameraDuration = 1f;

	public bool _immediateRevivalUsage = true;

	public float _decompositionTimeSeconds = 6f;

	public bool _ghostUsesCharacterSprite;

	public float _physicalScreenBoundsTopOffsetPixels = 30f;

	public MultiplayerRevivalUI _multiplayerRevivalUIPrefab;

	public PlayerIndicator _playerIndicatorUIPrefab;

	public Material _navigationUIMaterial;

	public int _amuletsInAmuletBag = 1;

	public int _amuletBagSize = 7;

	public CameraMode _cameraMode;

	public AccessoryBonusMode _accessoryBonusMode;

	public bool _shareEvolutionPassives;

	public float _goldBonusForNotSharingPassives = 0.25f;
}
