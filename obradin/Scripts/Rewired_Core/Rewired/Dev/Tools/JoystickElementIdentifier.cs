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
		private IElementIdentifierTool JuXlVpBNvqGhNlCHbkodwVeYqoI;

		public void Awake()
		{
			if (!PDTvOkRCwEBjztxXxftWOQkVBjw())
			{
				goto IL_000b;
			}
			goto IL_0109;
			IL_000b:
			int num = 475280192;
			goto IL_0010;
			IL_0010:
			Platform platform = default(Platform);
			EditorPlatform editorPlatform = default(EditorPlatform);
			Platform platform2 = default(Platform);
			while (true)
			{
				switch (num ^ 0x1C543356)
				{
				case 6:
					break;
				case 16:
					JuXlVpBNvqGhNlCHbkodwVeYqoI = bGFFlqWHmLhYQxaMwARBAauOhZKw.YRWDvqEvCTLNYmWCOoePtbzsTOva("", "WindowsUWP") as IElementIdentifierTool;
					num = 475280193;
					continue;
				case 19:
					goto IL_00c0;
				case 10:
					goto IL_00e5;
				case 0:
					goto IL_0109;
				case 5:
					goto IL_0134;
				case 21:
					goto IL_0155;
				case 17:
					goto IL_0179;
				case 23:
					goto IL_019d;
				case 30:
					goto IL_01c7;
				case 25:
					platform = Platform.OSX;
					num = 475280204;
					continue;
				case 28:
					JuXlVpBNvqGhNlCHbkodwVeYqoI = new kpDhpqDOpflhbpqcXmUaqQLlTBq();
					num = 475280193;
					continue;
				case 29:
					num = 475280193;
					continue;
				case 11:
					goto IL_0207;
				case 22:
					return;
				case 26:
					switch (ReInput.primaryInputManager.inputSourceType)
					{
					case InputSource.RawInput:
						goto IL_027c;
					case InputSource.Fallback:
					case InputSource.Fallback_PreConfigured:
						goto IL_0386;
					}
					num = 475280215;
					continue;
				case 3:
					goto IL_0261;
				case 1:
					goto IL_027c;
				case 7:
					switch (editorPlatform)
					{
					case EditorPlatform.OSX:
						break;
					default:
						goto IL_02a7;
					case EditorPlatform.Windows:
						goto IL_02b1;
					case EditorPlatform.Linux:
						goto IL_037a;
					}
					goto case 25;
				case 24:
					goto IL_02b1;
				case 27:
					goto IL_02bd;
				case 9:
					num = 475280193;
					continue;
				case 2:
					goto IL_02eb;
				case 13:
					editorPlatform = UnityTools.editorPlatform;
					num = 475280209;
					continue;
				case 18:
					base.transform.position = Vector3.zero;
					num = 475280197;
					continue;
				case 4:
					goto IL_0356;
				case 8:
					goto IL_037a;
				case 12:
					goto IL_0386;
				case 14:
					num = 475280193;
					continue;
				case 20:
					num = 475280193;
					continue;
				default:
					goto IL_03af;
					IL_037a:
					platform = Platform.Linux;
					num = 475280204;
					continue;
					IL_02b1:
					platform = Platform.Windows;
					num = 475280204;
					continue;
					IL_02a7:
					num = 475280204;
					continue;
					IL_0386:
					JuXlVpBNvqGhNlCHbkodwVeYqoI = new kpDhpqDOpflhbpqcXmUaqQLlTBq();
					num = 475280215;
					continue;
					IL_027c:
					if (JuXlVpBNvqGhNlCHbkodwVeYqoI == null)
					{
						platform2 = platform;
						num = 475280212;
						continue;
					}
					goto IL_019d;
				}
				break;
				IL_02eb:
				switch (platform2)
				{
				case Platform.Linux:
					break;
				case Platform.WebGL:
					goto IL_0179;
				case Platform.WindowsPhone8:
				case Platform.iOS:
					goto IL_019d;
				case Platform.WindowsAppStore:
					goto IL_01c7;
				case Platform.Windows:
					goto IL_0207;
				default:
					goto IL_0318;
				case Platform.WindowsUWP:
					goto IL_0320;
				case Platform.OSX:
					goto IL_0356;
				}
				goto IL_0155;
				IL_0356:
				JuXlVpBNvqGhNlCHbkodwVeYqoI = bGFFlqWHmLhYQxaMwARBAauOhZKw.YRWDvqEvCTLNYmWCOoePtbzsTOva("Rewired_OSX", "OSX") as IElementIdentifierTool;
				num = 475280193;
				continue;
				IL_0320:
				num = 475280198;
				int num2 = num;
				continue;
				IL_0318:
				num = 475280194;
				num2 = num;
				continue;
				IL_0261:
				int num3;
				if (ReInput.usingUnityInput)
				{
					num = 475280202;
					num3 = num;
				}
				else
				{
					num = 475280211;
					num3 = num;
				}
				continue;
				IL_0179:
				JuXlVpBNvqGhNlCHbkodwVeYqoI = bGFFlqWHmLhYQxaMwARBAauOhZKw.YRWDvqEvCTLNYmWCOoePtbzsTOva("Rewired_WebGL", "WebGL") as IElementIdentifierTool;
				num = 475280193;
				continue;
				IL_0155:
				JuXlVpBNvqGhNlCHbkodwVeYqoI = bGFFlqWHmLhYQxaMwARBAauOhZKw.YRWDvqEvCTLNYmWCOoePtbzsTOva("Rewired_Linux", "Linux") as IElementIdentifierTool;
				num = 475280203;
				continue;
				IL_0207:
				InputSource inputSourceType = ReInput.primaryInputManager.inputSourceType;
				if (inputSourceType != InputSource.DirectInput)
				{
					if (inputSourceType != InputSource.RawInput)
					{
						num = 475280193;
						continue;
					}
					goto IL_00e5;
				}
				goto IL_02bd;
				IL_0134:
				platform = UnityTools.platform;
				int num4;
				if (!UnityTools.isEditor)
				{
					num = 475280204;
					num4 = num;
				}
				else
				{
					num = 475280219;
					num4 = num;
				}
				continue;
				IL_00e5:
				JuXlVpBNvqGhNlCHbkodwVeYqoI = bGFFlqWHmLhYQxaMwARBAauOhZKw.YRWDvqEvCTLNYmWCOoePtbzsTOva("Rewired_Windows", "RawInput") as IElementIdentifierTool;
				num = 475280223;
				continue;
				IL_02bd:
				JuXlVpBNvqGhNlCHbkodwVeYqoI = bGFFlqWHmLhYQxaMwARBAauOhZKw.YRWDvqEvCTLNYmWCOoePtbzsTOva("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
				num = 475280216;
				continue;
				IL_01c7:
				JuXlVpBNvqGhNlCHbkodwVeYqoI = new kpDhpqDOpflhbpqcXmUaqQLlTBq();
				num = 475280193;
				continue;
				IL_019d:
				if (JuXlVpBNvqGhNlCHbkodwVeYqoI == null)
				{
					Logger.LogWarning("There was an error initializing the platform tool for the current platform and input source. Unity input will be shown instead.");
					JuXlVpBNvqGhNlCHbkodwVeYqoI = new kpDhpqDOpflhbpqcXmUaqQLlTBq();
					num = 475280217;
					continue;
				}
				goto IL_03af;
				IL_00c0:
				int num5;
				if (!ReInput.UserData.ConfigVars.alwaysUseUnityInput)
				{
					num = 475280213;
					num5 = num;
				}
				else
				{
					num = 475280202;
					num5 = num;
				}
				continue;
				IL_03af:
				JuXlVpBNvqGhNlCHbkodwVeYqoI.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				return;
			}
			goto IL_000b;
			IL_0109:
			int num6;
			if (base.transform.position != Vector3.zero)
			{
				num = 475280196;
				num6 = num;
			}
			else
			{
				num = 475280197;
				num6 = num;
			}
			goto IL_0010;
		}

		public void Start()
		{
			if (JuXlVpBNvqGhNlCHbkodwVeYqoI != null)
			{
				JuXlVpBNvqGhNlCHbkodwVeYqoI.Start();
			}
		}

		public void Update()
		{
			if (JuXlVpBNvqGhNlCHbkodwVeYqoI != null)
			{
				JuXlVpBNvqGhNlCHbkodwVeYqoI.Update();
			}
		}

		public void OnDestroy()
		{
			if (JuXlVpBNvqGhNlCHbkodwVeYqoI != null)
			{
				while (true)
				{
					int num = -847129673;
					while (true)
					{
						switch (num ^ -847129675)
						{
						case 0:
							break;
						case 2:
							JuXlVpBNvqGhNlCHbkodwVeYqoI.OnDestroy();
							num = -847129676;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			JuXlVpBNvqGhNlCHbkodwVeYqoI = null;
		}

		private bool PDTvOkRCwEBjztxXxftWOQkVBjw()
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
