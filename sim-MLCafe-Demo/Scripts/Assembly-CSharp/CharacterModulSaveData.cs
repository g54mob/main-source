using System;

[Serializable]
public class CharacterModulSaveData
{
	public byte gender;

	public byte firstNameIndex;

	public byte secondNameIndex;

	public bool isBaseChar;

	public byte headIndex;

	public byte bodyIndex;

	public byte hairIndex;

	public byte hairColorIndex;

	public CharacterModulSaveData(byte _gender, byte _firstNameIndex, byte _secondNameIndex, bool _isBaseChar, byte _headIndex, byte _bodyIndex, byte _hairIndex, byte _hairColorIndex)
	{
		gender = _gender;
		firstNameIndex = _firstNameIndex;
		secondNameIndex = _secondNameIndex;
		isBaseChar = _isBaseChar;
		headIndex = _headIndex;
		bodyIndex = _bodyIndex;
		hairIndex = _hairIndex;
		hairColorIndex = _hairColorIndex;
	}
}
