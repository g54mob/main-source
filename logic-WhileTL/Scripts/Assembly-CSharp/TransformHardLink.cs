using UnityEngine;

[ExecuteInEditMode]
public class TransformHardLink : MonoBehaviour
{
	public Transform Parent;

	private Vector3 _lastPos;

	private Vector3 _lastRot;

	private void Update()
	{
		if (!(Parent == null))
		{
			base.transform.position += _lastPos - Parent.position;
			base.transform.rotation = Quaternion.Euler(base.transform.rotation.eulerAngles + _lastRot - Parent.rotation.eulerAngles);
			_lastPos = Parent.position;
			_lastRot = Parent.rotation.eulerAngles;
		}
	}
}
