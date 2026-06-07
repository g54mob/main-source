using System;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Solvers;
using MathNet.Numerics.LinearAlgebra.Storage;

namespace MathNet.Numerics.LinearAlgebra.Complex.Solvers
{
	public sealed class MILU0Preconditioner : IPreconditioner<System.Numerics.Complex>
	{
		private System.Numerics.Complex[] _alu;

		private int[] _jlu;

		private int[] _diag;

		public bool UseModified { get; set; }

		public bool IsInitialized { get; private set; }

		public MILU0Preconditioner(bool modified = true)
		{
			UseModified = modified;
		}

		public void Initialize(Matrix<System.Numerics.Complex> matrix)
		{
			if (!(matrix.Storage is SparseCompressedRowMatrixStorage<System.Numerics.Complex> { RowCount: var rowCount } sparseCompressedRowMatrixStorage))
			{
				throw new ArgumentException("Matrix must be in sparse storage format", "matrix");
			}
			if (rowCount != sparseCompressedRowMatrixStorage.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.", "matrix");
			}
			System.Numerics.Complex[] values = sparseCompressedRowMatrixStorage.Values;
			int[] columnIndices = sparseCompressedRowMatrixStorage.ColumnIndices;
			int[] rowPointers = sparseCompressedRowMatrixStorage.RowPointers;
			_alu = new System.Numerics.Complex[rowPointers[rowCount] + 1];
			_jlu = new int[rowPointers[rowCount] + 1];
			_diag = new int[rowCount];
			int num = Compute(rowCount, values, columnIndices, rowPointers, _alu, _jlu, _diag, UseModified);
			if (num > -1)
			{
				throw new NumericalBreakdownException("Zero pivot encountered on row " + num + " during ILU process");
			}
			IsInitialized = true;
		}

		public void Approximate(Vector<System.Numerics.Complex> input, Vector<System.Numerics.Complex> result)
		{
			if (_alu == null)
			{
				throw new ArgumentException("The requested matrix does not exist.");
			}
			if (result.Count != input.Count || result.Count != _diag.Length)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			int num = _diag.Length;
			for (int i = 0; i < num; i++)
			{
				result[i] = input[i];
				for (int j = _jlu[i]; j < _diag[i]; j++)
				{
					result[i] -= _alu[j] * result[_jlu[j]];
				}
			}
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				for (int k = _diag[num2]; k < _jlu[num2 + 1]; k++)
				{
					result[num2] -= _alu[k] * result[_jlu[k]];
				}
				result[num2] = _alu[num2] * result[num2];
			}
		}

		private int Compute(int n, System.Numerics.Complex[] a, int[] ja, int[] ia, System.Numerics.Complex[] alu, int[] jlu, int[] ju, bool modified)
		{
			int[] array = new int[n];
			int num = (jlu[0] = n + 1);
			for (int i = 0; i < n; i++)
			{
				array[i] = -1;
			}
			for (int i = 0; i < n; i++)
			{
				int num2 = num;
				for (int j = ia[i]; j < ia[i + 1]; j++)
				{
					int num3 = ja[j];
					if (num3 == i)
					{
						alu[i] = a[j];
						array[num3] = i;
						ju[i] = num;
					}
					else
					{
						alu[num] = a[j];
						jlu[num] = ja[j];
						array[num3] = num;
						num++;
					}
				}
				jlu[i + 1] = num;
				System.Numerics.Complex zero = System.Numerics.Complex.Zero;
				for (int j = num2; j < ju[i]; j++)
				{
					int num4 = jlu[j];
					System.Numerics.Complex complex = (alu[j] *= alu[num4]);
					for (int k = ju[num4]; k < jlu[num4 + 1]; k++)
					{
						int num5 = array[jlu[k]];
						if (num5 != -1)
						{
							alu[num5] -= complex * alu[k];
						}
						else
						{
							zero += complex * alu[k];
						}
					}
				}
				if (modified)
				{
					alu[i] -= zero;
				}
				if (alu[i] == System.Numerics.Complex.Zero)
				{
					return i;
				}
				alu[i] = 1.0 / alu[i];
				array[i] = -1;
				for (int k = num2; k < num; k++)
				{
					array[jlu[k]] = -1;
				}
			}
			return -1;
		}
	}
}
