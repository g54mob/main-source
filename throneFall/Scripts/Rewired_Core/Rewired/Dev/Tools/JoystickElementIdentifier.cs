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
		private IElementIdentifierTool pJyALYHrTSGqBmCSXlbOzzlSFyPIA;

		public void Awake()
		{
			if (!HfSGKuBrzXhOVgexkNCfUGeGCgyhA())
			{
				return;
			}
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
			}
			if (ReInput.UserData.ConfigVars.alwaysUseUnityInput || ReInput.usingUnityInput)
			{
				pJyALYHrTSGqBmCSXlbOzzlSFyPIA = new JyIBiZiVRImIXkZoMnljBdMNCzzDA();
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
					pJyALYHrTSGqBmCSXlbOzzlSFyPIA = new JyIBiZiVRImIXkZoMnljBdMNCzzDA();
				}
				if (pJyALYHrTSGqBmCSXlbOzzlSFyPIA == null)
				{
					switch (platform)
					{
					case Platform.Windows:
						switch (ReInput.primaryInputManager.inputSourceType)
						{
						case InputSource.DirectInput:
							pJyALYHrTSGqBmCSXlbOzzlSFyPIA = WPUsVLvIKoiluyoUtdcARrtcCvPs.PeYSlTVcygzshWVHVNsZTNNoUQgs("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
							break;
						case InputSource.RawInput:
							pJyALYHrTSGqBmCSXlbOzzlSFyPIA = WPUsVLvIKoiluyoUtdcARrtcCvPs.PeYSlTVcygzshWVHVNsZTNNoUQgs("Rewired_Windows", "RawInput") as IElementIdentifierTool;
							break;
						}
						break;
					case Platform.WindowsAppStore:
						pJyALYHrTSGqBmCSXlbOzzlSFyPIA = new JyIBiZiVRImIXkZoMnljBdMNCzzDA();
						break;
					case Platform.WindowsUWP:
						pJyALYHrTSGqBmCSXlbOzzlSFyPIA = WPUsVLvIKoiluyoUtdcARrtcCvPs.PeYSlTVcygzshWVHVNsZTNNoUQgs("", "WindowsUWP") as IElementIdentifierTool;
						break;
					case Platform.OSX:
						pJyALYHrTSGqBmCSXlbOzzlSFyPIA = WPUsVLvIKoiluyoUtdcARrtcCvPs.PeYSlTVcygzshWVHVNsZTNNoUQgs("Rewired_OSX", "OSX") as IElementIdentifierTool;
						break;
					case Platform.Linux:
						pJyALYHrTSGqBmCSXlbOzzlSFyPIA = WPUsVLvIKoiluyoUtdcARrtcCvPs.PeYSlTVcygzshWVHVNsZTNNoUQgs("Rewired_Linux", "Linux") as IElementIdentifierTool;
						break;
					case Platform.WebGL:
						pJyALYHrTSGqBmCSXlbOzzlSFyPIA = WPUsVLvIKoiluyoUtdcARrtcCvPs.PeYSlTVcygzshWVHVNsZTNNoUQgs("Rewired_WebGL", "WebGL") as IElementIdentifierTool;
						break;
					case Platform.GameCoreXboxOne:
					case Platform.GameCoreScarlett:
						pJyALYHrTSGqBmCSXlbOzzlSFyPIA = WPUsVLvIKoiluyoUtdcARrtcCvPs.PeYSlTVcygzshWVHVNsZTNNoUQgs("Rewired_GameCore", "GameCore") as IElementIdentifierTool;
						break;
					}
				}
			}
			if (pJyALYHrTSGqBmCSXlbOzzlSFyPIA == null)
			{
				Logger.LogWarning("There was an error initializing the platform tool for the current platform and input source. Unity input will be shown instead.");
				pJyALYHrTSGqBmCSXlbOzzlSFyPIA = new JyIBiZiVRImIXkZoMnljBdMNCzzDA();
			}
			pJyALYHrTSGqBmCSXlbOzzlSFyPIA.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
		}

		public void Start()
		{
			if (pJyALYHrTSGqBmCSXlbOzzlSFyPIA != null)
			{
				pJyALYHrTSGqBmCSXlbOzzlSFyPIA.Start();
			}
		}

		public void Update()
		{
			if (pJyALYHrTSGqBmCSXlbOzzlSFyPIA != null)
			{
				pJyALYHrTSGqBmCSXlbOzzlSFyPIA.Update();
			}
		}

		public void OnDestroy()
		{
			if (pJyALYHrTSGqBmCSXlbOzzlSFyPIA != null)
			{
				pJyALYHrTSGqBmCSXlbOzzlSFyPIA.OnDestroy();
			}
			pJyALYHrTSGqBmCSXlbOzzlSFyPIA = null;
		}

		private bool HfSGKuBrzXhOVgexkNCfUGeGCgyhA()
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
