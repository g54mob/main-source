using UnityEngine;

[DefaultExecutionOrder(-1000)]
public class InstancedRendererLoader : MonoBehaviour
{
	[SerializeField]
	private Material m_Material;

	[SerializeField]
	private Material[] m_PreloadedMaterials;

	[SerializeField]
	private ReflectionProbe m_StoreReflectionProbe;

	[SerializeField]
	private ReflectionProbe m_StorageReflectionProbe;

	private SubRenderer m_ProductOpaque;

	private SubRenderer m_ProductTransparent;

	private SubRenderer m_StaticBox;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void UpdateUniforms(SubRenderer renderer, ReflectionProbe probe)
	{
	}
}
