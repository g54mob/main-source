using TMPro;
using UnityEngine;

public class LocalizeConcatenator : SceneBehaviour
{
	[SerializeField]
	private ConcatenatedLocalizedString _concatenator;

	[SerializeField]
	private TextMeshProUGUI _target;

	private void OnValidate()
	{
		if (_target == null)
		{
			_target = GetComponent<TextMeshProUGUI>();
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (_target == null)
		{
			_target = GetComponent<TextMeshProUGUI>();
		}
	}

	private void OnEnable()
	{
		_target.text = _concatenator.ToString();
	}
}
