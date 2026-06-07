using UnityEngine;

public class SkateboardInteraction : MonoBehaviour
{
	[SerializeField]
	private float m_MaxRaycastDistance;

	[SerializeField]
	private LayerMask m_LabelInteractionLayer;

	private Camera m_MainCamera;

	private RaycastHit m_Hit;

	private Ray m_Ray;

	public SkateboardController m_CurrentSkate;

	private PlayerInstance m_PlayerInstance;

	private bool m_InSkateboard => false;

	private PlayerInstance PlayerInstance => null;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnSell(bool obj)
	{
	}

	private void CheckForInteraction()
	{
	}

	private void DefaultHints(bool show)
	{
	}

	private void SetCurrentInteractable(SkateboardController skt)
	{
	}
}
