using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	[AddComponentMenu("")]
	public sealed class RawInputJoystickElementIdentifier : MonoBehaviour
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
				IL_006c:
				int num;
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
					num = -152282555;
					goto IL_000e;
				}
				goto IL_004b;
				IL_000e:
				while (true)
				{
					switch (num ^ -152282557)
					{
					case 0:
						num = -152282554;
						continue;
					case 1:
						Logger.LogError("RawInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
						num = -152282553;
						continue;
					case 6:
						break;
					case 5:
						goto IL_006c;
					case 4:
						return;
					case 3:
						goto IL_00a8;
					default:
						JuXlVpBNvqGhNlCHbkodwVeYqoI.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
						return;
					}
					break;
					IL_00a8:
					int num2;
					if (JuXlVpBNvqGhNlCHbkodwVeYqoI == null)
					{
						num = -152282558;
						num2 = num;
					}
					else
					{
						num = -152282559;
						num2 = num;
					}
				}
				goto IL_004b;
				IL_004b:
				JuXlVpBNvqGhNlCHbkodwVeYqoI = bGFFlqWHmLhYQxaMwARBAauOhZKw.YRWDvqEvCTLNYmWCOoePtbzsTOva("Rewired_Windows", "RawInput") as IElementIdentifierTool;
				num = -152282560;
				goto IL_000e;
			}
		}

		public void Start()
		{
			if (JuXlVpBNvqGhNlCHbkodwVeYqoI == null)
			{
				return;
			}
			while (true)
			{
				int num = -1140028613;
				while (true)
				{
					switch (num ^ -1140028614)
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
					JuXlVpBNvqGhNlCHbkodwVeYqoI.Start();
					num = -1140028616;
				}
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
			}
			JuXlVpBNvqGhNlCHbkodwVeYqoI = null;
		}

		private bool HMatKMrWmoxUBeTjAemyCOnZtRF()
		{
			InputManager_Base[] array = (InputManager_Base[])Object.FindObjectsOfType(typeof(InputManager_Base));
			if (array != null)
			{
				while (true)
				{
					int num = 312076112;
					while (true)
					{
						switch (num ^ 0x1299E752)
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
							num = 312076115;
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
