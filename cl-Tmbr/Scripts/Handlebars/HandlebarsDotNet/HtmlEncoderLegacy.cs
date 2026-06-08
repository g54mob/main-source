using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using HandlebarsDotNet.StringUtils;

namespace HandlebarsDotNet
{
	public class HtmlEncoderLegacy : ITextEncoder
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Encode(StringBuilder text, TextWriter target)
		{
			if (text != null && text.Length != 0)
			{
				EncodeImpl(new StringBuilderEnumerator(text), target);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Encode(string text, TextWriter target)
		{
			if (!string.IsNullOrEmpty(text))
			{
				EncodeImpl(new StringEnumerator(text), target);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Encode<T>(T text, TextWriter target) where T : IEnumerator<char>
		{
			if (text != null)
			{
				EncodeImpl(text, target);
			}
		}

		private static void EncodeImpl<T>(T text, TextWriter target) where T : IEnumerator<char>
		{
			while (text.MoveNext())
			{
				char current = text.Current;
				switch (current)
				{
				case '"':
					target.Write("&quot;");
					continue;
				case '&':
					target.Write("&amp;");
					continue;
				case '<':
					target.Write("&lt;");
					continue;
				case '>':
					target.Write("&gt;");
					continue;
				}
				if (current > '\u009f')
				{
					target.Write("&#");
					target.Write((int)current);
					target.Write(";");
				}
				else
				{
					target.Write(current);
				}
			}
		}
	}
}
