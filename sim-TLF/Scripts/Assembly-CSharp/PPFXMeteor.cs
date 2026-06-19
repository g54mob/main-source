using System.Collections;
using UnityEngine;

public class PPFXMeteor : MonoBehaviour
{
	private Vector3 groundPos = new Vector3(0f, 0f, 0f);

	public Vector3 spawnPosOffset = new Vector3(0f, 0f, 0f);

	public float speed = 10f;

	public GameObject detonationPrefab;

	public bool destroyOnHit;

	public bool setRateToNull;

	private float dist;

	private float radius = 2f;

	private ParticleSystem[] psystems;

	private void Start()
	{
		groundPos = base.transform.position;
		base.transform.position = base.transform.position + spawnPosOffset;
		dist = Vector3.Distance(base.transform.position, groundPos);
		StartCoroutine(Move());
	}

	private IEnumerator Move()
	{
		psystems = GetComponentsInChildren<ParticleSystem>();
		ParticleSystem[] array = psystems;
		for (int i = 0; i < array.Length; i++)
		{
			ParticleSystem.EmissionModule emission = array[i].emission;
			ParticleSystem.MinMaxCurve rateOverTime = emission.rateOverTime;
			rateOverTime.constantMax *= speed / 10f;
			emission.rateOverTime = rateOverTime;
		}
		while (dist > radius)
		{
			float maxDistanceDelta = speed * Time.deltaTime;
			base.transform.position = Vector3.MoveTowards(base.transform.position, groundPos, maxDistanceDelta);
			dist = Vector3.Distance(base.transform.position, groundPos);
			yield return null;
		}
		if (destroyOnHit)
		{
			Object.Destroy(base.gameObject);
		}
		else if (setRateToNull)
		{
			array = psystems;
			for (int i = 0; i < array.Length; i++)
			{
				ParticleSystem.EmissionModule emission2 = array[i].emission;
				ParticleSystem.MinMaxCurve rateOverTime2 = emission2.rateOverTime;
				rateOverTime2.constantMax = 0f;
				emission2.rateOverTime = rateOverTime2;
			}
			GetComponent<PPFXAutodestruct>().DestroyPSystem(base.gameObject);
		}
		else
		{
			array = psystems;
			for (int i = 0; i < array.Length; i++)
			{
				ParticleSystem.EmissionModule emission3 = array[i].emission;
				ParticleSystem.MinMaxCurve rateOverTime3 = emission3.rateOverTime;
				rateOverTime3.constantMax /= speed / 10f;
				emission3.rateOverTime = rateOverTime3;
			}
		}
		if (detonationPrefab != null)
		{
			Object.Instantiate(detonationPrefab, base.transform.position, detonationPrefab.transform.rotation);
		}
	}
}
