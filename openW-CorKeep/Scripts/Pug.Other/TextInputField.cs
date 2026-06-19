using UnityEngine;
using UnityEngine.Events;

public class TextInputField : UIelement, InputManager.TextInputInterface
{
	public PugText pugText;

	public PugText hintText;

	public string hintString;

	private int currentCharIndex;

	public GameObject selectedMarker;

	public CharacterMarkBlinker characterMarkBlinker;

	public float maxWidth;

	public float maxHeight;

	public bool dontAllowNewLines;

	public bool trim = true;

	public string characterWhiteList = "";

	public UnityEvent onInputFieldDone;

	public bool triggerOnInputFieldDoneWhenCanceling;

	public bool dontDeactivateOnDeselect;

	private bool shouldHide;

	public bool inputIsActive { get; private set; }

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

	protected void Awake()
	{
		characterMarkBlinker.gameObject.SetActive(value: false);
		selectedMarker.SetActive(value: false);
		if (pugText != null)
		{
			pugText.maxWidth = maxWidth + (float)(dontAllowNewLines ? 1 : 0);
		}
	}

	private void OnValidate()
	{
		if (pugText != null)
		{
			pugText.maxWidth = maxWidth;
		}
	}

	protected void Update()
	{
		UpdateHintText();
		Vector2 vector = new Vector2(pugText.transform.position.x, pugText.transform.position.y);
		float num = ((pugText.dimensions.height > 0f) ? (pugText.dimensions.height / ((float)pugText.displayedTextStringLinesAmount * 2f)) : 0f);
		int num2 = currentCharIndex;
		Vector2 vector2 = vector + new Vector2(pugText.dimensions.min.x, pugText.dimensions.max.y) + new Vector2(1f / 32f, 0f - num);
		vector2 += ((num2 > 0 && num2 <= pugText.localCharacterEndPositions.Count) ? pugText.localCharacterEndPositions[num2 - 1] : Vector2.zero);
		characterMarkBlinker.transform.position = new Vector3(vector2.x, vector2.y, characterMarkBlinker.transform.position.z);
		pugText.Render();
		bool checkForProfanity = pugText.checkForProfanity;
		pugText.checkForProfanity = false;
		TrimTextToFitRestrictions();
		if (checkForProfanity)
		{
			pugText.checkForProfanity = true;
			pugText.Render(rewindEffectAnims: false);
		}
		currentCharIndex = Mathf.Clamp(currentCharIndex, 0, pugText.displayedTextString.Length);
	}

	private void TrimTextToFitRestrictions()
	{
		while (currentCharIndex > 0 && ((maxWidth > 0f && pugText.dimensions.width > maxWidth) || (maxHeight > 0f && pugText.dimensions.height > maxHeight)))
		{
			currentCharIndex--;
			string text = pugText.GetText();
			pugText.SetText(text.Remove(currentCharIndex, 1));
			pugText.Render(rewindEffectAnims: false);
		}
	}

	private void UpdateHintText()
	{
		if (pugText.GetText() == "" && hintText.GetText() == "")
		{
			hintText.Render(hintString);
		}
		else if (pugText.GetText() != "" && hintText.GetText() != "")
		{
			hintText.Render("");
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
				for (i = 0; i < characterWhiteList.Length && s[num] != characterWhiteList[i]; i++)
				{
				}
				if (characterWhiteList.Length > 0 && i == characterWhiteList.Length)
				{
					s = s.Remove(num, 1);
				}
			}
		}
		if (currentCharIndex > pugText.displayedTextString.Length)
		{
			Debug.LogError("currentCharIndex > pugText.displayedTextString.Length");
			currentCharIndex = pugText.displayedTextString.Length;
		}
		if (currentCharIndex == pugText.displayedTextString.Length)
		{
			pugText.SetText(pugText.displayedTextString + s);
		}
		else
		{
			pugText.SetText(pugText.displayedTextString.Insert(currentCharIndex, s));
		}
		bool num2 = currentCharIndex == pugText.displayedTextString.Length;
		currentCharIndex += s.Length;
		pugText.Render(rewindEffectAnims: false);
		TrimTextToFitRestrictions();
		if (num2)
		{
			currentCharIndex = pugText.displayedTextString.Length;
		}
		WasAutoActivated = false;
	}

	public void MoveCharMarker(int relativeChange)
	{
		currentCharIndex += relativeChange;
		currentCharIndex = Mathf.Clamp(currentCharIndex, 0, pugText.displayedTextString.Length);
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
		if (pugText.displayedTextString.Length > currentCharIndex)
		{
			pugText.SetText(pugText.displayedTextString.Remove(currentCharIndex, 1));
			pugText.Render(rewindEffectAnims: false);
		}
	}

	public void RemoveCharBehindMarker()
	{
		if (currentCharIndex > 0 && pugText.displayedTextString.Length >= currentCharIndex)
		{
			pugText.SetText(pugText.displayedTextString.Remove(currentCharIndex - 1, 1));
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
		if (!dontDeactivateOnDeselect)
		{
			Deactivate(commit: false);
		}
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		Manager.input.SetActiveInputField(this);
		Manager.input.DisableInput();
		characterMarkBlinker.EnableAndResetBlink();
		inputIsActive = true;
	}

	public void ResetText()
	{
		SetInputText("");
	}

	public string GetInputText()
	{
		if (pugText.checkForProfanity && !Manager.networking.OfflineSession)
		{
			return pugText.displayedTextString;
		}
		return pugText.GetText();
	}

	public void SetInputText(string text)
	{
		pugText.SetText(text);
		pugText.Render(rewindEffectAnims: false);
		currentCharIndex = text.Length;
		UpdateHintText();
	}

	public void Deactivate(bool commit)
	{
		Manager.input.SetActiveInputField(null);
		Manager.input.EnableInput();
		characterMarkBlinker.gameObject.SetActive(value: false);
		if (commit || triggerOnInputFieldDoneWhenCanceling)
		{
			onInputFieldDone?.Invoke();
		}
		inputIsActive = false;
	}
}
