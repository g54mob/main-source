using System.Collections.Immutable;
using System.Reflection.PortableExecutable;

namespace Sentry.Internal.Extensions
{
	internal static class PEReaderExtensions
	{
		public static PEDebugImageData? TryGetPEDebugImageData(this PEReader peReader)
		{
			try
			{
				return peReader.GetPEDebugImageData();
			}
			catch
			{
				return null;
			}
		}

		private static PEDebugImageData GetPEDebugImageData(this PEReader peReader)
		{
			PEHeaders pEHeaders = peReader.PEHeaders;
			PEHeader pEHeader = pEHeaders.PEHeader;
			string codeId = ((pEHeader != null) ? $"{pEHeaders.CoffHeader.TimeDateStamp:X8}{pEHeader.SizeOfImage:x}" : null);
			string text = null;
			string debugFile = null;
			string text2 = null;
			ImmutableArray<DebugDirectoryEntry>.Enumerator enumerator = peReader.ReadDebugDirectory().GetEnumerator();
			while (enumerator.MoveNext())
			{
				DebugDirectoryEntry current = enumerator.Current;
				switch (current.Type)
				{
				case DebugDirectoryEntryType.PdbChecksum:
				{
					PdbChecksumDebugDirectoryData pdbChecksumDebugDirectoryData = peReader.ReadPdbChecksumDebugDirectoryData(current);
					string text3 = pdbChecksumDebugDirectoryData.Checksum.AsSpan().ToHexString();
					text2 = pdbChecksumDebugDirectoryData.AlgorithmName + ":" + text3;
					break;
				}
				case DebugDirectoryEntryType.CodeView:
				{
					CodeViewDebugDirectoryData codeViewDebugDirectoryData = peReader.ReadCodeViewDebugDirectoryData(current);
					debugFile = codeViewDebugDirectoryData.Path;
					text = ((!current.IsPortableCodeView) ? $"{codeViewDebugDirectoryData.Guid}-{codeViewDebugDirectoryData.Age}" : $"{codeViewDebugDirectoryData.Guid}-{current.Stamp:x8}");
					break;
				}
				}
				if (text != null && text2 != null)
				{
					break;
				}
			}
			return new PEDebugImageData
			{
				CodeId = codeId,
				DebugId = text,
				DebugChecksum = text2,
				DebugFile = debugFile
			};
		}
	}
}
