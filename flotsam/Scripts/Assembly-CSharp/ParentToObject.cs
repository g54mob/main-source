using UnityEngine;

public class ParentToObject : MonoBehaviour
{
	public bool KeepWorldPosition = true;

	public Transform NewParent;

	private void Start()
	{
		base.transform.SetParent(NewParent, KeepWorldPosition);
	}

	private void Update()
	{
	}
}
