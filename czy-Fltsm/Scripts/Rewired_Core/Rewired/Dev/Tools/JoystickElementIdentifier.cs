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
		private IElementIdentifierTool CuYgwaDhWSSzIfjHzVPldnUmZaSiA;

		public void Awake()
		{
			if (!kUogvWPduHvDKPgsIzsEIIZkkmdn())
			{
				return;
			}
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
			}
			if (ReInput.UserData.ConfigVars.alwaysUseUnityInput || ReInput.usingUnityInput)
			{
				CuYgwaDhWSSzIfjHzVPldnUmZaSiA = new ooqJkpsBSWIDQBazgNVCPOfbzfkO();
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
					CuYgwaDhWSSzIfjHzVPldnUmZaSiA = new ooqJkpsBSWIDQBazgNVCPOfbzfkO();
				}
				if (CuYgwaDhWSSzIfjHzVPldnUmZaSiA == null)
				{
					switch (platform)
					{
					case Platform.Windows:
						switch (ReInput.primaryInputManager.inputSourceType)
						{
						case InputSource.DirectInput:
							CuYgwaDhWSSzIfjHzVPldnUmZaSiA = rCyaPdzoTeAsnETRLiAjpHCITzUaA.iqwKWpREpyQjgpFEdnCyLMcWdMxZ("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
							break;
						case InputSource.RawInput:
							CuYgwaDhWSSzIfjHzVPldnUmZaSiA = rCyaPdzoTeAsnETRLiAjpHCITzUaA.iqwKWpREpyQjgpFEdnCyLMcWdMxZ("Rewired_Windows", "RawInput") as IElementIdentifierTool;
							break;
						}
						break;
					case Platform.WindowsAppStore:
						CuYgwaDhWSSzIfjHzVPldnUmZaSiA = new ooqJkpsBSWIDQBazgNVCPOfbzfkO();
						break;
					case Platform.WindowsUWP:
						CuYgwaDhWSSzIfjHzVPldnUmZaSiA = rCyaPdzoTeAsnETRLiAjpHCITzUaA.iqwKWpREpyQjgpFEdnCyLMcWdMxZ("", "WindowsUWP") as IElementIdentifierTool;
						break;
					case Platform.OSX:
						CuYgwaDhWSSzIfjHzVPldnUmZaSiA = rCyaPdzoTeAsnETRLiAjpHCITzUaA.iqwKWpREpyQjgpFEdnCyLMcWdMxZ("Rewired_OSX", "OSX") as IElementIdentifierTool;
						break;
					case Platform.Linux:
						CuYgwaDhWSSzIfjHzVPldnUmZaSiA = rCyaPdzoTeAsnETRLiAjpHCITzUaA.iqwKWpREpyQjgpFEdnCyLMcWdMxZ("Rewired_Linux", "Linux") as IElementIdentifierTool;
						break;
					case Platform.WebGL:
						CuYgwaDhWSSzIfjHzVPldnUmZaSiA = rCyaPdzoTeAsnETRLiAjpHCITzUaA.iqwKWpREpyQjgpFEdnCyLMcWdMxZ("Rewired_WebGL", "WebGL") as IElementIdentifierTool;
						break;
					case Platform.GameCoreXboxOne:
					case Platform.GameCoreScarlett:
						CuYgwaDhWSSzIfjHzVPldnUmZaSiA = rCyaPdzoTeAsnETRLiAjpHCITzUaA.iqwKWpREpyQjgpFEdnCyLMcWdMxZ("Rewired_GameCore", "GameCore") as IElementIdentifierTool;
						break;
					}
				}
			}
			if (CuYgwaDhWSSzIfjHzVPldnUmZaSiA == null)
			{
				Logger.LogWarning("There was an error initializing the platform tool for the current platform and input source. Unity input will be shown instead.");
				CuYgwaDhWSSzIfjHzVPldnUmZaSiA = new ooqJkpsBSWIDQBazgNVCPOfbzfkO();
			}
			CuYgwaDhWSSzIfjHzVPldnUmZaSiA.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			if (CuYgwaDhWSSzIfjHzVPldnUmZaSiA != null)
			{
				CuYgwaDhWSSzIfjHzVPldnUmZaSiA.Start();
			}
		}

		public void Update()
		{
			if (CuYgwaDhWSSzIfjHzVPldnUmZaSiA != null)
			{
				CuYgwaDhWSSzIfjHzVPldnUmZaSiA.Update();
			}
		}

		public void OnDestroy()
		{
			if (CuYgwaDhWSSzIfjHzVPldnUmZaSiA != null)
			{
				CuYgwaDhWSSzIfjHzVPldnUmZaSiA.OnDestroy();
			}
			CuYgwaDhWSSzIfjHzVPldnUmZaSiA = null;
		}

		private bool kUogvWPduHvDKPgsIzsEIIZkkmdn()
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
