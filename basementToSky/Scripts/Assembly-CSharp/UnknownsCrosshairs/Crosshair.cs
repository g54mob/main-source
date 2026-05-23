using UnityEngine;
using UnityEngine.UI;

namespace UnknownsCrosshairs
{
	public class Crosshair : MonoBehaviour
	{
		public RawImage up;

		public RawImage down;

		public RawImage left;

		public RawImage right;

		private Vector3 upDefaultPos;

		private Vector3 downDefaultPos;

		private Vector3 leftDefaultPos;

		private Vector3 rightDefaultPos;

		private float returnToCenterSpeed;

		private void Start()
		{
			upDefaultPos = up.transform.position;
			downDefaultPos = down.transform.position;
			leftDefaultPos = left.transform.position;
			rightDefaultPos = right.transform.position;
		}

		private void LateUpdate()
		{
			ShrinkCrosshairToNormal();
		}

		private void ShrinkCrosshairToNormal()
		{
			if (up.transform.position.y > upDefaultPos.y)
			{
				up.transform.position = new Vector3(up.transform.position.x, up.transform.position.y - returnToCenterSpeed, up.transform.position.z);
			}
			if (down.transform.position.y < downDefaultPos.y)
			{
				down.transform.position = new Vector3(down.transform.position.x, down.transform.position.y + returnToCenterSpeed, down.transform.position.z);
			}
			if (left.transform.position.x < leftDefaultPos.x)
			{
				left.transform.position = new Vector3(left.transform.position.x + returnToCenterSpeed, left.transform.position.y, left.transform.position.z);
			}
			if (right.transform.position.x > rightDefaultPos.x)
			{
				right.transform.position = new Vector3(right.transform.position.x - returnToCenterSpeed, right.transform.position.y, right.transform.position.z);
			}
		}

		public void Expand(float expandAmount)
		{
			up.transform.position = new Vector3(up.transform.position.x, up.transform.position.y + expandAmount, up.transform.position.z);
			down.transform.position = new Vector3(down.transform.position.x, down.transform.position.y - expandAmount, down.transform.position.z);
			left.transform.position = new Vector3(left.transform.position.x - expandAmount, left.transform.position.y, left.transform.position.z);
			right.transform.position = new Vector3(right.transform.position.x + expandAmount, right.transform.position.y, right.transform.position.z);
		}

		public void SetShrinkSpeed(float shrinkSpeed)
		{
			returnToCenterSpeed = shrinkSpeed;
		}
	}
}
