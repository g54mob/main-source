using DG.Tweening;
using UnityEngine;

public class IceCreamFlavourGraphics : MonoBehaviour
{
	[SerializeField]
	private int m_BlendShapeCount;

	[SerializeField]
	private SkinnedMeshRenderer m_Renderer;

	[SerializeField]
	private float m_BlendShapeMaxWeight;

	[SerializeField]
	private float m_MaxBlendShapeEffect;

	[SerializeField]
	private float m_MaxY;

	private Sequence m_CurrentRateTween;

	[SerializeField]
	private Material m_CarveBlitMaterial;

	[SerializeField]
	private Material m_CarveClearMaterial;

	[SerializeField]
	private Transform m_Target;

	[SerializeField]
	private Transform m_PullTo;

	private RenderTexture m_CarveTexture;

	public float BlendShapeRate { get; private set; }

	public Vector3 GetTarget()
	{
		return default(Vector3);
	}

	public Vector3 GetPullTo()
	{
		return default(Vector3);
	}

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void SetFlavour(IceCreamFlavour flavour)
	{
	}

	public void AddCarve(Vector2 uvA, Vector3 uvB)
	{
	}

	public void ClearCarveStep()
	{
	}

	private void Update()
	{
	}

	public void UpdateBlendShapes(float rate)
	{
	}

	public void UpdateRotation()
	{
	}
}
