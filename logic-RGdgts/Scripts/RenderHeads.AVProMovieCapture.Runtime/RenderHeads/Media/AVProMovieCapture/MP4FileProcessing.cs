using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace RenderHeads.Media.AVProMovieCapture
{
	public class MP4FileProcessing
	{
		public struct Options
		{
			public bool applyFastStart;

			public bool applyStereoMode;

			public StereoPacking stereoMode;

			public bool applySphericalVideoLayout;

			public SphericalVideoLayout sphericalVideoLayout;

			public bool applyMoveCaptureFile;

			public string finalCaptureFilePath;

			public bool HasOptions()
			{
				return false;
			}

			public bool RequiresProcessing()
			{
				return false;
			}

			public void ResetOptions()
			{
			}
		}

		private class Chunk
		{
			public uint id;

			public long size;

			public long offset;

			public long headerSize;

			public long writeOffset;
		}

		internal enum StereoMode_st3d
		{
			Monoscopic = 0,
			Stereoscopic_TopBottom = 1,
			Stereoscopic_LeftRight = 2,
			Stereoscopic_Custom = 3,
			Stereoscopic_RightLeft = 4
		}

		private const int ChunkHeaderSize = 8;

		private const int ExtendedChunkHeaderSize = 16;

		private const int CopyBufferSize = 65536;

		private static readonly uint Atom_moov;

		private static readonly uint Atom_mdat;

		private static readonly uint Atom_cmov;

		private static readonly uint Atom_trak;

		private static readonly uint Atom_mdia;

		private static readonly uint Atom_hdlr;

		private static readonly uint Atom_minf;

		private static readonly uint Atom_stbl;

		private static readonly uint Atom_stco;

		private static readonly uint Atom_co64;

		private static readonly uint Atom_stsd;

		private static readonly uint Atom_avc1;

		private static readonly uint Atom_hev1;

		private static readonly uint Atom_hvc1;

		private static readonly uint Atom_st3d;

		private static readonly uint Atom_uuid;

		private static readonly uint Atom_sv3d;

		private static readonly uint Atom_svhd;

		private static readonly uint Atom_proj;

		private static readonly uint Atom_prhd;

		private static readonly uint Atom_equi;

		private BinaryReader _reader;

		private Stream _writeFile;

		private Options _options;

		private bool _requires64BitOffsets;

		private List<Chunk> _offsetChunks;

		private List<Chunk> _offsetUpgradeChunks;

		public static ManualResetEvent ProcessFileAsync(string filePath, bool keepBackup, Options options)
		{
			return null;
		}

		public static bool ProcessFile(string filePath, bool keepBackup, Options options)
		{
			return false;
		}

		public static bool ProcessFile(string srcPath, string dstPath, Options options)
		{
			return false;
		}

		public MP4FileProcessing(Options options)
		{
		}

		public bool Process(Stream srcStream, Stream dstStream)
		{
			return false;
		}

		public void Close()
		{
		}

		private static Chunk GetFirstChunkOfType(uint id, List<Chunk> chunks)
		{
			return null;
		}

		private List<Chunk> ReadChildChunks(Chunk parentChunk)
		{
			return null;
		}

		private List<Chunk> ReadChildChunks(long chunkEndPosition)
		{
			return null;
		}

		private Chunk ReadChunkHeader()
		{
			return null;
		}

		private bool ChunkContainsChildChunkWithId(Chunk chunk, uint id)
		{
			return false;
		}

		private static string ChunkDesc(Chunk chunk)
		{
			return null;
		}

		private void WriteChunk(Chunk chunk)
		{
		}

		private void CopyChunkHeader(Chunk chunk)
		{
		}

		private void InjectChunkHeader(Chunk chunk)
		{
		}

		private void CopyBytes(long numBytes)
		{
		}

		private void WriteZeros(long numBytes)
		{
		}

		private uint WriteChunkRecursive_moov(Chunk parentChunk)
		{
			return 0u;
		}

		private bool IsVideoTrack(Chunk trackChunk)
		{
			return false;
		}

		private void WriteChunk_stco(Chunk chunk, uint mdatByteOffset)
		{
		}

		private void WriteChunk_co64_from_stco(Chunk chunk, uint mdatByteOffset)
		{
		}

		private void WriteChunk_co64(Chunk chunk, uint mdatByteOffset)
		{
		}

		private uint InjectChunkStub_co64_from_stco(Chunk chunk)
		{
			return 0u;
		}

		private uint WriteChunk_stsd(Chunk chunk)
		{
			return 0u;
		}

		private static StereoMode_st3d Convert(StereoPacking mode)
		{
			return default(StereoMode_st3d);
		}

		private uint InjectChunk_st3d(StereoMode_st3d stereoMode)
		{
			return 0u;
		}

		private uint InjectChunk_sv3d(SphericalVideoLayout layout)
		{
			return 0u;
		}

		private uint InjectChunk_uuid_GoogleSphericalVideoV1()
		{
			return 0u;
		}

		private uint InjectChunk_svhd(string toolname)
		{
			return 0u;
		}

		private uint InjectChunk_proj(SphericalVideoLayout layout)
		{
			return 0u;
		}

		private uint InjectChunk_prhd()
		{
			return 0u;
		}

		private uint InjectChunk_equi()
		{
			return 0u;
		}

		private void OverwriteChunkSize(Chunk chunk, long writePosition)
		{
		}

		private ushort ReadUInt16()
		{
			return 0;
		}

		private uint ReadUInt32()
		{
			return 0u;
		}

		private ulong ReadUInt64()
		{
			return 0uL;
		}

		private void WriteUInt16(ushort value)
		{
		}

		private void WriteChunkId(uint id)
		{
		}

		private void WriteUInt32(uint value, bool isBigEndian = true)
		{
		}

		private void WriteUInt64(ulong value)
		{
		}

		private static string ChunkIdToString(uint id)
		{
			return null;
		}

		private static uint ChunkId(string id)
		{
			return 0u;
		}

		private static void DebugLog(string message)
		{
		}
	}
}
