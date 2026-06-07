namespace Crosstales.Ude.Core
{
	public abstract class SequenceModel
	{
		protected byte[] charToOrderMap;

		protected byte[] precedenceMatrix;

		protected float typicalPositiveRatio;

		protected bool keepEnglishLetter;

		protected string charsetName;

		public float TypicalPositiveRatio => typicalPositiveRatio;

		public bool KeepEnglishLetter => keepEnglishLetter;

		public string CharsetName => charsetName;

		public SequenceModel(byte[] charToOrderMap, byte[] precedenceMatrix, float typicalPositiveRatio, bool keepEnglishLetter, string charsetName)
		{
			this.charToOrderMap = charToOrderMap;
			this.precedenceMatrix = precedenceMatrix;
			this.typicalPositiveRatio = typicalPositiveRatio;
			this.keepEnglishLetter = keepEnglishLetter;
			this.charsetName = charsetName;
		}

		public byte GetOrder(byte b)
		{
			return charToOrderMap[b];
		}

		public byte GetPrecedence(int pos)
		{
			return precedenceMatrix[pos];
		}
	}
}
