using System;
using UnityEngine;
using UnityEngine.UI;

public class CursorEntry : MonoBehaviour
{
	[SerializeField]
	private Button button;

	[SerializeField]
	private LocalizeStringHandler handler;

	[SerializeField]
	private Image cursorPreview;

	private CursorSkin _skin;

	private IDisposable _subscription;

	public event Action<CursorSkin> Selected;

	public void Setup(CursorSkin skin)
	{
		CursorData data = skin.Value();
		_skin = skin;
		handler.SetLocalizedString(LocalizationUtility.For(_skin));
		cursorPreview.sprite = data.texture.ToSprite();
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
