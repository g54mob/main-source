using UnityEngine;

public abstract class Volume : MonoBehaviour
{
	public abstract bool IsWithin(Vector3 point);
}
