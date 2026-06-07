using System.Collections;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters;
using BestHTTP.SecureProtocol.Org.BouncyCastle.Utilities;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Digests
{
	public class SkeinEngine : IMemoable
	{
		private class Configuration
		{
			private byte[] bytes;

			public byte[] Bytes => null;

			public Configuration(long outputSizeBits)
			{
			}
		}

		public class Parameter
		{
			private int type;

			private byte[] value;

			public int Type => 0;

			public byte[] Value => null;

			public Parameter(int type, byte[] value)
			{
			}
		}

		private class UbiTweak
		{
			private const ulong LOW_RANGE = 18446744069414584320uL;

			private const ulong T1_FINAL = 9223372036854775808uL;

			private const ulong T1_FIRST = 4611686018427387904uL;

			private ulong[] tweak;

			private bool extendedPosition;

			public uint Type
			{
				get
				{
					return 0u;
				}
				set
				{
				}
			}

			public bool First
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public bool Final
			{
				get
				{
					return false;
				}
				set
				{
				}
			}

			public void Reset(UbiTweak tweak)
			{
			}

			public void Reset()
			{
			}

			public void AdvancePosition(int advance)
			{
			}

			public ulong[] GetWords()
			{
				return null;
			}

			public override string ToString()
			{
				return null;
			}
		}

		private class UBI
		{
			private readonly UbiTweak tweak;

			private readonly SkeinEngine engine;

			private byte[] currentBlock;

			private int currentOffset;

			private ulong[] message;

			public UBI(SkeinEngine engine, int blockSize)
			{
			}

			public void Reset(UBI ubi)
			{
			}

			public void Reset(int type)
			{
			}

			public void Update(byte[] value, int offset, int len, ulong[] output)
			{
			}

			private void ProcessBlock(ulong[] output)
			{
			}

			public void DoFinal(ulong[] output)
			{
			}
		}

		public const int SKEIN_256 = 256;

		public const int SKEIN_512 = 512;

		public const int SKEIN_1024 = 1024;

		private const int PARAM_TYPE_KEY = 0;

		private const int PARAM_TYPE_CONFIG = 4;

		private const int PARAM_TYPE_MESSAGE = 48;

		private const int PARAM_TYPE_OUTPUT = 63;

		private static readonly IDictionary INITIAL_STATES;

		private readonly ThreefishEngine threefish;

		private readonly int outputSizeBytes;

		private ulong[] chain;

		private ulong[] initialState;

		private byte[] key;

		private Parameter[] preMessageParameters;

		private Parameter[] postMessageParameters;

		private readonly UBI ubi;

		private readonly byte[] singleByte;

		public int OutputSize => 0;

		public int BlockSize => 0;

		static SkeinEngine()
		{
		}

		private static void InitialState(int blockSize, int outputSize, ulong[] state)
		{
		}

		private static int VariantIdentifier(int blockSizeBytes, int outputSizeBytes)
		{
			return 0;
		}

		public SkeinEngine(int blockSizeBits, int outputSizeBits)
		{
		}

		public SkeinEngine(SkeinEngine engine)
		{
		}

		private void CopyIn(SkeinEngine engine)
		{
		}

		private static Parameter[] Clone(Parameter[] data, Parameter[] existing)
		{
			return null;
		}

		public IMemoable Copy()
		{
			return null;
		}

		public void Reset(IMemoable other)
		{
		}

		public void Init(SkeinParameters parameters)
		{
		}

		private void InitParams(IDictionary parameters)
		{
		}

		private void CreateInitialState()
		{
		}

		public void Reset()
		{
		}

		private void UbiComplete(int type, byte[] value)
		{
		}

		private void UbiInit(int type)
		{
		}

		private void UbiFinal()
		{
		}

		private void CheckInitialised()
		{
		}

		public void Update(byte inByte)
		{
		}

		public void Update(byte[] inBytes, int inOff, int len)
		{
		}

		public int DoFinal(byte[] outBytes, int outOff)
		{
			return 0;
		}

		private void Output(ulong outputSequence, byte[] outBytes, int outOff, int outputBytes)
		{
		}
	}
}
