using System;
using System.Collections.Generic;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Complex.Solvers
{
	public sealed class ILUTPPreconditioner : IPreconditioner<System.Numerics.Complex>
	{
		public const double DefaultFillLevel = 200.0;

		public const double DefaultDropTolerance = 0.0001;

		private SparseMatrix _upper;

		private SparseMatrix _lower;

		private int[] _pivots;

		private double _fillLevel = 200.0;

		private double _dropTolerance = 0.0001;

		private double _pivotTolerance;

		public double FillLevel
		{
			get
			{
				return _fillLevel;
			}
			set
			{
				if (value < 0.0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_fillLevel = value;
			}
		}

		public double DropTolerance
		{
			get
			{
				return _dropTolerance;
			}
			set
			{
				if (value < 0.0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_dropTolerance = value;
			}
		}

		public double PivotTolerance
		{
			get
			{
				return _pivotTolerance;
			}
			set
			{
				if (value < 0.0)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_pivotTolerance = value;
			}
		}

		public ILUTPPreconditioner()
		{
		}

		public ILUTPPreconditioner(double fillLevel, double dropTolerance, double pivotTolerance)
		{
			if (fillLevel < 0.0)
			{
				throw new ArgumentOutOfRangeException("fillLevel");
			}
			if (dropTolerance < 0.0)
			{
				throw new ArgumentOutOfRangeException("dropTolerance");
			}
			if (pivotTolerance < 0.0)
			{
				throw new ArgumentOutOfRangeException("pivotTolerance");
			}
			_fillLevel = fillLevel;
			_dropTolerance = dropTolerance;
			_pivotTolerance = pivotTolerance;
		}

		internal Matrix<System.Numerics.Complex> UpperTriangle()
		{
			return _upper.Clone();
		}

		internal Matrix<System.Numerics.Complex> LowerTriangle()
		{
			return _lower.Clone();
		}

		internal int[] Pivots()
		{
			int[] array = new int[_pivots.Length];
			for (int i = 0; i < _pivots.Length; i++)
			{
				array[i] = _pivots[i];
			}
			return array;
		}

		public void Initialize(Matrix<System.Numerics.Complex> matrix)
		{
			if (matrix == null)
			{
				throw new ArgumentNullException("matrix");
			}
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.", "matrix");
			}
			SparseMatrix sparseMatrix = (matrix as SparseMatrix) ?? SparseMatrix.OfMatrix(matrix);
			_lower = new SparseMatrix(sparseMatrix.RowCount);
			_upper = new SparseMatrix(sparseMatrix.RowCount);
			_pivots = new int[sparseMatrix.RowCount];
			for (int i = 0; i < _pivots.Length; i++)
			{
				_pivots[i] = i;
			}
			DenseVector denseVector = new DenseVector(sparseMatrix.RowCount);
			DenseVector denseVector2 = new DenseVector(sparseMatrix.ColumnCount);
			int[] array = new int[sparseMatrix.RowCount];
			int num = (int)_fillLevel * sparseMatrix.NonZerosCount;
			for (int j = 0; j < sparseMatrix.RowCount; j++)
			{
				sparseMatrix.Row(j, denseVector);
				PivotRow(denseVector);
				double num2 = denseVector.InfinityNorm();
				for (int k = 0; k < j; k++)
				{
					if (!(denseVector[k] != 0.0))
					{
						continue;
					}
					denseVector[k] /= _upper[k, k];
					if (denseVector[k].Magnitude < _dropTolerance)
					{
						denseVector[k] = 0.0;
					}
					if (denseVector[k] != 0.0)
					{
						_upper.Row(k, denseVector2);
						for (int l = 0; l <= k; l++)
						{
							denseVector2[l] = 0.0;
						}
						denseVector2.Multiply(denseVector[k], denseVector2);
						denseVector.Subtract(denseVector2, denseVector);
					}
				}
				for (int m = j; m < sparseMatrix.RowCount; m++)
				{
					if (denseVector[m].Magnitude <= _dropTolerance * num2)
					{
						denseVector[m] = 0.0;
					}
				}
				int num3 = num / (sparseMatrix.RowCount - j + 1);
				int num4 = num3 / 2;
				FindLargestItems(0, j - 1, array, denseVector);
				int num5 = 0;
				int num6 = 0;
				for (int n = 0; n < j; n++)
				{
					if (num6 > num4)
					{
						break;
					}
					if (array[n] == -1)
					{
						break;
					}
					_lower[j, array[n]] = denseVector[array[n]];
					num6++;
					num5++;
				}
				FindLargestItems(j + 1, sparseMatrix.RowCount - 1, array, denseVector);
				num4 = num3 - num5;
				int num7 = 0;
				num6 = 0;
				for (int num8 = 0; num8 < sparseMatrix.RowCount - j; num8++)
				{
					if (num6 > num4 - 1)
					{
						break;
					}
					if (array[num8] == -1)
					{
						break;
					}
					_upper[j, array[num8]] = denseVector[array[num8]];
					num6++;
					num7++;
				}
				_upper[j, j] = denseVector[j];
				if (j + 1 < sparseMatrix.RowCount - 1 && denseVector[j].Magnitude < _pivotTolerance * denseVector[array[0]].Magnitude)
				{
					SwapColumns(_upper, j, array[0]);
					ref int reference = ref _pivots[j];
					ref int reference2 = ref _pivots[array[0]];
					int num9 = _pivots[array[0]];
					int num10 = _pivots[j];
					reference = num9;
					reference2 = num10;
				}
				num -= num5 + num7;
			}
			for (int num11 = 0; num11 < _lower.RowCount; num11++)
			{
				_lower[num11, num11] = 1.0;
			}
		}

		private void PivotRow(Vector<System.Numerics.Complex> row)
		{
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			for (int i = 0; i < row.Count; i++)
			{
				if (_pivots[i] != i && !PivotMapFound(dictionary, i))
				{
					dictionary.Add(_pivots[i], i);
					int index = i;
					int index2 = _pivots[i];
					System.Numerics.Complex value = row[_pivots[i]];
					System.Numerics.Complex value2 = row[i];
					row[index] = value;
					row[index2] = value2;
				}
			}
		}

		private bool PivotMapFound(Dictionary<int, int> knownPivots, int currentItem)
		{
			if (knownPivots.TryGetValue(_pivots[currentItem], out var value) && value.Equals(currentItem))
			{
				return true;
			}
			if (knownPivots.TryGetValue(currentItem, out var value2) && value2.Equals(_pivots[currentItem]))
			{
				return true;
			}
			return false;
		}

		private static void SwapColumns(Matrix<System.Numerics.Complex> matrix, int firstColumn, int secondColumn)
		{
			for (int i = 0; i < matrix.RowCount; i++)
			{
				int row = i;
				int row2 = i;
				System.Numerics.Complex value = matrix[i, secondColumn];
				System.Numerics.Complex value2 = matrix[i, firstColumn];
				matrix[row, firstColumn] = value;
				matrix[row2, secondColumn] = value2;
			}
		}

		private static void FindLargestItems(int lowerBound, int upperBound, int[] sortedIndices, Vector<System.Numerics.Complex> values)
		{
			for (int i = 0; i < upperBound + 1 - lowerBound; i++)
			{
				sortedIndices[i] = lowerBound + i;
			}
			for (int j = upperBound + 1 - lowerBound; j < sortedIndices.Length; j++)
			{
				sortedIndices[j] = -1;
			}
			ILUTPElementSorter.SortDoubleIndicesDecreasing(0, upperBound - lowerBound, sortedIndices, values);
		}

		public void Approximate(Vector<System.Numerics.Complex> rhs, Vector<System.Numerics.Complex> lhs)
		{
			if (_upper == null)
			{
				throw new ArgumentException("The requested matrix does not exist.");
			}
			if (lhs.Count != rhs.Count || lhs.Count != _upper.RowCount)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.", "rhs");
			}
			DenseVector denseVector = new DenseVector(_lower.RowCount);
			for (int i = 0; i < _lower.RowCount; i++)
			{
				_lower.Row(i, denseVector);
				System.Numerics.Complex zero = System.Numerics.Complex.Zero;
				for (int j = 0; j < i; j++)
				{
					zero += denseVector[j] * lhs[j];
				}
				lhs[i] = rhs[i] - zero;
			}
			for (int num = _upper.RowCount - 1; num > -1; num--)
			{
				_upper.Row(num, denseVector);
				System.Numerics.Complex zero2 = System.Numerics.Complex.Zero;
				for (int num2 = _upper.RowCount - 1; num2 > num; num2--)
				{
					zero2 += denseVector[num2] * lhs[num2];
				}
				lhs[num] = 1 / denseVector[num] * (lhs[num] - zero2);
			}
			Vector<System.Numerics.Complex> vector = lhs.Clone();
			Pivot(vector, lhs);
		}

		private void Pivot(Vector<System.Numerics.Complex> vector, Vector<System.Numerics.Complex> result)
		{
			for (int i = 0; i < _pivots.Length; i++)
			{
				result[i] = vector[_pivots[i]];
			}
		}
	}
}
