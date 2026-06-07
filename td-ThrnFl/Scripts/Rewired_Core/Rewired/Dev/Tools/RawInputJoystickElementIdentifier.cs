using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class RawInputJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool GzhVzClRoUYQjxhsMHpdAVIzGhwA;

		public void Awake()
		{
			if (MwzxzFxDzAXFBEDragLjoKaAAnyC())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				GzhVzClRoUYQjxhsMHpdAVIzGhwA = WPUsVLvIKoiluyoUtdcARrtcCvPs.PeYSlTVcygzshWVHVNsZTNNoUQgs("Rewired_Windows", "RawInput") as IElementIdentifierTool;
				if (GzhVzClRoUYQjxhsMHpdAVIzGhwA == null)
				{
					Logger.LogError("RawInput Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					GzhVzClRoUYQjxhsMHpdAVIzGhwA.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (GzhVzClRoUYQjxhsMHpdAVIzGhwA != null)
			{
				GzhVzClRoUYQjxhsMHpdAVIzGhwA.Start();
			}
		}

		public void Update()
		{
			if (GzhVzClRoUYQjxhsMHpdAVIzGhwA != null)
			{
				GzhVzClRoUYQjxhsMHpdAVIzGhwA.Update();
			}
		}

		public void OnDestroy()
		{
			if (GzhVzClRoUYQjxhsMHpdAVIzGhwA != null)
			{
				GzhVzClRoUYQjxhsMHpdAVIzGhwA.OnDestroy();
			}
			GzhVzClRoUYQjxhsMHpdAVIzGhwA = null;
		}

		private bool MwzxzFxDzAXFBEDragLjoKaAAnyC()
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
