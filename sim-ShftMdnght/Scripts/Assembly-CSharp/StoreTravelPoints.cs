using UnityEngine;

public class StoreTravelPoints : MonoBehaviour
{
	public Transform[] targPoints;

	public Transform checkoutPoint;

	public Transform exitPoint;

	public static StoreTravelPoints Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}
}
