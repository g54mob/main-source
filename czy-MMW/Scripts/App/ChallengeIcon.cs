using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ChallengeIcon : MonoBehaviour
{
	[SerializeField]
	private Image _challengeIcon;

	[SerializeField]
	private Image _challengeSubIcon;

	[SerializeField]
	private Image _challengeSubIconBackground;

	[SerializeField]
	private Image _normalBackground;

	[SerializeField]
	private Image _wildcardBackground;

	public void SetChallengeIcons(Sprite challengeIconSprite, bool isWildcardChallenge)
	{
		SetChallengeIcons(challengeIconSprite, isWildcardChallenge, null, null);
	}

	public void SetChallengeIcons(Sprite challengeIconSprite, bool isWildcardChallenge, Sprite subIcon, Sprite subiconBackground)
	{
		_challengeIcon.sprite = challengeIconSprite;
		if (subIcon != null && subiconBackground != null)
		{
			_challengeSubIcon.enabled = true;
			_challengeSubIconBackground.enabled = true;
			_challengeSubIcon.sprite = subIcon;
			_challengeSubIconBackground.sprite = subiconBackground;
		}
		else
		{
			_challengeSubIcon.enabled = false;
			_challengeSubIconBackground.enabled = false;
		}
		_normalBackground.gameObject.SetActive(!isWildcardChallenge);
		_wildcardBackground.gameObject.SetActive(isWildcardChallenge);
	}
}
