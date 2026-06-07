using UnityEngine;

public class DoorCollider : MonoBehaviour
{
	public bool Front;

	public DoorScript[] Doors;

	public Transform Left;

	private void OnTriggerEnter(Collider other)
	{
		IDoorTriggerer component;
		if (!other.transform.parent.TryGetComponent<IDoorTriggerer>(out component))
		{
			return;
		}
		Vector2 p = component.GetPosition().FlattenVector3();
		Vector2 p2 = component.GetFuturePoint(1.5f).FlattenVector3();
		Vector2 vector = Left.position.FlattenVector3();
		Vector2 p3 = vector + Left.forward.FlattenVector3();
		if (Utilities.IsLeft(vector, p3, p) != Utilities.IsLeft(vector, p3, p2))
		{
			for (int i = 0; i < Doors.Length; i++)
			{
				Doors[i].DoorCollision(Front);
			}
		}
	}
}
