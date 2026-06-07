namespace Humanizer.Localisation.Ordinalizers
{
	internal class DefaultOrdinalizer : IOrdinalizer
	{
		public virtual string Convert(int number, string numberString, GrammaticalGender gender)
		{
			return null;
		}

		public virtual string Convert(int number, string numberString)
		{
			return null;
		}

		public virtual string Convert(int number, string numberString, WordForm wordForm)
		{
			return null;
		}

		public virtual string Convert(int number, string numberString, GrammaticalGender gender, WordForm wordForm)
		{
			return null;
		}
	}
}
