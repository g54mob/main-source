using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class OSXJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool wiTBqirJxgunqDtGTgkxTCeSabZG;

		public void Awake()
		{
			if (!mMuyGHPdqwfCcQuqiAsctQhFUyA())
			{
				return;
			}
			while (true)
			{
				int num;
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
					num = -686247285;
					goto IL_000e;
				}
				goto IL_0061;
				IL_000e:
				while (true)
				{
					switch (num ^ -686247286)
					{
					case 0:
						num = -686247287;
						continue;
					case 3:
						break;
					case 1:
						goto IL_0061;
					case 5:
						return;
					case 4:
						if (wiTBqirJxgunqDtGTgkxTCeSabZG == null)
						{
							Logger.LogError("OSX Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
							num = -686247281;
							continue;
						}
						goto default;
					default:
						wiTBqirJxgunqDtGTgkxTCeSabZG.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
						return;
					}
					break;
				}
				continue;
				IL_0061:
				wiTBqirJxgunqDtGTgkxTCeSabZG = IdRpivuosRElvZpXQUPVXhgAeUF.lPUTufBSEBrmzgsDsKmRQblmXBu("Rewired_OSX", "OSX") as IElementIdentifierTool;
				num = -686247282;
				goto IL_000e;
			}
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
			if (wiTBqirJxgunqDtGTgkxTCeSabZG != null)
			{
				wiTBqirJxgunqDtGTgkxTCeSabZG.Update();
			}
		}

		public void OnDestroy()
		{
			if (wiTBqirJxgunqDtGTgkxTCeSabZG != null)
			{
				goto IL_0008;
			}
			goto IL_003c;
			IL_0008:
			int num = 1558032672;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x5CDDB122)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					wiTBqirJxgunqDtGTgkxTCeSabZG.OnDestroy();
					num = 1558032675;
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
			wiTBqirJxgunqDtGTgkxTCeSabZG = null;
			num = 1558032673;
			goto IL_000d;
		}

		private bool mMuyGHPdqwfCcQuqiAsctQhFUyA()
		{
			InputManager_Base[] array = (InputManager_Base[])Object.FindObjectsOfType(typeof(InputManager_Base));
			if (array == null || array.Length == 0)
			{
				Logger.LogError("No active Rewired Input Manager was found in the scene! You must create a Rewired Input Manager for the tool to function.");
				return false;
			}
			return true;
		}
	}
}
