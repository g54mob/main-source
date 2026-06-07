using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class RawInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool wiTBqirJxgunqDtGTgkxTCeSabZG;

		public void Awake()
		{
			if (!mMuyGHPdqwfCcQuqiAsctQhFUyA())
			{
				goto IL_0008;
			}
			goto IL_006c;
			IL_0008:
			int num = 1800724146;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x6B54DEB1)
			{
			case 5:
				break;
			default:
				return;
			case 4:
				goto IL_0039;
			case 6:
				goto IL_006c;
			case 3:
				return;
			case 2:
				goto IL_00a8;
			case 1:
				return;
			case 0:
				return;
			}
			goto IL_0008;
			IL_006c:
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
				num = 1800724149;
				goto IL_000d;
			}
			goto IL_0039;
			IL_0039:
			wiTBqirJxgunqDtGTgkxTCeSabZG = IdRpivuosRElvZpXQUPVXhgAeUF.lPUTufBSEBrmzgsDsKmRQblmXBu("Rewired_Windows", "RawInput") as IElementIdentifierTool;
			if (wiTBqirJxgunqDtGTgkxTCeSabZG == null)
			{
				Logger.LogError("RawInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				num = 1800724144;
				goto IL_000d;
			}
			goto IL_00a8;
			IL_00a8:
			wiTBqirJxgunqDtGTgkxTCeSabZG.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
			num = 1800724145;
			goto IL_000d;
		}

		public void Start()
		{
			if (wiTBqirJxgunqDtGTgkxTCeSabZG != null)
			{
				wiTBqirJxgunqDtGTgkxTCeSabZG.Start();
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
				int num = 151483635;
				while (true)
				{
					switch (num ^ 0x90774F2)
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
					num = 151483634;
				}
			}
		}

		public void OnDestroy()
		{
			if (wiTBqirJxgunqDtGTgkxTCeSabZG != null)
			{
				wiTBqirJxgunqDtGTgkxTCeSabZG.OnDestroy();
				goto IL_0013;
			}
			goto IL_0031;
			IL_0031:
			wiTBqirJxgunqDtGTgkxTCeSabZG = null;
			int num = -657055471;
			goto IL_0018;
			IL_0013:
			num = -657055472;
			goto IL_0018;
			IL_0018:
			switch (num ^ -657055471)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				goto IL_0031;
			case 0:
				return;
			}
			goto IL_0013;
		}

		private bool mMuyGHPdqwfCcQuqiAsctQhFUyA()
		{
			InputManager_Base[] array = (InputManager_Base[])Object.FindObjectsOfType(typeof(InputManager_Base));
			if (array != null)
			{
				while (true)
				{
					int num = 1520573390;
					while (true)
					{
						switch (num ^ 0x5AA21BCC)
						{
						case 0:
							break;
						case 2:
							goto IL_0036;
						default:
							goto end_IL_0018;
						}
						break;
						IL_0036:
						if (array.Length == 0)
						{
							num = 1520573389;
							continue;
						}
						return true;
					}
					continue;
					end_IL_0018:
					break;
				}
			}
			Logger.LogError("No active Rewired Input Manager was found in the scene! You must create a Rewired Input Manager for the tool to function.");
			return false;
		}
	}
}
