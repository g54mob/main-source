using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Level1 : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCanvasGroupFadeAnimation_003Ed__219 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float delay;

		public CanvasGroup canvasGroup;

		public float time;

		public TypeAnim animationType;

		public float targetAlpha;

		private float _003CstartAlpha_003E5__2;

		private float _003Celapsed_003E5__3;

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
		public _003CCanvasGroupFadeAnimation_003Ed__219(int _003C_003E1__state)
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
	private sealed class _003CDoneAnim_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tutorial_Level1 _003C_003E4__this;

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
		public _003CDoneAnim_003Ed__51(int _003C_003E1__state)
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
	private sealed class _003CStopTut_003Ed__49 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tutorial_Level1 _003C_003E4__this;

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
		public _003CStopTut_003Ed__49(int _003C_003E1__state)
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
	private sealed class _003CWaitForLoad_003Ed__46 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Tutorial_Level1 _003C_003E4__this;

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
		public _003CWaitForLoad_003Ed__46(int _003C_003E1__state)
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

	[Header("UI")]
	public CanvasGroup tutorialBG;

	public CanvasGroup tutorialTX;

	public RectTransform tutorialArea;

	public DropShadow tutorialDropShadown;

	[Header("Component")]
	public TutorialManager tutorialManager;

	public PlayerManager playerManager;

	public PauseGame pauseGame;

	public MiniMapHover miniMapHover;

	public MapConvertPositionToMap mapConvertPositionToMap;

	public MiniMapDeviceInfoMouseOn miniMapDeviceInfoMouseOn_locker;

	public DoorControllerPro doorControllerPro_locker;

	public InventoryManager inventoryManager;

	public ClothesCabinet clothesCabinet;

	public TabletDevice tabletDevice;

	public TabletAppSettings_Wifi tabletAppSettings_Wifi;

	public TabletDeviceWiFiAdapter tabletDeviceWiFiAdapter;

	public ComputerStation computerStation;

	public yourComputerInSmallCorp yourComputerInSmallCorp;

	public AppBrowser appBrowser;

	public FaskoManager appFaskoManager;

	public TabletAppAutentication tabletAppAutentication;

	public AppBrowserDownloader appBrowserDownloader;

	public appExplorer appExplorer;

	public AppErrorOpenUnsupportedApplication appErrorOpenUnsupportedApplication;

	public AppBase appBase;

	public ComputerDesktop computerDesktop;

	public AppPDFReader appPDFReader;

	public TaskRandom taskRandom;

	public AppMail appMail;

	public TaskManager taskManager;

	public Web_router Web_router;

	public ComputerInterferenceNetwork computerInterferenceNetwork;

	public ComputerPortsInterface computerPortsInterface;

	public PlayerInventory playerInventory;

	public ComputerFrontPort computerFrontPort;

	public NetworkRackPlayer networkRackPlayer;

	public MiniMapMovement miniMapMovement;

	[Header("Steps")]
	public int nowStep;

	public TutorialStepData[] tutorialStepData;

	private bool doneAnim;

	public bool updateTutorial;

	private bool isViewTutorial;

	public bool isCloseTutorial;

	public string lastText;

	private void OnValidate()
	{
	}

	private void Start()
	{
	}

	[IteratorStateMachine(typeof(_003CWaitForLoad_003Ed__46))]
	private IEnumerator WaitForLoad()
	{
		return null;
	}

	private void Update()
	{
	}

	public string PrefixTimeInfo()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CStopTut_003Ed__49))]
	private IEnumerator StopTut()
	{
		return null;
	}

	private string TextDown(string text, bool value)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CDoneAnim_003Ed__51))]
	private IEnumerator DoneAnim()
	{
		return null;
	}

	public void Step_Welcome1_Update()
	{
	}

	private void Step_Welcome1_InfoView()
	{
	}

	public void Step_Minimap_Update()
	{
	}

	private void Step_Minimap_InfoView()
	{
	}

	public void Step_MinimapViewDevice_Update()
	{
	}

	private void Step_MinimapViewDevice_InfoView()
	{
	}

	public void Step_MinimapGhostMode_Update()
	{
	}

	private void Step_MinimapGhostMode_InfoView()
	{
	}

	public void Step_MinimapFindLocker_Update()
	{
	}

	private void Step_MinimapFindLocker_InfoView()
	{
	}

	public void Step_GoToLocker_Update()
	{
	}

	private void Step_GoToLocker_InfoView()
	{
	}

	public void Step_OpenTheLocker_Update()
	{
	}

	private void Step_OpenTheLocker_InfoView()
	{
	}

	public void Step_LockerInfo_Update()
	{
	}

	private void Step_LockerInfo_InfoView()
	{
	}

	public void Step_CloseLocker_Update()
	{
	}

	private void Step_CloseLocker_InfoView()
	{
	}

	public void Step_GoToItRoom_Update()
	{
	}

	private void Step_GoToItRoom_InfoView()
	{
	}

	public void Step_ItRoomInfo_Update()
	{
	}

	private void Step_ItRoomInfo_InfoView()
	{
	}

	public void Step_OpenTablet_Update()
	{
	}

	private void Step_OpenTablet_InfoView()
	{
	}

	public void Step_TabletGoToWIFI_Update()
	{
	}

	private void Step_TabletGoToWIFI_InfoView()
	{
	}

	public void Step_TabletSelectWiFi_Update()
	{
	}

	private void Step_TabletSelectWiFi_InfoView()
	{
	}

	public void Step_TabletSelectEAP_Update()
	{
	}

	private void Step_TabletSelectEAP_InfoView()
	{
	}

	public void Step_TabletSelectAutch_Update()
	{
	}

	private void Step_TabletSelectAutch_InfoView()
	{
	}

	public void Step_TabletEnterUserAndPass_Update()
	{
	}

	private void Step_TabletEnterUserAndPass_InfoView()
	{
	}

	public void Step_TabletOpenAdvAndEnterPAC_Update()
	{
	}

	private void Step_TabletOpenAdvAndEnterPAC_InfoView()
	{
	}

	public void Step_TabletWiFiConnection_Update()
	{
	}

	private void Step_TabletWiFiConnection_InfoView()
	{
	}

	public void Step_TabletInfoCloseAnyApp_Update()
	{
	}

	private void Step_TabletInfoCloseAnyApp_InfoView()
	{
	}

	public void Step_GoToPC_Update()
	{
	}

	private void Step_GoToPC_InfoView()
	{
	}

	public void Step_PCInfoStation_Update()
	{
	}

	private void Step_PCInfoStation_InfoView()
	{
	}

	public void Step_LoginToPC_Update()
	{
	}

	private void Step_LoginToPC_InfoView()
	{
	}

	public void Step_PCRunWiki_Update()
	{
	}

	public bool IsLastOrSecondLastUrl(string targetUrl)
	{
		return false;
	}

	public bool IsLastUrl(string targetUrl)
	{
		return false;
	}

	private void Step_PCRunWiki_InfoView()
	{
	}

	public void Step_PCCloseBrowser_Update()
	{
	}

	private void Step_PCCloseBrowser_InfoView()
	{
	}

	public void Step_PCRunFasko_Update()
	{
	}

	private void Step_PCRunFasko_InfoView()
	{
	}

	public void Step_PCFaskoRunConnect_Update()
	{
	}

	private void Step_PCFaskoRunConnect_InfoView()
	{
	}

	public void Step_PCFaskoAuthInfo_Update()
	{
	}

	private void Step_PCFaskoAuthInfo_InfoView()
	{
	}

	public void Step_PCClosePC_Update()
	{
	}

	private void Step_PCClosePC_InfoView()
	{
	}

	public void Step_OpenTablet2_Update()
	{
	}

	private void Step_OpenTablet2_InfoView()
	{
	}

	public void Step_TabletRunAuthApp_Update()
	{
	}

	private void Step_TabletRunAuthApp_InfoView()
	{
	}

	public void Step_TabletAuthComfirm_Update()
	{
	}

	private void Step_TabletAuthComfirm_InfoView()
	{
	}

	public void Step_TabletNetInfo_Update()
	{
	}

	private void Step_TabletNetInfo_InfoView()
	{
	}

	public void Step_GoToPC2_Update()
	{
	}

	private void Step_GoToPC2_InfoView()
	{
	}

	public void Step_PCCloseAuthAndOpenWiki_Update()
	{
	}

	private void Step_PCCloseAuthAndOpenWiki_InfoView()
	{
	}

	public void Step_PCWikiGoToProcedures_Update()
	{
	}

	private void Step_PCWikiGoToProcedures_InfoView()
	{
	}

	public void Step_PCWikiDownloadAnyProcedures_Update()
	{
	}

	private void Step_PCWikiDownloadAnyProcedures_InfoView()
	{
	}

	public void Step_PCBrowserGoToDownload_Update()
	{
	}

	private void Step_PCBrowserGoToDownload_InfoView()
	{
	}

	public void Step_PCOpenUnsupportedFile_Update()
	{
	}

	private bool isOpenDownloadFile()
	{
		return false;
	}

	private void Step_PCOpenUnsupportedFile_InfoView()
	{
	}

	public void Step_PCOpenAppStorePDF_Update()
	{
	}

	public void Step_PCOpenAppStorePDF_Waiting()
	{
	}

	private void Step_PCOpenAppStorePDF_InfoView()
	{
	}

	public void Step_PCAppStoreInfo_Update()
	{
	}

	private void Step_PCAppStoreInfo_InfoView()
	{
	}

	public void Step_PCAppStoreInstallPDFReader_Update()
	{
	}

	private void Step_PCAppStoreInstallPDFReader_InfoView()
	{
	}

	public void Step_PCAppStoreCreateShortcutPDFReader_Update()
	{
	}

	private bool Step_PCAppStoreCreateShortcutPDFReader_Waiting()
	{
		return false;
	}

	private void Step_PCAppStoreCreateShortcutPDFReader_InfoView()
	{
	}

	public void Step_PCBrowserGoToDownloadAndOpenDownloadFile_Update()
	{
	}

	private bool Step_PCBrowserGoToDownloadAndOpenDownloadFile_Waiting()
	{
		return false;
	}

	private void Step_PCBrowserGoToDownloadAndOpenDownloadFile_InfoView()
	{
	}

	public void Step_PCForumHelpInfo_Update()
	{
	}

	private void Step_PCForumHelpInfo_InfoView()
	{
	}

	public void Step_PCOpenMailApp_Update()
	{
	}

	private void Step_PCOpenMailApp_InfoView()
	{
	}

	public void Step_PCOpenMailTask_Update()
	{
	}

	private void Step_PCOpenMailTask_InfoView()
	{
	}

	public void Step_PCMailTaskInfo_Update()
	{
	}

	private void Step_PCMailTaskInfo_InfoView()
	{
	}

	public void Step_PCMailTaskInfo2_Update()
	{
	}

	private void Step_PCMailTaskInfo2_InfoView()
	{
	}

	public void Step_PCMailTaskInfo3_Update()
	{
	}

	private void Step_PCMailTaskInfo3_InfoView()
	{
	}

	public void Step_PCMailTaskInfo4_Update()
	{
	}

	private void Step_PCMailTaskInfo4_InfoView()
	{
	}

	public void Step_PCMailTaskInfo5_Update()
	{
	}

	private void Step_PCMailTaskInfo5_InfoView()
	{
	}

	public void Step_TaskOpenWindow_Update()
	{
	}

	private void Step_TaskOpenWindow_InfoView()
	{
	}

	public void Step_TaskOpenTask_Update()
	{
	}

	private void Step_TaskOpenTask_InfoView()
	{
	}

	public void Step_TaskInfo1_Update()
	{
	}

	private void Step_TaskInfo1_InfoView()
	{
	}

	public void Step_TaskInfo_AdditionalImnfoWhenEasyOrMediu_Update()
	{
	}

	private void Step_TaskInfo_AdditionalImnfoWhenEasyOrMediu_InfoView()
	{
	}

	public void Step_TaskInfoToDoTask_Update()
	{
	}

	private bool Step_TaskInfoToDoTask_Wait()
	{
		return false;
	}

	private void Step_TaskInfoToDoTask_InfoView()
	{
	}

	public void Step_TaskInfo2_Update()
	{
	}

	private void Step_TaskInfo2_InfoView()
	{
	}

	public void Step_TaskInfo3_Update()
	{
	}

	private void Step_TaskInfo3_InfoView()
	{
	}

	public void Step_GoToPCAndOpenBrowser_Update()
	{
	}

	private void Step_GoToPCAndOpenBrowser_InfoView()
	{
	}

	public void Step_BrowserGoToRouter_Update()
	{
	}

	private void Step_BrowserGoToRouter_InfoView()
	{
	}

	public void Step_BrowserInfo1_Update()
	{
	}

	private void Step_BrowserInfo1_InfoView()
	{
	}

	public void Step_LoginToRouter_Update()
	{
	}

	private void Step_LoginToRouter_InfoView()
	{
	}

	public void Step_RouterInfo1_Update()
	{
	}

	private void Step_RouterInfo1_InfoView()
	{
	}

	public void Step_RouterInfo2_Update()
	{
	}

	private void Step_RouterInfo2_InfoView()
	{
	}

	public void Step_GoToSocketRJ_Update()
	{
	}

	private void Step_GoToSocketRJ_InfoView()
	{
	}

	public void Step_SocketRJInfo1_Update()
	{
	}

	private void Step_SocketRJInfo1_InfoView()
	{
	}

	public void Step_BackFromSocketRJ_Update()
	{
	}

	private void Step_BackFromSocketRJ_InfoView()
	{
	}

	public void Step_GoToPanelUSB_Update()
	{
	}

	private void Step_GoToPanelUSB_InfoView()
	{
	}

	public void Step_BackFromPanelUSB_Update()
	{
	}

	private void Step_BackFromPanelUSB_InfoView()
	{
	}

	public void Step_PickUpPendrive_Update()
	{
	}

	private bool Step_PickUpPendrive_Waiting()
	{
		return false;
	}

	private void Step_PickUpPendrive_InfoView()
	{
	}

	public void Step_BackFromPanelUSB2_Update()
	{
	}

	private void Step_BackFromPanelUSB2_InfoView()
	{
	}

	public void Step_ConnectPendriveToPC_Update()
	{
	}

	private bool Step_ConnectPendriveToPC_Waiting()
	{
		return false;
	}

	private void Step_ConnectPendriveToPC_InfoView()
	{
	}

	public void Step_PCGoToExplorer_Update()
	{
	}

	private void Step_PCGoToExplorer_InfoView()
	{
	}

	public void Step_PCExplorerInfo1_Update()
	{
	}

	private void Step_PCExplorerInfo1_InfoView()
	{
	}

	public void Step_PCExplorerInfo2_Update()
	{
	}

	private void Step_PCExplorerInfo2_InfoView()
	{
	}

	public void Step_Rack_Update()
	{
	}

	private void Step_Rack_InfoView()
	{
	}

	public void Step_RackItInfo1_Update()
	{
	}

	private void Step_RackItInfo1_InfoView()
	{
	}

	public void Step_End_Update()
	{
	}

	private void Step_End_InfoView()
	{
	}

	[IteratorStateMachine(typeof(_003CCanvasGroupFadeAnimation_003Ed__219))]
	public IEnumerator CanvasGroupFadeAnimation(CanvasGroup canvasGroup, float targetAlpha, float time, float delay, TypeAnim animationType)
	{
		return null;
	}
}
