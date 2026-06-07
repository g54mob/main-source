using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Throwable : MonoBehaviour
{
	[SerializeField]
	private float m_ForceForwards;

	[SerializeField]
	private float m_ForceUpwards;

	private Rigidbody m_Rigidbody;

	private void Awake()
	{
	}

	public void Throw(Vector3 direction)
	{
	}
}
