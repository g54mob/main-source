using UnityEngine;

public class Rack : MonoBehaviour
{
	public RackPosition[] positions;

	public int[] isPositionUsed;

	public RackMount rackMount;

	private AudioSource audioSource;

	public void Awake()
	{
	}

	private void Start()
	{
	}

	public bool IsPositionAvailable(int index, int sizeInU)
	{
		return false;
	}

	public void MarkPositionAsUsed(int index, int sizeInU)
	{
	}

	public void MarkPositionAsUnused(int index, int sizeInU)
	{
	}

	private void UpdateAudioVolume()
	{
	}

	public void InitializeLoadedRack(int[] loadedPositions)
	{
	}

	private void OnLoad()
	{
	}

	private void OnDestroy()
	{
	}
}
