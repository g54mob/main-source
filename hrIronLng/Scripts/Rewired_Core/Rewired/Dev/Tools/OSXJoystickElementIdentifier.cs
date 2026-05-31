using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	[AddComponentMenu("")]
	public sealed class OSXJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool nhujvekTWLfTVOztukLkjNhnRWD;

		public void Awake()
		{
			if (zqNElTSWZDoORFiBXswtLxoiCBM())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				nhujvekTWLfTVOztukLkjNhnRWD = JCgnTfxtFodHUKJsjLoIpGzzqJB.cprtqzExsqyICxwoBkhIgqSHtca("Rewired_OSX", "OSX") as IElementIdentifierTool;
				if (nhujvekTWLfTVOztukLkjNhnRWD == null)
				{
					Logger.LogError("OSX Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					nhujvekTWLfTVOztukLkjNhnRWD.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (nhujvekTWLfTVOztukLkjNhnRWD != null)
			{
				nhujvekTWLfTVOztukLkjNhnRWD.Start();
			}
		}

		public void Update()
		{
			if (nhujvekTWLfTVOztukLkjNhnRWD != null)
			{
				nhujvekTWLfTVOztukLkjNhnRWD.Update();
			}
		}

		public void OnDestroy()
		{
			if (nhujvekTWLfTVOztukLkjNhnRWD != null)
			{
				nhujvekTWLfTVOztukLkjNhnRWD.OnDestroy();
			}
			nhujvekTWLfTVOztukLkjNhnRWD = null;
		}

		private bool zqNElTSWZDoORFiBXswtLxoiCBM()
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
