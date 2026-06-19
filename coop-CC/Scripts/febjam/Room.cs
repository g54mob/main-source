using UnityEngine;

public class Room : MonoBehaviour
{
	public RoomType containerType = RoomType.Warehouse;

	public Transform instantiateContainer { get; private set; }

	private void Awake()
	{
		GameObject gameObject = new GameObject("[INSTANTIATED OBJECTS]");
		gameObject.transform.SetParentAndReset(base.transform);
		instantiateContainer = gameObject.transform;
	}
}
