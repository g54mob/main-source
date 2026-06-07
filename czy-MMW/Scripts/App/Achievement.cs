using System.Collections.Generic;
using Factory;

public abstract class Achievement
{
	private bool _isComplete;

	[Dependency]
	protected AchievementDatabase _achievementDatabase;

	[Dependency]
	protected IAchievementHandler _achievementHandler;

	private const string IdKey = "Id";

	private const string IsCompleteKey = "isComplete";

	private const string IsAwardedOnPlatformKey = "IsAwardedOnPlatform";

	public abstract string Id { get; protected set; }

	private bool _isAwardedOnPlatform { get; set; }

	public AchievementDefinition Definition => _achievementDatabase[Id];

	public void InitFromString(string stringId)
	{
		Id = stringId;
	}

	public void InitFromDefinition(AchievementDefinition achievementDefinition)
	{
		Id = achievementDefinition.Id;
	}

	public void InitFromJson(JSON.Dictionary jsonDictionary)
	{
		if (jsonDictionary != null)
		{
			InitFromString(jsonDictionary.GetString("Id"));
			_isComplete = jsonDictionary.GetBool("isComplete");
			_isAwardedOnPlatform = jsonDictionary.GetBool("IsAwardedOnPlatform");
		}
	}

	public bool IsComplete()
	{
		return _isComplete;
	}

	public void SetComplete(bool isComplete)
	{
		_isComplete = isComplete;
	}

	public bool Merge(Achievement other)
	{
		if (!_isComplete && other._isComplete)
		{
			_isComplete = true;
			return true;
		}
		return false;
	}

	public object ToJson()
	{
		return new Dictionary<string, object>
		{
			["Id"] = Id,
			["isComplete"] = _isComplete,
			["IsAwardedOnPlatform"] = _isAwardedOnPlatform
		};
	}
}
