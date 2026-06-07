namespace Humanizer.Localisation.NumberToWords
{
	public interface INumberToWordsConverter
	{
		string Convert(long number);

		string Convert(long number, WordForm wordForm);

		string Convert(long number, bool addAnd);

		string Convert(long number, bool addAnd, WordForm wordForm);

		string Convert(long number, GrammaticalGender gender, bool addAnd = true);

		string Convert(long number, WordForm wordForm, GrammaticalGender gender, bool addAnd = true);

		string ConvertToOrdinal(int number);

		string ConvertToOrdinal(int number, WordForm wordForm);

		string ConvertToOrdinal(int number, GrammaticalGender gender);

		string ConvertToOrdinal(int number, GrammaticalGender gender, WordForm wordForm);

		string ConvertToTuple(int number);
	}
}
