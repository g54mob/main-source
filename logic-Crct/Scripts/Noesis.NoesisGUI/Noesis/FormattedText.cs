using System;
using System.Runtime.InteropServices;

namespace Noesis
{
	public class FormattedText : BaseComponent
	{
		public struct LineInfo
		{
			public uint NumGlyphs { get; internal set; }

			public float Height { get; internal set; }

			public float Baseline { get; internal set; }
		}

		public Rect Bounds => default(Rect);

		public bool IsEmpty => false;

		public uint NumLines => 0u;

		internal new static FormattedText CreateProxy(IntPtr cPtr, bool cMemoryOwn)
		{
			return null;
		}

		internal FormattedText(IntPtr cPtr, bool cMemoryOwn)
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		internal static HandleRef getCPtr(FormattedText obj)
		{
			return default(HandleRef);
		}

		public LineInfo GetLineInfo(uint line)
		{
			return default(LineInfo);
		}

		public FormattedText()
			: base((IntPtr)0, cMemoryOwn: false)
		{
		}

		protected override IntPtr CreateCPtr(Type type, out bool registerExtend)
		{
			registerExtend = default(bool);
			return (IntPtr)0;
		}

		public void BuildTextRuns(string text, InlineCollection inlines, FontFamily fontFamily, FontWeight fontWeight, FontStretch fontStretch, FontStyle fontStyle, float fontSize, float strokeThickness, Brush background, Brush foreground, Brush stroke, TextDecorations textDecorations, int charSpacing)
		{
		}

		public Size Measure(TextAlignment alignment, TextWrapping wrapping, TextTrimming trimming, float maxWidth, float maxHeight, float lineHeight, LineStackingStrategy lineStacking)
		{
			return default(Size);
		}

		public void Layout(TextAlignment alignment, TextWrapping wrapping, TextTrimming trimming, float maxWidth, float maxHeight, float lineHeight, LineStackingStrategy lineStacking)
		{
		}

		public void GetGlyphPosition(uint chIndex, bool afterChar, ref float x, ref float y)
		{
		}

		public uint HitTest(float x, float y, ref bool isInside, ref bool isTrailing)
		{
			return 0u;
		}

		private void GetBoundsHelper(ref Rect bounds)
		{
		}

		private void GetLineInfoHelper(uint line, ref uint numGlyphs, ref float height, ref float baseline)
		{
		}
	}
}
