using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[RequireComponent(typeof(GUIText))]
	[AddComponentMenu("")]
	public sealed class OSXJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool pjNuODckPzdPEBkyBUPSMLZgFMksA;

		public void Awake()
		{
			if (rdSkEdFdlYIpsfeeBvFDBSPyMEDNA())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				pjNuODckPzdPEBkyBUPSMLZgFMksA = tGxuGLgAElwKEviYukvVkrfWPpfu.slnRDsCqDpFFYHJqGxOjyNiSQQnB("Rewired_OSX", "OSX") as IElementIdentifierTool;
				if (pjNuODckPzdPEBkyBUPSMLZgFMksA == null)
				{
					Logger.LogError("OSX Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					pjNuODckPzdPEBkyBUPSMLZgFMksA.Initialize(GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (pjNuODckPzdPEBkyBUPSMLZgFMksA != null)
			{
				pjNuODckPzdPEBkyBUPSMLZgFMksA.Start();
			}
		}

		public void Update()
		{
			if (pjNuODckPzdPEBkyBUPSMLZgFMksA != null)
			{
				pjNuODckPzdPEBkyBUPSMLZgFMksA.Update();
			}
		}

		public void OnDestroy()
		{
			if (pjNuODckPzdPEBkyBUPSMLZgFMksA != null)
			{
				pjNuODckPzdPEBkyBUPSMLZgFMksA.OnDestroy();
			}
			pjNuODckPzdPEBkyBUPSMLZgFMksA = null;
		}

		private bool rdSkEdFdlYIpsfeeBvFDBSPyMEDNA()
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
