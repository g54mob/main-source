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
		private IElementIdentifierTool RobslxwZcCFTnNNIMcvrQNHFCgre;

		public void Awake()
		{
			if (!vMNvQZONzVpyrraupFLCxjAHECCI())
			{
				return;
			}
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
			}
			if (ReInput.UserData.ConfigVars.alwaysUseUnityInput || ReInput.usingUnityInput)
			{
				RobslxwZcCFTnNNIMcvrQNHFCgre = new dQFRRkpuRSelxbLxNdmOgUoImHJV();
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
					RobslxwZcCFTnNNIMcvrQNHFCgre = new dQFRRkpuRSelxbLxNdmOgUoImHJV();
				}
				if (RobslxwZcCFTnNNIMcvrQNHFCgre == null)
				{
					switch (platform)
					{
					case Platform.Windows:
						switch (ReInput.primaryInputManager.inputSourceType)
						{
						case InputSource.DirectInput:
							RobslxwZcCFTnNNIMcvrQNHFCgre = sBZPLewyWajIYnWNsnbxikBrIXfS.lsDdOaMmsgIBRJQAOlzukIhlpkCt("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
							break;
						case InputSource.RawInput:
							RobslxwZcCFTnNNIMcvrQNHFCgre = sBZPLewyWajIYnWNsnbxikBrIXfS.lsDdOaMmsgIBRJQAOlzukIhlpkCt("Rewired_Windows", "RawInput") as IElementIdentifierTool;
							break;
						}
						break;
					case Platform.WindowsAppStore:
						RobslxwZcCFTnNNIMcvrQNHFCgre = new dQFRRkpuRSelxbLxNdmOgUoImHJV();
						break;
					case Platform.WindowsUWP:
						RobslxwZcCFTnNNIMcvrQNHFCgre = sBZPLewyWajIYnWNsnbxikBrIXfS.lsDdOaMmsgIBRJQAOlzukIhlpkCt("", "WindowsUWP") as IElementIdentifierTool;
						break;
					case Platform.OSX:
						RobslxwZcCFTnNNIMcvrQNHFCgre = sBZPLewyWajIYnWNsnbxikBrIXfS.lsDdOaMmsgIBRJQAOlzukIhlpkCt("Rewired_OSX", "OSX") as IElementIdentifierTool;
						break;
					case Platform.Linux:
						RobslxwZcCFTnNNIMcvrQNHFCgre = sBZPLewyWajIYnWNsnbxikBrIXfS.lsDdOaMmsgIBRJQAOlzukIhlpkCt("Rewired_Linux", "Linux") as IElementIdentifierTool;
						break;
					case Platform.WebGL:
						RobslxwZcCFTnNNIMcvrQNHFCgre = sBZPLewyWajIYnWNsnbxikBrIXfS.lsDdOaMmsgIBRJQAOlzukIhlpkCt("Rewired_WebGL", "WebGL") as IElementIdentifierTool;
						break;
					case Platform.GameCoreXboxOne:
					case Platform.GameCoreScarlett:
						RobslxwZcCFTnNNIMcvrQNHFCgre = sBZPLewyWajIYnWNsnbxikBrIXfS.lsDdOaMmsgIBRJQAOlzukIhlpkCt("Rewired_GameCore", "GameCore") as IElementIdentifierTool;
						break;
					}
				}
			}
			if (RobslxwZcCFTnNNIMcvrQNHFCgre == null)
			{
				Logger.LogWarning("There was an error initializing the platform tool for the current platform and input source. Unity input will be shown instead.");
				RobslxwZcCFTnNNIMcvrQNHFCgre = new dQFRRkpuRSelxbLxNdmOgUoImHJV();
			}
			RobslxwZcCFTnNNIMcvrQNHFCgre.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			if (RobslxwZcCFTnNNIMcvrQNHFCgre != null)
			{
				RobslxwZcCFTnNNIMcvrQNHFCgre.Start();
			}
		}

		public void Update()
		{
			if (RobslxwZcCFTnNNIMcvrQNHFCgre != null)
			{
				RobslxwZcCFTnNNIMcvrQNHFCgre.Update();
			}
		}

		public void OnDestroy()
		{
			if (RobslxwZcCFTnNNIMcvrQNHFCgre != null)
			{
				RobslxwZcCFTnNNIMcvrQNHFCgre.OnDestroy();
			}
			RobslxwZcCFTnNNIMcvrQNHFCgre = null;
		}

		private bool vMNvQZONzVpyrraupFLCxjAHECCI()
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
