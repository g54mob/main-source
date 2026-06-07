namespace Humanizer.Localisation.Ordinalizers
{
	public interface IOrdinalizer
	{
		string Convert(int number, string numberString);

		string Convert(int number, string numberString, WordForm wordForm);

		string Convert(int number, string numberString, GrammaticalGender gender);

		string Convert(int number, string numberString, GrammaticalGender gender, WordForm wordForm);
	}
}
