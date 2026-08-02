using UnityEngine;
using UnityEngine.Events;

public class ObjectManager : Singleton<ObjectManager>
{
	public UnityEvent<GrabbableObject> OnObjectPlaced = new UnityEvent<GrabbableObject>();

	public GameObject woodHalfBig;
}
