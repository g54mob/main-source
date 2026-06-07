using System.Collections;

namespace BestHTTP.SecureProtocol.Org.BouncyCastle.Crypto.Engines
{
	public class Gost28147Engine : IBlockCipher
	{
		private const int BlockSize = 8;

		private int[] workingKey;

		private bool forEncryption;

		private byte[] S;

		private static readonly byte[] Sbox_Default;

		private static readonly byte[] ESbox_Test;

		private static readonly byte[] ESbox_A;

		private static readonly byte[] ESbox_B;

		private static readonly byte[] ESbox_C;

		private static readonly byte[] ESbox_D;

		private static readonly byte[] DSbox_Test;

		private static readonly byte[] DSbox_A;

		private static readonly IDictionary sBoxes;

		public virtual string AlgorithmName => null;

		public virtual bool IsPartialBlockOkay => false;

		static Gost28147Engine()
		{
		}

		private static void AddSBox(string sBoxName, byte[] sBox)
		{
		}

		public virtual void Init(bool forEncryption, ICipherParameters parameters)
		{
		}

		public virtual int GetBlockSize()
		{
			return 0;
		}

		public virtual int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
		{
			return 0;
		}

		public virtual void Reset()
		{
		}

		private int[] generateWorkingKey(bool forEncryption, byte[] userKey)
		{
			return null;
		}

		private int Gost28147_mainStep(int n1, int key)
		{
			return 0;
		}

		private void Gost28147Func(int[] workingKey, byte[] inBytes, int inOff, byte[] outBytes, int outOff)
		{
		}

		private static int bytesToint(byte[] inBytes, int inOff)
		{
			return 0;
		}

		private static void intTobytes(int num, byte[] outBytes, int outOff)
		{
		}

		public static byte[] GetSBox(string sBoxName)
		{
			return null;
		}

		public static string GetSBoxName(byte[] sBox)
		{
			return null;
		}
	}
}
