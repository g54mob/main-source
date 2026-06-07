using UnityEngine;
using UnityEngine.UI;

public class HighlightImage : MonoBehaviour
{
	public RectTransform rt;

	private MenuButton parentButton;

	private RectTransform parentTransform;

	public Image image;

	public Color animationStartColor;

	public Color animationEndColor;

	public bool isRunningAnimation;

	public float animationProgress;

	public bool isRunningFadeAnimation;

	public float animationSpeed;

	private float highlightMargin;

	public void ResetState()
	{
		Unlink();
		base.gameObject.SetActive(value: false);
		rt.SetParent(null);
		rt.localScale = Vector3.one;
		rt.rotation = Quaternion.identity;
	}

	public void Unlink()
	{
		parentButton = null;
		parentTransform = null;
	}

	public void LinkWithParent(MenuButton b)
	{
		_ = null != parentButton;
		if (b.useOutlineHighlight)
		{
			image.sprite = IconManager.Instance.buttonHighlightOutline;
		}
		else
		{
			image.sprite = IconManager.Instance.buttonHighlightSolid;
		}
		isRunningFadeAnimation = false;
		parentTransform = (RectTransform)b.transform;
		parentButton = b;
		rt.SetParent(parentTransform);
		rt.SetSiblingIndex(0);
		rt.localScale = Vector3.one;
		if (b.highlightMargin > 0f)
		{
			highlightMargin = b.highlightMargin;
		}
		else
		{
			highlightMargin = 0f;
		}
		rt.anchorMin = Vector2.zero;
		rt.anchorMax = Vector2.one;
		rt.offsetMin = new Vector2(0f - highlightMargin, 0f - highlightMargin);
		rt.offsetMax = new Vector2(highlightMargin, highlightMargin);
		UpdateDisplay();
	}

	private void Update()
	{
		if (null == parentTransform || !isRunningAnimation)
		{
			return;
		}
		animationProgress += TimeManager.MenuDelta * animationSpeed;
		if (animationProgress > 1f)
		{
			animationProgress = 0f;
			isRunningAnimation = false;
			if (isRunningFadeAnimation)
			{
				parentButton.ReturnHighlightImageToPool();
				return;
			}
		}
		UpdateDisplay();
	}

	private void UpdateDisplay()
	{
		image.color = Color.Lerp(animationStartColor, animationEndColor, animationProgress);
	}

	public void JumpTo(Color target)
	{
		image.color = target;
		isRunningAnimation = false;
		isRunningFadeAnimation = false;
	}

	public void FadeTo(Color target)
	{
		animationSpeed = 2f;
		animationStartColor = image.color;
		animationEndColor = target;
		isRunningFadeAnimation = false;
		isRunningAnimation = true;
		UpdateDisplay();
	}

	public void BeginFade()
	{
		animationSpeed = 10f;
		animationStartColor = image.color;
		animationEndColor = new Color(animationStartColor.r, animationStartColor.g, animationStartColor.b, 0f);
		animationProgress = 0f;
		isRunningAnimation = true;
		isRunningFadeAnimation = true;
		UpdateDisplay();
	}
}
