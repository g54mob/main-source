using UnityEngine;

public class IndexedStaticInstancer : MonoBehaviour
{
	[SerializeField]
	private int m_MaxInstances;

	[SerializeField]
	private Mesh m_Mesh;

	[SerializeField]
	private Material m_Material;

	[SerializeField]
	private Matrix4x4[] m_Matrices;

	private Matrix4x4[] m_WorldMatrices;

	private bool m_AreWorldMatricesDirty;

	private int m_ActiveCount;

	private RenderParams m_RenderParams;

	private Bounds m_Bounds;

	private IndexedStaticInstancerMatrixGenerator m_Generator;

	public Mesh Mesh => null;

	public int ActiveCount
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool ForceRenderingOff { get; set; }

	private void Awake()
	{
	}

	private void OnValidate()
	{
	}

	public void GenerateMatrices()
	{
	}

	public void UpdateWorldMatrices()
	{
	}

	public Matrix4x4 GetLocalTarget(int targetIndex)
	{
		return default(Matrix4x4);
	}

	public Matrix4x4 GetWorldTarget(int targetIndex)
	{
		return default(Matrix4x4);
	}

	private void Update()
	{
	}

	public void SetMatrix(int index, Matrix4x4 matrix)
	{
	}
}
