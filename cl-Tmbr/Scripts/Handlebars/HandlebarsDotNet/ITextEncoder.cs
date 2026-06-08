using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HandlebarsDotNet
{
	public interface ITextEncoder
	{
		void Encode(StringBuilder text, TextWriter target);

		void Encode(string text, TextWriter target);

		void Encode<T>(T text, TextWriter target) where T : IEnumerator<char>;
	}
}
