using System;
using Restory.Gameplay.GameSettings;
using Restory.Gameplay.GameSettings.Observers;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.TextSizeModifiers
{
	public class TextSizeModifiersService : MonoBehaviour
	{
		[SerializeField]
		private TextSizeProfile defaultProfile;

		private GameSettingsTextSizeChangeObserver gameSettingsManager;

		public bool IsSizeModified { get; private set; }

		public TextSizeProfile DefaultProfile => defaultProfile;

		public event Action TextSizeSettingsChanged = delegate
		{
		};

		[Inject]
		private void Construct(GameSettingsTextSizeChangeObserver gameSettingsManager)
		{
			this.gameSettingsManager = gameSettingsManager;
			gameSettingsManager.AddSubscriber(this, OnTextSizeChanged);
			OnTextSizeChanged(gameSettingsManager.TextSize);
		}

		private void OnDestroy()
		{
			if (gameSettingsManager != null)
			{
				gameSettingsManager.RemoveSubscriber(this);
			}
			this.TextSizeSettingsChanged = null;
		}

		private void OnTextSizeChanged(TextSize? size)
		{
			if (size.HasValue)
			{
				SetSizeModified(size != TextSize.Default);
			}
		}

		private void SetSizeModified(bool modify)
		{
			bool num = IsSizeModified != modify;
			IsSizeModified = modify;
			if (num)
			{
				this.TextSizeSettingsChanged();
			}
		}
	}
}
