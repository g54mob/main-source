using UnityEngine;

public class opttrig : MonoBehaviour
{
	public opt optt;

	public int r;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			optt.on[r]++;
			optt.a();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			optt.on[r]--;
			optt.a();
		}
	}
}
