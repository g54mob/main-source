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
		private IElementIdentifierTool NhVPPvZKOcTaxmGjUWBgRnEXHaeD;

		public void Awake()
		{
			if (!RdJHHuRBJKPZRcGtQfEZnvQMGvQ())
			{
				return;
			}
			Platform platform2 = default(Platform);
			Platform platform = default(Platform);
			while (true)
			{
				int num;
				int num2;
				if (base.transform.position != Vector3.zero)
				{
					num = -48734131;
					num2 = num;
				}
				else
				{
					num = -48734086;
					num2 = num;
				}
				while (true)
				{
					InputSource inputSourceType;
					int num6;
					int num7;
					switch (num ^ -48734099)
					{
					case 2:
						num = -48734105;
						continue;
					case 10:
						break;
					case 0:
						switch (ReInput.primaryInputManager.inputSourceType)
						{
						case InputSource.Fallback:
						case InputSource.Fallback_PreConfigured:
							goto IL_0291;
						case InputSource.RawInput:
							goto IL_0415;
						}
						num = -48734085;
						continue;
					case 30:
						NhVPPvZKOcTaxmGjUWBgRnEXHaeD = leHaHiGKLRfwikIkRPeWBAYNSTq.QOQRefpnFXxmNXwxWZUuCDtOWF("", "WindowsUWP") as IElementIdentifierTool;
						num = -48734132;
						continue;
					case 29:
						NhVPPvZKOcTaxmGjUWBgRnEXHaeD = leHaHiGKLRfwikIkRPeWBAYNSTq.QOQRefpnFXxmNXwxWZUuCDtOWF("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
						num = -48734108;
						continue;
					case 13:
						platform2 = platform;
						if (platform2 <= Platform.WebGL)
						{
							switch (platform2)
							{
							case Platform.OSX:
								goto IL_01cc;
							case Platform.WindowsPhone8:
							case Platform.iOS:
								goto IL_0239;
							case Platform.Windows:
								goto IL_0307;
							case Platform.WebGL:
								goto IL_037a;
							case Platform.Linux:
								goto IL_03b8;
							case Platform.WindowsAppStore:
								goto IL_0400;
							}
							num = -48734108;
							continue;
						}
						goto case 19;
					case 20:
						Logger.LogWarning("There was an error initializing the platform tool for the current platform and input source. Unity input will be shown instead.");
						num = -48734091;
						continue;
					case 4:
						platform = Platform.Windows;
						num = -48734099;
						continue;
					case 8:
					{
						int num5;
						if (!UnityTools.isEditor)
						{
							num = -48734099;
							num5 = num;
						}
						else
						{
							num = -48734090;
							num5 = num;
						}
						continue;
					}
					case 14:
						platform = UnityTools.platform;
						num = -48734107;
						continue;
					case 26:
						goto IL_01cc;
					case 33:
						num = -48734108;
						continue;
					case 15:
					{
						int num4;
						if (ReInput.usingUnityInput)
						{
							num = -48734084;
							num4 = num;
						}
						else
						{
							num = -48734109;
							num4 = num;
						}
						continue;
					}
					case 27:
						switch (UnityTools.editorPlatform)
						{
						case EditorPlatform.Windows:
							break;
						default:
							goto IL_022f;
						case EditorPlatform.OSX:
							goto IL_0255;
						case EditorPlatform.Linux:
							goto IL_0285;
						}
						goto case 4;
					case 9:
						goto IL_0239;
					case 28:
						goto IL_0255;
					case 12:
						NhVPPvZKOcTaxmGjUWBgRnEXHaeD = leHaHiGKLRfwikIkRPeWBAYNSTq.QOQRefpnFXxmNXwxWZUuCDtOWF("Rewired_Windows", "RawInput") as IElementIdentifierTool;
						num = -48734108;
						continue;
					case 25:
						goto IL_0285;
					case 31:
						goto IL_0291;
					case 17:
						NhVPPvZKOcTaxmGjUWBgRnEXHaeD = new spBBieTDEjAXVoJIoAvlDgncYNW();
						num = -48734108;
						continue;
					case 23:
					{
						int num3;
						if (ReInput.UserData.ConfigVars.alwaysUseUnityInput)
						{
							num = -48734084;
							num3 = num;
						}
						else
						{
							num = -48734110;
							num3 = num;
						}
						continue;
					}
					case 19:
						switch (platform2)
						{
						case Platform.WindowsUWP:
							break;
						default:
							goto IL_02fd;
						case Platform.GameCoreXboxOne:
						case Platform.GameCoreScarlett:
							goto IL_0341;
						case Platform.Stadia:
							goto IL_03dc;
						}
						goto case 30;
					case 1:
						goto IL_0307;
					case 5:
						num = -48734099;
						continue;
					case 7:
						num = -48734108;
						continue;
					case 3:
						goto IL_0341;
					case 24:
						NhVPPvZKOcTaxmGjUWBgRnEXHaeD = new spBBieTDEjAXVoJIoAvlDgncYNW();
						num = -48734101;
						continue;
					case 18:
						goto IL_037a;
					case 32:
						base.transform.position = Vector3.zero;
						num = -48734086;
						continue;
					case 21:
						goto IL_03b8;
					case 11:
						goto IL_03dc;
					case 16:
						goto IL_0400;
					case 22:
						goto IL_0415;
					default:
						{
							NhVPPvZKOcTaxmGjUWBgRnEXHaeD.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
							return;
						}
						IL_01cc:
						NhVPPvZKOcTaxmGjUWBgRnEXHaeD = leHaHiGKLRfwikIkRPeWBAYNSTq.QOQRefpnFXxmNXwxWZUuCDtOWF("Rewired_OSX", "OSX") as IElementIdentifierTool;
						num = -48734108;
						continue;
						IL_0285:
						platform = Platform.Linux;
						num = -48734099;
						continue;
						IL_0255:
						platform = Platform.OSX;
						num = -48734104;
						continue;
						IL_022f:
						num = -48734099;
						continue;
						IL_03dc:
						NhVPPvZKOcTaxmGjUWBgRnEXHaeD = leHaHiGKLRfwikIkRPeWBAYNSTq.QOQRefpnFXxmNXwxWZUuCDtOWF("Rewired_Stadia", "Stadia") as IElementIdentifierTool;
						num = -48734108;
						continue;
						IL_0341:
						NhVPPvZKOcTaxmGjUWBgRnEXHaeD = leHaHiGKLRfwikIkRPeWBAYNSTq.QOQRefpnFXxmNXwxWZUuCDtOWF("Rewired_GameCore", "GameCore") as IElementIdentifierTool;
						num = -48734108;
						continue;
						IL_02fd:
						num = -48734108;
						continue;
						IL_0400:
						NhVPPvZKOcTaxmGjUWBgRnEXHaeD = new spBBieTDEjAXVoJIoAvlDgncYNW();
						num = -48734102;
						continue;
						IL_03b8:
						NhVPPvZKOcTaxmGjUWBgRnEXHaeD = leHaHiGKLRfwikIkRPeWBAYNSTq.QOQRefpnFXxmNXwxWZUuCDtOWF("Rewired_Linux", "Linux") as IElementIdentifierTool;
						num = -48734108;
						continue;
						IL_037a:
						NhVPPvZKOcTaxmGjUWBgRnEXHaeD = leHaHiGKLRfwikIkRPeWBAYNSTq.QOQRefpnFXxmNXwxWZUuCDtOWF("Rewired_WebGL", "WebGL") as IElementIdentifierTool;
						num = -48734108;
						continue;
						IL_0307:
						inputSourceType = ReInput.primaryInputManager.inputSourceType;
						if (inputSourceType == InputSource.DirectInput)
						{
							goto case 29;
						}
						if (inputSourceType != InputSource.RawInput)
						{
							num = -48734108;
							continue;
						}
						goto case 12;
						IL_0415:
						if (NhVPPvZKOcTaxmGjUWBgRnEXHaeD == null)
						{
							num = -48734112;
							num6 = num;
						}
						else
						{
							num = -48734108;
							num6 = num;
						}
						continue;
						IL_0239:
						if (NhVPPvZKOcTaxmGjUWBgRnEXHaeD == null)
						{
							num = -48734087;
							num7 = num;
						}
						else
						{
							num = -48734101;
							num7 = num;
						}
						continue;
						IL_0291:
						NhVPPvZKOcTaxmGjUWBgRnEXHaeD = new spBBieTDEjAXVoJIoAvlDgncYNW();
						num = -48734085;
						continue;
					}
					break;
				}
			}
		}

		public void Start()
		{
			if (NhVPPvZKOcTaxmGjUWBgRnEXHaeD != null)
			{
				NhVPPvZKOcTaxmGjUWBgRnEXHaeD.Start();
			}
		}

		public void Update()
		{
			if (NhVPPvZKOcTaxmGjUWBgRnEXHaeD != null)
			{
				NhVPPvZKOcTaxmGjUWBgRnEXHaeD.Update();
			}
		}

		public void OnDestroy()
		{
			if (NhVPPvZKOcTaxmGjUWBgRnEXHaeD != null)
			{
				goto IL_0008;
			}
			goto IL_003c;
			IL_0008:
			int num = -1548333494;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -1548333496)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					NhVPPvZKOcTaxmGjUWBgRnEXHaeD.OnDestroy();
					num = -1548333495;
					continue;
				case 1:
					goto IL_003c;
				case 3:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_003c:
			NhVPPvZKOcTaxmGjUWBgRnEXHaeD = null;
			num = -1548333493;
			goto IL_000d;
		}

		private bool RdJHHuRBJKPZRcGtQfEZnvQMGvQ()
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
