using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class RawInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool vBZAwGREuyDRbJtUDjqjBRcFCZiZA;

		public void Awake()
		{
			if (pWLGaaDEeOiCiEooZhTjtAdZrDvR())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				vBZAwGREuyDRbJtUDjqjBRcFCZiZA = nxoVcwPrvygPTyngCHqYYYXbiBMC.ovmwMulSZuezCOKeiaNPElezORnM("Rewired_Windows", "RawInput") as IElementIdentifierTool;
				if (vBZAwGREuyDRbJtUDjqjBRcFCZiZA == null)
				{
					Logger.LogError("RawInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					vBZAwGREuyDRbJtUDjqjBRcFCZiZA.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (vBZAwGREuyDRbJtUDjqjBRcFCZiZA != null)
			{
				vBZAwGREuyDRbJtUDjqjBRcFCZiZA.Start();
			}
		}

		public void Update()
		{
			if (vBZAwGREuyDRbJtUDjqjBRcFCZiZA != null)
			{
				vBZAwGREuyDRbJtUDjqjBRcFCZiZA.Update();
			}
		}

		public void OnDestroy()
		{
			if (vBZAwGREuyDRbJtUDjqjBRcFCZiZA != null)
			{
				vBZAwGREuyDRbJtUDjqjBRcFCZiZA.OnDestroy();
			}
			vBZAwGREuyDRbJtUDjqjBRcFCZiZA = null;
		}

		private bool pWLGaaDEeOiCiEooZhTjtAdZrDvR()
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
