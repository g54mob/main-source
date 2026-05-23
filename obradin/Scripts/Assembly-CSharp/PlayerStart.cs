using UnityEngine;

public class PlayerStart : MonoBehaviour
{
	public float lookUpDownAngle
	{
		get
		{
			Transform transform = base.transform.FindDescendant("lookupdown");
			if (transform == null)
			{
				return 0f;
			}
			return transform.localRotation.eulerAngles.x + transform.parent.localRotation.eulerAngles.x;
		}
	}
}
