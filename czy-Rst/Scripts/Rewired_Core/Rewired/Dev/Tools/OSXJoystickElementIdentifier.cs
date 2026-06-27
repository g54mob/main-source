using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class OSXJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool wefqZomaDuDZUywhBeNkZybXpeyu;

		public void Awake()
		{
			if (ejuZRKZHfXLpgmelHgZvhIjHRwHpA())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				wefqZomaDuDZUywhBeNkZybXpeyu = sBZPLewyWajIYnWNsnbxikBrIXfS.lsDdOaMmsgIBRJQAOlzukIhlpkCt("Rewired_OSX", "OSX") as IElementIdentifierTool;
				if (wefqZomaDuDZUywhBeNkZybXpeyu == null)
				{
					Logger.LogError("OSX Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					wefqZomaDuDZUywhBeNkZybXpeyu.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (wefqZomaDuDZUywhBeNkZybXpeyu != null)
			{
				wefqZomaDuDZUywhBeNkZybXpeyu.Start();
			}
		}

		public void Update()
		{
			if (wefqZomaDuDZUywhBeNkZybXpeyu != null)
			{
				wefqZomaDuDZUywhBeNkZybXpeyu.Update();
			}
		}

		public void OnDestroy()
		{
			if (wefqZomaDuDZUywhBeNkZybXpeyu != null)
			{
				wefqZomaDuDZUywhBeNkZybXpeyu.OnDestroy();
			}
			wefqZomaDuDZUywhBeNkZybXpeyu = null;
		}

		private bool ejuZRKZHfXLpgmelHgZvhIjHRwHpA()
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
