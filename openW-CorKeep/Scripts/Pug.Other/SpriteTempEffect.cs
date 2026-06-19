using System;
using Pug.UnityExtensions;
using UnityEngine;

public class SpriteTempEffect : PoolableSimple
{
	public float defaultLifespan = 0.35f;

	protected Animator animator;

	protected SpriteRendererAutoSort autoSorter;

	protected TimerSimple timer;

	protected bool looping;

	public SpriteRenderer sr;

	protected bool setCustomColor;

	protected Color color = Color.white;

	protected Transform followTransform;

	protected Vector2 followTransformOffset;

	protected Sprite overrideSprite;

	protected int srBackupLayer;

	protected int srBackupOrder;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		timer.lifespan = defaultLifespan;
		srBackupLayer = sr.sortingLayerID;
		srBackupOrder = sr.sortingOrder;
	}

	public override void OnFree()
	{
		followTransform = null;
		sr.sortingLayerID = srBackupLayer;
		sr.sortingOrder = srBackupOrder;
		sr.transform.localScale = Vector3.one;
		setCustomColor = false;
		overrideSprite = null;
		base.gameObject.SetActive_Clean(active: false);
	}

	public void Follow(Transform t, Vector2 offset)
	{
		followTransform = t;
		followTransformOffset = offset;
	}

	public void SetColor(Color c)
	{
		setCustomColor = true;
		color = c;
	}

	public void SetSortingOrder(int x)
	{
		sr.sortingOrder = x;
	}

	public void SetSortingLayer(int sortingLayerID)
	{
		sr.sortingLayerID = sortingLayerID;
	}

	public void SetAutoSortingEnabled(bool enabled)
	{
		autoSorter.enabled = enabled;
	}

	public void Play(int animHash, Vector3 position, float scale, float lifetime, float positionDev, bool looping)
	{
		if (positionDev != 0f)
		{
			float f = UnityEngine.Random.Range(0f, MathF.PI * 2f);
			position += new Vector3(positionDev * Mathf.Cos(f), positionDev * Mathf.Sin(f), 0f);
		}
		base.transform.position = position;
		base.transform.localScale = new Vector3(scale, scale, 1f);
		this.looping = looping;
		base.gameObject.SetActive(value: true);
		animator.Play(animHash, -1, 0f);
		timer.Start(lifetime + float.Epsilon);
	}

	public void Stop()
	{
		animator.StopPlayback();
		timer.Stop();
		Free();
	}

	private void LateUpdate()
	{
		if (setCustomColor)
		{
			sr.color = color;
		}
		if (followTransform != null)
		{
			base.transform.position = followTransform.position + followTransformOffset.To3D();
		}
		if (timer.isRunning && timer.isTimerElapsed && !looping)
		{
			Stop();
		}
		if (overrideSprite != null)
		{
			sr.sprite = overrideSprite;
		}
	}

	public void OverrideSprite(Sprite sprite)
	{
		overrideSprite = sprite;
	}
}
