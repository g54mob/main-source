using UnityEngine;
using UnityEngine.EventSystems;

public class HoverGrow : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	private RuleBookScreenManager ruleBookScreenManager;

	public AnimationCurve growCurve;

	private bool isHovering;

	private float growSeconds;

	public bool limitGrowthDuringConfirmation;

	public void Start()
	{
		if (limitGrowthDuringConfirmation)
		{
			ruleBookScreenManager = Object.FindObjectOfType<RuleBookScreenManager>();
		}
	}

	public void OnEnable()
	{
		base.transform.localScale = new Vector3(growCurve.Evaluate(0f), growCurve.Evaluate(0f), 0f);
		growSeconds = 0f;
		isHovering = false;
	}

	public void Update()
	{
		if (limitGrowthDuringConfirmation && (RuleBookScreenManager.isConfirmingCheatGuess || RuleBookScreenManager.isAnimatingAttempingCheatGuess || ruleBookScreenManager.showingCheatGuessResult))
		{
			if (growSeconds > 0f)
			{
				float num = growCurve.Evaluate(growSeconds);
				base.transform.localScale = new Vector3(num, num, 0f);
				growSeconds -= Time.deltaTime;
			}
		}
		else if (isHovering && growSeconds < growCurve[growCurve.length - 1].time)
		{
			float num2 = growCurve.Evaluate(growSeconds);
			base.transform.localScale = new Vector3(num2, num2, 0f);
			growSeconds += Time.deltaTime;
		}
		else if (growSeconds > 0f && !isHovering)
		{
			float num3 = growCurve.Evaluate(growSeconds);
			base.transform.localScale = new Vector3(num3, num3, 0f);
			growSeconds -= Time.deltaTime;
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		isHovering = true;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isHovering = false;
	}
}
