using UnityEngine;

public class Door : MonoBehaviour
{
	public enum LockIcon
	{
		Beam = 0,
		Cross = 1
	}

	public LockIcon lockIcon;

	private void Start()
	{
		Transform transform = base.transform.FindDescendant("noreset", false);
		if (transform != null)
		{
			transform.gameObject.SetActive(false);
		}
	}
}
