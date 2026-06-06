using System.Collections.Generic;
using Cysharp.Text;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ZLinq;
using ZLinq.Linq;

public class AchievementPopup : Popup
{
	[SerializeField]
	private ButtonWrapper studioTab;

	[SerializeField]
	private ButtonWrapper globalTab;

	[SerializeField]
	private TMP_Text achievementTotalText;

	[SerializeField]
	private Image achievementTotalImage;

	[SerializeField]
	private Transform entryParent;

	[SerializeField]
	private AchievementEntry entryPrefab;

	private readonly List<AchievementEntry> _entries = new List<AchievementEntry>();

	protected override void Initialize(StatelessInitializerContext initializer)
	{
		studioTab.onClick.AddListener(delegate
		{
			ShowAchievements(AchievementData.Scope.Studio);
		});
		globalTab.onClick.AddListener(delegate
		{
			ShowAchievements(AchievementData.Scope.Global);
		});
		EventHub.Scene.Subscribe(delegate(AchievementUnlocked ctx)
		{
			ShowToast(ctx.Achievement);
		}).AddTo(this);
		InitializeAchievements();
		InitializeTotal();
		ShowAchievements(AchievementData.Scope.Studio);
	}

	private void ShowAchievements(AchievementData.Scope scope)
	{
		if (scope == AchievementData.Scope.Studio)
		{
			studioTab.ForceSelected();
			globalTab.Clear();
		}
		else
		{
			studioTab.Clear();
			globalTab.ForceSelected();
		}
		foreach (AchievementEntry entry in _entries)
		{
			entry.ShowEntry(scope);
		}
	}

	private void InitializeAchievements()
	{
		using ValueEnumerator<Select<FromEnumerable<Achievement>, Achievement, AchievementData>, AchievementData> valueEnumerator = (from x in EnumUtility.GetValuesSkipNone<Achievement>().AsValueEnumerable()
			select x.Data()).GetEnumerator<Select<FromEnumerable<Achievement>, Achievement, AchievementData>, AchievementData>();
		while (valueEnumerator.MoveNext())
		{
			AchievementData current = valueEnumerator.Current;
			AchievementEntry achievementEntry = Object.Instantiate(entryPrefab, entryParent);
			achievementEntry.Setup(current);
			_entries.Add(achievementEntry);
		}
	}

	private void InitializeTotal()
	{
		Database.State.Achievements.Unlocked.Subscribe((achievementTotalText, achievementTotalImage), UpdateTotalProgress).AddTo(this);
	}

	private void ShowToast(Achievement achievement)
	{
		AchievementData data = achievement.Data();
		MonoSingleton<ToastManager>.Instance.ShowToast(data.TitleLocalized, data.DescriptionLocalized, data.sprite, delegate
		{
			ShowContent();
			ShowAchievements(data.scope);
		}, 3f);
	}

	private static void UpdateTotalProgress(int unlocked, (TMP_Text text, Image image) state)
	{
		int count = CatalogProvider.Achievements.Count;
		if (count != 0)
		{
			state.text.SetTextFormat("{0}/{1}", unlocked, count);
			state.image.fillAmount = Mathf.Clamp01((float)unlocked / (float)count);
		}
	}
}
