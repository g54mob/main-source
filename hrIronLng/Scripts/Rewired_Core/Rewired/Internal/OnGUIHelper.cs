using System.ComponentModel;
using UnityEngine;

namespace Rewired.Internal
{
	[RequireComponent(typeof(InputManager_Base))]
	[AddComponentMenu("")]
	[ExecuteInEditMode]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public class OnGUIHelper : MonoBehaviour
	{
		private InputManager_Base FGdfYZnSDUbKvZGpdheRKxuypZdG;

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			FGdfYZnSDUbKvZGpdheRKxuypZdG = GetComponent<InputManager_Base>();
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (!(FGdfYZnSDUbKvZGpdheRKxuypZdG == null))
			{
				FGdfYZnSDUbKvZGpdheRKxuypZdG.OnGUIUpdate();
			}
		}
	}
}
