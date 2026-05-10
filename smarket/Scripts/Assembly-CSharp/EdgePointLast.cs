using UnityEngine;

public class EdgePointLast : MonoBehaviour
{
	[SerializeField]
	private Transform m_ResetPoint;

	private int _playerLayer;

	private int _CarLayer;

	private int m_BoxLayer;

	private void Start()
	{
	}

	private void OnTriggerEnter(Collider other)
	{
	}

	private void OnCollisionEnter(Collision other)
	{
	}
}
