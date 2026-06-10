using System.ComponentModel;
using UnityEngine;

namespace Rewired.Internal
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExecuteInEditMode]
	[AddComponentMenu(null)]
	[Browsable(false)]
	[RequireComponent(typeof(InputManager_Base))]
	public class OnGUIHelper : MonoBehaviour
	{
		private InputManager_Base BaTtacyeRYNBocHXDZsGDxVdgZg;

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
		}
	}
}
