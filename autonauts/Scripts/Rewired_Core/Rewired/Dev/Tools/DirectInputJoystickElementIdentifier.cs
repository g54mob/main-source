using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	[AddComponentMenu("")]
	public sealed class DirectInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool wiTBqirJxgunqDtGTgkxTCeSabZG;

		public void Awake()
		{
			if (!mMuyGHPdqwfCcQuqiAsctQhFUyA())
			{
				goto IL_0008;
			}
			goto IL_0071;
			IL_0008:
			int num = -698605596;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -698605600)
				{
				case 0:
					break;
				case 4:
					return;
				case 2:
					wiTBqirJxgunqDtGTgkxTCeSabZG = IdRpivuosRElvZpXQUPVXhgAeUF.lPUTufBSEBrmzgsDsKmRQblmXBu("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
					if (wiTBqirJxgunqDtGTgkxTCeSabZG == null)
					{
						Logger.LogError("DirectInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
						return;
					}
					goto default;
				case 3:
					goto IL_0071;
				case 1:
					base.transform.position = Vector3.zero;
					num = -698605598;
					continue;
				default:
					wiTBqirJxgunqDtGTgkxTCeSabZG.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0071:
			int num2;
			if (base.transform.position != Vector3.zero)
			{
				num = -698605599;
				num2 = num;
			}
			else
			{
				num = -698605598;
				num2 = num;
			}
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
				int num = -874959781;
				while (true)
				{
					switch (num ^ -874959782)
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
					wiTBqirJxgunqDtGTgkxTCeSabZG.Update();
					num = -874959784;
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

		private bool mMuyGHPdqwfCcQuqiAsctQhFUyA()
		{
			InputManager_Base[] array = (InputManager_Base[])Object.FindObjectsOfType(typeof(InputManager_Base));
			if (array != null)
			{
				if (array.Length != 0)
				{
					return true;
				}
				goto IL_001d;
			}
			goto IL_003b;
			IL_0022:
			int num;
			switch (num ^ 0x7A058FB6)
			{
			case 0:
				break;
			case 2:
				goto IL_003b;
			default:
				return false;
			}
			goto IL_001d;
			IL_003b:
			Logger.LogError("No active Rewired Input Manager was found in the scene! You must create a Rewired Input Manager for the tool to function.");
			num = 2047184823;
			goto IL_0022;
			IL_001d:
			num = 2047184820;
			goto IL_0022;
		}
	}
}
