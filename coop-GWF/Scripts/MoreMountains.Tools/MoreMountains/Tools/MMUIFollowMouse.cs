using UnityEngine;
using UnityEngine.InputSystem;

namespace MoreMountains.Tools
{
	public class MMUIFollowMouse : MonoBehaviour
	{
		protected Vector2 _newPosition;

		protected Vector2 _mousePosition;

		public virtual Canvas TargetCanvas { get; set; }

		protected virtual void LateUpdate()
		{
			_mousePosition = Mouse.current.position.ReadValue();
			RectTransformUtility.ScreenPointToLocalPointInRectangle(TargetCanvas.transform as RectTransform, _mousePosition, TargetCanvas.worldCamera, out _newPosition);
			base.transform.position = TargetCanvas.transform.TransformPoint(_newPosition);
		}
	}
}
