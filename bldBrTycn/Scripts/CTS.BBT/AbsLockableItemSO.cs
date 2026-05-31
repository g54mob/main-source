using System;
using CTS;
using NaughtyAttributes;
using UnityEngine;

public abstract class AbsLockableItemSO : ScriptableObject
{
	public enum ELockState
	{
		Removed = 0,
		Locked = 1,
		OnTesting = 2,
		Validated = 3
	}

	[SerializeField]
	[BoxGroup("Validations")]
	[Tooltip("Developers Validation")]
	private ELockState _devValidation = ELockState.OnTesting;

	[SerializeField]
	[BoxGroup("Validations")]
	[Tooltip("Artists Validation")]
	private ELockState _artValidation = ELockState.OnTesting;

	[SerializeField]
	[BoxGroup("Validations")]
	[Tooltip("TechArts Validation")]
	private ELockState _techArtValidation = ELockState.OnTesting;

	[SerializeField]
	[BoxGroup("Validations")]
	[Tooltip("Game Designers Validation")]
	private ELockState _gameDesignValidation = ELockState.OnTesting;

	[SerializeField]
	[BoxGroup("Validations")]
	[TextArea]
	private string _notes;

	[SerializeField]
	[BoxGroup("Unlock Keys")]
	private EUnlockKey _unlockFULLVERSION;

	[SerializeField]
	[BoxGroup("Unlock Keys")]
	[ShowIf("IncludeInDEMO")]
	private EUnlockKey _unlockDEMO;

	[field: SerializeField]
	[field: BoxGroup("Unlock Keys")]
	public bool IncludeInDEMO { get; private set; }

	[field: SerializeField]
	[field: BoxGroup("Store")]
	public bool OutOfStore { get; private set; }

	public ELockState GetValidationState
	{
		get
		{
			if (_unlockFULLVERSION == (EUnlockKey)0)
			{
				return ELockState.Removed;
			}
			if (OutOfStore)
			{
				return ELockState.Removed;
			}
			if (_devValidation == ELockState.Validated && _artValidation == ELockState.Validated && _techArtValidation == ELockState.Validated && _gameDesignValidation == ELockState.Validated)
			{
				return ELockState.Validated;
			}
			return ELockState.Removed;
		}
	}

	public bool ContainsKey(EUnlockKey key)
	{
		EUnlockKey unlockKeys = GetUnlockKeys();
		Array values = Enum.GetValues(typeof(EUnlockKey));
		for (int i = 0; i < values.Length; i++)
		{
			EUnlockKey eUnlockKey = (EUnlockKey)values.GetValue(i);
			if (unlockKeys.HasFlag(eUnlockKey) && key.HasFlag(eUnlockKey))
			{
				return true;
			}
		}
		return false;
	}

	public EUnlockKey GetUnlockKeys()
	{
		return _unlockFULLVERSION;
	}
}
