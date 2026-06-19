using System;
using System.Security.Cryptography;

namespace Loxodon.Framework.Security.Cryptography
{
	public class AesCTRCryptoTransform : ICryptoTransform, IDisposable
	{
		private readonly byte[] key;

		private readonly byte[] iv;

		private readonly ICryptoTransform transform;

		private readonly int blockSize;

		private long position;

		private uint counter;

		private int index;

		private byte[] masks;

		public bool CanTransformMultipleBlocks => true;

		public bool CanReuseTransform => false;

		public int InputBlockSize => blockSize;

		public int OutputBlockSize => blockSize;

		protected uint Counter
		{
			get
			{
				return counter;
			}
			set
			{
				if (counter != value)
				{
					counter = value;
					CalculateMask(counter);
				}
			}
		}

		public long Position
		{
			get
			{
				return position;
			}
			set
			{
				if (position != value)
				{
					position = value;
					Counter = (uint)(position / blockSize);
					index = (int)(position % blockSize);
				}
			}
		}

		public AesCTRCryptoTransform(SymmetricAlgorithm algorithm, byte[] key, byte[] iv)
		{
			this.key = key;
			this.iv = iv;
			blockSize = algorithm.BlockSize / 8;
			transform = algorithm.CreateEncryptor(this.key, new byte[blockSize]);
			masks = new byte[blockSize];
			counter = 0u;
			index = 0;
			CalculateMask(counter);
		}

		public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
		{
			for (int i = 0; i < inputCount; i++)
			{
				byte b = masks[index];
				outputBuffer[outputOffset + i] = (byte)(inputBuffer[inputOffset + i] ^ b);
				position++;
				index++;
				if (index == blockSize)
				{
					Counter++;
					index = 0;
				}
			}
			return inputCount;
		}

		public byte[] TransformFinalBlock(byte[] inputBuffer, int inputOffset, int inputCount)
		{
			byte[] array = new byte[inputCount];
			TransformBlock(inputBuffer, inputOffset, inputCount, array, 0);
			return array;
		}

		private void CalculateMask(uint counter)
		{
			Array.Copy(BitConverter.GetBytes(counter), 0, iv, 12, 4);
			transform.TransformBlock(iv, 0, iv.Length, masks, 0);
		}

		public void Dispose()
		{
		}
	}
}
