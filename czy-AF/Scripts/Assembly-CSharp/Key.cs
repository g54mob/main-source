using UnityEngine;

public class Key
{
	public KeyCode key;

	public KeyCode keyAlternative;

	public bool modifierControl;

	public bool modifierShift;

	public bool modifierAlt;

	public Key(KeyCode _key, KeyCode _keyAlternative = KeyCode.None, bool _modifierControl = false, bool _modifierShift = false, bool _modifierAlt = false)
	{
		key = _key;
		if (_keyAlternative == KeyCode.None)
		{
			_keyAlternative = _key;
		}
		keyAlternative = _keyAlternative;
		modifierControl = _modifierControl;
		modifierShift = _modifierShift;
		modifierAlt = _modifierAlt;
	}
}
