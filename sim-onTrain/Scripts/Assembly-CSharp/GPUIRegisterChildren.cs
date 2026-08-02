using System.Collections;
using System.Collections.Generic;
using GPUInstancerPro.PrefabModule;
using UnityEngine;

public class GPUIRegisterChildren : MonoBehaviour
{
	public GPUIPrefabManager prefabManager;

	[Header("Auto-Register Settings")]
	[Tooltip("Automatically register new children when they are added")]
	public bool autoRegisterNewChildren = true;

	[Tooltip("Delay before registering (helps with instantiation timing)")]
	public float registerDelay = 0.1f;

	private readonly HashSet<GPUIPrefab> registeredPrefabs = new HashSet<GPUIPrefab>();

	private void Awake()
	{
		if (prefabManager == null)
		{
			prefabManager = Object.FindObjectOfType<GPUIPrefabManager>();
		}
	}

	private void Start()
	{
		if (registerDelay > 0f)
		{
			StartCoroutine(DelayedRegister());
		}
		else
		{
			RegisterAllChildren();
		}
	}

	private void OnEnable()
	{
		if (registerDelay > 0f)
		{
			StartCoroutine(DelayedRegister());
		}
		else
		{
			RegisterAllChildren();
		}
	}

	private IEnumerator DelayedRegister()
	{
		yield return new WaitForSeconds(registerDelay);
		RegisterAllChildren();
	}

	private void OnTransformChildrenChanged()
	{
		if (autoRegisterNewChildren)
		{
			if (registerDelay > 0f)
			{
				StartCoroutine(DelayedRegister());
			}
			else
			{
				RegisterAllChildren();
			}
		}
	}

	public void RegisterAllChildren()
	{
		if (prefabManager == null)
		{
			prefabManager = Object.FindObjectOfType<GPUIPrefabManager>();
			if (prefabManager == null)
			{
				Debug.LogWarning("[GPUIRegisterChildren] No GPUIPrefabManager found in scene on " + base.gameObject.name);
				return;
			}
		}
		foreach (Transform item in base.transform)
		{
			RegisterChild(item);
		}
	}

	public void RegisterChild(Transform child)
	{
		if (!(child == null) && !(prefabManager == null))
		{
			GPUIPrefab component = child.GetComponent<GPUIPrefab>();
			if (component != null && !registeredPrefabs.Contains(component))
			{
				GPUIPrefabManager.AddPrefabInstance(component);
				registeredPrefabs.Add(component);
			}
		}
	}

	public void RegisterChildObject(GameObject child)
	{
		if (child != null)
		{
			RegisterChild(child.transform);
		}
	}

	public void UnregisterChild(Transform child)
	{
		if (!(child == null))
		{
			GPUIPrefab component = child.GetComponent<GPUIPrefab>();
			if (component != null)
			{
				registeredPrefabs.Remove(component);
			}
		}
	}

	private void OnDisable()
	{
		registeredPrefabs.Clear();
	}
}
