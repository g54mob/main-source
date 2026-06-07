using UnityEngine;

public abstract class RemoteControllable : MonoBehaviour
{
	public abstract void HandleThumbpad(Vector2 axis);
}
