namespace Simulator
{
	public interface ISaveManagerModifier
	{
		Save CreateSave();

		Save ReadSaveFromFile(string content);

		string GetSaveContent();
	}
}
