using UnityEngine;

public class IceCreamConeInteractable : MonoBehaviour, ITransformSyncReceiver
{
	[SerializeField]
	private IceCreamCone m_ConePrefab;

	[SerializeField]
	private ProductSO m_Product;

	private IndexedStaticInstancer m_Renderer;

	[SerializeField]
	private MeshRenderer m_HighlightMesh;

	private NetworkIceCreamConeInteractable m_NetworkConeInteractable;

	private int m_Value;

	[SerializeField]
	private int m_Max;

	private NetworkIceCreamConeInteractable NetworkConeInteractable => null;

	public int Value
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int Max => 0;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void SetValueWithoutNotify(int value)
	{
	}

	public void SetValueInternal(int value)
	{
	}

	public void UpdateInventory(int newValue, int prevValue)
	{
	}

	private void UpdateHighlightTransform()
	{
	}

	public bool Interact()
	{
		return false;
	}

	void ITransformSyncReceiver.OnSyncReceived()
	{
	}
}
