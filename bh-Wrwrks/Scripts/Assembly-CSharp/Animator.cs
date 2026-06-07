using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator : MonoBehaviour
{
	public int fps = 2;

	public List<Sprite> frames;

	public bool autostart = true;

	private bool started;

	private bool unstoppable;

	public bool dropshadow;

	public bool mask;

	public List<Sprite> maskFrames;

	public SpriteMask attachedMask;

	public int currFrame;

	public int skip;

	public bool unpausable;

	private void Start()
	{
		if (autostart && !started)
		{
			StartCoroutine(animate());
		}
	}

	public void StartAnim()
	{
		if (!autostart)
		{
			StartCoroutine(animate());
			autostart = true;
		}
	}

	public void StartAnimCount(int x)
	{
		if (!autostart)
		{
			StartCoroutine(animate(oneShot: false, x));
			autostart = true;
		}
	}

	public void StartAnimOneShot(bool stopOnLastFrame = false)
	{
		if (!autostart)
		{
			StartCoroutine(animate(oneShot: true, -1, stopOnLastFrame));
			autostart = true;
		}
	}

	public void StopAnim(bool force = false)
	{
		if (!(unstoppable && force))
		{
			autostart = false;
			StopAllCoroutines();
		}
	}

	public void CustomAnim(List<Sprite> s, float f, bool oneshot = false, int c = -1)
	{
		frames = s;
		fps = (int)f;
		StopAnim();
		if (c != -1)
		{
			unstoppable = true;
			StartAnimCount(c);
		}
		else if (oneshot)
		{
			StartAnimOneShot();
		}
		else
		{
			StartAnim();
		}
	}

	public void ChangeFPS(float f, bool oneShot = false, int count = -1, bool stopOnLast = false)
	{
		int customStart = frames.FindIndex((Sprite x) => x == GetComponent<SpriteRenderer>().sprite);
		StopAnim(force: true);
		fps = (int)f;
		StartCoroutine(animate(oneShot, count, stopOnLast, customStart));
		autostart = true;
	}

	public IEnumerator animate(bool oneShot = false, int count = -1, bool stopOnLast = false, int customStart = 0)
	{
		started = true;
		currFrame = customStart;
		float frame_wait = (float)Application.targetFrameRate / (float)fps;
		if (frame_wait <= 0f)
		{
			yield break;
		}
		while (true)
		{
			if (dropshadow)
			{
				GetComponent<DropShadow>().spriteRenderer.sprite = frames[currFrame];
			}
			if (mask)
			{
				attachedMask.sprite = maskFrames[currFrame];
			}
			GetComponent<SpriteRenderer>().sprite = frames[currFrame];
			for (int i = 0; (float)i < frame_wait; i++)
			{
				yield return null;
				while (Dungeon.Instance.paused && !unpausable)
				{
					yield return null;
				}
			}
			currFrame += skip;
			currFrame = ++currFrame % frames.Count;
			if (oneShot && currFrame == 0)
			{
				if (!stopOnLast)
				{
					if (dropshadow)
					{
						GetComponent<DropShadow>().spriteRenderer.sprite = frames[currFrame];
					}
					GetComponent<SpriteRenderer>().sprite = frames[currFrame];
					if (mask)
					{
						attachedMask.sprite = maskFrames[currFrame];
					}
				}
				StopAnim();
				yield break;
			}
			if (count != -1 && currFrame == 0)
			{
				count--;
				if (count == 0)
				{
					break;
				}
			}
		}
		if (!stopOnLast)
		{
			if (dropshadow)
			{
				GetComponent<DropShadow>().spriteRenderer.sprite = frames[currFrame];
			}
			GetComponent<SpriteRenderer>().sprite = frames[currFrame];
			if (mask)
			{
				attachedMask.sprite = maskFrames[currFrame];
			}
		}
		unstoppable = false;
		StopAnim();
	}

	private void Update()
	{
	}
}
