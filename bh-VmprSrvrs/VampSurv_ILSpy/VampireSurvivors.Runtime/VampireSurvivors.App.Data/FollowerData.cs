using System;
using VampireSurvivors.Data;
using VampireSurvivors.Objects.Algorithm;

namespace VampireSurvivors.App.Data;

[Serializable]
public class FollowerData
{
	private CharacterType _003CFollowerCharacter_003Ek__BackingField;

	private AIType _003CFollowerAI_003Ek__BackingField;

	private bool _003CIsFollowerInvinceable_003Ek__BackingField;

	private bool _003CCountsAsMainCharacterForRevivals_003Ek__BackingField;

	private bool _003CManualLevelUps_003Ek__BackingField;

	private bool _003CTrackedByCamera_003Ek__BackingField;

	private bool _003CShouldFollowMainPlayer_003Ek__BackingField;

	private bool _003CAllowDuplicates_003Ek__BackingField;

	private int _003CEveryXLevels_003Ek__BackingField = 3;

	private bool _003CShouldSharePassives_003Ek__BackingField = true;

	private bool _003CShouldFollowerReactToArcanas_003Ek__BackingField;

	public CharacterType FollowerCharacter
	{
		get
		{
			return _003CFollowerCharacter_003Ek__BackingField;
		}
		set
		{
			_003CFollowerCharacter_003Ek__BackingField = value;
		}
	}

	public AIType FollowerAI
	{
		get
		{
			return _003CFollowerAI_003Ek__BackingField;
		}
		set
		{
			_003CFollowerAI_003Ek__BackingField = value;
		}
	}

	public bool IsFollowerInvinceable
	{
		get
		{
			return _003CIsFollowerInvinceable_003Ek__BackingField;
		}
		set
		{
			_003CIsFollowerInvinceable_003Ek__BackingField = value;
		}
	}

	public bool CountsAsMainCharacterForRevivals
	{
		get
		{
			return _003CCountsAsMainCharacterForRevivals_003Ek__BackingField;
		}
		set
		{
			_003CCountsAsMainCharacterForRevivals_003Ek__BackingField = value;
		}
	}

	public bool ManualLevelUps
	{
		get
		{
			return _003CManualLevelUps_003Ek__BackingField;
		}
		set
		{
			_003CManualLevelUps_003Ek__BackingField = value;
		}
	}

	public bool TrackedByCamera
	{
		get
		{
			return _003CTrackedByCamera_003Ek__BackingField;
		}
		set
		{
			_003CTrackedByCamera_003Ek__BackingField = value;
		}
	}

	public bool ShouldFollowMainPlayer
	{
		get
		{
			return _003CShouldFollowMainPlayer_003Ek__BackingField;
		}
		set
		{
			_003CShouldFollowMainPlayer_003Ek__BackingField = value;
		}
	}

	public bool AllowDuplicates
	{
		get
		{
			return _003CAllowDuplicates_003Ek__BackingField;
		}
		set
		{
			_003CAllowDuplicates_003Ek__BackingField = value;
		}
	}

	public int EveryXLevels
	{
		get
		{
			return _003CEveryXLevels_003Ek__BackingField;
		}
		set
		{
			_003CEveryXLevels_003Ek__BackingField = value;
		}
	}

	public bool ShouldSharePassives
	{
		get
		{
			return _003CShouldSharePassives_003Ek__BackingField;
		}
		set
		{
			_003CShouldSharePassives_003Ek__BackingField = value;
		}
	}

	public bool ShouldFollowerReactToArcanas
	{
		get
		{
			return _003CShouldFollowerReactToArcanas_003Ek__BackingField;
		}
		set
		{
			_003CShouldFollowerReactToArcanas_003Ek__BackingField = value;
		}
	}
}
