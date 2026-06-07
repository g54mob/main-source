using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class RawInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool rwZqCRdIimXdJEfeAxQKWJqkUJkK;

		public void Awake()
		{
			if (tyXYIdxCrMWtKzSwEOUEcdzmIEhE())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				rwZqCRdIimXdJEfeAxQKWJqkUJkK = rCyaPdzoTeAsnETRLiAjpHCITzUaA.iqwKWpREpyQjgpFEdnCyLMcWdMxZ("Rewired_Windows", "RawInput") as IElementIdentifierTool;
				if (rwZqCRdIimXdJEfeAxQKWJqkUJkK == null)
				{
					Logger.LogError("RawInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					rwZqCRdIimXdJEfeAxQKWJqkUJkK.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (rwZqCRdIimXdJEfeAxQKWJqkUJkK != null)
			{
				rwZqCRdIimXdJEfeAxQKWJqkUJkK.Start();
			}
		}

		public void Update()
		{
			if (rwZqCRdIimXdJEfeAxQKWJqkUJkK != null)
			{
				rwZqCRdIimXdJEfeAxQKWJqkUJkK.Update();
			}
		}

		public void OnDestroy()
		{
			if (rwZqCRdIimXdJEfeAxQKWJqkUJkK != null)
			{
				rwZqCRdIimXdJEfeAxQKWJqkUJkK.OnDestroy();
			}
			rwZqCRdIimXdJEfeAxQKWJqkUJkK = null;
		}

		private bool tyXYIdxCrMWtKzSwEOUEcdzmIEhE()
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
