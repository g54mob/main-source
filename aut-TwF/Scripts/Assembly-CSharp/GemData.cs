using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "GemData_default", menuName = "Tower Factory/Gem Data")]
public class GemData : ScriptableObject, ISavable
{
	[SerializeField]
	[Savable("id", true, false)]
	private string id = "ASSING_AN_ID";

	[SerializeField]
	private LocalizedString displayName;

	[SerializeField]
	private Sprite icon;

	[SerializeField]
	private GameplayEffectData[] gameplayEffectsToApply;

	[SerializeField]
	private int value;

	public string DisplayName => displayName.GetLocalizedString();

	public string Description
	{
		get
		{
			if (gameplayEffectsToApply != null && gameplayEffectsToApply.Length != 0)
			{
				return gameplayEffectsToApply[0].Description;
			}
			return "";
		}
	}

	public string Id => id;

	public Sprite Icon => icon;

	public GameplayEffectData[] GameplayEffectsToApply => gameplayEffectsToApply;

	public int Value => value;

	private void SetNameAsID()
	{
		id = base.name;
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}
