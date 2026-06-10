using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class UpgradesController : MonoBehaviour
{
	public enum SyncDiskState
	{
		notInstalled = 0,
		option1 = 1,
		option2 = 2,
		option3 = 3
	}

	[Serializable]
	public class Upgrades
	{
		public string upgrade;

		public SyncDiskState state;

		public int list;

		public int level;

		public int objId;

		public int uninstallCost;

		[NonSerialized]
		public SyncDiskPreset preset;

		public SyncDiskPreset GetPreset()
		{
			return null;
		}

		public Interactable GetObject()
		{
			return null;
		}

		public List<UpgradeEffectController.AppliedEffect> GetAllEffects()
		{
			return null;
		}

		public List<UpgradeEffectController.AppliedEffect> GetMainEffects()
		{
			return null;
		}

		public List<UpgradeEffectController.AppliedEffect> GetUpgradeEffects()
		{
			return null;
		}

		public List<UpgradeEffectController.AppliedEffect> GetSideEffects()
		{
			return null;
		}

		public float GetEffectiveness()
		{
			return 0f;
		}

		public float GetSideEffectValue()
		{
			return 0f;
		}
	}

	[CompilerGenerated]
	private sealed class _003COpen_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UpgradesController _003C_003E4__this;

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
		public _003COpen_003Ed__39(int _003C_003E1__state)
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
	private sealed class _003CClose_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public UpgradesController _003C_003E4__this;

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
		public _003CClose_003Ed__41(int _003C_003E1__state)
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

	[Header("Components")]
	public RectTransform mainContentRect;

	public RectTransform mainViewport;

	public CustomScrollRect mainScrollRect;

	public RectTransform listContentRect;

	public RectTransform listRect;

	[Space(7f)]
	public ButtonController closeButton;

	public TextMeshProUGUI installedDisksText;

	public TextMeshProUGUI syncClinicPromptText;

	public TextMeshProUGUI configText;

	public TextMeshProUGUI upgradesText;

	public TextMeshProUGUI sideEffectsText;

	public TextMeshProUGUI descriptionText;

	public TextMeshProUGUI optionsText;

	public GameObject syncDiskElementPrefab;

	[NonSerialized]
	[Header("State")]
	public float openProgress;

	public bool isOpen;

	public bool installedAllowed;

	public int notInstalled;

	public bool playSyncDiskInstallAudio;

	public List<Upgrades> upgrades;

	public List<SyncDiskElementController> spawnedDisks;

	public Dictionary<string, SyncDiskPreset> upgradesQuickRef;

	public List<Interactable> upgradeVials;

	private static UpgradesController _instance;

	public static UpgradesController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetupQuickRef()
	{
	}

	public void Setup()
	{
	}

	public void UpdateUpgrades()
	{
	}

	public void InstallSyncDisk(Upgrades application, int option)
	{
	}

	public void UninstallSyncDisk(Upgrades removal)
	{
	}

	public void UpgradeSyncDisk(Upgrades upgradeThis)
	{
	}

	public void UpdateInstallButton(bool newInstallAllowed)
	{
	}

	public void UpdateInstalledAvailableText()
	{
	}

	public void OpenUpgrades(bool playSound = true)
	{
	}

	[IteratorStateMachine(typeof(_003COpen_003Ed__39))]
	private IEnumerator Open()
	{
		return null;
	}

	public void CloseUpgrades(bool playSound = true)
	{
	}

	[IteratorStateMachine(typeof(_003CClose_003Ed__41))]
	private IEnumerator Close()
	{
		return null;
	}

	public void UpdateActivation()
	{
	}

	public void UpdateNavigation()
	{
	}
}
