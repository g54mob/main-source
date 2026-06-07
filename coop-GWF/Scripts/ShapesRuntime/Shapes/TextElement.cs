using System;
using System.Globalization;
using System.Text;

namespace Shapes
{
	public class TextElement : IDisposable
	{
		private static int idCounter;

		public readonly int id;

		private StringBuilder sb = new StringBuilder();

		public TextMeshProShapes Tmp => ShapesObjPool<TextMeshProShapes, ShapesTextPool>.Instance.GetElement(id);

		public static int GetNextId()
		{
			return idCounter++;
		}

		public TextElement()
		{
			id = GetNextId();
		}

		public void Dispose()
		{
			ShapesObjPool<TextMeshProShapes, ShapesTextPool>.Instance.ReleaseElement(id);
		}

		public void ClearText()
		{
			sb.Clear();
			Tmp.SetText(sb);
		}

		public void AppendInt(int value, ReadOnlySpan<char> format = default(ReadOnlySpan<char>), int maxCharCount = 12)
		{
			Span<char> span = stackalloc char[maxCharCount];
			value.TryFormat(span, out var charsWritten, format, CultureInfo.InvariantCulture);
			Span<char> span2 = span;
			AppendString(span2.Slice(0, charsWritten));
		}

		public void AppendFloat(float value, ReadOnlySpan<char> format = default(ReadOnlySpan<char>), int maxCharCount = 32)
		{
			Span<char> span = stackalloc char[maxCharCount];
			value.TryFormat(span, out var charsWritten, format, CultureInfo.InvariantCulture);
			Span<char> span2 = span;
			AppendString(span2.Slice(0, charsWritten));
		}

		public void AppendDouble(double value, ReadOnlySpan<char> format = default(ReadOnlySpan<char>), int maxCharCount = 32)
		{
			Span<char> span = stackalloc char[maxCharCount];
			value.TryFormat(span, out var charsWritten, format, CultureInfo.InvariantCulture);
			Span<char> span2 = span;
			AppendString(span2.Slice(0, charsWritten));
		}

		public void AppendString(ReadOnlySpan<char> stringValue)
		{
			sb.Append(stringValue);
			Tmp.SetText(sb);
		}
	}
}
