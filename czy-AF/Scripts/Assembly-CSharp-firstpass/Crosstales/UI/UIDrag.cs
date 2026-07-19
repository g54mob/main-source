using UnityEngine;

namespace Crosstales.UI
{
	public class UIDrag : MonoBehaviour
	{
		private float offsetX;

		private float offsetY;

		private Transform tf;

		public void Start()
		{
			tf = base.transform;
		}

		public void BeginDrag()
		{
			Vector3 position = tf.position;
			offsetX = position.x - Input.mousePosition.x;
			offsetY = position.y - Input.mousePosition.y;
		}

		public void OnDrag()
		{
			tf.position = new Vector3(offsetX + Input.mousePosition.x, offsetY + Input.mousePosition.y);
		}
	}
}
