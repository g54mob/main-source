using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class STMMatchRect : MonoBehaviour
{
	public enum RectToMatch
	{
		ActiveBounds = 0,
		FinalBounds = 1,
		MaxBounds = 2
	}

	private RectTransform tr;

	public SuperTextMesh stm;

	private Vector2 size;

	private Vector2 offset;

	public Vector2 padding = Vector2.zero;

	public RectToMatch rectToMatch;

	public void OnEnable()
	{
		tr = GetComponent<RectTransform>();
		stm.OnPrintEvent += Match;
	}

	public void OnDisable()
	{
		stm.OnPrintEvent -= Match;
	}

	public void Match()
	{
		if (rectToMatch == RectToMatch.ActiveBounds)
		{
			size.x = stm.bottomRightTextBounds.x - stm.topLeftTextBounds.x;
			size.y = 0f - stm.bottomRightTextBounds.y + stm.topLeftTextBounds.y;
		}
		else if (rectToMatch == RectToMatch.FinalBounds)
		{
			size.x = stm.finalBottomRightTextBounds.x - stm.topLeftTextBounds.x;
			size.y = 0f - stm.finalBottomRightTextBounds.y + stm.topLeftTextBounds.y;
		}
		else
		{
			size.x = stm.bottomRightBounds.x - stm.topLeftBounds.x;
			size.y = 0f - stm.bottomRightBounds.y + stm.topLeftBounds.y;
		}
		size.x += padding.x;
		size.y += padding.y;
		offset.x = stm.t.position.x + stm.rawTopLeftBounds.x + stm.rawBottomRightBounds.x * 2f - padding.x / 2f;
		offset.y = stm.t.position.y - size.y - stm.rawTopLeftBounds.y + padding.y / 2f;
		tr.sizeDelta = size;
		tr.position = offset;
		tr.pivot = Vector2.zero;
	}
}
