using UnityEngine;

public class Obj_MovingSceneObject : MonoBehaviour
{
	[SerializeField]
	private float moveSpeed;

	[SerializeField]
	private float xBorder;

	[SerializeField]
	private Vector3 moveDistanceOnReachBorder;

	[SerializeField]
	private Obj_MovingSceneObject objToActiveAfterFinished;

	private bool doActiveNextObject;

	private void Update()
	{
	}

	public void ActivateNextObject()
	{
	}

	public void ImmidiateActivateNextObject()
	{
	}
}
