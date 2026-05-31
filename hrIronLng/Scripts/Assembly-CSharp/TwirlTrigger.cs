using UnityEngine;

public class TwirlTrigger : MonoBehaviour
{
	private GameObject plr;

	public float MaxRange;

	public float MaxTwirl;

	private TwirlManagerScript Manager;

	private void Start()
	{
		plr = GameObject.Find("FakeSub");
		Manager = GameObject.Find("PlayerCamera").GetComponent<TwirlManagerScript>();
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
		float num = Vector3.Distance(base.transform.position, plr.transform.position);
		float num2 = MaxRange - num;
		if (num2 < 0f)
		{
			num2 = 0f;
		}
		Manager.TwirlAmount = num2 * MaxTwirl / MaxRange;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(base.transform.position, MaxRange);
	}
}
