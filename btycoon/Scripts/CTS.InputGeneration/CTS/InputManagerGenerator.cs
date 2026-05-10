using UnityEngine;
using UnityEngine.InputSystem;

namespace CTS
{
	public class InputManagerGenerator : MonoBehaviour
	{
		[SerializeField]
		private InputActionAsset _inputAsset;

		[SerializeField]
		private Object _pathReference;

		[SerializeField]
		private TextAsset _backupFile;
	}
}
