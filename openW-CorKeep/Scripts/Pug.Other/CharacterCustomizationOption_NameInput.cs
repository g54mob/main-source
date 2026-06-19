public class CharacterCustomizationOption_NameInput : RadicalMenuOptionTextInput
{
	public CharacterCustomizationMenu characterCustomizationMenu;

	public override bool OnSkimRight()
	{
		characterCustomizationMenu.SelectNextIndex();
		return true;
	}
}
