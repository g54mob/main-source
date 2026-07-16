using System;
using UnityEngine;

public class SlidingUIElement : MonoBehaviour
{
	[Header("Popup")]
	[SerializeField]
	protected Vector2 startPosition = Vector2.zero;

	[SerializeField]
	protected Vector2 endPosition = Vector2.zero;

	[SerializeField]
	protected Vector2 startScale = Vector2.one;

	[SerializeField]
	protected Vector2 endScale = Vector2.one;

	protected RectTransform rectTransform;

	[SerializeField]
	public float slideInTime = 1f;

	[SerializeField]
	public float slideOutTime = 1f;

	protected float slideInTimer = 5f;

	protected float slideOutTimer = 5f;

	protected bool slidingIn;

	protected bool slidingOut;

	[NonSerialized]
	public float customSlideInTime;

	[NonSerialized]
	public float customSlideOutTime;

	[NonSerialized]
	public Vector2 customStartPosition;

	[NonSerialized]
	public Vector2 customEndPosition;

	private bool custom;

	[SerializeField]
	private UnitAudioController audioController;

	[SerializeField]
	private int audioClipChannelIndex;

	[field: NonSerialized]
	public bool SlidingInRunning { get; protected set; }

	[field: NonSerialized]
	public bool SlidingOutRunning { get; protected set; }

	public event Action OnSlideInFinished;

	public event Action OnSlideOutFinished;

	public event Action OnSlideOutStarted;

	public event Action OnSlideInStarted;

	protected void Start()
	{
		rectTransform = GetComponent<RectTransform>();
		rectTransform.anchoredPosition = startPosition;
	}

	protected void Update()
	{
		if (!custom)
		{
			if (slideInTimer < slideInTime)
			{
				if (!SlidingInRunning)
				{
					this.OnSlideInStarted?.Invoke();
				}
				SlidingInRunning = true;
				slideInTimer += Time.unscaledDeltaTime;
				float t = Mathf.Clamp01(slideInTimer / slideInTime);
				if (startPosition != Vector2.zero || endPosition != Vector2.zero)
				{
					rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, t);
				}
				if (startScale != Vector2.zero || endScale != Vector2.zero)
				{
					rectTransform.localScale = Vector2.Lerp(startScale, endScale, t);
				}
			}
			else if (SlidingInRunning)
			{
				SlidingInRunning = false;
				slidingIn = false;
				SlideInFinished();
			}
			if (slideOutTimer < slideOutTime)
			{
				if (!SlidingOutRunning)
				{
					this.OnSlideOutStarted?.Invoke();
				}
				SlidingOutRunning = true;
				slideOutTimer += Time.unscaledDeltaTime;
				float t2 = Mathf.Clamp01(slideOutTimer / slideOutTime);
				if (startPosition != Vector2.zero || endPosition != Vector2.zero)
				{
					rectTransform.anchoredPosition = Vector2.Lerp(endPosition, startPosition, t2);
				}
				if (startScale != Vector2.zero || endScale != Vector2.zero)
				{
					rectTransform.localScale = Vector2.Lerp(startScale, endScale, t2);
				}
			}
			else if (SlidingOutRunning)
			{
				SlidingOutRunning = false;
				slidingIn = true;
				SlideOutFinished();
			}
		}
		else
		{
			if (slideInTimer < customSlideInTime)
			{
				SlidingInRunning = true;
				slideInTimer += Time.unscaledDeltaTime;
				float t3 = Mathf.Clamp01(slideInTimer / customSlideInTime);
				rectTransform.anchoredPosition = Vector2.Lerp(customStartPosition, customEndPosition, t3);
			}
			else if (SlidingInRunning)
			{
				SlidingInRunning = false;
				slidingIn = false;
				custom = false;
				SlideInFinished();
			}
			if (slideOutTimer < customSlideOutTime)
			{
				SlidingOutRunning = true;
				slideOutTimer += Time.unscaledDeltaTime;
				float t4 = Mathf.Clamp01(slideOutTimer / customSlideOutTime);
				rectTransform.anchoredPosition = Vector2.Lerp(customEndPosition, customStartPosition, t4);
			}
			else if (SlidingOutRunning)
			{
				SlidingOutRunning = false;
				slidingIn = true;
				custom = false;
				SlideOutFinished();
			}
		}
	}

	public void SlideIn()
	{
		slideInTimer = 0f;
		slideOutTimer = 10f;
		if (audioController != null)
		{
			audioController.PlayOnChannel(audioClipChannelIndex);
		}
	}

	public void SlideOut()
	{
		slideOutTimer = 0f;
		slideInTimer = 10f;
		if (audioController != null)
		{
			audioController.PlayOnChannel(audioClipChannelIndex);
		}
	}

	public void CustomSlideIn(float cSlideInTime, Vector2 cStartPos, Vector3 cEndPos)
	{
		customSlideInTime = cSlideInTime;
		customStartPosition = cStartPos;
		customEndPosition = cEndPos;
		custom = true;
		slideInTimer = 0f;
		slideOutTimer = 10f;
	}

	public void CustomSlideOut(float cSlideOutTime, Vector2 cStartPos, Vector3 cEndPos)
	{
		customSlideOutTime = cSlideOutTime;
		customStartPosition = cStartPos;
		customEndPosition = cEndPos;
		custom = true;
		slideOutTimer = 0f;
		slideInTimer = 10f;
	}

	private void SlideInFinished()
	{
		if (audioController != null)
		{
			audioController.StopChannel(audioClipChannelIndex);
		}
		this.OnSlideInFinished?.Invoke();
	}

	private void SlideOutFinished()
	{
		if (audioController != null)
		{
			audioController.StopChannel(audioClipChannelIndex);
		}
		this.OnSlideOutFinished?.Invoke();
	}

	public Vector3 GetStartPos()
	{
		return startPosition;
	}

	public Vector3 GetEndPos()
	{
		return endPosition;
	}

	public Vector3 GetStartScale()
	{
		return startScale;
	}

	public Vector3 GetEndScale()
	{
		return endScale;
	}
}
