using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class OSXJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool rfIAHjzGGcLlrUYvaducaowyBAFZ;

		public void Awake()
		{
			if (pzVLrVSBgTJhFCwdggKthaqgKWwU())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				rfIAHjzGGcLlrUYvaducaowyBAFZ = rCyaPdzoTeAsnETRLiAjpHCITzUaA.iqwKWpREpyQjgpFEdnCyLMcWdMxZ("Rewired_OSX", "OSX") as IElementIdentifierTool;
				if (rfIAHjzGGcLlrUYvaducaowyBAFZ == null)
				{
					Logger.LogError("OSX Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					rfIAHjzGGcLlrUYvaducaowyBAFZ.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (rfIAHjzGGcLlrUYvaducaowyBAFZ != null)
			{
				rfIAHjzGGcLlrUYvaducaowyBAFZ.Start();
			}
		}

		public void Update()
		{
			if (rfIAHjzGGcLlrUYvaducaowyBAFZ != null)
			{
				rfIAHjzGGcLlrUYvaducaowyBAFZ.Update();
			}
		}

		public void OnDestroy()
		{
			if (rfIAHjzGGcLlrUYvaducaowyBAFZ != null)
			{
				rfIAHjzGGcLlrUYvaducaowyBAFZ.OnDestroy();
			}
			rfIAHjzGGcLlrUYvaducaowyBAFZ = null;
		}

		private bool pzVLrVSBgTJhFCwdggKthaqgKWwU()
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
