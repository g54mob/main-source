using Aggro.Core;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStressBarUI : EntityBehaviourBase
{
	public Image fastFill;

	public Image slowFill;

	public Transform barParent;

	public EaseUI easeUI;

	public float teststress;

	public Vector2 fillbarMinMax = new Vector2(0f, 100f);

	public float slowFillSpeed = 2f;

	public float previousFastFillAmount;

	protected override void OnUpdatePresentation()
	{
		if (!GameUtil.TryGetLocalPlayer(out var player))
		{
			return;
		}
		PlayerStress playerStress = player.GetObject<PlayerStress>();
		float num = fillbarMinMax.y - fillbarMinMax.x;
		fastFill.fillAmount = fillbarMinMax.x + playerStress.stressNormalizedValue * num;
		if (previousFastFillAmount > fastFill.fillAmount)
		{
			slowFill.fillAmount = fastFill.fillAmount;
		}
		else
		{
			float num2 = ((slowFill.fillAmount > fastFill.fillAmount) ? (-1f) : 1f);
			slowFill.fillAmount += num2 * slowFillSpeed * Time.deltaTime;
			if ((slowFill.fillAmount - fastFill.fillAmount) * num2 > 0f)
			{
				slowFill.fillAmount = fastFill.fillAmount;
			}
		}
		easeUI.show = (double)slowFill.fillAmount > (double)fillbarMinMax.x + 0.01 * (double)num;
		previousFastFillAmount = fastFill.fillAmount;
	}
}
