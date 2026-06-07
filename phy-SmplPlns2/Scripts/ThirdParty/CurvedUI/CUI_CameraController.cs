using UnityEngine;

namespace CurvedUI
{
	public class CUI_CameraController : MonoBehaviour
	{
		public static CUI_CameraController instance;

		[SerializeField]
		private Transform CameraObject;

		[SerializeField]
		private float rotationMargin = 25f;

		[SerializeField]
		private bool runInEditorOnly = true;

		private void Awake()
		{
			instance = this;
		}
	}
}
