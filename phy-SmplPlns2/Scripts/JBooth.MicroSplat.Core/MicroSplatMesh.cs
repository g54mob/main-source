using System;
using System.Collections.Generic;
using JBooth.MicroSplat;
using UnityEngine;

[ExecuteInEditMode]
[DisallowMultipleComponent]
public class MicroSplatMesh : MicroSplatObject
{
	public delegate void MaterialSyncAll();

	public delegate void MaterialSync(Material m);

	[Serializable]
	public class SubMeshOverride
	{
		public string materialName;

		public bool active;

		public bool bUVOverride;

		public Vector4 UVOverride = new Vector4(1f, 1f, 0f, 0f);

		public Texture2D[] controlTextures = new Texture2D[0];

		public Texture2D displacementDampening;

		public Texture2D streamTex;

		public Texture2D tint;

		public bool bUVRangeOverride;

		public Vector4 uvRange = new Vector4(1f, 1f, 0.5f, 0.5f);

		public long GetHash()
		{
			long num = 3L;
			num += ((displacementDampening == null) ? 3 : displacementDampening.GetNativeTexturePtr().ToInt64()) * 3;
			num += ((streamTex == null) ? 13 : streamTex.GetNativeTexturePtr().ToInt64()) * 13;
			num += ((tint == null) ? 7 : tint.GetNativeTexturePtr().ToInt64()) * 7;
			if (bUVOverride)
			{
				num += UVOverride.GetHashCode() * 11;
			}
			num += (int)(uvRange.x * 1000f + uvRange.y * 1000f + uvRange.z * 1000f + uvRange.w * 1000f);
			if (controlTextures != null)
			{
				for (int i = 0; i < controlTextures.Length; i++)
				{
					num *= ((controlTextures[i] == null) ? (7 * (i + 1)) : (controlTextures[i].GetNativeTexturePtr().ToInt64() + i));
				}
			}
			if (num == 0L)
			{
				Debug.Log("Submesh override hash returned 0, this should not happen");
			}
			return num;
		}
	}

	[Serializable]
	public class SplatOverride
	{
		public bool bDisplacementOverride;

		public float displacementOverride = 1f;

		public Vector4 subArray = new Vector4(0f, 1f, 2f, 3f);

		public long GetHash()
		{
			long num = 3L + (long)(subArray.GetHashCode() * 13) + (bDisplacementOverride ? 5 : 17) + (int)(displacementOverride * 1000f) * 21;
			if (num == 0L)
			{
				Debug.Log("Splat override hash returned 0, this should not happen");
			}
			return num;
		}
	}

	[Serializable]
	public class SubMeshEntry
	{
		public CombinedOverride combinedOverride = new CombinedOverride();

		public SubMeshOverride subMeshOverride = new SubMeshOverride();

		public Material matInstance;

		public long oldKey;

		public long GetHash()
		{
			return combinedOverride.GetHash() * 7 + subMeshOverride.GetHash() * 3;
		}
	}

	public struct MaterialInstranceEntry
	{
		public int refCount;

		public Material matInstance;
	}

	private static List<MicroSplatMesh> sInstances = new List<MicroSplatMesh>();

	[HideInInspector]
	public MeshRenderer rend;

	public SplatOverride splatOverride = new SplatOverride();

	public List<SubMeshEntry> subMeshEntries = new List<SubMeshEntry>();

	private static Dictionary<long, MaterialInstranceEntry> materialRegistry = new Dictionary<long, MaterialInstranceEntry>();

	public static event MaterialSyncAll OnMaterialSyncAll;

	public event MaterialSync OnMaterialSync;

	public static int GetRegistrySize()
	{
		return materialRegistry.Count;
	}

	public static void ClearMaterialCache()
	{
		foreach (KeyValuePair<long, MaterialInstranceEntry> item in materialRegistry)
		{
			if (item.Value.matInstance != null)
			{
				UnityEngine.Object.DestroyImmediate(item.Value.matInstance);
			}
		}
		materialRegistry.Clear();
		SyncAll();
	}

	private long GetMaterialInstanceHash(int subMesh)
	{
		if (templateMaterial == null)
		{
			return 0L;
		}
		long num = 3L;
		num += templateMaterial.GetInstanceID();
		num += templateMaterial.shader.GetInstanceID();
		if (subMesh < subMeshEntries.Count)
		{
			num += subMeshEntries[subMesh].GetHash();
		}
		num += splatOverride.GetHash();
		num += GetOverrideHash();
		if (num == 0L)
		{
			Debug.LogError("Material instance hash is 0");
		}
		return num;
	}

	private void Cleanup(long key, int subMesh)
	{
		if (subMesh >= subMeshEntries.Count || key == 0L)
		{
			return;
		}
		if (materialRegistry.TryGetValue(key, out var value))
		{
			value.refCount--;
			subMeshEntries[subMesh].matInstance = null;
			if (value.refCount < 0)
			{
				Debug.LogError("Reference count < 0, something is broken");
			}
			if (value.refCount == 0)
			{
				if (value.matInstance != null)
				{
					UnityEngine.Object.DestroyImmediate(value.matInstance);
					value.matInstance = null;
				}
				materialRegistry.Remove(key);
			}
			else
			{
				materialRegistry[key] = value;
			}
		}
		subMeshEntries[subMesh].oldKey = 0L;
	}

	private void Cleanup()
	{
		for (int i = 0; i < subMeshEntries.Count; i++)
		{
			Cleanup(subMeshEntries[i].oldKey, i);
		}
	}

	private Material GetMaterialInstance(int subMesh)
	{
		long materialInstanceHash = GetMaterialInstanceHash(subMesh);
		if (materialInstanceHash == 0L)
		{
			Debug.LogError("0 key found, check hashing functions");
		}
		if (subMesh >= subMeshEntries.Count)
		{
			Debug.LogError("SubMesh out of range");
		}
		SubMeshEntry subMeshEntry = subMeshEntries[subMesh];
		if (subMeshEntry.oldKey != materialInstanceHash)
		{
			Cleanup(subMeshEntry.oldKey, subMesh);
		}
		subMeshEntry.oldKey = materialInstanceHash;
		if (materialRegistry.TryGetValue(materialInstanceHash, out var value))
		{
			value.refCount++;
			if (value.matInstance == null)
			{
				value.matInstance = new Material(templateMaterial);
			}
			materialRegistry[materialInstanceHash] = value;
		}
		else
		{
			value = new MaterialInstranceEntry
			{
				matInstance = new Material(templateMaterial),
				refCount = 1
			};
			materialRegistry.Add(materialInstanceHash, value);
		}
		subMeshEntry.matInstance = value.matInstance;
		return value.matInstance;
	}

	private void Awake()
	{
		rend = GetComponent<MeshRenderer>();
	}

	private void OnEnable()
	{
		sInstances.Add(this);
		Sync();
	}

	private void OnDisable()
	{
		sInstances.Remove(this);
		Cleanup();
	}

	public void Sync()
	{
		if (templateMaterial == null || this == null)
		{
			return;
		}
		if (keywordSO == null)
		{
			RevisionFromMat();
		}
		if (keywordSO == null)
		{
			return;
		}
		if (rend == null)
		{
			rend = GetComponent<MeshRenderer>();
		}
		if (rend == null)
		{
			Debug.LogError("No renderer found on MicroSplatMesh component's game object, cannot sync");
			return;
		}
		if (!keywordSO.IsKeywordEnabled("_MESHOVERLAYSPLATS") && rend.sharedMaterials.Length != subMeshEntries.Count)
		{
			Material[] array = rend.sharedMaterials;
			Array.Resize(ref array, subMeshEntries.Count);
			rend.sharedMaterials = array;
		}
		ApplySharedData(templateMaterial);
		for (int i = 0; i < subMeshEntries.Count; i++)
		{
			SubMeshEntry subMeshEntry = subMeshEntries[i];
			if (!subMeshEntry.subMeshOverride.active)
			{
				continue;
			}
			Material materialInstance = GetMaterialInstance(i);
			if (materialInstance == null)
			{
				materialInstance = GetMaterialInstance(i);
			}
			matInstance = materialInstance;
			materialInstance.CopyPropertiesFromMaterial(templateMaterial);
			if (keywordSO.IsKeywordEnabled("_MESHOVERLAYSPLATS"))
			{
				Material[] array2 = rend.sharedMaterials;
				bool flag = false;
				int num = -1;
				for (int j = 0; j < array2.Length; j++)
				{
					if (array2[j] == null)
					{
						num = j;
					}
					else if (array2[j].shader == matInstance.shader)
					{
						array2[j] = matInstance;
						flag = true;
					}
				}
				if (!flag)
				{
					if (num > -1)
					{
						array2[num] = matInstance;
					}
					else
					{
						Array.Resize(ref array2, array2.Length + 1);
						array2[^1] = matInstance;
					}
					rend.sharedMaterials = array2;
				}
			}
			else
			{
				Material[] sharedMaterials = rend.sharedMaterials;
				sharedMaterials[i] = materialInstance;
				rend.sharedMaterials = sharedMaterials;
			}
			if (keywordSO.IsKeywordEnabled("_MESHSUBARRAY"))
			{
				materialInstance.SetVector("_MeshSubArrayIndexes", splatOverride.subArray);
			}
			materialInstance.hideFlags = HideFlags.HideAndDontSave;
			if (subMeshEntry.subMeshOverride.bUVRangeOverride)
			{
				materialInstance.SetVector("_UVMeshRange", subMeshEntry.subMeshOverride.uvRange);
			}
			ApplyMaps(materialInstance);
			if (keywordSO.IsKeywordEnabled("_MESHCOMBINED"))
			{
				SetMap(materialInstance, "_StandardDiffuse", subMeshEntry.combinedOverride.standardAlbedoOverride);
				SetMap(materialInstance, "_StandardNormal", subMeshEntry.combinedOverride.standardNormalOverride);
				SetMap(materialInstance, "_StandardSmoothMetal", subMeshEntry.combinedOverride.standardMetalSmoothOverride);
				SetMap(materialInstance, "_StandardHeight", subMeshEntry.combinedOverride.standardHeightOverride);
				SetMap(materialInstance, "_StandardEmission", subMeshEntry.combinedOverride.standardEmissionOverride);
				SetMap(materialInstance, "_StandardOcclusion", subMeshEntry.combinedOverride.standardOcclusionOverride);
				SetMap(materialInstance, "_StandardPackedMap", subMeshEntry.combinedOverride.standardPackedOverride);
				SetMap(materialInstance, "_StandardSSS", subMeshEntry.combinedOverride.standardSSS);
				if (subMeshEntry.combinedOverride.bStandardColorOverride && materialInstance.HasProperty("_StandardDiffuseTint"))
				{
					materialInstance.SetColor("_StandardDiffuseTint", subMeshEntry.combinedOverride.standardColorOverride);
				}
				if (subMeshEntry.combinedOverride.bStandardUVOverride && materialInstance.HasProperty("_StandardUVScaleOffset"))
				{
					materialInstance.SetVector("_StandardUVScaleOffset", subMeshEntry.combinedOverride.standardUVOverride);
				}
			}
			if (subMeshEntry.subMeshOverride.bUVOverride && materialInstance.HasProperty("_UVScale"))
			{
				materialInstance.SetVector("_UVScale", subMeshEntry.subMeshOverride.UVOverride);
			}
			if (subMeshEntry.subMeshOverride.bUVOverride && materialInstance.HasProperty("_TriplanarUVScale"))
			{
				materialInstance.SetVector("_TriplanarUVScale", subMeshEntry.subMeshOverride.UVOverride);
			}
			if (splatOverride.bDisplacementOverride && materialInstance.HasProperty("_TessData1"))
			{
				Vector4 vector = materialInstance.GetVector("_TessData1");
				vector.y = splatOverride.displacementOverride;
				materialInstance.SetVector("_TessData1", vector);
			}
			if (subMeshEntry.subMeshOverride.controlTextures != null && subMeshEntry.subMeshOverride.controlTextures.Length != 0 && !keywordSO.IsKeywordEnabled("_DISABLESPLATMAPS"))
			{
				ApplyControlTextures(subMeshEntry.subMeshOverride.controlTextures, materialInstance);
			}
			SetMap(materialInstance, "_DisplacementDampening", subMeshEntry.subMeshOverride.displacementDampening);
			SetMap(materialInstance, "_GlobalTintTex", subMeshEntry.subMeshOverride.tint);
			SetMap(materialInstance, "_StreamControl", subMeshEntry.subMeshOverride.streamTex);
			MicroSplatBlendableObject component = GetComponent<MicroSplatBlendableObject>();
			if (component != null)
			{
				component.Sync();
			}
			if (this.OnMaterialSync != null)
			{
				this.OnMaterialSync(materialInstance);
			}
		}
	}

	public override Bounds GetBounds()
	{
		return rend.bounds;
	}

	public new static void SyncAll()
	{
		for (int i = 0; i < sInstances.Count; i++)
		{
			sInstances[i].Sync();
		}
		if (MicroSplatMesh.OnMaterialSyncAll != null)
		{
			MicroSplatMesh.OnMaterialSyncAll();
		}
	}
}
