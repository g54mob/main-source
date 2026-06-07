using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class OSXJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool YsGTIVFWVtOVYCvVsHJEYzEuABNO;

		public void Awake()
		{
			if (OGjYSyzQSpAeIRilTNBNihHxvASU())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				YsGTIVFWVtOVYCvVsHJEYzEuABNO = kiEAOtICCYZEVKAUfeKkKOUsmQTE.PgPcEEdakAFSXbfSNOFobDRMKzmBb("Rewired_OSX", "OSX") as IElementIdentifierTool;
				if (YsGTIVFWVtOVYCvVsHJEYzEuABNO == null)
				{
					Logger.LogError("OSX Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					YsGTIVFWVtOVYCvVsHJEYzEuABNO.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (YsGTIVFWVtOVYCvVsHJEYzEuABNO != null)
			{
				YsGTIVFWVtOVYCvVsHJEYzEuABNO.Start();
			}
		}

		public void Update()
		{
			if (YsGTIVFWVtOVYCvVsHJEYzEuABNO != null)
			{
				YsGTIVFWVtOVYCvVsHJEYzEuABNO.Update();
			}
		}

		public void OnDestroy()
		{
			if (YsGTIVFWVtOVYCvVsHJEYzEuABNO != null)
			{
				YsGTIVFWVtOVYCvVsHJEYzEuABNO.OnDestroy();
			}
			YsGTIVFWVtOVYCvVsHJEYzEuABNO = null;
		}

		private bool OGjYSyzQSpAeIRilTNBNihHxvASU()
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
