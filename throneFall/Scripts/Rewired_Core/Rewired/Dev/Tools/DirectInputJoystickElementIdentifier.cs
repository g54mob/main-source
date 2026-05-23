using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class DirectInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool YfTkYCXrzEdEGVApXKHPRBETjHNq;

		public void Awake()
		{
			if (EZTTrIKiftEmSvLlAeYgxQVPkvlM())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				YfTkYCXrzEdEGVApXKHPRBETjHNq = WPUsVLvIKoiluyoUtdcARrtcCvPs.PeYSlTVcygzshWVHVNsZTNNoUQgs("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
				if (YfTkYCXrzEdEGVApXKHPRBETjHNq == null)
				{
					Logger.LogError("DirectInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					YfTkYCXrzEdEGVApXKHPRBETjHNq.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (YfTkYCXrzEdEGVApXKHPRBETjHNq != null)
			{
				YfTkYCXrzEdEGVApXKHPRBETjHNq.Start();
			}
		}

		public void Update()
		{
			if (YfTkYCXrzEdEGVApXKHPRBETjHNq != null)
			{
				YfTkYCXrzEdEGVApXKHPRBETjHNq.Update();
			}
		}

		public void OnDestroy()
		{
			if (YfTkYCXrzEdEGVApXKHPRBETjHNq != null)
			{
				YfTkYCXrzEdEGVApXKHPRBETjHNq.OnDestroy();
			}
			YfTkYCXrzEdEGVApXKHPRBETjHNq = null;
		}

		private bool EZTTrIKiftEmSvLlAeYgxQVPkvlM()
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
