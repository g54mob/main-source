using System.Collections;
using UnityEngine;

public class DogPoopController : MonoBehaviour
{
	public InventoryItem poop;

	private bool needsPoop;

	private float poopTimerMin = 5f;

	private float poopTimerMax = 30f;

	private Coroutine poopCountdownRoutine;

	private float poopMeter;

	private float poopMeterMax = 10f;

	private float poopMeterEmergency = 15f;

	private float poopMeterAutoIncrement = 0.16f;

	private float poopSizeVariationLow = 0.85f;

	private float poopSizeVariationHigh = 1.15f;

	private string dogPoopSound = "dog_poop";

	private Transform buttRef;

	private Inchworm inchwormRef;

	private DogDenController denRef;

	private DogParticleController particleRef;

	private void Awake()
	{
		denRef = GetComponent<DogDenController>();
		particleRef = GetComponent<DogParticleController>();
		buttRef = GetComponent<LegController>().butt.transform;
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		inchwormRef = registrationScript.GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
	}

	private void Update()
	{
		if (NeedsToPoop() && poopMeter >= poopMeterMax)
		{
			poopMeter += Time.deltaTime * poopMeterAutoIncrement;
		}
	}

	public void OnBiteTaken()
	{
		if (!needsPoop && poopMeter < poopMeterMax)
		{
			poopMeter += 1f;
			if (poopMeter >= poopMeterMax)
			{
				StartPoopRoutine();
			}
		}
	}

	public float GetPoopMeter()
	{
		return poopMeter;
	}

	public void SetPoopMeter(float value)
	{
		poopMeter = value;
	}

	public void StartPoopRoutine()
	{
		if (poopCountdownRoutine == null)
		{
			poopCountdownRoutine = StartCoroutine(PoopCountdownRoutine());
		}
	}

	public bool IsInPoopRoutine()
	{
		return poopCountdownRoutine != null;
	}

	public bool NeedsToPoop()
	{
		return needsPoop;
	}

	public bool NeedsToPoopImmediately()
	{
		if (NeedsToPoop() && poopMeter >= poopMeterEmergency)
		{
			return true;
		}
		return false;
	}

	public void SetNeedsToPoop(bool newVal)
	{
		needsPoop = newVal;
	}

	public void Poop()
	{
		needsPoop = false;
		AudioController.Play(dogPoopSound, buttRef.position);
		GameObject gameObject = Object.Instantiate(poop.itemPrefab, buttRef.position, Quaternion.identity);
		ObjectRegistration.GetRegistrationScript().AssignID(gameObject, poop);
		particleRef.RequestSurpriseParticlesStart();
		StartCoroutine(PoopInRoutine(gameObject));
	}

	private IEnumerator PoopCountdownRoutine()
	{
		yield return new WaitForSeconds(Random.Range(poopTimerMin, poopTimerMax));
		needsPoop = true;
		poopCountdownRoutine = null;
	}

	private IEnumerator PoopInRoutine(GameObject newPoop)
	{
		float num = 1f;
		BoundingBoxComponent bbc = newPoop.GetComponent<BoundingBoxComponent>();
		ulong? expectedRoomUID = bbc.GetRoomUID();
		poopMeter = 0f;
		newPoop.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
		float num2 = Random.Range(base.transform.localScale.x * poopSizeVariationLow, base.transform.localScale.x * poopSizeVariationHigh);
		if (denRef.IsInDen())
		{
			newPoop.transform.localScale = new Vector3(num2, num2, num2);
			yield break;
		}
		WaitForFixedUpdate fixedWait = new WaitForFixedUpdate();
		inchwormRef.RequestEaseToScale(newPoop, new Vector3(num2, num2, num2), num, Inchworm.EaseStyle.ElasticOut);
		for (float totalWait = num; totalWait > 0f; totalWait -= Time.fixedDeltaTime)
		{
			yield return fixedWait;
			if (expectedRoomUID.HasValue && bbc != null)
			{
				bbc.MoveInsideRoom(expectedRoomUID.Value);
			}
		}
		Gravboost componentInChildren = newPoop.GetComponentInChildren<Gravboost>();
		if (componentInChildren != null)
		{
			componentInChildren.SetOrCreateBBCManual(newPoop);
		}
	}
}
