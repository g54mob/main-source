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
		private IElementIdentifierTool GOSGgjBTkIKfqGIjqyAWihCRCbYu;

		public void Awake()
		{
			if (!yTyAhJipMNiZesgMFXvtiBRFJhjnA())
			{
				return;
			}
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
			}
			if (ReInput.UserData.ConfigVars.alwaysUseUnityInput || ReInput.usingUnityInput)
			{
				GOSGgjBTkIKfqGIjqyAWihCRCbYu = new kOgVqfOcjKNquuTyxQzAGtlWqeGB();
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
					GOSGgjBTkIKfqGIjqyAWihCRCbYu = new kOgVqfOcjKNquuTyxQzAGtlWqeGB();
				}
				if (GOSGgjBTkIKfqGIjqyAWihCRCbYu == null)
				{
					switch (platform)
					{
					case Platform.Windows:
						switch (ReInput.primaryInputManager.inputSourceType)
						{
						case InputSource.DirectInput:
							GOSGgjBTkIKfqGIjqyAWihCRCbYu = nxoVcwPrvygPTyngCHqYYYXbiBMC.ovmwMulSZuezCOKeiaNPElezORnM("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
							break;
						case InputSource.RawInput:
							GOSGgjBTkIKfqGIjqyAWihCRCbYu = nxoVcwPrvygPTyngCHqYYYXbiBMC.ovmwMulSZuezCOKeiaNPElezORnM("Rewired_Windows", "RawInput") as IElementIdentifierTool;
							break;
						}
						break;
					case Platform.WindowsAppStore:
						GOSGgjBTkIKfqGIjqyAWihCRCbYu = new kOgVqfOcjKNquuTyxQzAGtlWqeGB();
						break;
					case Platform.WindowsUWP:
						GOSGgjBTkIKfqGIjqyAWihCRCbYu = nxoVcwPrvygPTyngCHqYYYXbiBMC.ovmwMulSZuezCOKeiaNPElezORnM("", "WindowsUWP") as IElementIdentifierTool;
						break;
					case Platform.OSX:
						GOSGgjBTkIKfqGIjqyAWihCRCbYu = nxoVcwPrvygPTyngCHqYYYXbiBMC.ovmwMulSZuezCOKeiaNPElezORnM("Rewired_OSX", "OSX") as IElementIdentifierTool;
						break;
					case Platform.Linux:
						GOSGgjBTkIKfqGIjqyAWihCRCbYu = nxoVcwPrvygPTyngCHqYYYXbiBMC.ovmwMulSZuezCOKeiaNPElezORnM("Rewired_Linux", "Linux") as IElementIdentifierTool;
						break;
					case Platform.WebGL:
						GOSGgjBTkIKfqGIjqyAWihCRCbYu = nxoVcwPrvygPTyngCHqYYYXbiBMC.ovmwMulSZuezCOKeiaNPElezORnM("Rewired_WebGL", "WebGL") as IElementIdentifierTool;
						break;
					case Platform.GameCoreXboxOne:
					case Platform.GameCoreScarlett:
						GOSGgjBTkIKfqGIjqyAWihCRCbYu = nxoVcwPrvygPTyngCHqYYYXbiBMC.ovmwMulSZuezCOKeiaNPElezORnM("Rewired_GameCore", "GameCore") as IElementIdentifierTool;
						break;
					}
				}
			}
			if (GOSGgjBTkIKfqGIjqyAWihCRCbYu == null)
			{
				Logger.LogWarning("There was an error initializing the platform tool for the current platform and input source. Unity input will be shown instead.");
				GOSGgjBTkIKfqGIjqyAWihCRCbYu = new kOgVqfOcjKNquuTyxQzAGtlWqeGB();
			}
			GOSGgjBTkIKfqGIjqyAWihCRCbYu.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			if (GOSGgjBTkIKfqGIjqyAWihCRCbYu != null)
			{
				GOSGgjBTkIKfqGIjqyAWihCRCbYu.Start();
			}
		}

		public void Update()
		{
			if (GOSGgjBTkIKfqGIjqyAWihCRCbYu != null)
			{
				GOSGgjBTkIKfqGIjqyAWihCRCbYu.Update();
			}
		}

		public void OnDestroy()
		{
			if (GOSGgjBTkIKfqGIjqyAWihCRCbYu != null)
			{
				GOSGgjBTkIKfqGIjqyAWihCRCbYu.OnDestroy();
			}
			GOSGgjBTkIKfqGIjqyAWihCRCbYu = null;
		}

		private bool yTyAhJipMNiZesgMFXvtiBRFJhjnA()
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
