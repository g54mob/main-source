using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[RequireComponent(typeof(GUIText))]
	[AddComponentMenu("")]
	public sealed class DirectInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool tUaaCMKKdHLOgbOzJEJYsmQPxNdzB;

		public void Awake()
		{
			if (rQwStODMpwANaqRhZUZpScLdhtVK())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				tUaaCMKKdHLOgbOzJEJYsmQPxNdzB = tGxuGLgAElwKEviYukvVkrfWPpfu.slnRDsCqDpFFYHJqGxOjyNiSQQnB("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
				if (tUaaCMKKdHLOgbOzJEJYsmQPxNdzB == null)
				{
					Logger.LogError("DirectInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					tUaaCMKKdHLOgbOzJEJYsmQPxNdzB.Initialize(GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (tUaaCMKKdHLOgbOzJEJYsmQPxNdzB != null)
			{
				tUaaCMKKdHLOgbOzJEJYsmQPxNdzB.Start();
			}
		}

		public void Update()
		{
			if (tUaaCMKKdHLOgbOzJEJYsmQPxNdzB != null)
			{
				tUaaCMKKdHLOgbOzJEJYsmQPxNdzB.Update();
			}
		}

		public void OnDestroy()
		{
			if (tUaaCMKKdHLOgbOzJEJYsmQPxNdzB != null)
			{
				tUaaCMKKdHLOgbOzJEJYsmQPxNdzB.OnDestroy();
			}
			tUaaCMKKdHLOgbOzJEJYsmQPxNdzB = null;
		}

		private bool rQwStODMpwANaqRhZUZpScLdhtVK()
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
