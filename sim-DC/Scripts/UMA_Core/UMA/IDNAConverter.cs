using System;

namespace UMA
{
	public interface IDNAConverter
	{
		Type DNAType { get; }

		string name { get; }

		string DisplayValue { get; }

		int DNATypeHash { get; }

		DNAConvertDelegate PreApplyDnaAction { get; }

		DNAConvertDelegate ApplyDnaAction { get; }

		DNAConvertDelegate PostApplyDnaAction { get; }

		void Prepare();
	}
}
