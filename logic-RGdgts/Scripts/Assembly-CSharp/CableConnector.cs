using UnityEngine;

public class CableConnector : MonoBehaviour
{
	[HideInInspector]
	public Transform socket;

	public Transform connector90;

	public Transform connector45;

	private Material ledMaterial;

	private SpriteRenderer currentLedRenderer;

	private bool ledStatus;

	public Color ledColor => default(Color);

	private void Awake()
	{
	}

	public void Setup(Vector3 direction)
	{
	}

	public void SetLed(bool status)
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}
}
