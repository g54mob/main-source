using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultLuggageBar : MonoBehaviour
{
	[SerializeField]
	private Image luggageIcon;

	[SerializeField]
	private Image buffIcon;

	[SerializeField]
	private Image countBar;

	[SerializeField]
	private TMP_Text countText;

	[SerializeField]
	private List<Sprite> buffSprite;

	[SerializeField]
	private Sprite sallyCountBarSprite;

	private float _fillAmountCache;

	public void Init(bool isSally, string iconPath, float count, float maxCount, int buffLevel = -1, bool needAnimation = false)
	{
	}

	public void AnimationBar(float duration = 1f)
	{
	}
}
