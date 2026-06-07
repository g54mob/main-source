namespace Humanizer.Localisation.NumberToWords
{
	internal abstract class GenderedNumberToWordsConverter : INumberToWordsConverter
	{
		private readonly GrammaticalGender _defaultGender;

		protected GenderedNumberToWordsConverter(GrammaticalGender defaultGender = GrammaticalGender.Masculine)
		{
		}

		public string Convert(long number)
		{
			return null;
		}

		public string Convert(long number, WordForm wordForm)
		{
			return null;
		}

		public string Convert(long number, bool addAnd)
		{
			return null;
		}

		public string Convert(long number, bool addAnd, WordForm wordForm)
		{
			return null;
		}

		public abstract string Convert(long number, GrammaticalGender gender, bool addAnd = true);

		public virtual string Convert(long number, WordForm wordForm, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		public string ConvertToOrdinal(int number)
		{
			return null;
		}

		public abstract string ConvertToOrdinal(int number, GrammaticalGender gender);

		public string ConvertToOrdinal(int number, WordForm wordForm)
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
