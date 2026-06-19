using Rewired.Interfaces;
using Rewired.Internal;
using UnityEngine;

namespace Rewired.Dev.Tools
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(Rewired.Internal.GUIText))]
	public sealed class OSXJoystickElementIdentifier : MonoBehaviour
	{
		private IElementIdentifierTool rZIJBoHemujaJpfVbpEBbpgNTdNj;

		public void Awake()
		{
			if (ndTHjWgoIFDybnNSflzMquYNNuqC())
			{
				if (base.transform.position != Vector3.zero)
				{
					base.transform.position = Vector3.zero;
				}
				rZIJBoHemujaJpfVbpEBbpgNTdNj = nxoVcwPrvygPTyngCHqYYYXbiBMC.ovmwMulSZuezCOKeiaNPElezORnM("Rewired_OSX", "OSX") as IElementIdentifierTool;
				if (rZIJBoHemujaJpfVbpEBbpgNTdNj == null)
				{
					Logger.LogError("OSX Tool could not be initialized! Make sure the correct platform mode is chosen in Unity's Build Settings.");
				}
				else
				{
					rZIJBoHemujaJpfVbpEBbpgNTdNj.Initialize(Rewired.Internal.GUIText.CreateLogger(base.gameObject));
				}
			}
		}

		public void Start()
		{
			if (rZIJBoHemujaJpfVbpEBbpgNTdNj != null)
			{
				rZIJBoHemujaJpfVbpEBbpgNTdNj.Start();
			}
		}

		public void Update()
		{
			if (rZIJBoHemujaJpfVbpEBbpgNTdNj != null)
			{
				rZIJBoHemujaJpfVbpEBbpgNTdNj.Update();
			}
		}

		public void OnDestroy()
		{
			if (rZIJBoHemujaJpfVbpEBbpgNTdNj != null)
			{
				rZIJBoHemujaJpfVbpEBbpgNTdNj.OnDestroy();
			}
			rZIJBoHemujaJpfVbpEBbpgNTdNj = null;
		}

		private bool ndTHjWgoIFDybnNSflzMquYNNuqC()
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
