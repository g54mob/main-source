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
		private IElementIdentifierTool ljOVHAbUhpcgmnejRcvuZgjrYVHt;

		public void Awake()
		{
			if (!xtOaTZjNcNEDSzHtXzyLfcbgMCzr())
			{
				return;
			}
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
			}
			if (ReInput.UserData.ConfigVars.alwaysUseUnityInput || ReInput.usingUnityInput)
			{
				ljOVHAbUhpcgmnejRcvuZgjrYVHt = new SZQINXtHteyLWtnGxgZphVQOpmrib();
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
					ljOVHAbUhpcgmnejRcvuZgjrYVHt = new SZQINXtHteyLWtnGxgZphVQOpmrib();
				}
				if (ljOVHAbUhpcgmnejRcvuZgjrYVHt == null)
				{
					switch (platform)
					{
					case Platform.Windows:
						switch (ReInput.primaryInputManager.inputSourceType)
						{
						case InputSource.DirectInput:
							ljOVHAbUhpcgmnejRcvuZgjrYVHt = HRAHJFkTwSqevhcmQwYIThdxMwDV.wCVjTDJJWEkhtTGccjlGVEyVXhmKA("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
							break;
						case InputSource.RawInput:
							ljOVHAbUhpcgmnejRcvuZgjrYVHt = HRAHJFkTwSqevhcmQwYIThdxMwDV.wCVjTDJJWEkhtTGccjlGVEyVXhmKA("Rewired_Windows", "RawInput") as IElementIdentifierTool;
							break;
						}
						break;
					case Platform.WindowsAppStore:
						ljOVHAbUhpcgmnejRcvuZgjrYVHt = new SZQINXtHteyLWtnGxgZphVQOpmrib();
						break;
					case Platform.WindowsUWP:
						ljOVHAbUhpcgmnejRcvuZgjrYVHt = HRAHJFkTwSqevhcmQwYIThdxMwDV.wCVjTDJJWEkhtTGccjlGVEyVXhmKA("", "WindowsUWP") as IElementIdentifierTool;
						break;
					case Platform.OSX:
						ljOVHAbUhpcgmnejRcvuZgjrYVHt = HRAHJFkTwSqevhcmQwYIThdxMwDV.wCVjTDJJWEkhtTGccjlGVEyVXhmKA("Rewired_OSX", "OSX") as IElementIdentifierTool;
						break;
					case Platform.Linux:
						ljOVHAbUhpcgmnejRcvuZgjrYVHt = HRAHJFkTwSqevhcmQwYIThdxMwDV.wCVjTDJJWEkhtTGccjlGVEyVXhmKA("Rewired_Linux", "Linux") as IElementIdentifierTool;
						break;
					case Platform.WebGL:
						ljOVHAbUhpcgmnejRcvuZgjrYVHt = HRAHJFkTwSqevhcmQwYIThdxMwDV.wCVjTDJJWEkhtTGccjlGVEyVXhmKA("Rewired_WebGL", "WebGL") as IElementIdentifierTool;
						break;
					case Platform.Stadia:
						ljOVHAbUhpcgmnejRcvuZgjrYVHt = HRAHJFkTwSqevhcmQwYIThdxMwDV.wCVjTDJJWEkhtTGccjlGVEyVXhmKA("Rewired_Stadia", "Stadia") as IElementIdentifierTool;
						break;
					case Platform.GameCoreXboxOne:
					case Platform.GameCoreScarlett:
						ljOVHAbUhpcgmnejRcvuZgjrYVHt = HRAHJFkTwSqevhcmQwYIThdxMwDV.wCVjTDJJWEkhtTGccjlGVEyVXhmKA("Rewired_GameCore", "GameCore") as IElementIdentifierTool;
						break;
					}
				}
			}
			if (ljOVHAbUhpcgmnejRcvuZgjrYVHt == null)
			{
				Logger.LogWarning("There was an error initializing the platform tool for the current platform and input source. Unity input will be shown instead.");
				ljOVHAbUhpcgmnejRcvuZgjrYVHt = new SZQINXtHteyLWtnGxgZphVQOpmrib();
			}
			ljOVHAbUhpcgmnejRcvuZgjrYVHt.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			if (ljOVHAbUhpcgmnejRcvuZgjrYVHt != null)
			{
				ljOVHAbUhpcgmnejRcvuZgjrYVHt.Start();
			}
		}

		public void Update()
		{
			if (ljOVHAbUhpcgmnejRcvuZgjrYVHt != null)
			{
				ljOVHAbUhpcgmnejRcvuZgjrYVHt.Update();
			}
		}

		public void OnDestroy()
		{
			if (ljOVHAbUhpcgmnejRcvuZgjrYVHt != null)
			{
				ljOVHAbUhpcgmnejRcvuZgjrYVHt.OnDestroy();
			}
			ljOVHAbUhpcgmnejRcvuZgjrYVHt = null;
		}

		private bool xtOaTZjNcNEDSzHtXzyLfcbgMCzr()
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
