using System;
using System.IO;
using System.Threading.Tasks;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.FullSerializerWrappers;
using Restory.Data.SaveLoad.Providers;
using UnityEngine;
using Zenject;

namespace Restory.Data.Analytics
{
	public class AnalyticsConsentCheckingService : MonoBehaviour, IInitializable
	{
		[SerializeField]
		private string privacySettingsFileName = "privacySettingsDefaultProfile";

		[SerializeField]
		private SaveSystemSettings settings;

		private AnalyticsConsentState state;

		private bool isDataLoadingCompleted;

		private CommonFullSerializer.Factory fsFactory;

		private IAnalyticsService analyticsService;

		public bool IsDataLoadingCompleted => isDataLoadingCompleted;

		public AnalyticsConsentState State
		{
			get
			{
				return state;
			}
			set
			{
				state = value;
				analyticsService.IsActive = state == AnalyticsConsentState.Confirmed;
				if (state == AnalyticsConsentState.Canceled)
				{
					analyticsService.RequestDataDeletion();
				}
			}
		}

		public event Action OnDataLoadingCompleted;

		[Inject]
		private void Construct(CommonFullSerializer.Factory fsFactory, IAnalyticsService analyticsService)
		{
			this.fsFactory = fsFactory;
			this.analyticsService = analyticsService;
		}

		public void Initialize()
		{
			Load();
		}

		public void Save()
		{
			SaveAsync(new AnalyticsConsentCheckingServiceSavedState
			{
				ConsentState = state
			});
		}

		private void Load()
		{
			string text = Path.Combine(settings.WorkDirectory, privacySettingsFileName + ".json");
			Debug.Log("[AnalyticsConsentCheckingService] Loading privacy settings from: " + text);
			IJsonSaveDataProvider jsonProvider = DataProviders.GetJsonProvider();
			if (!jsonProvider.FileExists(text))
			{
				Debug.Log("[AnalyticsConsentCheckingService] privacy settings save file " + text + " not found");
				state = AnalyticsConsentState.Unknown;
				analyticsService.IsActive = state == AnalyticsConsentState.Confirmed;
				isDataLoadingCompleted = true;
				this.OnDataLoadingCompleted?.Invoke();
				return;
			}
			string serializedState = jsonProvider.Load(text);
			try
			{
				AnalyticsConsentCheckingServiceSavedState analyticsConsentCheckingServiceSavedState = fsFactory.Create().FromJsonUnsafe<AnalyticsConsentCheckingServiceSavedState>(serializedState);
				state = analyticsConsentCheckingServiceSavedState.ConsentState;
				analyticsService.IsActive = state == AnalyticsConsentState.Confirmed;
			}
			catch (Exception)
			{
			}
			isDataLoadingCompleted = true;
			this.OnDataLoadingCompleted?.Invoke();
		}

		private async void SaveAsync(AnalyticsConsentCheckingServiceSavedState consentSettings)
		{
			string fullPath = Path.Combine(settings.WorkDirectory, privacySettingsFileName + ".json");
			string jsonValue = await Task.Run(() => ToJson(consentSettings));
			DataProviders.GetJsonProvider().Save(jsonValue, fullPath);
			Debug.Log("[AnalyticsConsentCheckingService] Saving privacy settings to: " + fullPath);
		}

		private string ToJson(AnalyticsConsentCheckingServiceSavedState consentSettings)
		{
			return fsFactory.Create().ToJson(consentSettings);
		}
	}
}
