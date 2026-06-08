using System;
using System.Collections.Generic;
using UnityEngine;

public class FocusBiomeUpdater : MonoBehaviour
{
	[SerializeField]
	private BiomeManager biomeManager;

	[SerializeField]
	private Vector2 screenFocusPoint = new Vector2(0.5f, 0.3f);

	[SerializeField]
	private SettingsRouter settingsRouter;

	private IBiomeAffectedObject[] biomeAffectedObjects;

	private Camera mainCamera;

	private Vector3 previousFocusPoint = new Vector3(100000f, 10000f, 100000f);

	private Dictionary<Biome, float> previousBiomeInfluence;

	[SerializeField]
	private Vector2 debug_focusPos;

	public List<Debug_BiomeInfluence> debug_biomeInfluence;

	public event Action<Dictionary<Biome, float>> OnBiomeInfluenceChanged;

	private void Start()
	{
		mainCamera = OverwritingSingleton<IngameUi>.Instance.mainCamera;
		biomeAffectedObjects = GetComponents<IBiomeAffectedObject>();
		BiomeManager obj = biomeManager;
		obj.OnFocusBiomeUpdated = (Action<Dictionary<Biome, float>>)Delegate.Combine(obj.OnFocusBiomeUpdated, new Action<Dictionary<Biome, float>>(ApplyBiomeToObjects));
	}

	private void ApplyBiomeToObjects(Dictionary<Biome, float> focusBiomeInfluence)
	{
		IBiomeAffectedObject[] array = biomeAffectedObjects;
		for (int i = 0; i < array.Length; i++)
		{
			BiomeManager.ApplyBiomeToObject(array[i], focusBiomeInfluence);
		}
	}

	private Vector3 WorldFocusPoint()
	{
		Ray ray = mainCamera.ScreenPointToRay(new Vector3(screenFocusPoint.x * (float)Screen.width, screenFocusPoint.y * (float)Screen.height));
		new Plane(Vector3.up, Vector3.zero).Raycast(ray, out var enter);
		return ray.GetPoint(enter);
	}

	private void Update()
	{
		if (!settingsRouter.FocusBiomeEnabled)
		{
			return;
		}
		Vector3 vector = WorldFocusPoint();
		if (!(vector == previousFocusPoint))
		{
			previousFocusPoint = vector;
			Dictionary<Biome, float> dictionary = biomeManager.DetermineBiomeInfluence(vector, createSections: false);
			if (!ListHelper.Equals(previousBiomeInfluence, dictionary))
			{
				ApplyBiomeToObjects(dictionary);
				this.OnBiomeInfluenceChanged?.Invoke(dictionary);
				Debug.DrawLine(mainCamera.transform.position, vector, Color.red);
				DebugBiomeInfluence(dictionary);
				previousBiomeInfluence = dictionary;
			}
		}
	}

	public void DebugBiomeInfluence(Dictionary<Biome, float> biomeInfluenceDictionary)
	{
		debug_biomeInfluence.Clear();
		foreach (KeyValuePair<Biome, float> item in biomeInfluenceDictionary)
		{
			debug_biomeInfluence.Add(new Debug_BiomeInfluence(item.Key, item.Value));
		}
	}
}
