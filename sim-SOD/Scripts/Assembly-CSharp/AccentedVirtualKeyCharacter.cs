using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class AccentedVirtualKeyCharacter : MonoBehaviour
{
	public List<string> spanishAccentCharacters;

	public List<string> frenchAccentCharacters;

	public List<string> portugueseAccentCharacters;

	public List<string> germanAccentCharacters;

	private List<string> _selectedLanguageSet;

	private string _originalCharacter;

	private ButtonController _buttonController;

	private Rewired.Player _player;

	private bool _accentToggleHeld;

	private int _charIndex;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void SetLanguage(string language)
	{
	}

	private void OnDisable()
	{
	}

	private void Update()
	{
	}

	private void CycleTextCharacter()
	{
	}
}
