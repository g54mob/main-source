using Aggro.Core;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class ShopItemUI : EntityBehaviourBase
{
	public RectTransform container;

	public TextMeshProUGUI nameText;

	public TextMeshProUGUI descriptionText;

	public float easeSpeed = 5f;

	public EasingFunction.Ease easeIn = EasingFunction.Ease.Linear;

	public EasingFunction.Ease easeOut = EasingFunction.Ease.Linear;

	public bool viewing;

	private float currentScale;

	public float scale = 1f;

	private Vector3 targetWorldPos = Vector3.zero;

	public Vector3 offset;

	protected override void OnUpdatePresentation()
	{
		if (GameUtil.TryGetLocalPlayer(out var player) && player.TryGetObject<PlayerGrabber>(out var obj) && obj.TryGetShopHolderGrabTarget(out var holder) && holder.TryGetShopItem(out var _))
		{
			viewing = true;
			targetWorldPos = holder.transform.position + offset;
		}
		else
		{
			viewing = false;
		}
		Vector3 vector = GameUtil.mainCamera.WorldToScreenPoint(targetWorldPos);
		vector *= math.sign(vector.z) / Options.renderScale;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(container, vector, GameUtil.uiCamera, out var localPoint);
		base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, localPoint, 100f * Time.deltaTime);
		float num = (viewing ? 1f : (-1f));
		EasingFunction.Ease ease = (viewing ? easeIn : easeOut);
		currentScale += num * easeSpeed * Time.deltaTime;
		currentScale = Mathf.Clamp01(currentScale);
		float num2 = EasingFunction.Evaluate(ease, currentScale);
		base.transform.localScale = scale * num2 * Vector3.one;
	}
}
