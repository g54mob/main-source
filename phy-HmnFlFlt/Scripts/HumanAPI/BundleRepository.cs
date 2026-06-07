using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BundleRepository
{
	public static Dictionary<string, AssetBundle> loadedBundles = new Dictionary<string, AssetBundle>();

	public static AssetBundle LoadBundle(string bundleName)
	{
		if (loadedBundles.ContainsKey(bundleName))
		{
			return loadedBundles[bundleName];
		}
		AssetBundle assetBundle = AssetBundle.LoadFromFile(Path.Combine("C:\\Research\\DynamicLoading\\AssetBundle\\Assets\\AssetBundles", bundleName));
		if (assetBundle != null)
		{
			loadedBundles[bundleName] = assetBundle;
		}
		return assetBundle;
	}

	public static void UnloadBundle(string bundleName)
	{
		AssetBundle value;
		if (loadedBundles.TryGetValue(bundleName, out value))
		{
			value.Unload(false);
			loadedBundles.Remove(bundleName);
		}
	}

	public static void UnloadAll()
	{
		AssetBundle.UnloadAllAssetBundles(false);
		loadedBundles.Clear();
	}

	public static GameObject GetPrefab(string bundleName, string prefabName)
	{
		AssetBundle assetBundle = LoadBundle(bundleName);
		if (assetBundle == null)
		{
			Debug.LogFormat("Unable to load bundle {0} for prefab {1}", bundleName, prefabName);
			return null;
		}
		GameObject gameObject = assetBundle.LoadAsset<GameObject>(prefabName);
		if (gameObject == null)
		{
			Debug.LogFormat("Unable to load prefab {1} from bundle {0}", bundleName, prefabName);
			return null;
		}
		return gameObject;
	}

	public static GameObject Instantiate(string bundleName, string prefabName)
	{
		AssetBundle assetBundle = LoadBundle(bundleName);
		if (assetBundle != null)
		{
			GameObject gameObject = assetBundle.LoadAsset<GameObject>(prefabName);
			if (gameObject != null)
			{
				GameObject gameObject2 = Object.Instantiate(gameObject);
				BundleReference bundleReference = gameObject2.AddComponent<BundleReference>();
				bundleReference.bundle = bundleName;
				bundleReference.prefab = prefabName;
				BindHierarchy(gameObject.transform, bundleReference.transform);
				return gameObject2;
			}
			Debug.LogFormat("Unable to load {0} from bundle {1}", prefabName, bundleName);
		}
		else
		{
			Debug.LogFormat("Unable to load {0} from bundle {1}", prefabName, bundleName);
		}
		return null;
	}

	public static void RebindScene(Scene scene)
	{
		GameObject[] rootGameObjects = scene.GetRootGameObjects();
		foreach (GameObject gameObject in rootGameObjects)
		{
			BundleReference[] componentsInChildren = gameObject.GetComponentsInChildren<BundleReference>();
			BundleReference[] array = componentsInChildren;
			foreach (BundleReference bundleRef in array)
			{
				RebindPrefab(bundleRef);
			}
		}
	}

	public static void StripScene(Scene scene)
	{
		GameObject[] rootGameObjects = scene.GetRootGameObjects();
		foreach (GameObject gameObject in rootGameObjects)
		{
			BundleReference[] componentsInChildren = gameObject.GetComponentsInChildren<BundleReference>();
			BundleReference[] array = componentsInChildren;
			foreach (BundleReference bundleRef in array)
			{
				StripPrefab(bundleRef);
			}
		}
	}

	public static void StripPrefab(BundleReference bundleRef)
	{
		StripHierarchy(bundleRef.transform);
	}

	public static void RebindPrefab(BundleReference bundleRef)
	{
		AssetBundle assetBundle = LoadBundle(bundleRef.bundle);
		if (assetBundle != null)
		{
			GameObject gameObject = assetBundle.LoadAsset<GameObject>(bundleRef.prefab);
			if (gameObject != null)
			{
				BindHierarchy(gameObject.transform, bundleRef.transform);
				return;
			}
			Debug.LogFormat("Unable to load {0} from bundle {1}", bundleRef.prefab, bundleRef.bundle);
		}
		else
		{
			Debug.LogFormat("Unable to load {0} from bundle {1}", bundleRef.prefab, bundleRef.bundle);
		}
	}

	private static void BindHierarchy(Transform src, Transform dst)
	{
		MeshRenderer component = src.GetComponent<MeshRenderer>();
		MeshRenderer component2 = dst.GetComponent<MeshRenderer>();
		if (component != null && component2 != null)
		{
			component2.sharedMaterials = component.sharedMaterials;
			Material[] sharedMaterials = component2.sharedMaterials;
			foreach (Material material in sharedMaterials)
			{
				if (material.shader.name.Equals("Standard"))
				{
					material.shader = Shader.Find("Standard");
				}
			}
		}
		for (int j = 0; j < src.childCount; j++)
		{
			Transform child = src.GetChild(j);
			Transform transform = dst.Find(child.name);
			if (transform != null)
			{
				BindHierarchy(child, transform);
			}
		}
	}

	private static void StripHierarchy(Transform dst)
	{
		MeshRenderer component = dst.GetComponent<MeshRenderer>();
		if (component != null)
		{
			Material[] sharedMaterials = component.sharedMaterials;
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				sharedMaterials[i] = null;
			}
			component.sharedMaterials = sharedMaterials;
		}
		for (int j = 0; j < dst.childCount; j++)
		{
			Transform child = dst.GetChild(j);
			if (child != null)
			{
				StripHierarchy(child);
			}
		}
	}
}
