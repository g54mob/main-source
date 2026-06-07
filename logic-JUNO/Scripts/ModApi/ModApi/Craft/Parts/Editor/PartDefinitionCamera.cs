using UnityEngine;

namespace ModApi.Craft.Parts.Editor
{
	public class PartDefinitionCamera : MonoBehaviour
	{
		[SerializeField]
		private Transform _cameraFocusTransform;

		public Camera Camera => GetComponentInChildren<Camera>();

		public Transform CameraFocusTransform
		{
			get
			{
				return _cameraFocusTransform;
			}
			set
			{
				_cameraFocusTransform = value;
			}
		}
	}
}
