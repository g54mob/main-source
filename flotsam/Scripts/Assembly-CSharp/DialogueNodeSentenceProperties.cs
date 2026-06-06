using UnityEngine;

public class DialogueNodeSentenceProperties : DialogueNodeProperties
{
	[SerializeField]
	private ConcatenatedLocalizedString _sentenceTexts;

	[SerializeField]
	[Tooltip("This should be used for development only! If no localization key is provided, this will be used instead.")]
	private string _fallbackText;

	protected override string DefaultNodeName => "Sentence";

	public bool HasText
	{
		get
		{
			if (_sentenceTexts == null || !_sentenceTexts.HasText())
			{
				return !_fallbackText.IsNullOrEmpty();
			}
			return true;
		}
	}

	public string Text => _sentenceTexts.GetOrDefault(_fallbackText);
}
