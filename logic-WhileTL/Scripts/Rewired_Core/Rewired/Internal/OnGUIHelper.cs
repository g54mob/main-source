using System.ComponentModel;
using UnityEngine;

namespace Rewired.Internal
{
	[Browsable(false)]
	[ExecuteInEditMode]
	[RequireComponent(typeof(InputManager_Base))]
	[AddComponentMenu("")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class OnGUIHelper : MonoBehaviour
	{
		private InputManager_Base LNFmGxqdskDZYydfYKbBBRoonLzv;

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			LNFmGxqdskDZYydfYKbBBRoonLzv = GetComponent<InputManager_Base>();
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (!(LNFmGxqdskDZYydfYKbBBRoonLzv == null))
			{
				LNFmGxqdskDZYydfYKbBBRoonLzv.OnGUIUpdate();
			}
		}
	}
}
