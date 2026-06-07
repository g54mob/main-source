using UnityEngine;

public class UnparentOnStart : MonoBehaviour
{
	private void Start()
	{
		base.transform.parent = null;
	}
}
