using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	[AddComponentMenu("")]
	public sealed class OSXJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool NhVPPvZKOcTaxmGjUWBgRnEXHaeD;

		public void Awake()
		{
			if (!ZqilHQttJwFHjjkBpqPhtOBCZbv())
			{
				goto IL_0008;
			}
			goto IL_007f;
			IL_0008:
			int num = -1750620281;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -1750620283)
				{
				case 4:
					break;
				default:
					return;
				case 2:
					return;
				case 3:
					NhVPPvZKOcTaxmGjUWBgRnEXHaeD.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
					num = -1750620285;
					continue;
				case 1:
					goto IL_005e;
				case 5:
					goto IL_007f;
				case 0:
					if (NhVPPvZKOcTaxmGjUWBgRnEXHaeD == null)
					{
						Logger.LogError("OSX Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
						return;
					}
					goto case 3;
				case 6:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_007f:
			if (base.transform.position != Vector3.zero)
			{
				base.transform.position = Vector3.zero;
				num = -1750620284;
				goto IL_000d;
			}
			goto IL_005e;
			IL_005e:
			NhVPPvZKOcTaxmGjUWBgRnEXHaeD = leHaHiGKLRfwikIkRPeWBAYNSTq.QOQRefpnFXxmNXwxWZUuCDtOWF("Rewired_OSX", "OSX") as IElementIdentifierTool;
			num = -1750620283;
			goto IL_000d;
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
			if (NhVPPvZKOcTaxmGjUWBgRnEXHaeD == null)
			{
				return;
			}
			while (true)
			{
				int num = -1769713217;
				while (true)
				{
					switch (num ^ -1769713219)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_0026;
					case 1:
						return;
					}
					break;
					IL_0026:
					NhVPPvZKOcTaxmGjUWBgRnEXHaeD.Update();
					num = -1769713220;
				}
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
			if (array == null || array.Length == 0)
			{
				Logger.LogError("No active Rewired Input Manager was found in the scene! You must create a Rewired Input Manager for the tool to function.");
				return false;
			}
			return true;
		}
	}
}
