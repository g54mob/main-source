using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[RequireComponent(typeof(GUIText))]
	[AddComponentMenu("")]
	public sealed class RawInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool tbWQzhecLzzuwafzrEXezETmcQHV;

		public void Awake()
		{
			if (nmODLPcqDBludPHLjvbuFGWggMCJA())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				tbWQzhecLzzuwafzrEXezETmcQHV = tGxuGLgAElwKEviYukvVkrfWPpfu.slnRDsCqDpFFYHJqGxOjyNiSQQnB("Rewired_Windows", "RawInput") as IElementIdentifierTool;
				if (tbWQzhecLzzuwafzrEXezETmcQHV == null)
				{
					Logger.LogError("RawInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					tbWQzhecLzzuwafzrEXezETmcQHV.Initialize(GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (tbWQzhecLzzuwafzrEXezETmcQHV != null)
			{
				tbWQzhecLzzuwafzrEXezETmcQHV.Start();
			}
		}

		public void Update()
		{
			if (tbWQzhecLzzuwafzrEXezETmcQHV != null)
			{
				tbWQzhecLzzuwafzrEXezETmcQHV.Update();
			}
		}

		public void OnDestroy()
		{
			if (tbWQzhecLzzuwafzrEXezETmcQHV != null)
			{
				tbWQzhecLzzuwafzrEXezETmcQHV.OnDestroy();
			}
			tbWQzhecLzzuwafzrEXezETmcQHV = null;
		}

		private bool nmODLPcqDBludPHLjvbuFGWggMCJA()
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
