using UnityEngine;

public class BoxSelection : MonoBehaviour
{
	public void OnTriggerEnter(Collider _other)
	{
		if ((bool)_other.transform.parent && (_other.transform.parent == Global.elements["workbench"] || _other.transform.parent == Global.elements["selection"]))
		{
			Selection.Add(_other.transform);
		}
	}
}
