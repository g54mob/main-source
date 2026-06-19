using UnityEngine;

namespace UI
{
	public class UIObjectFollowMouse : MonoBehaviour
	{
		private void LateUpdate()
		{
			base.transform.localPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
		}
	}
}
