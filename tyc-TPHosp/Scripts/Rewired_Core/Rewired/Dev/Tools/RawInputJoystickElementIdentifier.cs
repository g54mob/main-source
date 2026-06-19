using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	[AddComponentMenu("")]
	public sealed class RawInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool NuSUCGZLzYJQRRtHbKwdvZMVsDb;

		public void Awake()
		{
			if (LMbSKbxreUBvTAGzIYicKBLQiUiG())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				NuSUCGZLzYJQRRtHbKwdvZMVsDb = fGSYDPYatdKEeBAFoRjBvWMFmqp.CmFGRHtcYveRYoRMGDqJodZrdxQ("Rewired_Windows", "RawInput") as IElementIdentifierTool;
				if (NuSUCGZLzYJQRRtHbKwdvZMVsDb == null)
				{
					Logger.LogError("RawInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					NuSUCGZLzYJQRRtHbKwdvZMVsDb.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (NuSUCGZLzYJQRRtHbKwdvZMVsDb != null)
			{
				NuSUCGZLzYJQRRtHbKwdvZMVsDb.Start();
			}
		}

		public void Update()
		{
			if (NuSUCGZLzYJQRRtHbKwdvZMVsDb != null)
			{
				NuSUCGZLzYJQRRtHbKwdvZMVsDb.Update();
			}
		}

		public void OnDestroy()
		{
			if (NuSUCGZLzYJQRRtHbKwdvZMVsDb != null)
			{
				NuSUCGZLzYJQRRtHbKwdvZMVsDb.OnDestroy();
			}
			NuSUCGZLzYJQRRtHbKwdvZMVsDb = null;
		}

		private bool LMbSKbxreUBvTAGzIYicKBLQiUiG()
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
