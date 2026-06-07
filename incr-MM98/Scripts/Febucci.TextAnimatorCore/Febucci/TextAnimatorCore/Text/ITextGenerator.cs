namespace Febucci.TextAnimatorCore.Text
{
	public interface ITextGenerator
	{
		void SetTextToSource(string text);

		void CopyMeshFromSource(ref CharacterData[] characterData, int charactersCount);

		void PasteMeshToSource(CharacterData[] characterData, int charactersCount);

		void ForceMeshUpdate();

		string GetStrippedTextWithoutAnyTags(string textWithoutTAnimTags);

		string GetFullText();

		int GetCharactersCount();

		bool HasChangedMeshRenderingSettings();

		int GetFirstCharacterIndexInsidePage();

		int GetRenderedCharactersCountInsidePage(int charactersCount);
	}
}
