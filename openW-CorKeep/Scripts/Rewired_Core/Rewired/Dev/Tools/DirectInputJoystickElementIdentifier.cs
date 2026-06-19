using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class DirectInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool rivHOdxbGWuejFZGezCHWgrYdMUy;

		public void Awake()
		{
			if (tnrkivcOFdbZffYvbrhmgkvIuuwc())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				rivHOdxbGWuejFZGezCHWgrYdMUy = nxoVcwPrvygPTyngCHqYYYXbiBMC.ovmwMulSZuezCOKeiaNPElezORnM("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
				if (rivHOdxbGWuejFZGezCHWgrYdMUy == null)
				{
					Logger.LogError("DirectInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					rivHOdxbGWuejFZGezCHWgrYdMUy.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (rivHOdxbGWuejFZGezCHWgrYdMUy != null)
			{
				rivHOdxbGWuejFZGezCHWgrYdMUy.Start();
			}
		}

		public void Update()
		{
			if (rivHOdxbGWuejFZGezCHWgrYdMUy != null)
			{
				rivHOdxbGWuejFZGezCHWgrYdMUy.Update();
			}
		}

		public void OnDestroy()
		{
			if (rivHOdxbGWuejFZGezCHWgrYdMUy != null)
			{
				rivHOdxbGWuejFZGezCHWgrYdMUy.OnDestroy();
			}
			rivHOdxbGWuejFZGezCHWgrYdMUy = null;
		}

		private bool tnrkivcOFdbZffYvbrhmgkvIuuwc()
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
