using System.Collections.Generic;
using UnityEngine;

public class GPUInstancingManager : MonoBehaviour
{
	private struct MaterialMeshPair
	{
		public Material material;

		public Mesh mesh;
	}

	private struct TransformMatrixPair
	{
		public List<Transform> transforms;

		public List<Matrix4x4> matrices;
	}

	public static GPUInstancingManager Instance;

	[Tooltip("Do not change this during runtime!")]
	[SerializeField]
	private bool gpuInstancingEnabled = true;

	[SerializeField]
	private bool debugLogs;

	private Dictionary<MaterialMeshPair, TransformMatrixPair> matMeshPairToRenderersDictionary;

	private List<Matrix4x4> transformMatricesBuffer = new List<Matrix4x4>();

	private void Awake()
	{
		if (gpuInstancingEnabled)
		{
			Instance = this;
		}
		else
		{
			Instance = null;
		}
		matMeshPairToRenderersDictionary = new Dictionary<MaterialMeshPair, TransformMatrixPair>();
	}

	private void Update()
	{
		int num = 0;
		int num2 = 0;
		foreach (KeyValuePair<MaterialMeshPair, TransformMatrixPair> item in matMeshPairToRenderersDictionary)
		{
			TransformMatrixPair value = item.Value;
			for (int i = 0; i < value.transforms.Count; i++)
			{
				if (value.transforms[i] != null)
				{
					value.matrices[i] = value.transforms[i].localToWorldMatrix;
				}
			}
			if (value.matrices.Count >= 1024)
			{
				Debug.LogWarning("Drawing too many meshes with mesh: " + item.Key.mesh.ToString());
			}
			try
			{
				Graphics.DrawMeshInstanced(item.Key.mesh, 0, item.Key.material, value.matrices);
			}
			catch
			{
				Debug.LogError("GPU instancing with material failed: " + item.Key.material.ToString());
			}
			num += value.transforms.Count;
			num2++;
		}
	}

	public void AddVirtualMeshRenderer(Mesh mesh, Material material, Transform transform)
	{
		MaterialMeshPair key = default(MaterialMeshPair);
		key.material = material;
		key.mesh = mesh;
		if (!matMeshPairToRenderersDictionary.TryGetValue(key, out var value))
		{
			value = new TransformMatrixPair
			{
				transforms = new List<Transform>(),
				matrices = new List<Matrix4x4>()
			};
			matMeshPairToRenderersDictionary[key] = value;
		}
		value.transforms.Add(transform);
		value.matrices.Add(transform.localToWorldMatrix);
	}

	public void RemoveVirtualMeshRenderer(Mesh mesh, Material material, Transform transform)
	{
		MaterialMeshPair key = default(MaterialMeshPair);
		key.material = material;
		key.mesh = mesh;
		if (matMeshPairToRenderersDictionary.TryGetValue(key, out var value))
		{
			int num = value.transforms.IndexOf(transform);
			if (num != -1)
			{
				value.transforms.RemoveAt(num);
				value.matrices.RemoveAt(num);
			}
			if (value.transforms.Count == 0)
			{
				matMeshPairToRenderersDictionary.Remove(key);
			}
		}
	}

	public void UpdateVirtualMeshRenderer(Mesh oldMesh, Material oldMaterial, Mesh newMesh, Material newMaterial, Transform transform)
	{
		RemoveVirtualMeshRenderer(oldMesh, oldMaterial, transform);
		AddVirtualMeshRenderer(newMesh, newMaterial, transform);
	}
}
