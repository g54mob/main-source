using UnityEngine;

namespace MoreMountains.Tools
{
	public class MMUIFollowMouse : MonoBehaviour
	{
		protected Vector2 _newPosition;

		protected Vector2 _mousePosition;

		public Canvas TargetCanvas { get; set; }

		protected virtual void Start()
		{
		}

		protected virtual void LateUpdate()
		{
			_mousePosition = Input.mousePosition;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(TargetCanvas.transform as RectTransform, _mousePosition, TargetCanvas.worldCamera, out _newPosition);
			base.transform.position = TargetCanvas.transform.TransformPoint(_newPosition);
		}
	}
}
