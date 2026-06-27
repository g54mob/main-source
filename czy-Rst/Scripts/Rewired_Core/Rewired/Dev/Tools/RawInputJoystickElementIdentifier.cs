using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class RawInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool kgsToKiKPwjzkfesbfAUZvfJCcHib;

		public void Awake()
		{
			if (akcGAoFqFOhitOVWlrfSCZcTDyCiA())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				kgsToKiKPwjzkfesbfAUZvfJCcHib = sBZPLewyWajIYnWNsnbxikBrIXfS.lsDdOaMmsgIBRJQAOlzukIhlpkCt("Rewired_Windows", "RawInput") as IElementIdentifierTool;
				if (kgsToKiKPwjzkfesbfAUZvfJCcHib == null)
				{
					Logger.LogError("RawInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					kgsToKiKPwjzkfesbfAUZvfJCcHib.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (kgsToKiKPwjzkfesbfAUZvfJCcHib != null)
			{
				kgsToKiKPwjzkfesbfAUZvfJCcHib.Start();
			}
		}

		public void Update()
		{
			if (kgsToKiKPwjzkfesbfAUZvfJCcHib != null)
			{
				kgsToKiKPwjzkfesbfAUZvfJCcHib.Update();
			}
		}

		public void OnDestroy()
		{
			if (kgsToKiKPwjzkfesbfAUZvfJCcHib != null)
			{
				kgsToKiKPwjzkfesbfAUZvfJCcHib.OnDestroy();
			}
			kgsToKiKPwjzkfesbfAUZvfJCcHib = null;
		}

		private bool akcGAoFqFOhitOVWlrfSCZcTDyCiA()
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
