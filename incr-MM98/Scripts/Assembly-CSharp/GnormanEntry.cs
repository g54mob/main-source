using System;
using UnityEngine;
using UnityEngine.UI;

public class GnormanEntry : MonoBehaviour
{
	[SerializeField]
	private Button button;

	[SerializeField]
	private LocalizeStringHandler handler;

	[SerializeField]
	private Image skinImage;

	private GnormanSkin _skin;

	private IDisposable _subscription;

	public event Action<GnormanSkin> Selected;

	public void Setup(GnormanSkin skin)
	{
		GnormanSkinData data = skin.Value();
		_skin = skin;
		handler.SetLocalizedString(LocalizationUtility.For(_skin));
		skinImage.sprite = data.sprite;
		button.onClick.AddListener(delegate
		{
			this.Selected?.Invoke(_skin);
		});
		base.gameObject.SetActive(Database.State.Achievements.IsUnlocked(data.achievement));
		_subscription = EventHub.Scene.Subscribe(delegate
		{
			SkinUnlocked();
		}, (AchievementUnlocked ctx) => ctx.Achievement == data.achievement);
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
