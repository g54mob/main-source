using UnityEngine;

public class BarcodeSpawner : MonoBehaviour
{
	[SerializeField]
	private Barcode m_BarcodePrefab;

	[SerializeField]
	private Transform m_SpawnPoint;

	private Barcode m_ActiveBarcode;

	private AudioSource m_AudioSource;

	public Barcode ActiveBarcode => null;

	private void Awake()
	{
	}

	public bool TryCreate(string code, Sprite icon, out Barcode barcode)
	{
		barcode = null;
		return false;
	}

	public bool TryCreate(string code, out Barcode barcode)
	{
		barcode = null;
		return false;
	}

	public bool TryCreateInternal(string code, out Barcode barcode)
	{
		barcode = null;
		return false;
	}

	public void DestroyActive()
	{
	}
}
