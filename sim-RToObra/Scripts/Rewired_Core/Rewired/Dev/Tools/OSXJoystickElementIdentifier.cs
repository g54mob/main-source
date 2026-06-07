using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	[AddComponentMenu("")]
	public sealed class OSXJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool JuXlVpBNvqGhNlCHbkodwVeYqoI;

		public void Awake()
		{
			if (!HMatKMrWmoxUBeTjAemyCOnZtRF())
			{
				return;
			}
			while (true)
			{
				int num;
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
					num = 1565086058;
					goto IL_000e;
				}
				goto IL_005d;
				IL_000e:
				while (true)
				{
					switch (num ^ 0x5D49516B)
					{
					case 3:
						num = 1565086057;
						continue;
					case 2:
						break;
					case 1:
						goto IL_005d;
					case 4:
						return;
					default:
						goto end_IL_002f;
					}
					break;
				}
				continue;
				IL_005d:
				JuXlVpBNvqGhNlCHbkodwVeYqoI = bGFFlqWHmLhYQxaMwARBAauOhZKw.YRWDvqEvCTLNYmWCOoePtbzsTOva("Rewired_OSX", "OSX") as IElementIdentifierTool;
				if (JuXlVpBNvqGhNlCHbkodwVeYqoI != null)
				{
					break;
				}
				Logger.LogError("OSX Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				num = 1565086063;
				goto IL_000e;
				continue;
				end_IL_002f:
				break;
			}
			JuXlVpBNvqGhNlCHbkodwVeYqoI.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
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
				JuXlVpBNvqGhNlCHbkodwVeYqoI.OnDestroy();
				goto IL_0013;
			}
			goto IL_0031;
			IL_0031:
			JuXlVpBNvqGhNlCHbkodwVeYqoI = null;
			int num = -1498113154;
			goto IL_0018;
			IL_0013:
			num = -1498113153;
			goto IL_0018;
			IL_0018:
			switch (num ^ -1498113154)
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

		private bool HMatKMrWmoxUBeTjAemyCOnZtRF()
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
			switch (num ^ 0x71CD97DF)
			{
			case 0:
				break;
			case 1:
				goto IL_003b;
			default:
				return false;
			}
			goto IL_001d;
			IL_003b:
			Logger.LogError("No active Rewired Input Manager was found in the scene! You must create a Rewired Input Manager for the tool to function.");
			num = 1909299165;
			goto IL_0022;
			IL_001d:
			num = 1909299166;
			goto IL_0022;
		}
	}
}
