using System.Collections.Generic;
using UnityEngine;

namespace TinyGiantStudio.Text
{
	public class TypeFace
	{
		private const byte ON_CURVE = 1;

		private const byte X_SHORT = 2;

		private const byte Y_SHORT = 4;

		private const byte REPEAT = 8;

		private const byte X_SAME = 16;

		private const byte Y_SAME = 32;

		private const byte MINIMUM = 2;

		private const byte KERN_VERTICAL = 128;

		public bool kerningSupported;

		public Dictionary<KernPair, short> kernTable;

		private const ushort ARG_1_AND_2_ARE_WORDS = 1;

		private const ushort ARGS_ARE_XY_VALUES = 2;

		private const ushort WE_HAVE_A_SCALE = 8;

		private const ushort MORE_COMPONENTS = 32;

		private const ushort WE_HAVE_AN_X_AND_Y_SCALE = 64;

		private const ushort WE_HAVE_A_TWO_BY_TWO = 128;

		private const ushort USE_MY_METRICS = 512;

		private byte[] fontBytes;

		private bool _isAvailable;

		public string nameEntry;

		private int _unitsPerEm;

		private int _ascent;

		private int _descent;

		private int _lineHeight;

		private uint _glyphDataOffset;

		private int _cmapFormat;

		public int[] glyphIndexArray;

		private int[] _endCodeArray;

		private int[] _startCodeArray;

		private int[] _idDeltaArray;

		private int[] _idRangeOffsetArray;

		private int[] _glyphIdArray;

		private uint[] _locationIndexArray;

		private ushort[] _advanceArray;

		private int[] _leftSideBearing;

		private bool debugLog;

		public Dictionary<char, Glyph> glyphs;

		public int unitsPerEm => 0;

		public int lineHeight => 0;

		public ushort[] advanceArray => null;

		public int[] leftSideBearing => null;

		public TypeFace(byte[] newFontByte)
		{
		}

		private void GetKerning(ref uint idx, ref uint length, bool macTTF)
		{
		}

		private void GetGPOSTag(ref uint idx, ref uint length, int numOfLongHorMetrics)
		{
		}

		private void ParsePairPosLookupTable(byte[] fontBytes, uint offset, Dictionary<string, uint> scriptList, Dictionary<string, uint> featureList, Dictionary<ushort, uint> lookupList)
		{
		}

		private void ParsePairValueRecordSubtable(byte[] fontBytes, ref uint idx, Dictionary<string, uint> scriptList, Dictionary<string, uint> featureList, Dictionary<ushort, uint> lookupList)
		{
		}

		private void ProcessLookupTable(byte[] fontBytes, uint offset, Dictionary<string, uint> scriptList, Dictionary<string, uint> featureList)
		{
		}

		private void ParseTable(byte[] fontBytes, uint offset, out Dictionary<string, uint> dictionary)
		{
			dictionary = null;
		}

		public bool SetGlyphData(char character)
		{
			return false;
		}

		private void ReadGlyphData(uint idx, int numberOfContours, List<Vector2[]> pointsList, List<bool[]> onCurvesList, int xOffset, int yOffset)
		{
		}

		private void SetFormat4(ref uint idx)
		{
		}

		private string GetName(byte[] ttfData, ref uint idx)
		{
			return null;
		}

		private bool TagSearch(byte[] ttfData, string tag, ref uint offset, ref uint length)
		{
			return false;
		}

		private string GetTag(byte[] ttfData, ref uint idx)
		{
			return null;
		}

		private uint GetUint(byte[] ttfData, ref uint idx)
		{
			return 0u;
		}

		private ushort GetUshort(byte[] ttfData, ref uint idx)
		{
			return 0;
		}

		private short GetShort(byte[] ttfData, ref uint idx)
		{
			return 0;
		}

		private ushort[] GetUshortArray(byte[] ttfData, ref uint idx, int arrayLength)
		{
			return null;
		}

		private int[] GetUshortToIntArray(byte[] ttfData, ref uint idx, int arrayLength)
		{
			return null;
		}

		private int[] GetShortToIntArray(byte[] ttfData, ref uint idx, int arrayLength)
		{
			return null;
		}

		private byte[] GetByteArray(byte[] ttfData, ref uint idx, int arrayLength)
		{
			return null;
		}

		private byte[] GetLittleEndianByteArray(byte[] ttfData, ref uint idx, int arrayLength)
		{
			return null;
		}
	}
}
