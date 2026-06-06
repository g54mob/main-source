using System.ComponentModel;
using UnityEngine;

namespace Rewired.Internal
{
	[ExecuteInEditMode]
	[AddComponentMenu("")]
	[RequireComponent(typeof(InputManager_Base))]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class OnGUIHelper : MonoBehaviour
	{
		private InputManager_Base EHftJwddtmigttcqFiYKdaBvIzwH;

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			EHftJwddtmigttcqFiYKdaBvIzwH = GetComponent<InputManager_Base>();
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (!(EHftJwddtmigttcqFiYKdaBvIzwH == null))
			{
				EHftJwddtmigttcqFiYKdaBvIzwH.OnGUIUpdate();
			}
		}
	}
}
