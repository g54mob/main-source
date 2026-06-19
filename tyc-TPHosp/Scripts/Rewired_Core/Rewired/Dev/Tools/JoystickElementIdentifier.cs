using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	[AddComponentMenu("")]
	public sealed class JoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool NuSUCGZLzYJQRRtHbKwdvZMVsDb;

		public void Awake()
		{
			if (!PKKDMThTkiBdpZTPzcnUnTCYFQLr())
			{
				return;
			}
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
			}
			if (ReInput.UserData.ConfigVars.alwaysUseUnityInput || ReInput.usingUnityInput)
			{
				NuSUCGZLzYJQRRtHbKwdvZMVsDb = new mQlGRRnbLWhhTtcJnIqlEtsWmB();
			}
			else
			{
				Platform platform = UnityTools.platform;
				if (UnityTools.isEditor)
				{
					switch (UnityTools.editorPlatform)
					{
					case EditorPlatform.Windows:
						platform = Platform.Windows;
						break;
					case EditorPlatform.OSX:
						platform = Platform.OSX;
						break;
					case EditorPlatform.Linux:
						platform = Platform.Linux;
						break;
					}
				}
				switch (ReInput.primaryInputManager.inputSourceType)
				{
				case InputSource.Fallback:
				case InputSource.Fallback_PreConfigured:
					NuSUCGZLzYJQRRtHbKwdvZMVsDb = new mQlGRRnbLWhhTtcJnIqlEtsWmB();
					break;
				}
				if (NuSUCGZLzYJQRRtHbKwdvZMVsDb == null)
				{
					switch (platform)
					{
					case Platform.Windows:
						switch (ReInput.primaryInputManager.inputSourceType)
						{
						case InputSource.DirectInput:
							NuSUCGZLzYJQRRtHbKwdvZMVsDb = fGSYDPYatdKEeBAFoRjBvWMFmqp.CmFGRHtcYveRYoRMGDqJodZrdxQ("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
							break;
						case InputSource.RawInput:
							NuSUCGZLzYJQRRtHbKwdvZMVsDb = fGSYDPYatdKEeBAFoRjBvWMFmqp.CmFGRHtcYveRYoRMGDqJodZrdxQ("Rewired_Windows", "RawInput") as IElementIdentifierTool;
							break;
						}
						break;
					case Platform.WindowsAppStore:
						NuSUCGZLzYJQRRtHbKwdvZMVsDb = new mQlGRRnbLWhhTtcJnIqlEtsWmB();
						break;
					case Platform.WindowsUWP:
						NuSUCGZLzYJQRRtHbKwdvZMVsDb = fGSYDPYatdKEeBAFoRjBvWMFmqp.CmFGRHtcYveRYoRMGDqJodZrdxQ("", "WindowsUWP") as IElementIdentifierTool;
						break;
					case Platform.OSX:
						NuSUCGZLzYJQRRtHbKwdvZMVsDb = fGSYDPYatdKEeBAFoRjBvWMFmqp.CmFGRHtcYveRYoRMGDqJodZrdxQ("Rewired_OSX", "OSX") as IElementIdentifierTool;
						break;
					case Platform.Linux:
						NuSUCGZLzYJQRRtHbKwdvZMVsDb = fGSYDPYatdKEeBAFoRjBvWMFmqp.CmFGRHtcYveRYoRMGDqJodZrdxQ("Rewired_Linux", "Linux") as IElementIdentifierTool;
						break;
					case Platform.WebGL:
						NuSUCGZLzYJQRRtHbKwdvZMVsDb = fGSYDPYatdKEeBAFoRjBvWMFmqp.CmFGRHtcYveRYoRMGDqJodZrdxQ("Rewired_WebGL", "WebGL") as IElementIdentifierTool;
						break;
					case Platform.Stadia:
						NuSUCGZLzYJQRRtHbKwdvZMVsDb = fGSYDPYatdKEeBAFoRjBvWMFmqp.CmFGRHtcYveRYoRMGDqJodZrdxQ("Rewired_Stadia", "Stadia") as IElementIdentifierTool;
						break;
					case Platform.GameCoreXboxOne:
					case Platform.GameCoreScarlett:
						NuSUCGZLzYJQRRtHbKwdvZMVsDb = fGSYDPYatdKEeBAFoRjBvWMFmqp.CmFGRHtcYveRYoRMGDqJodZrdxQ("Rewired_GameCore", "GameCore") as IElementIdentifierTool;
						break;
					}
				}
			}
			if (NuSUCGZLzYJQRRtHbKwdvZMVsDb == null)
			{
				Logger.LogWarning("There was an error initializing the platform tool for the current platform and input source. Unity input will be shown instead.");
				NuSUCGZLzYJQRRtHbKwdvZMVsDb = new mQlGRRnbLWhhTtcJnIqlEtsWmB();
			}
			NuSUCGZLzYJQRRtHbKwdvZMVsDb.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			if (NuSUCGZLzYJQRRtHbKwdvZMVsDb != null)
			{
				NuSUCGZLzYJQRRtHbKwdvZMVsDb.Start();
			}
		}

		public void Update()
		{
			if (NuSUCGZLzYJQRRtHbKwdvZMVsDb != null)
			{
				NuSUCGZLzYJQRRtHbKwdvZMVsDb.Update();
			}
		}

		public void OnDestroy()
		{
			if (NuSUCGZLzYJQRRtHbKwdvZMVsDb != null)
			{
				NuSUCGZLzYJQRRtHbKwdvZMVsDb.OnDestroy();
			}
			NuSUCGZLzYJQRRtHbKwdvZMVsDb = null;
		}

		private bool PKKDMThTkiBdpZTPzcnUnTCYFQLr()
		{
			if (!ReInput.isReady)
			{
				Logger.LogError("No active Rewired Input Manager was found in the scene! You must create a Rewired Input Manager for the tool to function.");
				return false;
			}
			return true;
		}
	}
}
