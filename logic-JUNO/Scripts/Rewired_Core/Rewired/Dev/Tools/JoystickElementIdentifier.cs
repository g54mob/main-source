using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class JoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool KvScErlWBticwJJiiVYmqVzsEBCb;

		public void Awake()
		{
			if (!enwdjsHjimfMclDkPWmhFCOtBYgaA())
			{
				return;
			}
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
			}
			if (ReInput.UserData.ConfigVars.alwaysUseUnityInput || ReInput.usingUnityInput)
			{
				KvScErlWBticwJJiiVYmqVzsEBCb = new qIuhPDwAAnDIailbndXlSAseAPrlA();
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
				InputSource inputSourceType = ReInput.primaryInputManager.inputSourceType;
				if (inputSourceType == InputSource.Fallback || inputSourceType == InputSource.Fallback_PreConfigured)
				{
					KvScErlWBticwJJiiVYmqVzsEBCb = new qIuhPDwAAnDIailbndXlSAseAPrlA();
				}
				if (KvScErlWBticwJJiiVYmqVzsEBCb == null)
				{
					switch (platform)
					{
					case Platform.Windows:
						switch (ReInput.primaryInputManager.inputSourceType)
						{
						case InputSource.DirectInput:
							KvScErlWBticwJJiiVYmqVzsEBCb = xkwDVLzkLVknJzRRMIYEQzJNeNRn.eiyQrZHnjZoSGXdYeIeHSZjRyQoF("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
							break;
						case InputSource.RawInput:
							KvScErlWBticwJJiiVYmqVzsEBCb = xkwDVLzkLVknJzRRMIYEQzJNeNRn.eiyQrZHnjZoSGXdYeIeHSZjRyQoF("Rewired_Windows", "RawInput") as IElementIdentifierTool;
							break;
						}
						break;
					case Platform.WindowsAppStore:
						KvScErlWBticwJJiiVYmqVzsEBCb = new qIuhPDwAAnDIailbndXlSAseAPrlA();
						break;
					case Platform.WindowsUWP:
						KvScErlWBticwJJiiVYmqVzsEBCb = xkwDVLzkLVknJzRRMIYEQzJNeNRn.eiyQrZHnjZoSGXdYeIeHSZjRyQoF("", "WindowsUWP") as IElementIdentifierTool;
						break;
					case Platform.OSX:
						KvScErlWBticwJJiiVYmqVzsEBCb = xkwDVLzkLVknJzRRMIYEQzJNeNRn.eiyQrZHnjZoSGXdYeIeHSZjRyQoF("Rewired_OSX", "OSX") as IElementIdentifierTool;
						break;
					case Platform.Linux:
						KvScErlWBticwJJiiVYmqVzsEBCb = xkwDVLzkLVknJzRRMIYEQzJNeNRn.eiyQrZHnjZoSGXdYeIeHSZjRyQoF("Rewired_Linux", "Linux") as IElementIdentifierTool;
						break;
					case Platform.WebGL:
						KvScErlWBticwJJiiVYmqVzsEBCb = xkwDVLzkLVknJzRRMIYEQzJNeNRn.eiyQrZHnjZoSGXdYeIeHSZjRyQoF("Rewired_WebGL", "WebGL") as IElementIdentifierTool;
						break;
					case Platform.Stadia:
						KvScErlWBticwJJiiVYmqVzsEBCb = xkwDVLzkLVknJzRRMIYEQzJNeNRn.eiyQrZHnjZoSGXdYeIeHSZjRyQoF("Rewired_Stadia", "Stadia") as IElementIdentifierTool;
						break;
					case Platform.GameCoreXboxOne:
					case Platform.GameCoreScarlett:
						KvScErlWBticwJJiiVYmqVzsEBCb = xkwDVLzkLVknJzRRMIYEQzJNeNRn.eiyQrZHnjZoSGXdYeIeHSZjRyQoF("Rewired_GameCore", "GameCore") as IElementIdentifierTool;
						break;
					}
				}
			}
			if (KvScErlWBticwJJiiVYmqVzsEBCb == null)
			{
				Logger.LogWarning("There was an error initializing the platform tool for the current platform and input source. Unity input will be shown instead.");
				KvScErlWBticwJJiiVYmqVzsEBCb = new qIuhPDwAAnDIailbndXlSAseAPrlA();
			}
			KvScErlWBticwJJiiVYmqVzsEBCb.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			if (KvScErlWBticwJJiiVYmqVzsEBCb != null)
			{
				KvScErlWBticwJJiiVYmqVzsEBCb.Start();
			}
		}

		public void Update()
		{
			if (KvScErlWBticwJJiiVYmqVzsEBCb != null)
			{
				KvScErlWBticwJJiiVYmqVzsEBCb.Update();
			}
		}

		public void OnDestroy()
		{
			if (KvScErlWBticwJJiiVYmqVzsEBCb != null)
			{
				KvScErlWBticwJJiiVYmqVzsEBCb.OnDestroy();
			}
			KvScErlWBticwJJiiVYmqVzsEBCb = null;
		}

		private bool enwdjsHjimfMclDkPWmhFCOtBYgaA()
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
