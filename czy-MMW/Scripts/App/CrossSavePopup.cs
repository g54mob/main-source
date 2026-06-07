using Factory;
using Motorways;
using Popups;
using UnityEngine;
using UnityEngine.UI;

public class CrossSavePopup : BasePopup
{
	private AsyncRequestHandle _requestHandle;

	private float _spinTimer;

	[SerializeField]
	private GameObject _spinner;

	[SerializeField]
	[Tooltip("The maximum time in seconds the spinner will be shown before the cancel button will be revealed.")]
	[Min(1f)]
	private float _maxSpinTime = 5f;

	[SerializeField]
	private TouchButton _yesButton;

	[SerializeField]
	private TouchButton _noButton;

	[SerializeField]
	private LocalizedTextUI _mainPromptText;

	[SerializeField]
	private LocalizedTextUI _additionalText;

	[Dependency]
	private IScope _scope;

	[Dependency]
	private ISteamCloudSyncService _cloudSyncService;

	[Dependency]
	private PopupStack _popupStack;

	[Dependency]
	private ActivePlayer _player;

	[Dependency]
	private IReachability _reachability;

	private static readonly int Highlighted = Animator.StringToHash("Highlighted");

	public void StartSteamSync()
	{
		_mainPromptText.SetStringId(_scope, StringId.CrossSave_Importer_Header);
		SetAdditionalInfo(StringId.CrossSave_Importer_Loading);
		SetButtonVisibility(isYesVisible: false, isNoVisible: false);
		_spinner.SetActive(value: true);
		_spinTimer = _maxSpinTime;
		_reachability.OpenManualConnection(delegate(InternetConnectionHandle handle)
		{
			if (!handle.IsAvailable)
			{
				handle.Close();
				PresentError(SteamCloudSyncError.NoConnection);
			}
			else
			{
				_requestHandle = _cloudSyncService.Authenticate(delegate(string token, SteamCloudSyncError error)
				{
					_requestHandle = null;
					_spinTimer = 0f;
					if (error != SteamCloudSyncError.None || string.IsNullOrEmpty(token))
					{
						PresentError(error);
						handle.Close();
					}
					else
					{
						_requestHandle = _cloudSyncService.DownloadProfiles(token, delegate(ILegacyUserProfile legacyUserProfile, IExtendedUserProfile extendedUserProfile, SteamCloudSyncError syncError)
						{
							_requestHandle = null;
							if (error != SteamCloudSyncError.None)
							{
								PresentError(error);
								handle.Close();
							}
							else if (legacyUserProfile == null && extendedUserProfile == null)
							{
								PresentError(StringId.CrossSave_Error_NoSteamData);
								handle.Close();
							}
							else
							{
								if (legacyUserProfile != null)
								{
									_player.Player.MergeUserProfile(legacyUserProfile);
								}
								if (extendedUserProfile != null)
								{
									_player.Player.MergeExtendedUserProfile(extendedUserProfile);
								}
								SetAdditionalInfo(StringId.CrossSave_ImportSuccessful);
								SetButtonVisibility(isYesVisible: true, isNoVisible: false);
								_spinner.SetActive(value: false);
								handle.Close();
							}
						});
					}
				});
			}
		});
	}

	public void Update()
	{
		if (_spinTimer > 0f)
		{
			_spinTimer -= Time.deltaTime;
			if (_spinTimer <= 0f)
			{
				_spinTimer = 0f;
				SetButtonVisibility(isYesVisible: false, isNoVisible: true);
			}
		}
	}

	private void SetAdditionalInfo(StringId additionalInfoStringId)
	{
		if (additionalInfoStringId != StringId.None)
		{
			_additionalText.gameObject.SetActive(value: true);
			_additionalText.SetStringId(_scope, additionalInfoStringId);
		}
		else
		{
			_additionalText.gameObject.SetActive(value: false);
		}
	}

	private void PresentError(SteamCloudSyncError error)
	{
		PresentError(error switch
		{
			SteamCloudSyncError.AuthorizationDenied => StringId.CrossSave_Error_SteamLinkCancel, 
			SteamCloudSyncError.NoConnection => StringId.CrossSave_Error_NoConnection, 
			SteamCloudSyncError.NotSupported => StringId.CrossSave_Error_SteamLinkFail, 
			SteamCloudSyncError.InvalidData => StringId.CrossSave_Error_DataImportFail, 
			_ => StringId.CrossSave_Error_DataDownloadFail, 
		});
	}

	private void PresentError(StringId errorStringId)
	{
		SetAdditionalInfo(errorStringId);
		SetButtonVisibility(isYesVisible: true, isNoVisible: false);
		_spinner.SetActive(value: false);
	}

	public void NoPressed()
	{
		_requestHandle?.Cancel();
		_popupStack.PopPopup();
	}

	public void YesPressed()
	{
		_popupStack.PopPopup();
	}

	private void SetButtonVisibility(bool isYesVisible, bool isNoVisible)
	{
		_yesButton.gameObject.SetActive(isYesVisible);
		_noButton.gameObject.SetActive(isNoVisible);
		if (isYesVisible != isNoVisible && appScope.Get<InputState>().CurrentInputTypeRequiresFocus)
		{
			Selectable selectable = (isYesVisible ? _yesButton : _noButton);
			navigation.SetNewFocus(selectable);
			selectable.animator.SetTrigger(Highlighted);
		}
	}
}
