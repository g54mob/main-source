public class PlayerKeyArtTable : ScriptableDataBlock
{
	public KeyArtCharacters[] keyArtCharacters;

	public bool IsKeyArt(PlayerCustomization customization)
	{
		KeyArtCharacters[] array = this.keyArtCharacters;
		foreach (KeyArtCharacters keyArtCharacters in array)
		{
			if (keyArtCharacters.Matches(customization))
			{
				return true;
			}
		}
		return false;
	}
}
