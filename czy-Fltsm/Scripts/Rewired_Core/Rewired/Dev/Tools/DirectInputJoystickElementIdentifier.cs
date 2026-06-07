using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class DirectInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool dgrJjeXNyIeVTaTezoZuFPztZfGi;

		public void Awake()
		{
			if (tMbcxkSGcdGtVAQasWaHpPilCjyFA())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				dgrJjeXNyIeVTaTezoZuFPztZfGi = rCyaPdzoTeAsnETRLiAjpHCITzUaA.iqwKWpREpyQjgpFEdnCyLMcWdMxZ("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
				if (dgrJjeXNyIeVTaTezoZuFPztZfGi == null)
				{
					Logger.LogError("DirectInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					dgrJjeXNyIeVTaTezoZuFPztZfGi.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (dgrJjeXNyIeVTaTezoZuFPztZfGi != null)
			{
				dgrJjeXNyIeVTaTezoZuFPztZfGi.Start();
			}
		}

		public void Update()
		{
			if (dgrJjeXNyIeVTaTezoZuFPztZfGi != null)
			{
				dgrJjeXNyIeVTaTezoZuFPztZfGi.Update();
			}
		}

		public void OnDestroy()
		{
			if (dgrJjeXNyIeVTaTezoZuFPztZfGi != null)
			{
				dgrJjeXNyIeVTaTezoZuFPztZfGi.OnDestroy();
			}
			dgrJjeXNyIeVTaTezoZuFPztZfGi = null;
		}

		private bool tMbcxkSGcdGtVAQasWaHpPilCjyFA()
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
