using System;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundEntry : MonoBehaviour
{
	[SerializeField]
	private Button button;

	[SerializeField]
	private LocalizeStringHandler handler;

	private BackgroundSkin _skin;

	private IDisposable _subscription;

	public event Action<BackgroundSkin> Selected;

	public void Setup(BackgroundSkin skin)
	{
		_skin = skin;
		handler.SetLocalizedString(LocalizationUtility.For(_skin));
		button.onClick.AddListener(delegate
		{
			this.Selected?.Invoke(_skin);
		});
		Achievement achievement = skin.Value().achievement;
		base.gameObject.SetActive(Database.State.Achievements.IsUnlocked(achievement));
		_subscription = EventHub.Scene.Subscribe(delegate
		{
			SkinUnlocked();
		}, (AchievementUnlocked ctx) => ctx.Achievement == achievement);
	}

	private void SkinUnlocked()
	{
		base.gameObject.SetActive(value: true);
		_subscription?.Dispose();
	}

	private void OnDestroy()
	{
		_subscription?.Dispose();
	}
}
