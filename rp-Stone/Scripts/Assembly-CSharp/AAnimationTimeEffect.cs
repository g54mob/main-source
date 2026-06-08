using UnityEngine;

[RequireComponent(typeof(AsciiAnimation))]
public abstract class AAnimationTimeEffect : MonoBehaviour
{
	public float timeToTrigger;

	public bool triggerOnlyIfOnScreen = true;

	private AsciiAnimation myAnimation;

	private bool lastPlaying;

	private float lastElapsedTime;

	private bool drewLastFrame;

	public abstract void ExecuteEffect(AsciiAnimation animation, AsciiSprite sprite, AsciiRenderProcedural r);

	protected virtual void Awake()
	{
		myAnimation = GetComponent<AsciiAnimation>();
	}

	protected virtual void Start()
	{
		myAnimation.Sprite.OnDraw += HandleOnDraw;
	}

	protected virtual void OnDestroy()
	{
		if (myAnimation != null && myAnimation.Sprite != null)
		{
			myAnimation.Sprite.OnDraw -= HandleOnDraw;
		}
	}

	private void HandleOnDraw(AsciiSprite sprite, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		drewLastFrame = offsetX >= -sprite.width && offsetX < r.width && offsetY >= -sprite.height && offsetY < r.height;
		bool playing = myAnimation.Playing;
		float elapsedTime = myAnimation.ElapsedTime;
		if (!lastPlaying && playing)
		{
			lastElapsedTime = -1f;
		}
		if (lastPlaying || playing)
		{
			if (drewLastFrame || !triggerOnlyIfOnScreen)
			{
				float num = Mathf.Abs(lastElapsedTime - elapsedTime);
				if (elapsedTime >= timeToTrigger && elapsedTime - num < timeToTrigger)
				{
					ExecuteEffect(myAnimation, sprite, r);
				}
			}
			lastElapsedTime = elapsedTime;
		}
		lastPlaying = playing;
	}
}
