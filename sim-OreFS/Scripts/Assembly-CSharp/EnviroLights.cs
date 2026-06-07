using System.Collections;
using System.Collections.Generic;
using Enviro;
using Mirror;
using UnityEngine;

public class EnviroLights : MonoBehaviour
{
	[Header("Gece Acilacak Objeler")]
	[Tooltip("Isik saatlerinde acilacak objeler (DayNightManager'daki lightsOnHour-lightsOffHour)")]
	[SerializeField]
	private List<GameObject> nightObjects = new List<GameObject>();

	[Header("Materyal Degisimi")]
	[Tooltip("Gece/gunduz materyal degisimi yapilsin mi?")]
	[SerializeField]
	private bool changeMaterials;

	[Tooltip("Materyal degistirilecek MeshRenderer'lar")]
	[SerializeField]
	private List<MeshRenderer> materialRenderers = new List<MeshRenderer>();

	[Tooltip("Gunduz materyali")]
	[SerializeField]
	private Material dayMaterial;

	[Tooltip("Gece materyali")]
	[SerializeField]
	private Material nightMaterial;

	[Header("Ayarlar")]
	[Tooltip("Baslangicta objelerin durumunu ayarla")]
	[SerializeField]
	private bool setStateOnStart = true;

	[Tooltip("Network hazir olduktan sonra ek bekleme suresi")]
	[SerializeField]
	private float additionalDelay = 0.5f;

	private void Start()
	{
		StartCoroutine(InitializeAfterNetwork());
	}

	private IEnumerator InitializeAfterNetwork()
	{
		while (!NetworkClient.ready)
		{
			yield return null;
		}
		yield return new WaitForSeconds(additionalDelay);
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnLightsStateChanged += OnLightsStateChanged;
			if (setStateOnStart)
			{
				SetObjectsState(DayNightManager.Instance.ShouldLightsBeOn);
				if (changeMaterials)
				{
					SwapMaterials(DayNightManager.Instance.ShouldLightsBeOn);
				}
			}
		}
		else
		{
			Debug.LogWarning("[EnviroLights] DayNightManager bulunamadi!");
		}
	}

	private void OnDestroy()
	{
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnLightsStateChanged -= OnLightsStateChanged;
		}
	}

	private void OnLightsStateChanged(bool lightsOn)
	{
		SetObjectsState(lightsOn);
		if (changeMaterials)
		{
			SwapMaterials(lightsOn);
		}
	}

	private void SwapMaterials(bool isNight)
	{
		if (dayMaterial == null || nightMaterial == null)
		{
			return;
		}
		Material material = (isNight ? dayMaterial : nightMaterial);
		Material material2 = (isNight ? nightMaterial : dayMaterial);
		foreach (MeshRenderer materialRenderer in materialRenderers)
		{
			if (materialRenderer == null)
			{
				continue;
			}
			Material[] sharedMaterials = materialRenderer.sharedMaterials;
			bool flag = false;
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				if (sharedMaterials[i] != null && sharedMaterials[i].name == material.name)
				{
					sharedMaterials[i] = material2;
					flag = true;
				}
			}
			if (flag)
			{
				materialRenderer.sharedMaterials = sharedMaterials;
			}
		}
	}

	private void SetObjectsState(bool active)
	{
		foreach (GameObject nightObject in nightObjects)
		{
			if (nightObject != null)
			{
				nightObject.SetActive(active);
			}
		}
	}

	public void AddObject(GameObject obj)
	{
		if (obj != null && !nightObjects.Contains(obj))
		{
			nightObjects.Add(obj);
		}
	}

	public void RemoveObject(GameObject obj)
	{
		nightObjects.Remove(obj);
	}

	public void ClearObjects()
	{
		nightObjects.Clear();
	}
}
