using UnityEngine;

namespace Cookieverse.CursorPos.Example
{
	public class RightClickRotate : MonoBehaviour
	{
		private LockCursorInPlace _lockCursor;

		public float RotateSensitivity = 5f;

		public bool Lock = true;

		private void Awake()
		{
			_lockCursor = GetComponent<LockCursorInPlace>();
		}

		public void Update()
		{
			if (Input.GetKey(KeyCode.Mouse1))
			{
				_lockCursor.Locked = Lock;
				base.transform.eulerAngles += new Vector3(0f, Input.GetAxis("Mouse X") * RotateSensitivity, 0f);
			}
			else
			{
				_lockCursor.Locked = false;
			}
		}
	}
}
