using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Providers.LinearAlgebra;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Single
{
	[Serializable]
	[DebuggerDisplay("DiagonalMatrix {RowCount}x{ColumnCount}-Single")]
	public class DiagonalMatrix : Matrix
	{
		private readonly float[] _data;

		public DiagonalMatrix(DiagonalMatrixStorage<float> storage)
			: base(storage)
		{
			_data = storage.Data;
		}

		public DiagonalMatrix(int order)
			: this(new DiagonalMatrixStorage<float>(order, order))
		{
		}

		public DiagonalMatrix(int rows, int columns)
			: this(new DiagonalMatrixStorage<float>(rows, columns))
		{
		}

		public DiagonalMatrix(int rows, int columns, float diagonalValue)
			: this(rows, columns)
		{
			for (int i = 0; i < _data.Length; i++)
			{
				_data[i] = diagonalValue;
			}
		}

		public DiagonalMatrix(int rows, int columns, float[] diagonalStorage)
			: this(new DiagonalMatrixStorage<float>(rows, columns, diagonalStorage))
		{
		}

		public static DiagonalMatrix OfMatrix(Matrix<float> matrix)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<float>.OfMatrix(matrix.Storage));
		}

		public static DiagonalMatrix OfArray(float[,] array)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<float>.OfArray(array));
		}

		public static DiagonalMatrix OfIndexedDiagonal(int rows, int columns, IEnumerable<Tuple<int, float>> diagonal)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<float>.OfIndexedEnumerable(rows, columns, diagonal));
		}

		public static DiagonalMatrix OfIndexedDiagonal(int rows, int columns, IEnumerable<(int, float)> diagonal)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<float>.OfIndexedEnumerable(rows, columns, diagonal));
		}

		public static DiagonalMatrix OfDiagonal(int rows, int columns, IEnumerable<float> diagonal)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<float>.OfEnumerable(rows, columns, diagonal));
		}

		public static DiagonalMatrix Create(int rows, int columns, Func<int, float> init)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<float>.OfInit(rows, columns, init));
		}

		public static DiagonalMatrix CreateIdentity(int order)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<float>.OfValue(order, order, Matrix<float>.One));
		}

		public static DiagonalMatrix CreateRandom(int rows, int columns, IContinuousDistribution distribution)
		{
			return new DiagonalMatrix(new DiagonalMatrixStorage<float>(rows, columns, Generate.RandomSingle(Math.Min(rows, columns), distribution)));
		}

		protected override void DoNegate(Matrix<float> result)
		{
			if (result is DiagonalMatrix diagonalMatrix)
			{
				LinearAlgebraControl.Provider.ScaleArray(-1f, _data, diagonalMatrix._data);
				return;
			}
			result.Clear();
			for (int i = 0; i < _data.Length; i++)
			{
				result.At(i, i, 0f - _data[i]);
			}
		}

		protected override void DoAdd(Matrix<float> other, Matrix<float> result)
		{
			if (other is DiagonalMatrix diagonalMatrix && result is DiagonalMatrix diagonalMatrix2)
			{
				LinearAlgebraControl.Provider.AddArrays(_data, diagonalMatrix._data, diagonalMatrix2._data);
				return;
			}
			other.CopyTo(result);
			for (int i = 0; i < _data.Length; i++)
			{
				result.At(i, i, result.At(i, i) + _data[i]);
			}
		}

		protected override void DoSubtract(Matrix<float> other, Matrix<float> result)
		{
			if (other is DiagonalMatrix diagonalMatrix && result is DiagonalMatrix diagonalMatrix2)
			{
				LinearAlgebraControl.Provider.SubtractArrays(_data, diagonalMatrix._data, diagonalMatrix2._data);
				return;
			}
			other.Negate(result);
			for (int i = 0; i < _data.Length; i++)
			{
				result.At(i, i, result.At(i, i) + _data[i]);
			}
		}

		protected override void DoMultiply(float scalar, Matrix<float> result)
		{
			if ((double)scalar == 0.0)
			{
				result.Clear();
			}
			else if ((double)scalar == 1.0)
			{
				CopyTo(result);
			}
			else if (result is DiagonalMatrix diagonalMatrix)
			{
				LinearAlgebraControl.Provider.ScaleArray(scalar, _data, diagonalMatrix._data);
			}
			else
			{
				base.DoMultiply(scalar, result);
			}
		}

		protected override void DoMultiply(Vector<float> rightSide, Vector<float> result)
		{
			int num = Math.Min(base.ColumnCount, base.RowCount);
			if (num < base.RowCount)
			{
				result.ClearSubVector(base.ColumnCount, base.RowCount - base.ColumnCount);
			}
			if (num == base.ColumnCount && rightSide.Storage is DenseVectorStorage<float> denseVectorStorage && result.Storage is DenseVectorStorage<float> denseVectorStorage2)
			{
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(_data, denseVectorStorage.Data, denseVectorStorage2.Data);
				return;
			}
			for (int i = 0; i < num; i++)
			{
				result.At(i, _data[i] * rightSide.At(i));
			}
		}

		protected override void DoMultiply(Matrix<float> other, Matrix<float> result)
		{
			if (other is DiagonalMatrix diagonalMatrix && result is DiagonalMatrix diagonalMatrix2)
			{
				float[] array = new float[diagonalMatrix2._data.Length];
				float[] array2 = new float[diagonalMatrix2._data.Length];
				Array.Copy(_data, 0, array, 0, (diagonalMatrix2._data.Length > _data.Length) ? _data.Length : diagonalMatrix2._data.Length);
				Array.Copy(diagonalMatrix._data, 0, array2, 0, (diagonalMatrix2._data.Length > diagonalMatrix._data.Length) ? diagonalMatrix._data.Length : diagonalMatrix2._data.Length);
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(array, array2, diagonalMatrix2._data);
			}
			else if (other.Storage is DenseColumnMajorMatrixStorage<float> { Data: var data } denseColumnMajorMatrixStorage)
			{
				float[] data2 = _data;
				int num = Math.Min(denseColumnMajorMatrixStorage.RowCount, base.RowCount);
				if (num < base.RowCount)
				{
					result.ClearSubMatrix(denseColumnMajorMatrixStorage.RowCount, base.RowCount - denseColumnMajorMatrixStorage.RowCount, 0, denseColumnMajorMatrixStorage.ColumnCount);
				}
				int num2 = 0;
				for (int i = 0; i < denseColumnMajorMatrixStorage.ColumnCount; i++)
				{
					for (int j = 0; j < num; j++)
					{
						result.At(j, i, data[num2] * data2[j]);
						num2++;
					}
					num2 += denseColumnMajorMatrixStorage.RowCount - num;
				}
			}
			else if (base.ColumnCount == base.RowCount)
			{
				other.Storage.MapIndexedTo(result.Storage, (int num3, int _, float x) => x * _data[num3], Zeros.AllowSkip, ExistingData.Clear);
			}
			else
			{
				result.Clear();
				other.Storage.MapSubMatrixIndexedTo(result.Storage, (int num3, int _, float x) => x * _data[num3], 0, 0, Math.Min(base.RowCount, other.RowCount), 0, 0, other.ColumnCount, Zeros.AllowSkip, ExistingData.AssumeZeros);
			}
		}

		protected override void DoTransposeAndMultiply(Matrix<float> other, Matrix<float> result)
		{
			if (other is DiagonalMatrix diagonalMatrix && result is DiagonalMatrix diagonalMatrix2)
			{
				float[] array = new float[diagonalMatrix2._data.Length];
				float[] array2 = new float[diagonalMatrix2._data.Length];
				Array.Copy(_data, 0, array, 0, (diagonalMatrix2._data.Length > _data.Length) ? _data.Length : diagonalMatrix2._data.Length);
				Array.Copy(diagonalMatrix._data, 0, array2, 0, (diagonalMatrix2._data.Length > diagonalMatrix._data.Length) ? diagonalMatrix._data.Length : diagonalMatrix2._data.Length);
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(array, array2, diagonalMatrix2._data);
			}
			else if (other.Storage is DenseColumnMajorMatrixStorage<float> { Data: var data } denseColumnMajorMatrixStorage)
			{
				float[] data2 = _data;
				int num = Math.Min(denseColumnMajorMatrixStorage.ColumnCount, base.RowCount);
				if (num < base.RowCount)
				{
					result.ClearSubMatrix(denseColumnMajorMatrixStorage.ColumnCount, base.RowCount - denseColumnMajorMatrixStorage.ColumnCount, 0, denseColumnMajorMatrixStorage.RowCount);
				}
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					for (int j = 0; j < denseColumnMajorMatrixStorage.RowCount; j++)
					{
						result.At(i, j, data[num2] * data2[i]);
						num2++;
					}
				}
			}
			else
			{
				base.DoTransposeAndMultiply(other, result);
			}
		}

		protected override void DoTransposeThisAndMultiply(Matrix<float> other, Matrix<float> result)
		{
			if (other is DiagonalMatrix diagonalMatrix && result is DiagonalMatrix diagonalMatrix2)
			{
				float[] array = new float[diagonalMatrix2._data.Length];
				float[] array2 = new float[diagonalMatrix2._data.Length];
				Array.Copy(_data, 0, array, 0, (diagonalMatrix2._data.Length > _data.Length) ? _data.Length : diagonalMatrix2._data.Length);
				Array.Copy(diagonalMatrix._data, 0, array2, 0, (diagonalMatrix2._data.Length > diagonalMatrix._data.Length) ? diagonalMatrix._data.Length : diagonalMatrix2._data.Length);
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(array, array2, diagonalMatrix2._data);
			}
			else if (other.Storage is DenseColumnMajorMatrixStorage<float> { Data: var data } denseColumnMajorMatrixStorage)
			{
				float[] data2 = _data;
				int num = Math.Min(denseColumnMajorMatrixStorage.RowCount, base.ColumnCount);
				if (num < base.ColumnCount)
				{
					result.ClearSubMatrix(denseColumnMajorMatrixStorage.RowCount, base.ColumnCount - denseColumnMajorMatrixStorage.RowCount, 0, denseColumnMajorMatrixStorage.ColumnCount);
				}
				int num2 = 0;
				for (int i = 0; i < denseColumnMajorMatrixStorage.ColumnCount; i++)
				{
					for (int j = 0; j < num; j++)
					{
						result.At(j, i, data[num2] * data2[j]);
						num2++;
					}
					num2 += denseColumnMajorMatrixStorage.RowCount - num;
				}
			}
			else if (base.ColumnCount == base.RowCount)
			{
				other.Storage.MapIndexedTo(result.Storage, (int num3, int _, float x) => x * _data[num3], Zeros.AllowSkip, ExistingData.Clear);
			}
			else
			{
				result.Clear();
				other.Storage.MapSubMatrixIndexedTo(result.Storage, (int num3, int _, float x) => x * _data[num3], 0, 0, other.RowCount, 0, 0, other.ColumnCount, Zeros.AllowSkip, ExistingData.AssumeZeros);
			}
		}

		protected override void DoTransposeThisAndMultiply(Vector<float> rightSide, Vector<float> result)
		{
			int num = Math.Min(base.ColumnCount, base.RowCount);
			if (num < base.ColumnCount)
			{
				result.ClearSubVector(base.RowCount, base.ColumnCount - base.RowCount);
			}
			if (num == base.RowCount && rightSide.Storage is DenseVectorStorage<float> denseVectorStorage && result.Storage is DenseVectorStorage<float> denseVectorStorage2)
			{
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(_data, denseVectorStorage.Data, denseVectorStorage2.Data);
				return;
			}
			for (int i = 0; i < num; i++)
			{
				result.At(i, _data[i] * rightSide.At(i));
			}
		}

		protected override void DoDivide(float divisor, Matrix<float> result)
		{
			if (divisor == 1f)
			{
				CopyTo(result);
				return;
			}
			if (result is DiagonalMatrix diagonalMatrix)
			{
				LinearAlgebraControl.Provider.ScaleArray(1f / divisor, _data, diagonalMatrix._data);
				return;
			}
			result.Clear();
			for (int i = 0; i < _data.Length; i++)
			{
				result.At(i, i, _data[i] / divisor);
			}
		}

		protected override void DoDivideByThis(float dividend, Matrix<float> result)
		{
			if (result is DiagonalMatrix diagonalMatrix)
			{
				float[] resultData = diagonalMatrix._data;
				CommonParallel.For(0, _data.Length, 4096, delegate(int a, int b)
				{
					for (int i = a; i < b; i++)
					{
						resultData[i] = dividend / _data[i];
					}
				});
			}
			else
			{
				result.Clear();
				for (int num = 0; num < _data.Length; num++)
				{
					result.At(num, num, dividend / _data[num]);
				}
			}
		}

		public override float Determinant()
		{
			if (base.RowCount != base.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			return _data.Aggregate(1f, (float current, float t) => current * t);
		}

		public override Vector<float> Diagonal()
		{
			return new DenseVector(_data).Clone();
		}

		public override void SetDiagonal(float[] source)
		{
			if (source.Length != _data.Length)
			{
				throw new ArgumentException("The array arguments must have the same length.", "source");
			}
			Buffer.BlockCopy(source, 0, _data, 0, source.Length * 4);
		}

		public override void SetDiagonal(Vector<float> source)
		{
			if (source is DenseVector denseVector)
			{
				if (_data.Length != denseVector.Values.Length)
				{
					throw new ArgumentException("All vectors must have the same dimensionality.", "source");
				}
				Buffer.BlockCopy(denseVector.Values, 0, _data, 0, denseVector.Values.Length * 4);
			}
			else
			{
				base.SetDiagonal(source);
			}
		}

		public override double L1Norm()
		{
			return _data.Aggregate(0f, (float current, float t) => Math.Max(current, Math.Abs(t)));
		}

		public override double L2Norm()
		{
			return _data.Aggregate(0f, (float current, float t) => Math.Max(current, Math.Abs(t)));
		}

		public override double InfinityNorm()
		{
			return L1Norm();
		}

		public override double FrobeniusNorm()
		{
			return Math.Sqrt(_data.Sum((float t) => t * t));
		}

		public override float ConditionNumber()
		{
			float num = float.NegativeInfinity;
			float num2 = float.PositiveInfinity;
			float[] data = _data;
			foreach (float value in data)
			{
				num = Math.Max(num, Math.Abs(value));
				num2 = Math.Min(num2, Math.Abs(value));
			}
			return num / num2;
		}

		public override Matrix<float> Inverse()
		{
			if (base.RowCount != base.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			DiagonalMatrix diagonalMatrix = (DiagonalMatrix)Clone();
			float[] data = diagonalMatrix._data;
			for (int i = 0; i < _data.Length; i++)
			{
				if ((double)_data[i] != 0.0)
				{
					data[i] = 1f / _data[i];
					continue;
				}
				throw new ArgumentException("Matrix must not be singular.");
			}
			return diagonalMatrix;
		}

		public override Matrix<float> LowerTriangle()
		{
			return Clone();
		}

		public override void LowerTriangle(Matrix<float> result)
		{
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			if (this != result)
			{
				result.Clear();
				for (int i = 0; i < _data.Length; i++)
				{
					result.At(i, i, _data[i]);
				}
			}
		}

		public override Matrix<float> StrictlyLowerTriangle()
		{
			return new DiagonalMatrix(base.RowCount, base.ColumnCount);
		}

		public override void StrictlyLowerTriangle(Matrix<float> result)
		{
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			result.Clear();
		}

		public override Matrix<float> UpperTriangle()
		{
			return Clone();
		}

		public override void UpperTriangle(Matrix<float> result)
		{
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			result.Clear();
			for (int i = 0; i < _data.Length; i++)
			{
				result.At(i, i, _data[i]);
			}
		}

		public override Matrix<float> StrictlyUpperTriangle()
		{
			return new DiagonalMatrix(base.RowCount, base.ColumnCount);
		}

		public override void StrictlyUpperTriangle(Matrix<float> result)
		{
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			result.Clear();
		}

		public override Matrix<float> SubMatrix(int rowIndex, int rowCount, int columnIndex, int columnCount)
		{
			Matrix<float> matrix = ((rowIndex == columnIndex) ? ((Matrix)new DiagonalMatrix(rowCount, columnCount)) : ((Matrix)new SparseMatrix(rowCount, columnCount)));
			base.Storage.CopySubMatrixTo(matrix.Storage, rowIndex, 0, rowCount, columnIndex, 0, columnCount, ExistingData.AssumeZeros);
			return matrix;
		}

		public override void PermuteColumns(Permutation p)
		{
			throw new InvalidOperationException("Permutations in diagonal matrix are not allowed");
		}

		public override void PermuteRows(Permutation p)
		{
			throw new InvalidOperationException("Permutations in diagonal matrix are not allowed");
		}

		public sealed override bool IsSymmetric()
		{
			return true;
		}

		protected override void DoModulus(float divisor, Matrix<float> result)
		{
			DiagonalMatrix diagonalResult = result as DiagonalMatrix;
			if (diagonalResult != null)
			{
				CommonParallel.For(0, _data.Length, 4096, delegate(int a, int b)
				{
					float[] data = diagonalResult._data;
					for (int i = a; i < b; i++)
					{
						data[i] = Euclid.Modulus(_data[i], divisor);
					}
				});
			}
			else
			{
				base.DoModulus(divisor, result);
			}
		}

		protected override void DoModulusByThis(float dividend, Matrix<float> result)
		{
			DiagonalMatrix diagonalResult = result as DiagonalMatrix;
			if (diagonalResult != null)
			{
				CommonParallel.For(0, _data.Length, 4096, delegate(int a, int b)
				{
					float[] data = diagonalResult._data;
					for (int i = a; i < b; i++)
					{
						data[i] = Euclid.Modulus(dividend, _data[i]);
					}
				});
			}
			else
			{
				base.DoModulusByThis(dividend, result);
			}
		}

		protected override void DoRemainder(float divisor, Matrix<float> result)
		{
			DiagonalMatrix diagonalResult = result as DiagonalMatrix;
			if (diagonalResult != null)
			{
				CommonParallel.For(0, _data.Length, 4096, delegate(int a, int b)
				{
					float[] data = diagonalResult._data;
					for (int i = a; i < b; i++)
					{
						data[i] = _data[i] % divisor;
					}
				});
			}
			else
			{
				base.DoRemainder(divisor, result);
			}
		}

		protected override void DoRemainderByThis(float dividend, Matrix<float> result)
		{
			DiagonalMatrix diagonalResult = result as DiagonalMatrix;
			if (diagonalResult != null)
			{
				CommonParallel.For(0, _data.Length, 4096, delegate(int a, int b)
				{
					float[] data = diagonalResult._data;
					for (int i = a; i < b; i++)
					{
						data[i] = dividend % _data[i];
					}
				});
			}
			else
			{
				base.DoRemainderByThis(dividend, result);
			}
		}
	}
}
