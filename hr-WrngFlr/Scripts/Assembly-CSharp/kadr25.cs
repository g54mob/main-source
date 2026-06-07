using UnityEngine;

public class kadr25 : MonoBehaviour
{
	public GameObject cam1;

	public GameObject cam2;

	private int t;

	public int maxt;

	private void FixedUpdate()
	{
		if (t >= maxt)
		{
			cam1.SetActive(value: false);
			cam2.SetActive(value: true);
			t = 0;
		}
		else
		{
			cam2.SetActive(value: false);
			cam1.SetActive(value: true);
		}
		t++;
	}
}
