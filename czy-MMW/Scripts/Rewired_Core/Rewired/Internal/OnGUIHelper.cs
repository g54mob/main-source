using System.ComponentModel;
using UnityEngine;

namespace Rewired.Internal
{
	[AddComponentMenu("")]
	[RequireComponent(typeof(InputManager_Base))]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[ExecuteInEditMode]
	public class OnGUIHelper : MonoBehaviour
	{
		private InputManager_Base UyyiuQynybNKMFUxsOPqIhsnyATS;

		[CustomObfuscation(rename = false)]
		private void Awake()
		{
			UyyiuQynybNKMFUxsOPqIhsnyATS = GetComponent<InputManager_Base>();
		}

		[CustomObfuscation(rename = false)]
		private void OnGUI()
		{
			if (!(UyyiuQynybNKMFUxsOPqIhsnyATS == null))
			{
				UyyiuQynybNKMFUxsOPqIhsnyATS.OnGUIUpdate();
			}
		}
	}
}
