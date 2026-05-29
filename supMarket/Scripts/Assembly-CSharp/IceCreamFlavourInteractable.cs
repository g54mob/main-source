using Photon.Pun;
using UnityEngine;

public class IceCreamFlavourInteractable : MonoBehaviour, IHoldDuration
{
	[SerializeField]
	private IceCreamFlavour m_Flavour;

	[SerializeField]
	private IceCreamFlavourGraphics m_Graphics;

	private float m_RefillTimer;

	public const int k_MaxValue = 50;

	private int m_Value;

	private PhotonView m_PhotonView;

	private DisplaySlot m_DisplaySlot;

	public IceCreamFlavour Flavour
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public IceCreamFlavourGraphics Graphics => null;

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

	public float Duration => 0f;

	public bool IsFull => false;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public bool CompleteHold(IceCreamInteraction interaction)
	{
		return false;
	}

	public void SetData(IceCreamFlavourData data)
	{
	}

	public void SetDataWithoutNotify(IceCreamFlavourData data)
	{
	}

	private void SetValueInternal(int value)
	{
	}

	public void SetValueWithoutNotify(int value)
	{
	}

	public void UpdateInventory(int newValue, int prevValue)
	{
	}

	private void SetFlavourInternal(IceCreamFlavour value)
	{
	}

	public void SyncValue_Others(int value)
	{
	}

	[PunRPC]
	private void SyncValue_RPC(int value)
	{
	}

	public void SetFlavour_Others(int id)
	{
	}

	[PunRPC]
	private void SetFlavour_RPC(int value)
	{
	}
}
