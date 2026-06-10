using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ModIO;
using ModIO.Util;
using ModIOBrowser.Implementation;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser
{
	public class Browser : MonoSingleton<Browser>
	{
		public delegate void VirtualKeyboardDelegate(string title, string text, string placeholder, VirtualKeyboardType virtualKeyboardType, int characterLimit, bool multiline, Action<string> onClose);

		public delegate void RetrieveAuthenticationCodeDelegate(Action<string> callbackOnReceiveCode);

		public enum VirtualKeyboardType
		{
			Default = 0,
			Search = 1,
			EmailAddress = 2
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CIsInitialized_003Ed__43 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			private TaskAwaiter<Result> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[Tooltip("Setting this to false will stop the Browser from automatically initializing the plugin")]
		[Header("Settings")]
		[SerializeField]
		private bool autoInitialize;

		internal static bool allowEmailAuthentication;

		internal static bool allowExternalAuthentication;

		[SerializeField]
		public UiSettings uiConfig;

		[SerializeField]
		public Home homePanel;

		public SingletonAwakener SingletonAwakener;

		[Header("Main")]
		public ColorScheme colorScheme;

		public GameObject BrowserCanvas;

		public static GameObject currentFocusedPanel;

		[SerializeField]
		[Header("Default Selections")]
		private Selectable defaultCollectionSelection;

		internal static Action OnClose;

		public static VirtualKeyboardDelegate OpenVirtualKeyboard;

		private static bool openOnInitialize;

		public static bool IsOpen;

		public SearchFilter FeaturedSearchFilter { get; private set; }

		public SearchFilter[] BrowserRowSearchFilters { get; private set; }

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		public void CloseBrowserPanel()
		{
		}

		public static void Open(Action onClose)
		{
		}

		public static void Close()
		{
		}

		[Obsolete("Use EncodeEncryptedSteamAppTicket located in ModIO.Utility instead.")]
		public static string EncodeEncryptedSteamAppTicket(byte[] ticketData, uint ticketSize)
		{
			return null;
		}

		public static void SetupXboxAuthenticationOption(RetrieveAuthenticationCodeDelegate getXboxTokenDelegate, string userEmail = null)
		{
		}

		public static void SetupSwitchAuthenticationOption(RetrieveAuthenticationCodeDelegate getSwitchNsaIdDelegate, string userEmail = null)
		{
		}

		public static void SetupSteamAuthenticationOption(RetrieveAuthenticationCodeDelegate getSteamTicketDelegate, string userEmail = null)
		{
		}

		public static void SetupEpicAuthenticationOption(RetrieveAuthenticationCodeDelegate getEpicTicketDelegate, string userEmail = null)
		{
		}

		public static void SetupGOGAuthenticationOption(RetrieveAuthenticationCodeDelegate getGogTicketDelegate, string userEmail = null)
		{
		}

		public static void SetupPlayStationAuthenticationOption(RetrieveAuthenticationCodeDelegate getPlayStationAuthCodeDelegate, PlayStationEnvironment environment, string userEmail = null)
		{
		}

		public void SetFeaturedFilter(SearchFilter searchFilter)
		{
		}

		public void SetBrowserRowSearchFilters(SearchFilter[] searchFilters)
		{
		}

		private void SetModRowFilterDefaults()
		{
		}

		private static void OnInitialize(Result result)
		{
		}

		[AsyncStateMachine(typeof(_003CIsInitialized_003Ed__43))]
		private static void IsInitialized()
		{
		}

		public void OpenMenuProfile()
		{
		}

		[ExposeMethodInEditor]
		public void CheckForMissingReferencesInScene()
		{
		}
	}
}
