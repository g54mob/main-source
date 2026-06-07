using UnityEngine;
using UnityEngine.UI;

public class AnimatedSelectionPointer : MonoBehaviour
{
	public enum SelectionPointerDirection
	{
		Down = 0,
		Up = 1,
		Hide = 2
	}

	[SerializeField]
	private RectTransform pivot;

	[SerializeField]
	private AnimationCurve animationCurve;

	[SerializeField]
	private AnimationCurve transparencyCurve;

	[SerializeField]
	private float animationCycleTime;

	[SerializeField]
	private float distanceToAnimate;

	[SerializeField]
	[Range(0f, 1f)]
	private float animationOffset = 0.4f;

	[SerializeField]
	private Image imageCenter;

	[SerializeField]
	private Image imageTop;

	[SerializeField]
	private Image imageBottom;

	private float elapsedAnimationTime;

	public SelectionPointerDirection direction;

	private Color imageColor = new Color(1f, 1f, 1f, 0.5f);

	private void OnDisable()
	{
		if (!UnloadWatcher.isUnloading)
		{
			pivot.anchoredPosition = new Vector2(pivot.anchoredPosition.x, 0f);
			elapsedAnimationTime = 0f;
		}
	}

	public void StartAnimation(SelectionPointerDirection direction)
	{
		if (base.gameObject.activeInHierarchy)
		{
			this.direction = direction;
			if (direction == SelectionPointerDirection.Hide)
			{
				Image image = imageTop;
				Image image2 = imageBottom;
				Color color = (imageCenter.color = Color.clear);
				Color color2 = (image2.color = color);
				image.color = color2;
				base.gameObject.SetActive(value: false);
			}
			else
			{
				Vector3 localEulerAngles = new Vector3(0f, 0f, (direction == SelectionPointerDirection.Down) ? 180 : 0);
				pivot.localEulerAngles = localEulerAngles;
				imageColor.a = 0.5f;
				Image image3 = imageTop;
				Image image4 = imageBottom;
				Color color = (imageCenter.color = imageColor);
				Color color2 = (image4.color = color);
				image3.color = color2;
			}
		}
	}

	private void Update()
	{
		if (elapsedAnimationTime > animationCycleTime)
		{
			elapsedAnimationTime -= animationCycleTime;
		}
		float num = animationOffset + elapsedAnimationTime / animationCycleTime;
		float num2 = ((num > 1f) ? (num - 1f) : num);
		float num3 = animationCurve.Evaluate(num2);
		float y = ((direction == SelectionPointerDirection.Down) ? (0f - distanceToAnimate) : distanceToAnimate) * num3;
		pivot.anchoredPosition = new Vector2(0f, y);
		if (num2 < 0.5f)
		{
			imageColor.a = transparencyCurve.Evaluate(num2 + 0.5f);
			imageCenter.color = imageColor;
		}
		else
		{
			imageColor.a = transparencyCurve.Evaluate(num2 - 0.5f);
			Image image = imageBottom;
			Color color = (imageTop.color = imageColor);
			image.color = color;
		}
		elapsedAnimationTime += Time.deltaTime;
	}
}
