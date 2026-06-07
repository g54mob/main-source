using FMODUnity;
using I2.Loc;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "Bouncer/LevelInfo")]
public class LevelInfo : SerializedScriptableObject
{
	public LevelType Type;

	public Sprite SprIcon;

	public Sprite SprPreview;

	public string Name;

	[TextArea]
	public string Desc;

	public GridPieceInfo BossInfo;

	public float DefaultTurnLength;

	public int[] BossTurns;

	public int[] FuserTurns;

	public float XPMult;

	[FormerlySerializedAs("Enemies")]
	public GridPieceInfo[] PreviewEnemies;

	public GridPieceInfo[] EnemyList;

	public PetInfo[] SpawnedPets;

	public Sprite SprHUDInactive;

	public Sprite SprHUDActive;

	public Vector2 HUDPlacement;

	public Vector2 HUDBurstPlacement;

	public float HUDBurstExtraSpacing;

	[Header("Loading")]
	public LevelAssetSet Assets;

	[BankRef]
	public string BankPath;

	[Header("Sounds")]
	public EventReference MusicEvent;

	public EventReference[] MusicSections;

	public EventReference DefaultEnemyHitSFX;

	public EventReference DefaultWallBounceSFX;

	public EventReference DefaultEnemyBreakSFX;

	public EventReference DefaultBigEnemyBreakSFX;

	public EventReference DefaultEnemyLandSFX;

	public EventReference LevelExpandSFX;

	public ObstacleType[] Obstacles;

	public Color DustColor;

	public Color DustColor2;

	public Color FakeLightColor;

	public float FakeLightIntensity;

	public bool OverrideCamBackgroundColor;

	public Color CamBackgroundColor;

	public Color LightBarColor;

	[HideInInspector]
	public string Slug;

	public BeatLength ChantBeat;

	public bool[,] ChantPatterns;

	public bool[,] ChantPatterns2;

	public bool[,] ChantPatterns3;

	public bool[,] ChantPatternsBoss;

	public void GenerateSlug()
	{
	}

	public string GetNameSlug()
	{
		return null;
	}

	public string GetNameTranslation(bool isTitle)
	{
		return null;
	}

	public string GetDescSlug()
	{
		return null;
	}

	public void ExportLoc(LanguageSourceAsset loc)
	{
	}

	public LevelData GetSaveData(int ngPlus)
	{
		return null;
	}

	public int GetLevelNum()
	{
		return 0;
	}

	public Cost GetWarRoomReward(CharType charType)
	{
		return null;
	}

	public int GetWarRoomLengthMinutes(CharType charType)
	{
		return 0;
	}
}
