using System.ComponentModel;
using UnityEngine;

namespace Rewired.Internal
{
	[RequireComponent(typeof(InputManager_Base))]
	[ExecuteInEditMode]
	[AddComponentMenu("")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public class OnGUIHelper : MonoBehaviour
	{
		private InputManager_Base vGQnsSUmFrTJHfYhJtHRHxFCImW;

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			vGQnsSUmFrTJHfYhJtHRHxFCImW = GetComponent<InputManager_Base>();
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (!(vGQnsSUmFrTJHfYhJtHRHxFCImW == null))
			{
				vGQnsSUmFrTJHfYhJtHRHxFCImW.OnGUIUpdate();
			}
		}
	}
}
