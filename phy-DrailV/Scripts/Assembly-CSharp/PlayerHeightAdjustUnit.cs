using System;
using System.Collections;
using Bolt;
using DV.Game.Tutorial;
using DV.Utils;
using Ludiq;
using UnityEngine;

[UnitCategory("Player")]
[UnitSubtitle("Make sure the player adjusts the height for a while")]
[TypeIcon(typeof(CharacterController))]
[UnitTitle("Player Height Adjust")]
public class PlayerHeightAdjustUnit : Unit
{
	[DoNotSerialize]
	public ControlInput inputTrigger;

	[DoNotSerialize]
	public ControlOutput doneTrigger;

	[DoNotSerialize]
	public ValueInput requiredMotion;

	[DoNotSerialize]
	public ValueInput requiredTime;

	[LocalizedValue]
	[DoNotSerialize]
	public ValueInput messageValue;

	protected override void Definition()
	{
		doneTrigger = ControlOutput("Done");
		requiredMotion = ValueInput("Req. motion", 0.5f);
		requiredTime = ValueInput("Req. time", 2f);
		messageValue = ValueInput("Message", "");
		inputTrigger = ControlInputCoroutine("Input", Routine);
	}

	private IEnumerator Routine(Flow flow)
	{
		float requiredMotion = flow.GetValue<float>(this.requiredMotion);
		float requiredTime = flow.GetValue<float>(this.requiredTime);
		float totalMotion = 0f;
		float totalTime = 0f;
		float lastHeight = 0f;
		bool flag = VRManager.IsVREnabled() && GamePreferences.Get<bool>(Preferences.SeatedPlayAreaType);
		Preferences heightPref = (flag ? Preferences.PlayerSeatedHeight : Preferences.PlayerRoomscaleHeight);
		string message = flow.GetValue<string>(messageValue);
		ACharacterControllerProvider provider = PlayerManager.PlayerTransform.GetComponent<ACharacterControllerProvider>();
		if ((bool)provider)
		{
			provider.OnPlayerHeightAdjusted = (Action<float, float>)Delegate.Combine(provider.OnPlayerHeightAdjusted, new Action<float, float>(OnHeightAdjusted));
		}
		else
		{
			lastHeight = GamePreferences.Get<float>(heightPref);
			GamePreferences.RegisterToPreferenceUpdated(heightPref, OnPrefHeightAdjusted);
		}
		if (!string.IsNullOrEmpty(message))
		{
			SingletonBehaviour<TutorialHelper>.Instance.ShowTutorialFloatie(message, null);
		}
		while (totalMotion < requiredMotion || totalTime < requiredTime || totalTime == 0f)
		{
			totalTime += Time.deltaTime;
			yield return null;
		}
		if ((bool)provider)
		{
			provider.OnPlayerHeightAdjusted = (Action<float, float>)Delegate.Remove(provider.OnPlayerHeightAdjusted, new Action<float, float>(OnHeightAdjusted));
		}
		else
		{
			GamePreferences.UnregisterFromPreferenceUpdated(heightPref, OnPrefHeightAdjusted);
		}
		if (!string.IsNullOrEmpty(message))
		{
			SingletonBehaviour<TutorialHelper>.Instance.HideTutorialFloatie();
		}
		yield return doneTrigger;
		void OnHeightAdjusted(float value, float delta)
		{
			totalMotion += Mathf.Abs(delta);
		}
		void OnPrefHeightAdjusted()
		{
			float num = GamePreferences.Get<float>(heightPref);
			totalMotion += Mathf.Abs(num - lastHeight);
			lastHeight = num;
		}
	}
}
