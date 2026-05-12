using UnityEngine;

public class tryaska : MonoBehaviour
{
	public float rand;

	public float flrand;

	public float flrandmax;

	public float flrandmin;

	public float fps;

	public float fltime;

	public GameObject fl;

	private void Update()
	{
		Application.targetFrameRate = (int)fps;
		base.transform.eulerAngles += new Vector3(Random.Range(0f - rand, rand), Random.Range(0f - rand, rand));
		if (flrand > 0f)
		{
			flrand = Random.Range(flrandmin, flrandmax);
			fl.SetActive(value: false);
			Invoke("a", fltime);
		}
		flrand += Time.deltaTime;
	}

	public void a()
	{
		fl.SetActive(value: true);
	}
}
