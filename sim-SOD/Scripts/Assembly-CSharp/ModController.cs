using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ModIO;
using NaughtyAttributes;
using Steamworks;
using UnityEngine;

public class ModController : MonoBehaviour
{
	[Serializable]
	public class ModIconSetup
	{
		public SubscribedModStatus state;

		public Sprite spriteEnabled;

		public Sprite spriteDisabled;
	}

	[CompilerGenerated]
	private sealed class _003CWaitForGetModsComplete_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ModController _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CWaitForGetModsComplete_003Ed__32(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CUploadToWorkshop_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public ModController _003C_003E4__this;

		public ModSettingsData modSettingsData;

		private bool _003CconfigValidated_003E5__2;

		private bool _003CcreatedItemRequest_003E5__3;

		private bool _003CupdateItemRequest_003E5__4;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CUploadToWorkshop_003Ed__38(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[InfoBox("IMPORTANT: The ModLoader.cs script is present in the ControllerDetect screen, and will not be removed on scene change; so mods are loaded at the beginning but this will behave differently in editor where you aren't first running the ControllerDetect scene.", EInfoBoxType.Normal)]
	[Header("Setup")]
	public GameObject browserPrefab;

	public GameObject modElementPrefab;

	public GameObject modLoaderPrefab;

	[Tooltip("If true, we will use mod.io")]
	public bool allowModIO;

	[Tooltip("If true, we will allow steam workshop (must also be set to the steam build config)")]
	public bool allowSteamWorkshop;

	[Header("Status")]
	[Tooltip("If true this will prompt a restart of the game to properly load-in mods")]
	public bool modConfigChanged;

	public bool waitingForModUpdate;

	public bool uploadingToWorkshop;

	public ModSettingsData uploadingModSettings;

	private string workshopAgreementURL;

	private bool createdNewWorkshopItem;

	private PublishedFileId_t createdItemHandle;

	private bool workshopUpdateSuccess;

	private string finalModUploadURL;

	[Header("Components")]
	public RectTransform modContentRect;

	public GameObject spawnedBrowser;

	public List<ModEntryController> spawnedModElements;

	public ButtonController applyButton;

	public ButtonController workshopButton;

	private static ModController _instance;

	private bool hasSpawned => false;

	public static ModController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	public void OpenModBrowser()
	{
	}

	public void OpenSteamWorkshop()
	{
	}

	public void OnBrowserClose()
	{
	}

	public void UpdateModEntries()
	{
	}

	[IteratorStateMachine(typeof(_003CWaitForGetModsComplete_003Ed__32))]
	private IEnumerator WaitForGetModsComplete()
	{
		return null;
	}

	public void SetModConfigChanged(bool val)
	{
	}

	public void OnApplyRestartButton()
	{
	}

	public void OnRestartConfirm()
	{
	}

	public void OnRestartCancel()
	{
	}

	public void UploadToSteamWorkshop(ModSettingsData modSettingsData)
	{
	}

	[IteratorStateMachine(typeof(_003CUploadToWorkshop_003Ed__38))]
	private IEnumerator UploadToWorkshop(ModSettingsData modSettingsData)
	{
		return null;
	}

	private void CreateWorkshopItem()
	{
	}

	private void HandleCreateItemResult(CreateItemResult_t result, bool bIOFailure)
	{
	}

	public void UpdateWorkshopItem(PublishedFileId_t itemId, ModSettingsData modSettings)
	{
	}

	private void HandleItemUpdateResult(SubmitItemUpdateResult_t result, bool bIOFailure)
	{
	}

	public void OnInputModName()
	{
	}

	public void OnInputModCreator()
	{
	}

	public void OnInputModDescription()
	{
	}

	public void ValidationCancel()
	{
	}

	public void OnOpenWorkshopAgreement()
	{
	}

	public void OnCancelWorkshopAgreement()
	{
	}

	public void OpenModDocumentation()
	{
	}
}
