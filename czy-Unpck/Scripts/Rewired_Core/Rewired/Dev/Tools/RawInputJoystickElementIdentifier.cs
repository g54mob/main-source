using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class RawInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool NhVPPvZKOcTaxmGjUWBgRnEXHaeD;

		public void Awake()
		{
			if (!ZqilHQttJwFHjjkBpqPhtOBCZbv())
			{
				return;
			}
			while (true)
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
					int num = -1614136833;
					while (true)
					{
						switch (num ^ -1614136835)
						{
						case 0:
							num = -1614136836;
							continue;
						case 1:
							break;
						case 2:
							goto IL_0059;
						default:
							goto end_IL_002b;
						}
						break;
					}
					continue;
				}
				goto IL_0059;
				IL_0059:
				NhVPPvZKOcTaxmGjUWBgRnEXHaeD = leHaHiGKLRfwikIkRPeWBAYNSTq.QOQRefpnFXxmNXwxWZUuCDtOWF("Rewired_Windows", "RawInput") as IElementIdentifierTool;
				if (NhVPPvZKOcTaxmGjUWBgRnEXHaeD != null)
				{
					break;
				}
				Logger.LogError("RawInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				return;
				continue;
				end_IL_002b:
				break;
			}
			NhVPPvZKOcTaxmGjUWBgRnEXHaeD.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
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
				goto IL_0013;
			}
			goto IL_0031;
			IL_0031:
			NhVPPvZKOcTaxmGjUWBgRnEXHaeD = null;
			int num = -177081355;
			goto IL_0018;
			IL_0013:
			num = -177081356;
			goto IL_0018;
			IL_0018:
			switch (num ^ -177081355)
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

		private bool ZqilHQttJwFHjjkBpqPhtOBCZbv()
		{
			InputManager_Base[] array = (InputManager_Base[])Object.FindObjectsOfType(typeof(InputManager_Base));
			while (true)
			{
				int num = 74547495;
				while (true)
				{
					switch (num ^ 0x4718124)
					{
					case 2:
						break;
					case 3:
						if (array != null)
						{
							if (array.Length == 0)
							{
								num = 74547492;
								continue;
							}
							return true;
						}
						goto case 0;
					case 0:
						Logger.LogError("No active Rewired Input Manager was found in the scene! You must create a Rewired Input Manager for the tool to function.");
						num = 74547493;
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
