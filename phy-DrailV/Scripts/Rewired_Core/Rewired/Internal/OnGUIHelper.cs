using System.ComponentModel;
using UnityEngine;

namespace Rewired.Internal
{
	[RequireComponent(typeof(InputManager_Base))]
	[AddComponentMenu("")]
	[ExecuteInEditMode]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class OnGUIHelper : MonoBehaviour
	{
		private InputManager_Base kxVVfsEvIkmogZXRbQDbWrFdzRdN;

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			kxVVfsEvIkmogZXRbQDbWrFdzRdN = GetComponent<InputManager_Base>();
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (!(kxVVfsEvIkmogZXRbQDbWrFdzRdN == null))
			{
				kxVVfsEvIkmogZXRbQDbWrFdzRdN.OnGUIUpdate();
			}
		}
	}
}
