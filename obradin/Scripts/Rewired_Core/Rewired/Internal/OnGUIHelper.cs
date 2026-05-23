using System.ComponentModel;
using UnityEngine;

namespace Rewired.Internal
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[AddComponentMenu("")]
	[RequireComponent(typeof(InputManager_Base))]
	[ExecuteInEditMode]
	[Browsable(false)]
	public class OnGUIHelper : MonoBehaviour
	{
		private InputManager_Base nCWCOIOOofbnfixPcuUIeRfVqGi;

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			nCWCOIOOofbnfixPcuUIeRfVqGi = GetComponent<InputManager_Base>();
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (nCWCOIOOofbnfixPcuUIeRfVqGi == null)
			{
				while (true)
				{
					switch (0x88FCA2A ^ 0x88FCA28)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			nCWCOIOOofbnfixPcuUIeRfVqGi.OnGUIUpdate();
		}
	}
}
