using System.Collections;
using UnityEngine;

public class RadicalMenuOptionTextInput : RadicalMenuOption, InputManager.TextInputInterface
{
	public PugText pugText;

	public PugText hintText;

	public string hintString;

	private int currentCharIndex;

	public GameObject selectedMarker;

	public CharacterMarkBlinker characterMarkBlinker;

	public float maxWidth;

	public bool resetTextOnActivate;

	public bool dontAllowNewLines;

	public bool trim = true;

	public string characterWhiteList = "";

	public bool ignoreCapitalizationInWhiteList;

	public RadicalMenuOption_Toggle radicalMenuOptionToggleVisibility;

	public bool readOnly;

	private bool shouldHide;

	public float shakeDuration = 0.4f;

	public float shakeMagnitude = 0.0625f;

	public int shakesPerSecond = 20;

	private Coroutine _shakeCoroutine;

	private Vector3 _shakeOriginalPosition;

	[field: SerializeField]
	public int MaxCharactersForOnScreenKeyboard { get; private set; } = 255;

	public bool WasAutoActivated
	{
		get
		{
			return wasAutoActivated;
		}
		set
		{
			wasAutoActivated = value;
		}
	}

	protected override void Awake()
	{
		base.Awake();
		characterMarkBlinker.gameObject.SetActive(value: false);
		selectedMarker.SetActive(value: false);
	}

	protected override void Update()
	{
		if (pugText.GetText() == "" && hintText.GetText() == "")
		{
			hintText.Render(hintString);
		}
		else if (pugText.GetText() != "" && hintText.GetText() != "")
		{
			hintText.Render("");
		}
		float num = pugText.transform.position.x + pugText.dimensions.xMin + 1f / 32f;
		num += ((currentCharIndex > 0 && currentCharIndex <= pugText.localCharacterEndPositions.Count) ? pugText.localCharacterEndPositions[currentCharIndex - 1].x : 0f);
		characterMarkBlinker.transform.position = new Vector3(num, characterMarkBlinker.transform.position.y, characterMarkBlinker.transform.position.z);
		if (radicalMenuOptionToggleVisibility != null)
		{
			bool num2 = pugText.isHidden != !radicalMenuOptionToggleVisibility.isOn;
			pugText.isHidden = !radicalMenuOptionToggleVisibility.isOn;
			if (num2)
			{
				pugText.Render();
			}
		}
		while (maxWidth > 0f && pugText.dimensions.width > maxWidth)
		{
			pugText.SetText(pugText.GetText().Substring(0, pugText.GetText().Length - 1));
			currentCharIndex--;
			pugText.Render(rewindEffectAnims: false);
		}
	}

	public void AppendString(string s)
	{
		if (trim)
		{
			s = s.Trim();
		}
		for (int num = s.Length - 1; num >= 0; num--)
		{
			if (dontAllowNewLines && (s[num] == '\n' || s[num] == '\r'))
			{
				s = s.Remove(num, 1);
			}
			else
			{
				int i;
				for (i = 0; i < characterWhiteList.Length && (ignoreCapitalizationInWhiteList || s[num] != characterWhiteList[i]) && (!ignoreCapitalizationInWhiteList || !(s[num].ToString().ToLower() == characterWhiteList[i].ToString().ToLower())); i++)
				{
				}
				if (characterWhiteList.Length > 0 && i == characterWhiteList.Length)
				{
					s = s.Remove(num, 1);
				}
			}
		}
		string text = pugText.GetText();
		if (currentCharIndex > pugText.GetText().Length)
		{
			Debug.LogError("currentCharIndex > pugText.textString.Length");
			currentCharIndex = pugText.GetText().Length;
		}
		if (currentCharIndex == pugText.GetText().Length)
		{
			pugText.SetText(pugText.GetText() + s);
		}
		else
		{
			pugText.SetText(pugText.GetText().Insert(currentCharIndex, s));
		}
		currentCharIndex += s.Length;
		pugText.Render(rewindEffectAnims: false);
		if (pugText.dimensions.width > maxWidth)
		{
			pugText.SetText(text);
			currentCharIndex -= s.Length;
			pugText.Render(rewindEffectAnims: false);
		}
		WasAutoActivated = false;
	}

	public void MoveCharMarker(int relativeChange)
	{
		currentCharIndex += relativeChange;
		currentCharIndex = Mathf.Clamp(currentCharIndex, 0, pugText.GetTextLength());
	}

	public string GetHintString()
	{
		return hintText.ProcessText(hintString);
	}

	public bool IsHidden()
	{
		return pugText.isHidden;
	}

	public void RemoveCharAtMarker()
	{
		if (pugText.GetTextLength() > currentCharIndex)
		{
			pugText.SetText(pugText.GetText().Remove(currentCharIndex, 1));
			pugText.Render(rewindEffectAnims: false);
		}
	}

	public void RemoveCharBehindMarker()
	{
		if (currentCharIndex > 0 && pugText.GetTextLength() >= currentCharIndex)
		{
			pugText.SetText(pugText.GetText().Remove(currentCharIndex - 1, 1));
			currentCharIndex--;
			pugText.Render(rewindEffectAnims: false);
		}
	}

	public override void OnSelected()
	{
		base.OnSelected();
		selectedMarker.SetActive(value: true);
	}

	public override void OnDeselected(bool playEffect = true)
	{
		base.OnDeselected(playEffect);
		selectedMarker.SetActive(value: false);
	}

	public override void OnActivated()
	{
		base.OnActivated();
		if (!readOnly)
		{
			if (resetTextOnActivate)
			{
				ResetText();
			}
			Manager.input.SetActiveInputField(this);
			characterMarkBlinker.EnableAndResetBlink();
		}
	}

	public override void OnParentMenuActivation()
	{
		base.OnParentMenuActivation();
		if (resetTextOnActivate)
		{
			ResetText();
		}
	}

	public void ResetText()
	{
		SetInputText("");
	}

	public string GetInputText()
	{
		return pugText.GetText();
	}

	public void SetInputText(string text)
	{
		pugText.SetText(text);
		pugText.Render(rewindEffectAnims: false);
		currentCharIndex = text.Length;
	}

	public void Deactivate(bool commit)
	{
		Manager.input.SetActiveInputField(null);
		characterMarkBlinker.gameObject.SetActive(value: false);
	}

	public void Shake()
	{
		if (_shakeCoroutine != null)
		{
			StopCoroutine(_shakeCoroutine);
			base.transform.localPosition = _shakeOriginalPosition;
		}
		_shakeOriginalPosition = base.transform.localPosition;
		_shakeCoroutine = StartCoroutine(ShakeAndClear());
	}

	private IEnumerator ShakeAndClear()
	{
		yield return EffectCoroutines.Shake(base.transform, shakeDuration, shakeMagnitude, shakesPerSecond);
		_shakeCoroutine = null;
	}
}
