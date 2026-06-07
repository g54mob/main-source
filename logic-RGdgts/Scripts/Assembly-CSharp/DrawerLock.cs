using DG.Tweening;
using UnityEngine;

public class DrawerLock : MonoBehaviour
{
	public SpriteRenderer lockRenderer;

	public SpriteRenderer ledRenderer;

	public Holder.TransitionDurations transitionDuration;

	public Ease ease;

	public float blinkTime;

	private Drawer drawer;

	private Vector2 lockSize;

	private Material ledMaterial;

	private bool status;

	private Sequence tween;

	private float blinkCountdown;

	private bool lockReady;

	private void Awake()
	{
	}

	private void Lock()
	{
	}

	private void Unlock()
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnTryOpenWhenLocked()
	{
	}
}
