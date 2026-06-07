using System;
using System.Collections.Generic;
using Factory;
using Motorways;
using UnityEngine;

public class ChallengeInfoText : MonoBehaviour
{
	[SerializeField]
	private LocalizedTextUI _challengeHeader;

	[SerializeField]
	private LocalizedTextUI _challengeDescription;

	[SerializeField]
	private ChallengeIcon _challengeIcon;

	public void SetChallengeInfo(ChallengeData data, bool isWildcard, IScope scope)
	{
		_challengeIcon.SetChallengeIcons(data.icon, isWildcard, data.subIcon, data.subIconBackground);
		float selectedModifierLocalizationParameter = data.GetSelectedModifierLocalizationParameter();
		MotorwaysStringKey motorwaysStringKey = scope.Get<MotorwaysStringKey>();
		if (!string.IsNullOrEmpty(data.challengeName) && Diagnostics.Verify(Enum.TryParse<StringId>(data.challengeName, out var result), "{0} is an invalid string id!", data.challengeDescription))
		{
			motorwaysStringKey.InitWithStringId(result, data.GetSelectedModifierLocalizationParameter(), new Dictionary<string, string> { 
			{
				"Num",
				selectedModifierLocalizationParameter.ToString()
			} });
			_challengeHeader.LocString = StandaloneLocString.CreateString(scope, motorwaysStringKey);
		}
		if (!string.IsNullOrEmpty(data.challengeDescription))
		{
			MotorwaysStringKey motorwaysStringKey2 = scope.Get<MotorwaysStringKey>();
			if (Diagnostics.Verify(Enum.TryParse<StringId>(data.challengeDescription, out var result2), "{0} is an invalid string id!", data.challengeDescription))
			{
				motorwaysStringKey2.InitWithStringId(result2, data.GetSelectedModifierLocalizationParameter(), new Dictionary<string, string> { 
				{
					"Num",
					selectedModifierLocalizationParameter.ToString()
				} });
				_challengeDescription.LocString = StandaloneLocString.CreateString(scope, motorwaysStringKey2);
			}
		}
	}
}
