using UnityEngine;

public class Speaker : MonoBehaviour
{
	[SerializeField]
	private GameObject m_Speaker;

	public FurniturePlacingMode furniturePlacingMode;

	public LayerMask layerMask;

	private bool isComputerClosed;

	public InteractactableType Type => default(InteractactableType);

	private void OnEnable()
	{
	}

	private void OnComputerInteractionStopped()
	{
	}

	private void OnDisable()
	{
	}

	private void OnSectionPurchased(int obj)
	{
	}

	[ContextMenu("Snap Speaker Wall")]
	private void SnapSpeakerWall()
	{
	}

	private void Start()
	{
	}

	public void AddToManager()
	{
	}

	public void RemoveFromManager()
	{
	}
}
