using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class RewardButton : MonoBehaviour
{
	public RectTransform TextTransform;

	public Text RewardLabel;

	public Image Button;

	public float MaxSize = 75f;

	private float _lastHint;

	private int _lastReward;

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		int num = GameSettings.Instance.CompletedTasks.Count - GameSettings.Instance.ClaimedRewards.Count;
		if (num != _lastReward)
		{
			if (num > _lastReward)
			{
				UISoundFX.PlaySFX("Reward", -1f, -0.5f);
			}
			if (num > 0)
			{
				RewardLabel.text = "Reward".LocPlural(num);
			}
			if (num == 0)
			{
				TextTransform.DOSizeDelta(new Vector2(0f, 24f), 1f, true);
				Button.DOColor(Color.white, 1f);
			}
			else
			{
				_lastHint = 0f;
				TextTransform.DOSizeDelta(new Vector2(MaxSize, 24f), 1f, true);
			}
			_lastReward = num;
		}
		else if (num > 0)
		{
			_lastHint += Time.deltaTime;
			if (_lastHint > 10f)
			{
				UISoundFX.PlaySFX("Reward", -1f, -0.5f);
				GetComponent<RectTransform>().DOPunchScale(new Vector3(0.5f, 0f, 0f), 0.5f);
				_lastHint = 0f;
			}
			Button.color = Utilities.Blink(Color.white, HUD.GetWarningColor(), 2f);
		}
	}
}
