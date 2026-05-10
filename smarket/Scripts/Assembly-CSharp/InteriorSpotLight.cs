using UnityEngine;

public class InteriorSpotLight : MonoBehaviour
{
	[SerializeField]
	private GameObject m_EmissionOn;

	[SerializeField]
	private GameObject m_EmissionOff;

	[SerializeField]
	private GameObject m_Light;

	private string m_BelongToSection;

	public FurniturePlacingMode furniturePlacingMode;

	private const float MaxYStoragePosition = 2.8f;

	private const float MaxYStorePosition = 2.9f;

	public bool TurnOn
	{
		set
		{
		}
	}

	private void Start()
	{
	}

	private void CheckSection()
	{
	}

	public void AddToManager()
	{
	}

	public void RemoveFromManager()
	{
	}
}
