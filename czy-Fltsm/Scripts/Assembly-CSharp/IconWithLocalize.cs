using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

public class IconWithLocalize : MonoBehaviour
{
	public const string TERM_MissingTerm = "MissingTerm";

	[SerializeField]
	private Image _icon;

	[SerializeField]
	private Localize _localize;

	public void Initialize(Sprite sprite, string term)
	{
		_icon.overrideSprite = sprite;
		if (string.IsNullOrEmpty(term))
		{
			_localize.SetTerm("MissingTerm");
		}
		else
		{
			_localize.SetTerm(term);
		}
	}

	public void OnLocalize()
	{
		if (!string.IsNullOrEmpty(Localize.MainTranslation))
		{
			Localize.MainTranslation = TextManager.ReplaceVariablesWithEmptyString(Localize.MainTranslation);
		}
	}
}
