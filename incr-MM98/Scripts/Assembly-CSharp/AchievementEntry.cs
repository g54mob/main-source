using System;
using System.Collections.Generic;
using Cysharp.Text;
using R3;
using UnityEngine;
using UnityEngine.UI;
using ZLinq;
using ZLinq.Linq;

public class AchievementEntry : MonoBehaviour
{
	[SerializeField]
	private LocalizeStringHandler titleHandler;

	[SerializeField]
	private LocalizeStringHandler descriptionHandler;

	[SerializeField]
	private Image image;

	[SerializeField]
	private GameObject lockedImage;

	[SerializeField]
	private SegmentedLoadingBar progressBar;

	[SerializeField]
	private ValueNumericDisplay progressValue;

	[SerializeField]
	private AchievementTooltip rewardTooltip;

	private AchievementData.Scope _scope;

	private AchievementData.Scope _currentScope;

	private bool _hidden;

	private bool _unlocked;

	public void Setup(AchievementData achievement)
	{
		titleHandler.SetLocalizedString(LocalizationUtility.Find(LocTable.Milestones, achievement.TitleKey));
		descriptionHandler.SetLocalizedString(LocalizationUtility.Find(LocTable.Milestones, achievement.DescriptionKey));
		image.overrideSprite = achievement.sprite;
		AchievementDetails? details = Database.State.Achievements.GetDetails(achievement);
		if (!details.HasValue)
		{
			throw new ArgumentNullException();
		}
		_scope = achievement.scope;
		_hidden = achievement.hidden;
		details.Value.Unlocked.Subscribe(SetUnlocked).AddTo(this);
		details.Value.Normalized.Subscribe((progressBar, progressValue), SetProgress).AddTo(this);
		List<string> list = RewardsForAchievement(achievement);
		rewardTooltip.gameObject.SetActive(list.Count > 0);
		rewardTooltip.Tooltip.description.Arguments = new object[1] { list };
	}

	private void SetUnlocked(bool unlocked)
	{
		lockedImage.SetActive(!unlocked);
		_unlocked = unlocked;
		ShowEntry(_currentScope);
	}

	public void ShowEntry(AchievementData.Scope scope)
	{
		_currentScope = scope;
		base.gameObject.SetActive(_scope == scope && (!_hidden || _unlocked));
	}

	private static void SetProgress(float progress, (SegmentedLoadingBar progressBar, ValueNumericDisplay progressValue) state)
	{
		state.progressBar.SetNormalizedValue(progress);
		state.progressValue.Animate(progress * 100f, Mathf.Approximately(progress, 1f) ? NumericFormat.MilestoneComplete : NumericFormat.MilestoneProgress, 0.5f);
	}

	private static List<string> RewardsForAchievement(Achievement achievement)
	{
		List<string> list = new List<string>();
		using (ValueEnumerator<Where<FromEnumerable<BackgroundSkin>, BackgroundSkin>, BackgroundSkin> valueEnumerator = (from x in EnumUtility.GetValues<BackgroundSkin>().AsValueEnumerable()
			where x.Value().achievement == achievement
			select x).GetEnumerator<Where<FromEnumerable<BackgroundSkin>, BackgroundSkin>, BackgroundSkin>())
		{
			while (valueEnumerator.MoveNext())
			{
				BackgroundSkin current = valueEnumerator.Current;
				list.Add(FormatSkin(current));
			}
		}
		using (ValueEnumerator<Where<FromEnumerable<CursorSkin>, CursorSkin>, CursorSkin> valueEnumerator2 = (from x in EnumUtility.GetValues<CursorSkin>().AsValueEnumerable()
			where x.Value().achievement == achievement
			select x).GetEnumerator<Where<FromEnumerable<CursorSkin>, CursorSkin>, CursorSkin>())
		{
			while (valueEnumerator2.MoveNext())
			{
				CursorSkin current2 = valueEnumerator2.Current;
				list.Add(FormatSkin(current2));
			}
		}
		using ValueEnumerator<Where<FromEnumerable<GnormanSkin>, GnormanSkin>, GnormanSkin> valueEnumerator3 = (from x in EnumUtility.GetValues<GnormanSkin>().AsValueEnumerable()
			where x.Value().achievement == achievement
			select x).GetEnumerator<Where<FromEnumerable<GnormanSkin>, GnormanSkin>, GnormanSkin>();
		while (valueEnumerator3.MoveNext())
		{
			GnormanSkin current3 = valueEnumerator3.Current;
			list.Add(FormatSkin(current3));
		}
		return list;
	}

	private static string FormatSkin(BackgroundSkin skin)
	{
		return ZString.Format("{0} - {1}", LocalizationUtility.Find(LocTable.General, "customization_wallpaper").GetLocalizedString(), LocalizationUtility.For(skin).GetLocalizedString());
	}

	private static string FormatSkin(CursorSkin skin)
	{
		return ZString.Format("{0} - {1}", LocalizationUtility.Find(LocTable.General, "customization_cursor").GetLocalizedString(), LocalizationUtility.For(skin).GetLocalizedString());
	}

	private static string FormatSkin(GnormanSkin skin)
	{
		return ZString.Format("{0} - {1}", LocalizationUtility.Find(LocTable.General, "customization_gnorman").GetLocalizedString(), LocalizationUtility.For(skin).GetLocalizedString());
	}
}
