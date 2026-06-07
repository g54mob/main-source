using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class DirectInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool fOzMLODAipbtdJKoimuNJYmchtRTA;

		public void Awake()
		{
			if (bupfeKYxsOaklynizauyqgbgiBxgA())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				fOzMLODAipbtdJKoimuNJYmchtRTA = xkwDVLzkLVknJzRRMIYEQzJNeNRn.eiyQrZHnjZoSGXdYeIeHSZjRyQoF("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
				if (fOzMLODAipbtdJKoimuNJYmchtRTA == null)
				{
					Logger.LogError("DirectInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					fOzMLODAipbtdJKoimuNJYmchtRTA.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (fOzMLODAipbtdJKoimuNJYmchtRTA != null)
			{
				fOzMLODAipbtdJKoimuNJYmchtRTA.Start();
			}
		}

		public void Update()
		{
			if (fOzMLODAipbtdJKoimuNJYmchtRTA != null)
			{
				fOzMLODAipbtdJKoimuNJYmchtRTA.Update();
			}
		}

		public void OnDestroy()
		{
			if (fOzMLODAipbtdJKoimuNJYmchtRTA != null)
			{
				fOzMLODAipbtdJKoimuNJYmchtRTA.OnDestroy();
			}
			fOzMLODAipbtdJKoimuNJYmchtRTA = null;
		}

		private bool bupfeKYxsOaklynizauyqgbgiBxgA()
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
