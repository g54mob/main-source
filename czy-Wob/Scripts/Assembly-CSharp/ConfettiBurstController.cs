using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiBurstController : MonoBehaviour
{
	public GameObject burstBase;

	public List<Material> confettiMaterials = new List<Material>();

	public float startDelay;

	private int destroyedBursts;

	private void Awake()
	{
		if (startDelay == 0f)
		{
			SetupConfetti();
		}
		else
		{
			StartCoroutine(DelayedSetup());
		}
	}

	public void OnDestroy()
	{
		destroyedBursts++;
		if (destroyedBursts >= confettiMaterials.Count)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private IEnumerator DelayedSetup()
	{
		yield return new WaitForSeconds(startDelay);
		SetupConfetti();
	}

	private void SetupConfetti()
	{
		for (int i = 0; i < confettiMaterials.Count; i++)
		{
			GameObject obj = Object.Instantiate(burstBase, base.transform, worldPositionStays: false);
			obj.GetComponent<Renderer>().material = confettiMaterials[i];
			obj.GetComponent<ParticleBurstConfetti>().SetController(this, i);
		}
	}
}
