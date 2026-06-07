using System.ComponentModel;
using UnityEngine;

namespace Rewired.Internal
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[RequireComponent(typeof(InputManager_Base))]
	[ExecuteInEditMode]
	[AddComponentMenu("")]
	public class OnGUIHelper : MonoBehaviour
	{
		private InputManager_Base GCQHnJkXanMbWWcIAkqAJMfPbnz;

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			GCQHnJkXanMbWWcIAkqAJMfPbnz = GetComponent<InputManager_Base>();
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (!(GCQHnJkXanMbWWcIAkqAJMfPbnz == null))
			{
				GCQHnJkXanMbWWcIAkqAJMfPbnz.OnGUIUpdate();
			}
		}
	}
}
