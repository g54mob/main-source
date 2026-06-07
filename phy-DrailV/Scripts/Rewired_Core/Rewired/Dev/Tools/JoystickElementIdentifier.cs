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
		private IElementIdentifierTool YsGTIVFWVtOVYCvVsHJEYzEuABNO;

		public void Awake()
		{
			if (!MqWEGAfVINuauMCDaSCdKgUxLEpIA())
			{
				return;
			}
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
			}
			if (ReInput.UserData.ConfigVars.alwaysUseUnityInput || ReInput.usingUnityInput)
			{
				YsGTIVFWVtOVYCvVsHJEYzEuABNO = new ldCOHIVPwsuScSoDQlVVIxYZwLne();
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
					YsGTIVFWVtOVYCvVsHJEYzEuABNO = new ldCOHIVPwsuScSoDQlVVIxYZwLne();
				}
				if (YsGTIVFWVtOVYCvVsHJEYzEuABNO == null)
				{
					switch (platform)
					{
					case Platform.Windows:
						switch (ReInput.primaryInputManager.inputSourceType)
						{
						case InputSource.DirectInput:
							YsGTIVFWVtOVYCvVsHJEYzEuABNO = kiEAOtICCYZEVKAUfeKkKOUsmQTE.PgPcEEdakAFSXbfSNOFobDRMKzmBb("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
							break;
						case InputSource.RawInput:
							YsGTIVFWVtOVYCvVsHJEYzEuABNO = kiEAOtICCYZEVKAUfeKkKOUsmQTE.PgPcEEdakAFSXbfSNOFobDRMKzmBb("Rewired_Windows", "RawInput") as IElementIdentifierTool;
							break;
						}
						break;
					case Platform.WindowsAppStore:
						YsGTIVFWVtOVYCvVsHJEYzEuABNO = new ldCOHIVPwsuScSoDQlVVIxYZwLne();
						break;
					case Platform.WindowsUWP:
						YsGTIVFWVtOVYCvVsHJEYzEuABNO = kiEAOtICCYZEVKAUfeKkKOUsmQTE.PgPcEEdakAFSXbfSNOFobDRMKzmBb("", "WindowsUWP") as IElementIdentifierTool;
						break;
					case Platform.OSX:
						YsGTIVFWVtOVYCvVsHJEYzEuABNO = kiEAOtICCYZEVKAUfeKkKOUsmQTE.PgPcEEdakAFSXbfSNOFobDRMKzmBb("Rewired_OSX", "OSX") as IElementIdentifierTool;
						break;
					case Platform.Linux:
						YsGTIVFWVtOVYCvVsHJEYzEuABNO = kiEAOtICCYZEVKAUfeKkKOUsmQTE.PgPcEEdakAFSXbfSNOFobDRMKzmBb("Rewired_Linux", "Linux") as IElementIdentifierTool;
						break;
					case Platform.WebGL:
						YsGTIVFWVtOVYCvVsHJEYzEuABNO = kiEAOtICCYZEVKAUfeKkKOUsmQTE.PgPcEEdakAFSXbfSNOFobDRMKzmBb("Rewired_WebGL", "WebGL") as IElementIdentifierTool;
						break;
					case Platform.GameCoreXboxOne:
					case Platform.GameCoreScarlett:
						YsGTIVFWVtOVYCvVsHJEYzEuABNO = kiEAOtICCYZEVKAUfeKkKOUsmQTE.PgPcEEdakAFSXbfSNOFobDRMKzmBb("Rewired_GameCore", "GameCore") as IElementIdentifierTool;
						break;
					}
				}
			}
			if (YsGTIVFWVtOVYCvVsHJEYzEuABNO == null)
			{
				Logger.LogWarning("There was an error initializing the platform tool for the current platform and input source. Unity input will be shown instead.");
				YsGTIVFWVtOVYCvVsHJEYzEuABNO = new ldCOHIVPwsuScSoDQlVVIxYZwLne();
			}
			YsGTIVFWVtOVYCvVsHJEYzEuABNO.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			if (YsGTIVFWVtOVYCvVsHJEYzEuABNO != null)
			{
				YsGTIVFWVtOVYCvVsHJEYzEuABNO.Start();
			}
		}

		public void Update()
		{
			if (YsGTIVFWVtOVYCvVsHJEYzEuABNO != null)
			{
				YsGTIVFWVtOVYCvVsHJEYzEuABNO.Update();
			}
		}

		public void OnDestroy()
		{
			if (YsGTIVFWVtOVYCvVsHJEYzEuABNO != null)
			{
				YsGTIVFWVtOVYCvVsHJEYzEuABNO.OnDestroy();
			}
			YsGTIVFWVtOVYCvVsHJEYzEuABNO = null;
		}

		private bool MqWEGAfVINuauMCDaSCdKgUxLEpIA()
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
