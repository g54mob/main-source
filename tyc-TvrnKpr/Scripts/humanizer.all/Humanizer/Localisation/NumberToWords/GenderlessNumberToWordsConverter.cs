namespace Humanizer.Localisation.NumberToWords
{
	internal abstract class GenderlessNumberToWordsConverter : INumberToWordsConverter
	{
		public abstract string Convert(long number);

		public string Convert(long number, WordForm wordForm)
		{
			return null;
		}

		public virtual string Convert(long number, bool addAnd)
		{
			return null;
		}

		public string Convert(long number, bool addAnd, WordForm wordForm)
		{
			return null;
		}

		public virtual string Convert(long number, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		public virtual string Convert(long number, WordForm wordForm, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		public abstract string ConvertToOrdinal(int number);

		public string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return null;
		}

		public virtual string ConvertToOrdinal(int number, WordForm wordForm)
		{
			return null;
		}

		public virtual string ConvertToOrdinal(int number, GrammaticalGender gender, WordForm wordForm)
		{
			return null;
		}

		public virtual string ConvertToTuple(int number)
		{
			return null;
		}
	}
}
