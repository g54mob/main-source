using UnityEngine;

public class LocalMarketDoor : MonoBehaviour
{
	[SerializeField]
	private LocalMarketStoreController m_StoreController;

	[SerializeField]
	private Transform m_DisplayTransform;

	[SerializeField]
	private float m_ClosedRotation;

	[SerializeField]
	private float m_OpenRotation;

	[SerializeField]
	private Collider m_Collider;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnStoreOpened()
	{
	}

	private void Close()
	{
	}

	private void Open()
	{
	}
}
