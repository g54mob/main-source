using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PeekRoom : MonoBehaviour
{
	public BoundingBoxComponent bbcRef;

	public CinemachineVirtualCamera peekCam;

	public ParticleSystem machineInDustParticles;

	public ParticleSystem fallingDirtParticlesHead;

	public ParticleSystem fallingDirtParticlesShoulders;

	public GameObject eggRef;

	public GameObject eggAltarRef;

	public GameObject spotlightRef;

	public BoxCollider floorColliderRef;

	public DogBreedingMachine breedingMachineRef;

	public GameObject loveParticles;

	public GameObject dogSpawnParticles;

	private Vector3 startingCameraPos = new Vector3(0f, -3.387f, -13.829f);

	private Vector3 startingCameraRot = new Vector3(13f, 0f, 0f);

	private Vector3 machineInCameraRot = new Vector3(-40f, 0f, 0f);

	private Vector3 snapPos_01 = new Vector3(0f, 48f, -210f);

	private Vector3 snapRot_01 = new Vector3(19f, 0f, 0f);

	private Vector3 snapPos_02 = new Vector3(0f, 26.17f, -100f);

	private Vector3 snapRot_02 = new Vector3(19f, 0f, 0f);

	private Vector3 snapPos_03 = new Vector3(0f, 13.23f, -48.47f);

	private Vector3 snapRot_03 = new Vector3(19f, 0f, 0f);

	private Vector3 snapPosFinal = new Vector3(0f, 8.2f, -13f);

	private Vector3 snapRotFinal = new Vector3(19f, 0f, 0f);

	private Vector3 fullMachinePos = new Vector3(0f, 9.5f, -27f);

	private Vector3 fullMachineRot = new Vector3(21f, 0f, 0f);

	private List<Renderer> leftRenderers = new List<Renderer>();

	private List<Renderer> rightRenderers = new List<Renderer>();

	private string cutsceneAudio = "cutscene_breeding";

	private void Awake()
	{
		floorColliderRef.enabled = false;
		peekCam.gameObject.SetActive(value: false);
	}

	public void PlacePeekDogA(GameObject dogA)
	{
		Renderer[] componentsInChildren = dogA.GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in componentsInChildren)
		{
			if (renderer.enabled)
			{
				renderer.enabled = false;
				leftRenderers.Add(renderer);
			}
		}
		PrepareDog(dogA);
		AttachDog(dogA, breedingMachineRef.leftArmAttachTransform);
	}

	public void PlacePeekDogB(GameObject dogB)
	{
		Renderer[] componentsInChildren = dogB.GetComponentsInChildren<Renderer>();
		foreach (Renderer renderer in componentsInChildren)
		{
			if (renderer.enabled)
			{
				renderer.enabled = false;
				rightRenderers.Add(renderer);
			}
		}
		PrepareDog(dogB);
		AttachDog(dogB, breedingMachineRef.rightArmAttachTransform, flip: true);
	}

	private void PrepareDog(GameObject dog)
	{
		dog.GetComponent<DogAI>().SetEnabled(enabledVal: false);
		dog.GetComponent<DoggyBrain>().SetNeedsFrozen(val: true);
		dog.GetComponent<DoggyBrain>().LockEmotionParticles();
		dog.GetComponent<DogNoises>().SetVocalizationAllowed(val: false);
		DogLooks component = dog.GetComponent<DogLooks>();
		if (!(component != null))
		{
			return;
		}
		if (component.leftWing != null)
		{
			List<WingController> list = new List<WingController>();
			list.AddRange(component.leftWing.GetComponentsInChildren<WingController>());
			for (int i = 0; i < list.Count; i++)
			{
				list[i].SetWingState(WingController.WingState.LOCKED);
			}
		}
		if (component.rightWing != null)
		{
			List<WingController> list2 = new List<WingController>();
			list2.AddRange(component.rightWing.GetComponentsInChildren<WingController>());
			for (int j = 0; j < list2.Count; j++)
			{
				list2[j].SetWingState(WingController.WingState.LOCKED);
			}
		}
	}

	private void AttachDog(GameObject dog, Transform handAttachTransform, bool flip = false)
	{
		if (flip)
		{
			dog.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
		}
		Transform transform = dog.GetComponent<LegController>().bodyFront.transform;
		transform.position = handAttachTransform.position;
		transform.position -= Vector3.forward * (transform.localScale.z / 2f);
		handAttachTransform.parent.gameObject.AddComponent<FixedJoint>().connectedBody = transform.GetComponent<Rigidbody>();
	}

	private void ShowDog(List<Renderer> renderers)
	{
		for (int i = 0; i < renderers.Count; i++)
		{
			renderers[i].enabled = true;
		}
	}

	public void OnRoutineStoppedEarly()
	{
		AudioController.Stop(cutsceneAudio);
	}

	public IEnumerator PeekRoutine(BreedingGUI guiRef)
	{
		peekCam.gameObject.SetActive(value: true);
		CinemachineBasicMultiChannelPerlin noiseController = peekCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
		float startingWait = 1f;
		float startingEaseTime = 5f;
		float startingCameraEaseTime = 4f;
		float cameraEarlyFinishBuffer = 0.25f;
		float easedInWait = 0.15f;
		float vibrationStoppedWait = 3f;
		float snapWaitInitial = 3f;
		float snapWaitIntermediary = 0.1f;
		float snapWaitFinal = 3f;
		float fullMachineViewWait = 1.5f;
		float dogSpawnWait = 2f;
		float finalWait = 1f;
		WaitForEndOfFrame frameWait = new WaitForEndOfFrame();
		Vector3 startingMachinePos = breedingMachineRef.GetStartingPosition();
		Vector3 startingMachineOffset = breedingMachineRef.GetStartingOffset();
		eggRef.SetActive(value: false);
		eggAltarRef.SetActive(value: true);
		spotlightRef.SetActive(value: false);
		noiseController.enabled = false;
		peekCam.transform.localPosition = startingCameraPos;
		peekCam.transform.rotation = Quaternion.Euler(startingCameraRot);
		AudioController.Play(cutsceneAudio);
		yield return new WaitForSeconds(2.25f);
		yield return new WaitForSeconds(1f);
		machineInDustParticles.Play();
		yield return new WaitForSeconds(1.5f);
		breedingMachineRef.SetVibrate(val: true);
		fallingDirtParticlesHead.Play();
		fallingDirtParticlesShoulders.Play();
		float currentEaseTime = 0f;
		while (currentEaseTime < startingEaseTime)
		{
			yield return frameWait;
			currentEaseTime += Time.deltaTime;
			float linearEasingValue = Inchworm.GetLinearEasingValue(currentEaseTime, startingMachinePos.y + startingMachineOffset.y, startingMachineOffset.y, startingEaseTime);
			breedingMachineRef.transform.position = new Vector3(breedingMachineRef.transform.position.x, linearEasingValue, breedingMachineRef.transform.position.z);
			float num = startingEaseTime - startingCameraEaseTime;
			float num2 = currentEaseTime - num;
			float num3 = startingCameraEaseTime - cameraEarlyFinishBuffer;
			if (num2 >= num3)
			{
				peekCam.transform.rotation = Quaternion.Euler(machineInCameraRot.x, 0f, 0f);
				continue;
			}
			float linearEasingValue2 = Inchworm.GetLinearEasingValue(num2, startingCameraRot.x, startingCameraRot.x - machineInCameraRot.x, num3);
			peekCam.transform.rotation = Quaternion.Euler(linearEasingValue2, 0f, 0f);
		}
		machineInDustParticles.Stop();
		fallingDirtParticlesHead.Stop();
		fallingDirtParticlesShoulders.Stop();
		floorColliderRef.enabled = true;
		breedingMachineRef.transform.position = startingMachinePos;
		peekCam.transform.rotation = Quaternion.Euler(machineInCameraRot);
		yield return new WaitForSeconds(easedInWait);
		breedingMachineRef.SetVibrate(val: false);
		yield return new WaitForSeconds(vibrationStoppedWait);
		noiseController.enabled = true;
		peekCam.transform.localPosition = snapPos_01;
		peekCam.transform.rotation = Quaternion.Euler(snapRot_01);
		yield return new WaitForSeconds(snapWaitInitial);
		peekCam.transform.localPosition = snapPos_02;
		peekCam.transform.rotation = Quaternion.Euler(snapRot_02);
		yield return new WaitForSeconds(snapWaitIntermediary);
		peekCam.transform.localPosition = snapPos_03;
		peekCam.transform.rotation = Quaternion.Euler(snapRot_03);
		yield return new WaitForSeconds(snapWaitIntermediary);
		peekCam.transform.localPosition = snapPosFinal;
		peekCam.transform.rotation = Quaternion.Euler(snapRotFinal);
		yield return new WaitForSeconds(snapWaitFinal);
		peekCam.transform.localPosition = fullMachinePos;
		peekCam.transform.rotation = Quaternion.Euler(fullMachineRot);
		yield return new WaitForSeconds(fullMachineViewWait);
		Object.Instantiate(dogSpawnParticles, breedingMachineRef.leftArmAttachTransform.position, Quaternion.identity);
		yield return new WaitForSeconds(0.25f);
		ShowDog(leftRenderers);
		yield return new WaitForSeconds(dogSpawnWait);
		Object.Instantiate(dogSpawnParticles, breedingMachineRef.rightArmAttachTransform.position, Quaternion.identity);
		yield return new WaitForSeconds(0.25f);
		ShowDog(rightRenderers);
		yield return new WaitForSeconds(fullMachineViewWait);
		breedingMachineRef.StartGearMovement();
		eggRef.SetActive(value: true);
		eggRef.transform.localPosition += breedingMachineRef.GetStartingEggOffset();
		float timer = startingWait;
		while (timer > 0f)
		{
			spotlightRef.SetActive((Random.value > 0.5f) ? true : false);
			timer -= Time.deltaTime;
			yield return frameWait;
		}
		spotlightRef.SetActive(value: true);
		yield return StartCoroutine(breedingMachineRef.SmashRoutine(eggRef, guiRef));
		yield return new WaitForSeconds(finalWait);
	}
}
