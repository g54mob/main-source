using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogParticleController : MonoBehaviour
{
	public GameObject sleepParticles;

	private float sleepParticlesDestroyTimer = -1f;

	private List<int> systemsToDestroy = new List<int>();

	public GameObject happyUpdateParticles;

	public GameObject angerUpdateParticles;

	public GameObject stressUpdateParticles;

	private float emotionalUpdateParticlesDestroyTimerHappy = 2f;

	private float emotionalUpdateParticlesDestroyTimerStress = 1f;

	private float emotionalUpdateParticlesDestroyTimerAnger = 0.75f;

	private float emotionalUpdateFaceswapTimer = 1f;

	private float emotionalUpdateFaceswapTimerSurprise = 0.5f;

	private Vector3 emotionalUpdateParticleLocalSpaceOffset = new Vector3(1.009f, 0.645f, 1.18f);

	private int currentEmotionalUpdateKey = -1;

	public GameObject surpriseParticles;

	private float surpriseParticlesDestroyTimer = 5f;

	private Vector3 surpriseParticleWorldspaceOffset = new Vector3(0f, 1.25f, 0f);

	public GameObject sneezeParticles;

	private float sneezeParticlesDestroyTimer = -1f;

	public GameObject barfParticles;

	private float barfParticlesDestroyTimer = 4f;

	public GameObject chokingParticles;

	private float chokingParticlesDestroyTimer = 4f;

	public GameObject biteParticles;

	private float biteParticlesDestroyTimer = 1.5f;

	public GameObject angrySteamParticles;

	private float angrySteamParticlesDestroyTimer = -1f;

	private Vector3 angrySteamParticleLocalSpaceOffset = new Vector3(0.6f, 0f, 1f);

	public GameObject stressParticles;

	private float stressParticlesDestroyTimer = -1f;

	private Vector3 stressParticlesLocalSpaceOffset = new Vector3(0.6f, 0f, 1f);

	private float dogReactionTime = 0.15f;

	private int keyCount;

	private Dictionary<int, ParticleInfo> particleDict = new Dictionary<int, ParticleInfo>();

	private List<int> destructionParticles = new List<int>();

	private Transform noseRef;

	private FaceController faceControllerRef;

	private void Awake()
	{
		noseRef = GetComponent<DogLooks>().nose.transform;
		faceControllerRef = GetComponent<FaceController>();
	}

	private void OnDestroy()
	{
		List<int> list = new List<int>();
		list.AddRange(particleDict.Keys);
		for (int i = 0; i < list.Count; i++)
		{
			RequestParticlesEnd(list[i]);
		}
	}

	private void Update()
	{
		CheckDestruction();
	}

	public void SetVisibility(bool val)
	{
		foreach (int key in particleDict.Keys)
		{
			if (!(particleDict[key].particleObject == null))
			{
				ParticleSystemRenderer[] componentsInChildren = particleDict[key].particleObject.GetComponentsInChildren<ParticleSystemRenderer>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].enabled = val;
				}
			}
		}
	}

	private void CheckDestruction()
	{
		systemsToDestroy.Clear();
		for (int i = 0; i < destructionParticles.Count; i++)
		{
			ParticleInfo value = particleDict[destructionParticles[i]];
			value.currentDestroyTimer -= Time.deltaTime;
			if (value.currentDestroyTimer <= 0f)
			{
				systemsToDestroy.Add(destructionParticles[i]);
			}
			particleDict[destructionParticles[i]] = value;
		}
		for (int j = 0; j < systemsToDestroy.Count; j++)
		{
			InternalDestroySystem(systemsToDestroy[j]);
		}
	}

	public int RequestHappyUpdateParticles()
	{
		if (particleDict.ContainsKey(currentEmotionalUpdateKey))
		{
			return -1;
		}
		GameObject particleBase = GetParticleBase(happyUpdateParticles);
		particleBase.transform.localPosition += emotionalUpdateParticleLocalSpaceOffset;
		currentEmotionalUpdateKey = AddParticleObject(particleBase, emotionalUpdateParticlesDestroyTimerHappy);
		return currentEmotionalUpdateKey;
	}

	public int RequestAngryUpdateParticles()
	{
		if (particleDict.ContainsKey(currentEmotionalUpdateKey))
		{
			return -1;
		}
		GameObject particleBase = GetParticleBase(angerUpdateParticles);
		particleBase.transform.localPosition += emotionalUpdateParticleLocalSpaceOffset;
		faceControllerRef.RequestFace(Face.ANGRY, emotionalUpdateFaceswapTimer, suppressEmote: true);
		currentEmotionalUpdateKey = AddParticleObject(particleBase, emotionalUpdateParticlesDestroyTimerAnger);
		return currentEmotionalUpdateKey;
	}

	public int RequestStressUpdateParticles()
	{
		if (particleDict.ContainsKey(currentEmotionalUpdateKey))
		{
			return -1;
		}
		GameObject particleBase = GetParticleBase(stressUpdateParticles);
		particleBase.transform.localPosition += emotionalUpdateParticleLocalSpaceOffset;
		faceControllerRef.RequestFace(Face.WINCE, emotionalUpdateFaceswapTimer);
		currentEmotionalUpdateKey = AddParticleObject(particleBase, emotionalUpdateParticlesDestroyTimerStress);
		return currentEmotionalUpdateKey;
	}

	public int RequestSleepParticlesStart()
	{
		return AddParticleObject(GetParticleBase(sleepParticles), sleepParticlesDestroyTimer);
	}

	public int RequestAngrySteamParticlesStart()
	{
		GameObject particleBase = GetParticleBase(angrySteamParticles);
		particleBase.transform.localPosition += angrySteamParticleLocalSpaceOffset;
		return AddParticleObject(particleBase, angrySteamParticlesDestroyTimer);
	}

	public int RequestStressParticlesStart()
	{
		GameObject particleBase = GetParticleBase(stressParticles);
		particleBase.transform.localPosition += stressParticlesLocalSpaceOffset;
		return AddParticleObject(particleBase, stressParticlesDestroyTimer);
	}

	public void RequestSurpriseParticlesStart(bool lockAI = true, bool immediate = false)
	{
		StartCoroutine(SurpriseParticlesRoutine(lockAI, immediate));
	}

	private IEnumerator SurpriseParticlesRoutine(bool lockAI, bool immediate)
	{
		if (!immediate)
		{
			yield return new WaitForSeconds(dogReactionTime);
		}
		GameObject particleBase = GetParticleBase(surpriseParticles);
		particleBase.transform.position += surpriseParticleWorldspaceOffset;
		faceControllerRef.RequestFace(Face.SURPRISED, emotionalUpdateFaceswapTimerSurprise, suppressEmote: false, lockAI);
		AddParticleObject(particleBase, surpriseParticlesDestroyTimer);
	}

	public int RequestBiteParticlesStart(int headIndex)
	{
		GameObject particleBase = GetParticleBase(biteParticles, headIndex);
		return AddParticleObject(particleBase, biteParticlesDestroyTimer);
	}

	public int RequestBarfParticlesStart(int headIndex)
	{
		GameObject particleBase = GetParticleBase(barfParticles, headIndex);
		return AddParticleObject(particleBase, barfParticlesDestroyTimer);
	}

	public int RequestSneezeParticlesStart()
	{
		GameObject noseParticlesBase = GetNoseParticlesBase(sneezeParticles);
		return AddParticleObject(noseParticlesBase, sneezeParticlesDestroyTimer);
	}

	public int RequestChokingParticlesStart(int headIndex)
	{
		GameObject particleBase = GetParticleBase(chokingParticles, headIndex);
		return AddParticleObject(particleBase, chokingParticlesDestroyTimer);
	}

	private GameObject GetParticleBase(GameObject prefabType, int headIndex = 0)
	{
		Transform mouthTransform = faceControllerRef.GetDogHeadForIndex(headIndex).mouthTransform;
		GameObject obj = Object.Instantiate(prefabType);
		obj.transform.localScale = new Vector3(1f / mouthTransform.localScale.x, 1f, 1f);
		obj.transform.localScale *= mouthTransform.root.localScale.x;
		obj.transform.SetParent(mouthTransform);
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localRotation = Quaternion.identity;
		return obj;
	}

	private GameObject GetNoseParticlesBase(GameObject prefabType)
	{
		GameObject obj = Object.Instantiate(prefabType);
		obj.transform.SetParent(noseRef);
		obj.transform.localScale = Vector3.one;
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localRotation = Quaternion.identity;
		obj.transform.SetParent(null);
		return obj;
	}

	private int AddParticleObject(GameObject obj, float destroyTimer = -1f)
	{
		keyCount++;
		ParticleInfo value = new ParticleInfo
		{
			particleObject = obj
		};
		if (destroyTimer != -1f)
		{
			value.destroyTimer = destroyTimer;
			value.currentDestroyTimer = destroyTimer;
			destructionParticles.Add(keyCount);
		}
		particleDict[keyCount] = value;
		return keyCount;
	}

	public void RequestParticlesEnd(int key)
	{
		if (!particleDict.ContainsKey(key))
		{
			Debug.LogError("Attempting to end particles for key " + key + " but that key is not in the particle dict.");
			return;
		}
		ParticleInfo value = particleDict[key];
		if (value.destroyTimer < 0f)
		{
			InternalDestroySystem(key);
			return;
		}
		if (value.particleObject != null)
		{
			ParticleSystem componentInChildren = value.particleObject.GetComponentInChildren<ParticleSystem>();
			if (componentInChildren != null)
			{
				componentInChildren.Stop();
			}
		}
		value.currentDestroyTimer = value.destroyTimer;
		particleDict[key] = value;
		destructionParticles.Add(key);
	}

	private void InternalDestroySystem(int key)
	{
		Object.Destroy(particleDict[key].particleObject);
		particleDict.Remove(key);
		destructionParticles.Remove(key);
	}
}
