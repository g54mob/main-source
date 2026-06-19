using UnityEngine;

public class ReservationTrigger : MonoBehaviour
{
	public BoundingBoxComponent bbcRef;

	public ReservableObject reservationRef;

	private void Awake()
	{
		reservationRef.SetTriggerBBC(bbcRef);
	}

	private void OnTriggerStay(Collider other)
	{
		if (!(other.transform == null))
		{
			reservationRef.OnTriggerStayReported(other.transform.root.gameObject);
		}
	}
}
