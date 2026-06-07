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
		private IElementIdentifierTool nhujvekTWLfTVOztukLkjNhnRWD;

		public void Awake()
		{
			if (!tEqphnoHVvCOndCzqPfTWFzclCvm())
			{
				return;
			}
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
			}
			if (ReInput.UserData.ConfigVars.alwaysUseUnityInput || ReInput.usingUnityInput)
			{
				nhujvekTWLfTVOztukLkjNhnRWD = new GoulwhsaGIMkbOYWWKWtbgAYarv();
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
					nhujvekTWLfTVOztukLkjNhnRWD = new GoulwhsaGIMkbOYWWKWtbgAYarv();
					break;
				}
				if (nhujvekTWLfTVOztukLkjNhnRWD == null)
				{
					switch (platform)
					{
					case Platform.Windows:
						switch (ReInput.primaryInputManager.inputSourceType)
						{
						case InputSource.DirectInput:
							nhujvekTWLfTVOztukLkjNhnRWD = JCgnTfxtFodHUKJsjLoIpGzzqJB.cprtqzExsqyICxwoBkhIgqSHtca("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
							break;
						case InputSource.RawInput:
							nhujvekTWLfTVOztukLkjNhnRWD = JCgnTfxtFodHUKJsjLoIpGzzqJB.cprtqzExsqyICxwoBkhIgqSHtca("Rewired_Windows", "RawInput") as IElementIdentifierTool;
							break;
						}
						break;
					case Platform.WindowsAppStore:
						nhujvekTWLfTVOztukLkjNhnRWD = new GoulwhsaGIMkbOYWWKWtbgAYarv();
						break;
					case Platform.WindowsUWP:
						nhujvekTWLfTVOztukLkjNhnRWD = JCgnTfxtFodHUKJsjLoIpGzzqJB.cprtqzExsqyICxwoBkhIgqSHtca("", "WindowsUWP") as IElementIdentifierTool;
						break;
					case Platform.OSX:
						nhujvekTWLfTVOztukLkjNhnRWD = JCgnTfxtFodHUKJsjLoIpGzzqJB.cprtqzExsqyICxwoBkhIgqSHtca("Rewired_OSX", "OSX") as IElementIdentifierTool;
						break;
					case Platform.Linux:
						nhujvekTWLfTVOztukLkjNhnRWD = JCgnTfxtFodHUKJsjLoIpGzzqJB.cprtqzExsqyICxwoBkhIgqSHtca("Rewired_Linux", "Linux") as IElementIdentifierTool;
						break;
					case Platform.WebGL:
						nhujvekTWLfTVOztukLkjNhnRWD = JCgnTfxtFodHUKJsjLoIpGzzqJB.cprtqzExsqyICxwoBkhIgqSHtca("Rewired_WebGL", "WebGL") as IElementIdentifierTool;
						break;
					case Platform.Stadia:
						nhujvekTWLfTVOztukLkjNhnRWD = JCgnTfxtFodHUKJsjLoIpGzzqJB.cprtqzExsqyICxwoBkhIgqSHtca("Rewired_Stadia", "Stadia") as IElementIdentifierTool;
						break;
					case Platform.GameCoreXboxOne:
					case Platform.GameCoreScarlett:
						nhujvekTWLfTVOztukLkjNhnRWD = JCgnTfxtFodHUKJsjLoIpGzzqJB.cprtqzExsqyICxwoBkhIgqSHtca("Rewired_GameCore", "GameCore") as IElementIdentifierTool;
						break;
					}
				}
			}
			if (nhujvekTWLfTVOztukLkjNhnRWD == null)
			{
				Logger.LogWarning("There was an error initializing the platform tool for the current platform and input source. Unity input will be shown instead.");
				nhujvekTWLfTVOztukLkjNhnRWD = new GoulwhsaGIMkbOYWWKWtbgAYarv();
			}
			nhujvekTWLfTVOztukLkjNhnRWD.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			if (nhujvekTWLfTVOztukLkjNhnRWD != null)
			{
				nhujvekTWLfTVOztukLkjNhnRWD.Start();
			}
		}

		public void Update()
		{
			if (nhujvekTWLfTVOztukLkjNhnRWD != null)
			{
				nhujvekTWLfTVOztukLkjNhnRWD.Update();
			}
		}

		public void OnDestroy()
		{
			if (nhujvekTWLfTVOztukLkjNhnRWD != null)
			{
				nhujvekTWLfTVOztukLkjNhnRWD.OnDestroy();
			}
			nhujvekTWLfTVOztukLkjNhnRWD = null;
		}

		private bool tEqphnoHVvCOndCzqPfTWFzclCvm()
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
