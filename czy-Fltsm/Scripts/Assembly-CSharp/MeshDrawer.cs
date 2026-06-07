using UnityEngine;
using UnityEngine.Rendering;

public class MeshDrawer : MonoBehaviour
{
	public LightingProperties Lighting;

	public Mesh[] Meshes;

	public Material[] Materials;

	private int _meshCount;

	private int _materialCount;

	private bool _useLightProbes;

	private void Awake()
	{
		_meshCount = Meshes.Length;
		_materialCount = Materials.Length;
		_useLightProbes = Lighting.LightProbes != LightProbeUsage.Off;
	}

	private void Update()
	{
		for (int i = 0; i < _meshCount; i++)
		{
			Mesh mesh = Meshes[i];
			for (int j = 0; j < _materialCount; j++)
			{
				Graphics.DrawMesh(mesh, base.transform.localToWorldMatrix, Materials[j], base.gameObject.layer, null, j, null, Lighting.CastShadows, Lighting.ReceiveShadows, Lighting.AnchorOverride, _useLightProbes);
			}
		}
	}
}
