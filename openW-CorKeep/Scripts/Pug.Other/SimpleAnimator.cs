using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimator : MonoBehaviour, IManagedLateUpdate
{
	public SpriteRenderer sr;

	public float timeBetweenFrames = 0.01f;

	public bool randomStartFrame;

	public List<Sprite> frames;

	private float randomOffset;

	private float timer;

	private void OnValidate()
	{
		if (timeBetweenFrames <= 0f)
		{
			timeBetweenFrames = 0.01f;
			Debug.LogWarning("timeBetweenFrames cannot be 0 or less.");
		}
	}

	private void OnEnable()
	{
		Manager.update.AddToLateUpdate(this);
		if (randomStartFrame)
		{
			randomOffset = (float)Random.Range(0, frames.Count) * timeBetweenFrames;
		}
	}

	private void OnDisable()
	{
		Manager.update.RemoveFromLateUpdate(this);
	}

	public void ManagedLateUpdate()
	{
		sr.sprite = frames[(int)((Time.time + randomOffset) / timeBetweenFrames) % frames.Count];
	}
}
