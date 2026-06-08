using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	[AddComponentMenu("")]
	public sealed class DirectInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool NhVPPvZKOcTaxmGjUWBgRnEXHaeD;

		public void Awake()
		{
			if (!ZqilHQttJwFHjjkBpqPhtOBCZbv())
			{
				goto IL_0008;
			}
			goto IL_007b;
			IL_0008:
			int num = -666977600;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -666977599)
				{
				case 2:
					break;
				case 1:
					return;
				case 6:
					goto IL_0041;
				case 3:
					goto IL_0062;
				case 4:
					goto IL_007b;
				case 0:
					Logger.LogError("DirectInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
					return;
				default:
					NhVPPvZKOcTaxmGjUWBgRnEXHaeD.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
					return;
				}
				break;
				IL_0062:
				int num2;
				if (NhVPPvZKOcTaxmGjUWBgRnEXHaeD == null)
				{
					num = -666977599;
					num2 = num;
				}
				else
				{
					num = -666977596;
					num2 = num;
				}
			}
			goto IL_0008;
			IL_0041:
			NhVPPvZKOcTaxmGjUWBgRnEXHaeD = leHaHiGKLRfwikIkRPeWBAYNSTq.QOQRefpnFXxmNXwxWZUuCDtOWF("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
			num = -666977598;
			goto IL_000d;
			IL_007b:
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
				num = -666977593;
				goto IL_000d;
			}
			goto IL_0041;
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
				NhVPPvZKOcTaxmGjUWBgRnEXHaeD.OnDestroy();
			}
			NhVPPvZKOcTaxmGjUWBgRnEXHaeD = null;
		}

		private bool ZqilHQttJwFHjjkBpqPhtOBCZbv()
		{
			InputManager_Base[] array = (InputManager_Base[])Object.FindObjectsOfType(typeof(InputManager_Base));
			while (true)
			{
				int num = -729437014;
				while (true)
				{
					switch (num ^ -729437016)
					{
					case 0:
						break;
					case 2:
						if (array != null)
						{
							if (array.Length == 0)
							{
								num = -729437015;
								continue;
							}
							return true;
						}
						goto case 1;
					case 1:
						Logger.LogError("No active Rewired Input Manager was found in the scene! You must create a Rewired Input Manager for the tool to function.");
						num = -729437013;
						continue;
					default:
						return false;
					}
					break;
				}
			}
		}
	}
}
