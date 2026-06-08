using System;
using UnityEngine;

namespace Dorfromantik
{
	public class LoadingProgressRouter : ScriptableObject
	{
		[SerializeField]
		private InputRouter inputRouter;

		[SerializeField]
		private InteractionRestriction loadingInteractionRestriction;

		private float _003CCurrentProgress_003Ek__BackingField;

		private bool _003CIsLoading_003Ek__BackingField;

		private bool _003CFastLoadingEnabled_003Ek__BackingField;

		public float CurrentProgress
		{
			get
			{
				return _003CCurrentProgress_003Ek__BackingField;
			}
			private set
			{
				_003CCurrentProgress_003Ek__BackingField = value;
			}
		}

		public bool IsLoading
		{
			get
			{
				return _003CIsLoading_003Ek__BackingField;
			}
			private set
			{
				_003CIsLoading_003Ek__BackingField = value;
			}
		}

		public bool FastLoadingEnabled
		{
			get
			{
				return _003CFastLoadingEnabled_003Ek__BackingField;
			}
			private set
			{
				_003CFastLoadingEnabled_003Ek__BackingField = value;
			}
		}

		public event Action OnStarted;

		public event Action OnCompleted;

		public event Action<float> OnProgressChanged;

		public event Action OnToggleLoadingUi;

		public void StartProgress()
		{
			SetProgress(0f);
			this.OnStarted?.Invoke();
			inputRouter.SetIsLoading(isLoading: true);
			IsLoading = true;
		}

		public void SetProgress(float newProgress)
		{
			CurrentProgress = Mathf.Clamp01(newProgress);
			this.OnProgressChanged?.Invoke(CurrentProgress);
			if (CurrentProgress >= 1f)
			{
				Resources.UnloadUnusedAssets();
				inputRouter.SetIsLoading(isLoading: false);
				IsLoading = false;
				this.OnCompleted?.Invoke();
				Debug.Log("Loading Complete");
			}
		}

		public void SetFastLoadingEnabled(bool isFastLoading)
		{
			FastLoadingEnabled = isFastLoading;
		}

		public void ToggleLoadingUi()
		{
			this.OnToggleLoadingUi?.Invoke();
		}
	}
}
