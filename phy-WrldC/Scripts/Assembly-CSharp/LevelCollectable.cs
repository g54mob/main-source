using System;
using UnityEngine;

public class LevelCollectable : MonoBehaviour
{
	public enum CollectableType
	{
		Silver = 0,
		Gold = 1
	}

	[SerializeField]
	private CollectableType type;

	private MeshRenderer meshRenderer;

	private BoxCollider boxCollider;

	public CollectableType Type => type;

	public bool IsInteractive { get; private set; }

	public bool WasCollected { get; private set; }

	public event Action<CollectableType> OnCollectedEvent;

	private void Awake()
	{
		meshRenderer = GetComponent<MeshRenderer>();
		boxCollider = GetComponent<BoxCollider>();
		WasCollected = false;
		IsInteractive = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Block") && IsInteractive)
		{
			meshRenderer.enabled = false;
			boxCollider.enabled = false;
			WasCollected = true;
			this.OnCollectedEvent?.Invoke(type);
		}
	}

	public void SetInteractive(bool isInteractive)
	{
		IsInteractive = isInteractive;
		meshRenderer.enabled = isInteractive;
		boxCollider.enabled = isInteractive;
	}
}
