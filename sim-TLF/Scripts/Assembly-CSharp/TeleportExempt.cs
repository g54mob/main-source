using UnityEngine;

public class TeleportExempt : MonoBehaviour
{
	public static bool IsExempt(Transform target)
	{
		if (target != null)
		{
			return target.GetComponentInParent<TeleportExempt>() != null;
		}
		return false;
	}

	public static bool IsExempt(Component target)
	{
		if (target != null)
		{
			return IsExempt(target.transform);
		}
		return false;
	}
}
