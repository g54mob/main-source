using UnityEngine;

public class PlayerModelController : MonoBehaviour
{
	private static PlayerModelController _instance;

	public GameObject playerCitizenPrefab;

	public Transform citizenModelsTransform;

	public Citizen playerCitizen;

	public static PlayerModelController Instance => null;

	private void Awake()
	{
	}

	public void DisableMeshRenderers()
	{
	}

	private void OnDestroy()
	{
	}
}
