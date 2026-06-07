using System.Collections.Generic;

public static class NumericFormatDataExtension
{
	private static readonly Dictionary<NumericFormat, string> data = new Dictionary<NumericFormat, string>
	{
		{
			NumericFormat.Currency,
			"${0:000,000,000}"
		},
		{
			NumericFormat.Percentage,
			"{0:N2}%"
		},
		{
			NumericFormat.PercentageDetailed,
			"{0:N4}%"
		},
		{
			NumericFormat.Integer3,
			"{0:000}"
		},
		{
			NumericFormat.Integer6,
			"{0:000,000}"
		},
		{
			NumericFormat.Integer9,
			"{0:000,000,000}"
		},
		{
			NumericFormat.Ping,
			"{0:000}ms"
		},
		{
			NumericFormat.Data,
			"{0:00.0}"
		},
		{
			NumericFormat.Revenue,
			"${0:N0}/s"
		},
		{
			NumericFormat.Tickrate,
			"{0:N0}Hz"
		},
		{
			NumericFormat.DataMax,
			"{0:00.0}TiB"
		},
		{
			NumericFormat.MilestoneProgress,
			"{0:N1}%"
		},
		{
			NumericFormat.Droprate,
			"{0:N0}%"
		},
		{
			NumericFormat.Escrow,
			"${0:000,000,000,000}"
		},
		{
			NumericFormat.MilestoneComplete,
			"{0:N0}%"
		}
	};

	public static string Value(this NumericFormat key)
	{
		return data[key];
	}
}
