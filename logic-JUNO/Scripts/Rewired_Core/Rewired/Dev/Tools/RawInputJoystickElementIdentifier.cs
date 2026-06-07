using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class RawInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool hHVFwrbzYXtClyToNgrhPStlCsvcA;

		public void Awake()
		{
			if (nIFUKJpnEdyVmZFSLxSztOonAmmp())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				hHVFwrbzYXtClyToNgrhPStlCsvcA = xkwDVLzkLVknJzRRMIYEQzJNeNRn.eiyQrZHnjZoSGXdYeIeHSZjRyQoF("Rewired_Windows", "RawInput") as IElementIdentifierTool;
				if (hHVFwrbzYXtClyToNgrhPStlCsvcA == null)
				{
					Logger.LogError("RawInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					hHVFwrbzYXtClyToNgrhPStlCsvcA.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (hHVFwrbzYXtClyToNgrhPStlCsvcA != null)
			{
				hHVFwrbzYXtClyToNgrhPStlCsvcA.Start();
			}
		}

		public void Update()
		{
			if (hHVFwrbzYXtClyToNgrhPStlCsvcA != null)
			{
				hHVFwrbzYXtClyToNgrhPStlCsvcA.Update();
			}
		}

		public void OnDestroy()
		{
			if (hHVFwrbzYXtClyToNgrhPStlCsvcA != null)
			{
				hHVFwrbzYXtClyToNgrhPStlCsvcA.OnDestroy();
			}
			hHVFwrbzYXtClyToNgrhPStlCsvcA = null;
		}

		private bool nIFUKJpnEdyVmZFSLxSztOonAmmp()
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
