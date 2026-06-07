using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class OSXJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool pMGeXXfHUVRsLkDvjeyLhpzzhqIMA;

		public void Awake()
		{
			if (jJLXRbCZqmwGjinlrqxGyCrpfkxW())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				pMGeXXfHUVRsLkDvjeyLhpzzhqIMA = xkwDVLzkLVknJzRRMIYEQzJNeNRn.eiyQrZHnjZoSGXdYeIeHSZjRyQoF("Rewired_OSX", "OSX") as IElementIdentifierTool;
				if (pMGeXXfHUVRsLkDvjeyLhpzzhqIMA == null)
				{
					Logger.LogError("OSX Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					pMGeXXfHUVRsLkDvjeyLhpzzhqIMA.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (pMGeXXfHUVRsLkDvjeyLhpzzhqIMA != null)
			{
				pMGeXXfHUVRsLkDvjeyLhpzzhqIMA.Start();
			}
		}

		public void Update()
		{
			if (pMGeXXfHUVRsLkDvjeyLhpzzhqIMA != null)
			{
				pMGeXXfHUVRsLkDvjeyLhpzzhqIMA.Update();
			}
		}

		public void OnDestroy()
		{
			if (pMGeXXfHUVRsLkDvjeyLhpzzhqIMA != null)
			{
				pMGeXXfHUVRsLkDvjeyLhpzzhqIMA.OnDestroy();
			}
			pMGeXXfHUVRsLkDvjeyLhpzzhqIMA = null;
		}

		private bool jJLXRbCZqmwGjinlrqxGyCrpfkxW()
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
