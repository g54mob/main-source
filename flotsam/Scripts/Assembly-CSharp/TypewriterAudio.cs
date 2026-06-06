using System;
using FMODUnity;
using Febucci.UI.Core;
using UnityEngine;

public class TypewriterAudio : MonoBehaviour
{
	[Serializable]
	private struct CharacterEvent
	{
		public string Characters;

		public EventReference Event;

		public bool Play(char character)
		{
			if (Characters.Contains(character))
			{
				AudioManager.PlayOneShot(Event);
				return true;
			}
			return false;
		}
	}

	[SerializeField]
	private TypewriterCore _typewriter;

	[Header("FMOD Events")]
	[SerializeField]
	private EventReference _defaultEvent;

	[SerializeField]
	private CharacterEvent[] _characterEvents;

	[SerializeField]
	private string _noEventCharacters;

	private void Awake()
	{
		if (_typewriter == null)
		{
			_typewriter = base.gameObject.GetComponentInChildren<TypewriterCore>(includeInactive: true);
		}
	}

	private void OnEnable()
	{
		_typewriter.onCharacterVisible.AddListener(OnCharactVisible);
	}

	private void OnDisable()
	{
		_typewriter.onCharacterVisible.RemoveListener(OnCharactVisible);
	}

	private void OnCharactVisible(char character)
	{
		if (_noEventCharacters.Contains(character))
		{
			return;
		}
		CharacterEvent[] characterEvents = _characterEvents;
		foreach (CharacterEvent characterEvent in characterEvents)
		{
			if (characterEvent.Play(character))
			{
				return;
			}
		}
		AudioManager.PlayOneShot(_defaultEvent);
	}
}
