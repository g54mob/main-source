using UnityEngine;

[RequireComponent(typeof(AsciiSprite))]
public abstract class ASpriteFrameEffect : MonoBehaviour
{
	public int frameToTrigger;

	private AsciiSprite mySprite;

	private int lastFrame = -1;

	private bool drewLastFrame;

	public abstract void ExecuteEffect(AsciiSprite sprite, AsciiRenderProcedural r);

	protected virtual void Awake()
	{
		mySprite = GetComponent<AsciiSprite>();
	}

	protected virtual void Start()
	{
		mySprite.OnDraw += HandleOnDraw;
	}

	protected virtual void OnDestroy()
	{
		if (mySprite != null)
		{
			mySprite.OnDraw -= HandleOnDraw;
		}
	}

	private void HandleOnDraw(AsciiSprite sprite, AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		drewLastFrame = offsetX >= -sprite.width && offsetX < r.width && offsetY >= -sprite.height && offsetY < r.height;
		int frameIndex = mySprite.GetFrameIndex();
		if (lastFrame == frameIndex)
		{
			return;
		}
		if (drewLastFrame)
		{
			int num = Mathf.Abs(lastFrame - frameIndex);
			if (frameIndex >= frameToTrigger && frameIndex - num < frameToTrigger)
			{
				ExecuteEffect(sprite, r);
			}
		}
		lastFrame = frameIndex;
	}
}
