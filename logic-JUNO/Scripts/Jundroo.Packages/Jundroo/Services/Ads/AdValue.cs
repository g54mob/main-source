namespace Jundroo.Services.Ads
{
	public class AdValue
	{
		public enum PrecisionType
		{
			Unknown = 0,
			Estimated = 1,
			PublisherProvided = 2,
			Precise = 3
		}

		public string CurrencyCode { get; set; }

		public PrecisionType Precision { get; set; }

		public long Value { get; set; }

		public AdValue(long value, PrecisionType precision, string currencyCode)
		{
			Value = value;
			Precision = precision;
			CurrencyCode = currencyCode;
		}

		public override string ToString()
		{
			return $"{Value} {CurrencyCode} ({Precision})";
		}
	}
}
