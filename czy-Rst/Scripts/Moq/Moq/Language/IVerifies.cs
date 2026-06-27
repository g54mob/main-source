using System;
using System.ComponentModel;

namespace Moq.Language
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public interface IVerifies : IFluentInterface
	{
		void Verifiable();

		void Verifiable(string failMessage);

		void Verifiable(Times times);

		void Verifiable(Func<Times> times);

		void Verifiable(Times times, string failMessage);

		void Verifiable(Func<Times> times, string failMessage);
	}
}
