using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AppVirusPlus : PTSMonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CChangeAlphaCoroutine_003Ed__74 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Image image;

		public float toAlpha;

		public float time;

		public AppVirusPlus _003C_003E4__this;

		private float _003CelapsedTime_003E5__2;

		private Color _003CstartColor_003E5__3;

		private Color _003CtargetColor_003E5__4;

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
		public _003CChangeAlphaCoroutine_003Ed__74(int _003C_003E1__state)
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
	private sealed class _003CEnterBadCode_003Ed__76 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppVirusPlus _003C_003E4__this;

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
		public _003CEnterBadCode_003Ed__76(int _003C_003E1__state)
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
	private sealed class _003CMenuShowCoroutine_003Ed__73 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public RectTransform obj;

		public float toX;

		public float time;

		public AppVirusPlus _003C_003E4__this;

		private float _003CelapsedTime_003E5__2;

		private Vector2 _003CstartPos_003E5__3;

		private Vector2 _003CtargetPos_003E5__4;

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
		public _003CMenuShowCoroutine_003Ed__73(int _003C_003E1__state)
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
	private sealed class _003CdeleteThisVirus_003Ed__82 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public AppVirusPlus _003C_003E4__this;

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
		public _003CdeleteThisVirus_003Ed__82(int _003C_003E1__state)
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

	[AppNameDropdown]
	[Header("Component Default")]
	public string nameInAppBase;

	public AppMovementFucus movementFucus;

	public WindowAppMinimalizeAnimation minimalizeAnimation;

	public ActivationKeyInput activationKeyInput;

	public Scanning scanning;

	public AppFirewall appFirewall;

	public AppBrowser appBrowser;

	[HideInInspector]
	public bool isOpen;

	public GameObject menu;

	public GameObject alphaMenuBG;

	public GameObject licenseActivation;

	public GameObject activationElement1;

	public GameObject activationElement2;

	public TMP_InputField inputCodeActivation;

	public RectTransform menuObject;

	public Image alphaBGmenu;

	private Coroutine showorhideMenuCoroutine;

	private Coroutine alphaMenuBGCoroutine;

	private Coroutine badcodeCoroutine;

	public bool isScanning;

	[Header("Computer")]
	public GameObject computerVirusView;

	public GameObject[] virusNotifi;

	public TextMeshProUGUI[] virusCounterText;

	public GameObject deletedThreatsButton;

	public TextMeshProUGUI deletedThreatsButtonText;

	public bool isDeletedVirus;

	public Coroutine deletetingVirusCoroutine;

	[Header("Web & Mail")]
	public GameObject webmailListView;

	public GameObject[] notifiWebMail;

	public bool isInfect;

	public bool isOpenWebCategory;

	public List<string> infectAddress;

	[Header("Hacker Attacks")]
	public GameObject hackerListView;

	public GameObject[] hackerViolations;

	[Header("Data")]
	public bool fullProtection;

	public TextMeshProUGUI uHaveBasicProtection;

	public TextMeshProUGUI[] statusService;

	public int virusCounter_BootSectorVirus;

	public int realvirusCounter_BootSectorVirus;

	public int virusCounter_FileInfector;

	public int realvirusCounter_FileInfector;

	public int virusCounter_Rootkit;

	public int realvirusCounter_Rootkit;

	public int virusCounter_Keylogger;

	public int realvirusCounter_Keylogger;

	public int virusCounter_Adware;

	public int realvirusCounter_Adware;

	public int virusCounter_Ransomware;

	public int realvirusCounter_Ransomware;

	public int virusCounter_Worm;

	public int realvirusCounter_Worm;

	public int virusCounter_Trojan;

	public int realvirusCounter_Trojan;

	public int CountVirusDocumentsDetected;

	public int realCountVirusDocuments;

	public int CountVirusPrivacyDetected;

	public int realCountVirusPrivacy;

	private AppBase AppBase;

	private DirectoryManager directoryManager;

	private string AppNameFromApplicationBase;

	private bool isMenuOpen;

	private bool isCoroutineEnded;

	public bool isCheckHacker;

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public bool ValidateFiles()
	{
		return false;
	}

	public void MainViewUpdate()
	{
	}

	public void ResetView()
	{
	}

	public void ShowMenu()
	{
	}

	public void ShowLicenseActivationView()
	{
	}

	public void CloseLicenseActivationView()
	{
	}

	public void CloseMenu()
	{
	}

	public void EnterCode()
	{
	}

	[IteratorStateMachine(typeof(_003CMenuShowCoroutine_003Ed__73))]
	private IEnumerator MenuShowCoroutine(RectTransform obj, float fromX, float toX, float time)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CChangeAlphaCoroutine_003Ed__74))]
	private IEnumerator ChangeAlphaCoroutine(Image image, float fromAlpha, float toAlpha, float time)
	{
		return null;
	}

	private void SetNullCoroutine(Coroutine cor)
	{
	}

	[IteratorStateMachine(typeof(_003CEnterBadCode_003Ed__76))]
	private IEnumerator EnterBadCode()
	{
		return null;
	}

	public int VirusCounter()
	{
		return 0;
	}

	public int RealVirusCounter()
	{
		return 0;
	}

	public void VirtualToReal()
	{
	}

	public void OpenComputer()
	{
	}

	public void RemoveVirus()
	{
	}

	[IteratorStateMachine(typeof(_003CdeleteThisVirus_003Ed__82))]
	private IEnumerator deleteThisVirus()
	{
		return null;
	}

	public void ResetNotifyVCirsuComputer()
	{
	}

	public void CloseComputer()
	{
	}

	public void OpenWebAndMail()
	{
	}

	public void CloseWebAndMail()
	{
	}

	public bool CheckIfInfectedAddress(List<AppBrowserBrowsingHistory> browsingHistory)
	{
		return false;
	}

	public void OpenHackerAttack()
	{
	}

	public void CloseHackerAttack()
	{
	}
}
