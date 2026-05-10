using UnityEngine;

public class InstancedRendererTest : MonoBehaviour
{
	public class TestRenderableInstance : RenderableInstance
	{
		public TestRenderableInstance(int id, Mesh mesh, Material material)
		{
		}
	}

	[SerializeField]
	private Mesh[] m_Meshes;

	[SerializeField]
	private int m_Count;

	[SerializeField]
	private Material m_CopyFromMaterial;

	private void Awake()
	{
	}
}
