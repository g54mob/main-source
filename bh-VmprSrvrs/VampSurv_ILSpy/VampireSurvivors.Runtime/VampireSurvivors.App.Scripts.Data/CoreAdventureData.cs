using System;
using System.Collections.Generic;
using VampireSurvivors.Achievements;
using VampireSurvivors.Data;

namespace VampireSurvivors.App.Scripts.Data;

[Serializable]
public class CoreAdventureData
{
	private string _003CAdventureName_003Ek__BackingField;

	private string _003CSubtitleImage_003Ek__BackingField;

	private int _003CStartingCoins_003Ek__BackingField;

	private CharacterType _003CStartingCharacter_003Ek__BackingField;

	private StageType _003CStartingStage_003Ek__BackingField;

	private string _003CSpriteName_003Ek__BackingField;

	private string _003CTexture_003Ek__BackingField;

	private DlcType? _003CRequiresDLC_003Ek__BackingField;

	private int _003CCompletionCoinReward_003Ek__BackingField;

	private List<SkinToUnlock> _003CCompletionSkinsReward_003Ek__BackingField;

	public string AdventureName
	{
		get
		{
			return _003CAdventureName_003Ek__BackingField;
		}
		set
		{
			_003CAdventureName_003Ek__BackingField = value;
		}
	}

	public string SubtitleImage
	{
		get
		{
			return _003CSubtitleImage_003Ek__BackingField;
		}
		set
		{
			_003CSubtitleImage_003Ek__BackingField = value;
		}
	}

	public int StartingCoins
	{
		get
		{
			return _003CStartingCoins_003Ek__BackingField;
		}
		set
		{
			_003CStartingCoins_003Ek__BackingField = value;
		}
	}

	public CharacterType StartingCharacter
	{
		get
		{
			return _003CStartingCharacter_003Ek__BackingField;
		}
		set
		{
			_003CStartingCharacter_003Ek__BackingField = value;
		}
	}

	public StageType StartingStage
	{
		get
		{
			return _003CStartingStage_003Ek__BackingField;
		}
		set
		{
			_003CStartingStage_003Ek__BackingField = value;
		}
	}

	public string SpriteName
	{
		get
		{
			return _003CSpriteName_003Ek__BackingField;
		}
		set
		{
			_003CSpriteName_003Ek__BackingField = value;
		}
	}

	public string Texture
	{
		get
		{
			return _003CTexture_003Ek__BackingField;
		}
		set
		{
			_003CTexture_003Ek__BackingField = value;
		}
	}

	public DlcType? RequiresDLC
	{
		get
		{
			return _003CRequiresDLC_003Ek__BackingField;
		}
		set
		{
			_003CRequiresDLC_003Ek__BackingField = value;
		}
	}

	public int CompletionCoinReward
	{
		get
		{
			return _003CCompletionCoinReward_003Ek__BackingField;
		}
		set
		{
			_003CCompletionCoinReward_003Ek__BackingField = value;
		}
	}

	public List<SkinToUnlock> CompletionSkinsReward
	{
		get
		{
			return _003CCompletionSkinsReward_003Ek__BackingField;
		}
		set
		{
			_003CCompletionSkinsReward_003Ek__BackingField = value;
		}
	}
}
