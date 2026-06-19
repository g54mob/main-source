using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SneezeBehavior : MonoBehaviour
{
	public delegate void SneezeFinishedCallback();

	private float windupMin = 0.1f;

	private float windupMax = 1f;

	private float openEyesPercentage = 0.5f;

	private Vector3 sneezeImpulse = new Vector3(-100f, 0f, 0f);

	private Coroutine currentSneezeRoutine;

	private DogNoises noisesRef;

	private FaceController faceController;

	private DogParticleController particleRef;

	private void Awake()
	{
		noisesRef = GetComponent<DogNoises>();
		faceController = GetComponent<FaceController>();
		particleRef = GetComponent<DogParticleController>();
	}

	public void RequestSneeze(SneezeFinishedCallback callback = null)
	{
		if (currentSneezeRoutine != null)
		{
			Debug.LogError("Attempting to sneeze but we're already sneezing.");
		}
		else
		{
			currentSneezeRoutine = StartCoroutine(SneezeRoutine(callback));
		}
	}

	public void RequestSneezeStop()
	{
		if (currentSneezeRoutine != null)
		{
			StopCoroutine(currentSneezeRoutine);
			currentSneezeRoutine = null;
		}
		faceController.ClearOverrideFaceRot();
		faceController.RequestFace(Face.DEFAULT);
	}

	private IEnumerator SneezeRoutine(SneezeFinishedCallback callback)
	{
		float windup = Random.Range(windupMin, windupMax);
		WaitForEndOfFrame waitRef = new WaitForEndOfFrame();
		faceController.CancelEmote();
		List<DogHead> allDogHeads = faceController.GetAllDogHeads();
		DogHead chosenHead = ListUtil.GetRandomElement(allDogHeads);
		float startAngle = 0f;
		if (!faceController.OldHead())
		{
			startAngle = chosenHead.emoteJoint.targetRotation.eulerAngles.y;
		}
		float timer = 0f;
		while (timer < windup)
		{
			if (timer < windup * openEyesPercentage && timer + Time.deltaTime >= windup * openEyesPercentage)
			{
				faceController.RequestFace(Face.SURPRISED, -1f, suppressEmote: true);
			}
			timer += Time.deltaTime;
			if (!faceController.OldHead())
			{
				float easeInQuartValue = Inchworm.GetEaseInQuartValue(Mathf.Min(timer, windup), startAngle, 65f, windup);
				Vector3 eulerAngles = chosenHead.emoteJoint.targetRotation.eulerAngles;
				Quaternion overrideFaceRot = Quaternion.Euler(eulerAngles.x, easeInQuartValue, eulerAngles.z);
				faceController.SetOverrideFaceRot(overrideFaceRot);
			}
			yield return waitRef;
		}
		faceController.ClearOverrideFaceRot();
		if (!faceController.OldHead())
		{
			chosenHead.emoteJoint.GetComponent<Rigidbody>().AddRelativeForce(sneezeImpulse, ForceMode.Impulse);
		}
		yield return new WaitForSeconds(0.1f);
		noisesRef.RequestSneeze();
		faceController.RequestFace(Face.WINCE, 0.5f, suppressEmote: true);
		DogBehaviorBase currentBehavior = GetComponent<DogAI>().GetCurrentBehavior();
		if (currentBehavior != null)
		{
			currentBehavior.AwardBehaviorDefinedLoot();
		}
		yield return new WaitForSeconds(0.05f);
		particleRef.RequestSneezeParticlesStart();
		yield return new WaitForSeconds(0.95f);
		callback?.Invoke();
		currentSneezeRoutine = null;
	}
}
