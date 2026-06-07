using UnityEngine;

public class Delete : MonoBehaviour
{
	public bool turnOffAfterTime = true;

	public bool destroy;

	public float time;

	public bool randomTime;

	private void OnEnable()
	{
		if (turnOffAfterTime)
		{
			CancelInvoke("TurnOff");
			float num = time;
			if (randomTime)
			{
				num = time + Random.Range(-0.9f, 0.9f);
			}
			Invoke("TurnOff", num);
		}
	}

	public void TurnOff()
	{
		if (destroy)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
