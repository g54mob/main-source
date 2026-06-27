using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class DirectInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool kXQiVrKsnQGMwMdeWSBgqOmCPjxP;

		public void Awake()
		{
			if (yROOcbDknbFJyHkkNrRDeSxKLJJzA())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				kXQiVrKsnQGMwMdeWSBgqOmCPjxP = sBZPLewyWajIYnWNsnbxikBrIXfS.lsDdOaMmsgIBRJQAOlzukIhlpkCt("Rewired_Windows", "DirectInput") as IElementIdentifierTool;
				if (kXQiVrKsnQGMwMdeWSBgqOmCPjxP == null)
				{
					Logger.LogError("DirectInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					kXQiVrKsnQGMwMdeWSBgqOmCPjxP.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (kXQiVrKsnQGMwMdeWSBgqOmCPjxP != null)
			{
				kXQiVrKsnQGMwMdeWSBgqOmCPjxP.Start();
			}
		}

		public void Update()
		{
			if (kXQiVrKsnQGMwMdeWSBgqOmCPjxP != null)
			{
				kXQiVrKsnQGMwMdeWSBgqOmCPjxP.Update();
			}
		}

		public void OnDestroy()
		{
			if (kXQiVrKsnQGMwMdeWSBgqOmCPjxP != null)
			{
				kXQiVrKsnQGMwMdeWSBgqOmCPjxP.OnDestroy();
			}
			kXQiVrKsnQGMwMdeWSBgqOmCPjxP = null;
		}

		private bool yROOcbDknbFJyHkkNrRDeSxKLJJzA()
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
