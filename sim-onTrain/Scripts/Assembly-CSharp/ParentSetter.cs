using UnityEngine;

public class ParentSetter : MonoBehaviour
{
	[SerializeField]
	private Transform parent;

	private void Start()
	{
		if (parent == null)
		{
			base.transform.parent = null;
		}
		else
		{
			base.transform.parent = parent;
		}
		base.transform.localPosition = Vector3.zero;
		base.transform.localEulerAngles = Vector3.zero;
	}
}
