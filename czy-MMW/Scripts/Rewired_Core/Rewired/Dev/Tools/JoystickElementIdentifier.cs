using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Platforms;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[RequireComponent(typeof(GUIText))]
	[AddComponentMenu("")]
	public sealed class JoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool WRTjRMmpNPHvnRkGIosLQFhucJrK;

		public void Awake()
		{
			if (!iQroiiMBpAzTpdozvXvideOwqrEE())
			{
				return;
			}
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
			}
			if (ReInput.UserData.ConfigVars.alwaysUseUnityInput || ReInput.usingUnityInput)
			{
				WRTjRMmpNPHvnRkGIosLQFhucJrK = new upnVADhOXFcrhhTaNBqgauAtnjJdb();
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
					WRTjRMmpNPHvnRkGIosLQFhucJrK = new upnVADhOXFcrhhTaNBqgauAtnjJdb();
				}
				if (WRTjRMmpNPHvnRkGIosLQFhucJrK == null)
				{
					switch (platform)
					{
					case Platform.Windows:
						switch (ReInput.primaryInputManager.inputSourceType)
						{
						case InputSource.DirectInput:
							WRTjRMmpNPHvnRkGIosLQFhucJrK = tGxuGLgAElwKEviYukvVkrfWPpfu.slnRDsCqDpFFYHJqGxOjyNiSQQnB("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
							break;
						case InputSource.RawInput:
							WRTjRMmpNPHvnRkGIosLQFhucJrK = tGxuGLgAElwKEviYukvVkrfWPpfu.slnRDsCqDpFFYHJqGxOjyNiSQQnB("Rewired_Windows", "RawInput") as IElementIdentifierTool;
							break;
						}
						break;
					case Platform.WindowsAppStore:
						WRTjRMmpNPHvnRkGIosLQFhucJrK = new upnVADhOXFcrhhTaNBqgauAtnjJdb();
						break;
					case Platform.WindowsUWP:
						WRTjRMmpNPHvnRkGIosLQFhucJrK = tGxuGLgAElwKEviYukvVkrfWPpfu.slnRDsCqDpFFYHJqGxOjyNiSQQnB("", "WindowsUWP") as IElementIdentifierTool;
						break;
					case Platform.OSX:
						WRTjRMmpNPHvnRkGIosLQFhucJrK = tGxuGLgAElwKEviYukvVkrfWPpfu.slnRDsCqDpFFYHJqGxOjyNiSQQnB("Rewired_OSX", "OSX") as IElementIdentifierTool;
						break;
					case Platform.Linux:
						WRTjRMmpNPHvnRkGIosLQFhucJrK = tGxuGLgAElwKEviYukvVkrfWPpfu.slnRDsCqDpFFYHJqGxOjyNiSQQnB("Rewired_Linux", "Linux") as IElementIdentifierTool;
						break;
					case Platform.WebGL:
						WRTjRMmpNPHvnRkGIosLQFhucJrK = tGxuGLgAElwKEviYukvVkrfWPpfu.slnRDsCqDpFFYHJqGxOjyNiSQQnB("Rewired_WebGL", "WebGL") as IElementIdentifierTool;
						break;
					case Platform.Stadia:
						WRTjRMmpNPHvnRkGIosLQFhucJrK = tGxuGLgAElwKEviYukvVkrfWPpfu.slnRDsCqDpFFYHJqGxOjyNiSQQnB("Rewired_Stadia", "Stadia") as IElementIdentifierTool;
						break;
					case Platform.GameCoreXboxOne:
					case Platform.GameCoreScarlett:
						WRTjRMmpNPHvnRkGIosLQFhucJrK = tGxuGLgAElwKEviYukvVkrfWPpfu.slnRDsCqDpFFYHJqGxOjyNiSQQnB("Rewired_GameCore", "GameCore") as IElementIdentifierTool;
						break;
					}
				}
			}
			if (WRTjRMmpNPHvnRkGIosLQFhucJrK == null)
			{
				Logger.LogWarning("There was an error initializing the platform tool for the current platform and input source. Unity input will be shown instead.");
				WRTjRMmpNPHvnRkGIosLQFhucJrK = new upnVADhOXFcrhhTaNBqgauAtnjJdb();
			}
			WRTjRMmpNPHvnRkGIosLQFhucJrK.Initialize(GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			if (WRTjRMmpNPHvnRkGIosLQFhucJrK != null)
			{
				WRTjRMmpNPHvnRkGIosLQFhucJrK.Start();
			}
		}

		public void Update()
		{
			if (WRTjRMmpNPHvnRkGIosLQFhucJrK != null)
			{
				WRTjRMmpNPHvnRkGIosLQFhucJrK.Update();
			}
		}

		public void OnDestroy()
		{
			if (WRTjRMmpNPHvnRkGIosLQFhucJrK != null)
			{
				WRTjRMmpNPHvnRkGIosLQFhucJrK.OnDestroy();
			}
			WRTjRMmpNPHvnRkGIosLQFhucJrK = null;
		}

		private bool iQroiiMBpAzTpdozvXvideOwqrEE()
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
