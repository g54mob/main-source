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
		private IElementIdentifierTool wiTBqirJxgunqDtGTgkxTCeSabZG;

		public void Awake()
		{
			if (!seHgSrzWeMQeYHJURpUSvnuDwYl())
			{
				goto IL_000b;
			}
			goto IL_0131;
			IL_000b:
			int num = -1351872681;
			goto IL_0010;
			IL_0010:
			EditorPlatform editorPlatform = default(EditorPlatform);
			Platform platform = default(Platform);
			Platform platform2 = default(Platform);
			InputSource inputSourceType = default(InputSource);
			while (true)
			{
				switch (num ^ -1351872676)
				{
				case 23:
					break;
				case 7:
					wiTBqirJxgunqDtGTgkxTCeSabZG = IdRpivuosRElvZpXQUPVXhgAeUF.lPUTufBSEBrmzgsDsKmRQblmXBu("", "WindowsUWP") as IElementIdentifierTool;
					num = -1351872643;
					continue;
				case 17:
					num = -1351872643;
					continue;
				case 21:
					goto IL_00da;
				case 19:
					goto IL_00fe;
				case 1:
					editorPlatform = UnityTools.editorPlatform;
					num = -1351872702;
					continue;
				case 10:
					num = -1351872643;
					continue;
				case 20:
					goto IL_0131;
				case 18:
					goto IL_0165;
				case 15:
					wiTBqirJxgunqDtGTgkxTCeSabZG = new ZoBmmpfqvlKEIRhdhNYsNLNprUb();
					num = -1351872697;
					continue;
				case 6:
					num = -1351872643;
					continue;
				case 4:
					goto IL_019d;
				case 30:
					switch (editorPlatform)
					{
					case EditorPlatform.Windows:
						goto IL_0249;
					case EditorPlatform.OSX:
						goto IL_026a;
					case EditorPlatform.Linux:
						goto IL_0276;
					}
					num = -1351872699;
					continue;
				case 27:
					goto IL_01f4;
				case 5:
					wiTBqirJxgunqDtGTgkxTCeSabZG = IdRpivuosRElvZpXQUPVXhgAeUF.lPUTufBSEBrmzgsDsKmRQblmXBu("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
					num = -1351872643;
					continue;
				case 3:
					goto IL_0234;
				case 13:
					goto IL_0249;
				case 11:
					return;
				case 0:
					num = -1351872697;
					continue;
				case 14:
					goto IL_026a;
				case 24:
					goto IL_0276;
				case 9:
					goto IL_0282;
				case 29:
					platform = platform2;
					num = -1351872680;
					continue;
				case 33:
					goto IL_02b3;
				case 32:
					Logger.LogWarning("There was an error initializing the platform tool for the current platform and input source. Unity input will be shown instead.");
					wiTBqirJxgunqDtGTgkxTCeSabZG = new ZoBmmpfqvlKEIRhdhNYsNLNprUb();
					num = -1351872688;
					continue;
				case 2:
					goto IL_02ee;
				case 25:
					switch (ReInput.primaryInputManager.inputSourceType)
					{
					case InputSource.Fallback:
					case InputSource.Fallback_PreConfigured:
						break;
					case InputSource.RawInput:
						goto IL_01f4;
					default:
						goto IL_033c;
					}
					goto case 15;
				case 34:
					wiTBqirJxgunqDtGTgkxTCeSabZG = IdRpivuosRElvZpXQUPVXhgAeUF.lPUTufBSEBrmzgsDsKmRQblmXBu("Rewired_WebGL", "WebGL") as IElementIdentifierTool;
					num = -1351872643;
					continue;
				case 28:
					goto IL_036a;
				case 22:
					goto IL_038e;
				case 26:
					wiTBqirJxgunqDtGTgkxTCeSabZG = IdRpivuosRElvZpXQUPVXhgAeUF.lPUTufBSEBrmzgsDsKmRQblmXBu("Rewired_Windows", "RawInput") as IElementIdentifierTool;
					num = -1351872684;
					continue;
				case 8:
					num = -1351872643;
					continue;
				case 31:
					goto IL_03d1;
				case 16:
					num = -1351872699;
					continue;
				default:
					{
						wiTBqirJxgunqDtGTgkxTCeSabZG.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
						return;
					}
					IL_033c:
					num = -1351872676;
					continue;
					IL_0276:
					platform2 = Platform.Linux;
					num = -1351872699;
					continue;
					IL_026a:
					platform2 = Platform.OSX;
					num = -1351872692;
					continue;
					IL_0249:
					platform2 = Platform.Windows;
					num = -1351872699;
					continue;
				}
				break;
				IL_03d1:
				platform2 = UnityTools.platform;
				int num2;
				if (!UnityTools.isEditor)
				{
					num = -1351872699;
					num2 = num;
				}
				else
				{
					num = -1351872675;
					num2 = num;
				}
				continue;
				IL_0282:
				inputSourceType = ReInput.primaryInputManager.inputSourceType;
				int num3;
				if (inputSourceType != InputSource.DirectInput)
				{
					num = -1351872689;
					num3 = num;
				}
				else
				{
					num = -1351872679;
					num3 = num;
				}
				continue;
				IL_00fe:
				int num4;
				if (inputSourceType != InputSource.RawInput)
				{
					num = -1351872678;
					num4 = num;
				}
				else
				{
					num = -1351872698;
					num4 = num;
				}
				continue;
				IL_01f4:
				int num5;
				if (wiTBqirJxgunqDtGTgkxTCeSabZG == null)
				{
					num = -1351872703;
					num5 = num;
				}
				else
				{
					num = -1351872643;
					num5 = num;
				}
				continue;
				IL_00da:
				wiTBqirJxgunqDtGTgkxTCeSabZG = IdRpivuosRElvZpXQUPVXhgAeUF.lPUTufBSEBrmzgsDsKmRQblmXBu("Rewired_Linux", "Linux") as IElementIdentifierTool;
				num = -1351872643;
				continue;
				IL_01ca:
				num = -1351872642;
				int num6 = num;
				continue;
				IL_019d:
				switch (platform)
				{
				case Platform.Linux:
					break;
				default:
					goto IL_01c2;
				case Platform.WebGL:
					goto IL_01ca;
				case Platform.Windows:
					goto IL_0282;
				case Platform.WindowsPhone8:
				case Platform.iOS:
					goto IL_02b3;
				case Platform.OSX:
					goto IL_036a;
				case Platform.WindowsAppStore:
					goto IL_038e;
				}
				goto IL_00da;
				IL_038e:
				wiTBqirJxgunqDtGTgkxTCeSabZG = new ZoBmmpfqvlKEIRhdhNYsNLNprUb();
				num = -1351872643;
				continue;
				IL_036a:
				wiTBqirJxgunqDtGTgkxTCeSabZG = IdRpivuosRElvZpXQUPVXhgAeUF.lPUTufBSEBrmzgsDsKmRQblmXBu("Rewired_OSX", "OSX") as IElementIdentifierTool;
				num = -1351872691;
				continue;
				IL_02b3:
				int num7;
				if (wiTBqirJxgunqDtGTgkxTCeSabZG != null)
				{
					num = -1351872688;
					num7 = num;
				}
				else
				{
					num = -1351872644;
					num7 = num;
				}
				continue;
				IL_01c2:
				num = -1351872690;
				num6 = num;
				continue;
				IL_0165:
				int num8;
				if (platform == Platform.WindowsUWP)
				{
					num = -1351872677;
					num8 = num;
				}
				else
				{
					num = -1351872682;
					num8 = num;
				}
			}
			goto IL_000b;
			IL_02ee:
			if (!ReInput.UserData.ConfigVars.alwaysUseUnityInput)
			{
				int num9;
				if (ReInput.usingUnityInput)
				{
					num = -1351872673;
					num9 = num;
				}
				else
				{
					num = -1351872701;
					num9 = num;
				}
				goto IL_0010;
			}
			goto IL_0234;
			IL_0131:
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
				num = -1351872674;
				goto IL_0010;
			}
			goto IL_02ee;
			IL_0234:
			wiTBqirJxgunqDtGTgkxTCeSabZG = new ZoBmmpfqvlKEIRhdhNYsNLNprUb();
			num = -1351872643;
			goto IL_0010;
		}

		public void Start()
		{
			if (wiTBqirJxgunqDtGTgkxTCeSabZG == null)
			{
				return;
			}
			while (true)
			{
				int num = -136395401;
				while (true)
				{
					switch (num ^ -136395402)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0026;
					case 2:
						return;
					}
					break;
					IL_0026:
					wiTBqirJxgunqDtGTgkxTCeSabZG.Start();
					num = -136395404;
				}
			}
		}

		public void Update()
		{
			if (wiTBqirJxgunqDtGTgkxTCeSabZG == null)
			{
				return;
			}
			while (true)
			{
				int num = 2015321302;
				while (true)
				{
					switch (num ^ 0x781F5CD7)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0026;
					case 0:
						return;
					}
					break;
					IL_0026:
					wiTBqirJxgunqDtGTgkxTCeSabZG.Update();
					num = 2015321303;
				}
			}
		}

		public void OnDestroy()
		{
			if (wiTBqirJxgunqDtGTgkxTCeSabZG != null)
			{
				wiTBqirJxgunqDtGTgkxTCeSabZG.OnDestroy();
			}
			wiTBqirJxgunqDtGTgkxTCeSabZG = null;
		}

		private bool seHgSrzWeMQeYHJURpUSvnuDwYl()
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
