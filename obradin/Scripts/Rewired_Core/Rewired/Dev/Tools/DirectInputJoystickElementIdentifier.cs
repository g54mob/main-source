using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	[AddComponentMenu("")]
	public sealed class DirectInputJoystickElementIdentifier : MonoBehaviour
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
				IL_0074:
				int num;
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
					num = 1166160001;
					goto IL_000e;
				}
				goto IL_0041;
				IL_000e:
				while (true)
				{
					switch (num ^ 0x45823081)
					{
					case 2:
						num = 1166160000;
						continue;
					case 3:
						Logger.LogError("DirectInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
						return;
					case 0:
						break;
					case 1:
						goto IL_0074;
					default:
						JuXlVpBNvqGhNlCHbkodwVeYqoI.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
						return;
					}
					break;
				}
				goto IL_0041;
				IL_0041:
				JuXlVpBNvqGhNlCHbkodwVeYqoI = bGFFlqWHmLhYQxaMwARBAauOhZKw.YRWDvqEvCTLNYmWCOoePtbzsTOva("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
				int num2;
				if (JuXlVpBNvqGhNlCHbkodwVeYqoI == null)
				{
					num = 1166160002;
					num2 = num;
				}
				else
				{
					num = 1166160005;
					num2 = num;
				}
				goto IL_000e;
			}
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
			if (JuXlVpBNvqGhNlCHbkodwVeYqoI == null)
			{
				return;
			}
			while (true)
			{
				int num = 883586381;
				while (true)
				{
					switch (num ^ 0x34AA754C)
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
					JuXlVpBNvqGhNlCHbkodwVeYqoI.Update();
					num = 883586382;
				}
			}
		}

		public void OnDestroy()
		{
			if (JuXlVpBNvqGhNlCHbkodwVeYqoI != null)
			{
				while (true)
				{
					int num = 852436874;
					while (true)
					{
						switch (num ^ 0x32CF278B)
						{
						case 0:
							break;
						case 1:
							JuXlVpBNvqGhNlCHbkodwVeYqoI.OnDestroy();
							num = 852436873;
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

		private bool HMatKMrWmoxUBeTjAemyCOnZtRF()
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
