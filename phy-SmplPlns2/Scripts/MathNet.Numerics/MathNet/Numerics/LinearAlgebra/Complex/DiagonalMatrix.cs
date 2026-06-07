using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Providers.LinearAlgebra;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Complex
{
	[Serializable]
	[DebuggerDisplay("DiagonalMatrix {RowCount}x{ColumnCount}-Complex")]
	public class DiagonalMatrix : Matrix
	{
		private readonly System.Numerics.Complex[] _data;

		public DiagonalMatrix(DiagonalMatrixStorage<System.Numerics.Complex> storage)
			: base(storage)
		{
			_data = storage.Data;
		}

		public DiagonalMatrix(int order)
			: this(new DiagonalMatrixStorage<System.Numerics.Complex>(order, order))
		{
		}

		public DiagonalMatrix(int rows, int columns)
			: this(new DiagonalMatrixStorage<System.Numerics.Complex>(rows, columns))
		{
		}

		public DiagonalMatrix(int rows, int columns, System.Numerics.Complex diagonalValue)
			: this(rows, columns)
		{
			for (int i = 0; i < _data.Length; i++)
			{
				_data[i] = diagonalValue;
			}
		}

		public DiagonalMatrix(int rows, int columns, System.Numerics.Complex[] diagonalStorage)
			: this(new DiagonalMatrixStorage<System.Numerics.Complex>(rows, columns, diagonalStorage))
		{
		}

		public static DiagonalMatrix OfMatrix(Matrix<System.Numerics.Complex> matrix)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<System.Numerics.Complex>.OfMatrix(matrix.Storage));
		}

		public static DiagonalMatrix OfArray(System.Numerics.Complex[,] array)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<System.Numerics.Complex>.OfArray(array));
		}

		public static DiagonalMatrix OfIndexedDiagonal(int rows, int columns, IEnumerable<Tuple<int, System.Numerics.Complex>> diagonal)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<System.Numerics.Complex>.OfIndexedEnumerable(rows, columns, diagonal));
		}

		public static DiagonalMatrix OfIndexedDiagonal(int rows, int columns, IEnumerable<(int, System.Numerics.Complex)> diagonal)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<System.Numerics.Complex>.OfIndexedEnumerable(rows, columns, diagonal));
		}

		public static DiagonalMatrix OfDiagonal(int rows, int columns, IEnumerable<System.Numerics.Complex> diagonal)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<System.Numerics.Complex>.OfEnumerable(rows, columns, diagonal));
		}

		public static DiagonalMatrix Create(int rows, int columns, Func<int, System.Numerics.Complex> init)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<System.Numerics.Complex>.OfInit(rows, columns, init));
		}

		public static DiagonalMatrix CreateIdentity(int order)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<System.Numerics.Complex>.OfValue(order, order, Matrix<System.Numerics.Complex>.One));
		}

		public static DiagonalMatrix CreateRandom(int rows, int columns, IContinuousDistribution distribution)
		{
			return new DiagonalMatrix(new DiagonalMatrixStorage<System.Numerics.Complex>(rows, columns, Generate.RandomComplex(Math.Min(rows, columns), distribution)));
		}

		protected override void DoNegate(Matrix<System.Numerics.Complex> result)
		{
			if (result is DiagonalMatrix diagonalMatrix)
			{
				LinearAlgebraControl.Provider.ScaleArray(-1, _data, diagonalMatrix._data);
				return;
			}
			result.Clear();
			for (int i = 0; i < _data.Length; i++)
			{
				result.At(i, i, -_data[i]);
			}
		}

		protected override void DoConjugate(Matrix<System.Numerics.Complex> result)
		{
			if (result is DiagonalMatrix diagonalMatrix)
			{
				LinearAlgebraControl.Provider.ConjugateArray(_data, diagonalMatrix._data);
				return;
			}
			result.Clear();
			for (int i = 0; i < _data.Length; i++)
			{
				result.At(i, i, _data[i].Conjugate());
			}
		}

		protected override void DoAdd(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
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

		protected override void DoSubtract(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
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

		protected override void DoMultiply(System.Numerics.Complex scalar, Matrix<System.Numerics.Complex> result)
		{
			if (scalar == 0.0)
			{
				result.Clear();
			}
			else if (scalar == 1.0)
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

		protected override void DoMultiply(Vector<System.Numerics.Complex> rightSide, Vector<System.Numerics.Complex> result)
		{
			int num = Math.Min(base.ColumnCount, base.RowCount);
			if (num < base.RowCount)
			{
				result.ClearSubVector(base.ColumnCount, base.RowCount - base.ColumnCount);
			}
			if (num == base.ColumnCount && rightSide.Storage is DenseVectorStorage<System.Numerics.Complex> denseVectorStorage && result.Storage is DenseVectorStorage<System.Numerics.Complex> denseVectorStorage2)
			{
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(_data, denseVectorStorage.Data, denseVectorStorage2.Data);
				return;
			}
			for (int i = 0; i < num; i++)
			{
				result.At(i, _data[i] * rightSide.At(i));
			}
		}

		protected override void DoMultiply(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			if (other is DiagonalMatrix diagonalMatrix && result is DiagonalMatrix diagonalMatrix2)
			{
				System.Numerics.Complex[] array = new System.Numerics.Complex[diagonalMatrix2._data.Length];
				System.Numerics.Complex[] array2 = new System.Numerics.Complex[diagonalMatrix2._data.Length];
				Array.Copy(_data, 0, array, 0, (diagonalMatrix2._data.Length > _data.Length) ? _data.Length : diagonalMatrix2._data.Length);
				Array.Copy(diagonalMatrix._data, 0, array2, 0, (diagonalMatrix2._data.Length > diagonalMatrix._data.Length) ? diagonalMatrix._data.Length : diagonalMatrix2._data.Length);
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(array, array2, diagonalMatrix2._data);
			}
			else if (other.Storage is DenseColumnMajorMatrixStorage<System.Numerics.Complex> { Data: var data } denseColumnMajorMatrixStorage)
			{
				System.Numerics.Complex[] data2 = _data;
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
				other.Storage.MapIndexedTo(result.Storage, (int num3, int _, System.Numerics.Complex x) => x * _data[num3], Zeros.AllowSkip, ExistingData.Clear);
			}
			else
			{
				result.Clear();
				other.Storage.MapSubMatrixIndexedTo(result.Storage, (int num3, int _, System.Numerics.Complex x) => x * _data[num3], 0, 0, Math.Min(base.RowCount, other.RowCount), 0, 0, other.ColumnCount, Zeros.AllowSkip, ExistingData.AssumeZeros);
			}
		}

		protected override void DoTransposeAndMultiply(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			if (other is DiagonalMatrix diagonalMatrix && result is DiagonalMatrix diagonalMatrix2)
			{
				System.Numerics.Complex[] array = new System.Numerics.Complex[diagonalMatrix2._data.Length];
				System.Numerics.Complex[] array2 = new System.Numerics.Complex[diagonalMatrix2._data.Length];
				Array.Copy(_data, 0, array, 0, (diagonalMatrix2._data.Length > _data.Length) ? _data.Length : diagonalMatrix2._data.Length);
				Array.Copy(diagonalMatrix._data, 0, array2, 0, (diagonalMatrix2._data.Length > diagonalMatrix._data.Length) ? diagonalMatrix._data.Length : diagonalMatrix2._data.Length);
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(array, array2, diagonalMatrix2._data);
			}
			else if (other.Storage is DenseColumnMajorMatrixStorage<System.Numerics.Complex> { Data: var data } denseColumnMajorMatrixStorage)
			{
				System.Numerics.Complex[] data2 = _data;
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

		protected override void DoConjugateTransposeAndMultiply(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			if (other is DiagonalMatrix diagonalMatrix && result is DiagonalMatrix diagonalMatrix2)
			{
				System.Numerics.Complex[] array = new System.Numerics.Complex[diagonalMatrix2._data.Length];
				System.Numerics.Complex[] array2 = new System.Numerics.Complex[diagonalMatrix2._data.Length];
				Array.Copy(_data, 0, array, 0, (diagonalMatrix2._data.Length > _data.Length) ? _data.Length : diagonalMatrix2._data.Length);
				Array.Copy(diagonalMatrix._data, 0, array2, 0, (diagonalMatrix2._data.Length > diagonalMatrix._data.Length) ? diagonalMatrix._data.Length : diagonalMatrix2._data.Length);
				LinearAlgebraControl.Provider.ConjugateArray(array2, array2);
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(array, array2, diagonalMatrix2._data);
			}
			else if (other.Storage is DenseColumnMajorMatrixStorage<System.Numerics.Complex> { Data: var data } denseColumnMajorMatrixStorage)
			{
				System.Numerics.Complex[] data2 = _data;
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
						result.At(i, j, data[num2].Conjugate() * data2[i]);
						num2++;
					}
				}
			}
			else
			{
				base.DoConjugateTransposeAndMultiply(other, result);
			}
		}

		protected override void DoTransposeThisAndMultiply(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			if (other is DiagonalMatrix diagonalMatrix && result is DiagonalMatrix diagonalMatrix2)
			{
				System.Numerics.Complex[] array = new System.Numerics.Complex[diagonalMatrix2._data.Length];
				System.Numerics.Complex[] array2 = new System.Numerics.Complex[diagonalMatrix2._data.Length];
				Array.Copy(_data, 0, array, 0, (diagonalMatrix2._data.Length > _data.Length) ? _data.Length : diagonalMatrix2._data.Length);
				Array.Copy(diagonalMatrix._data, 0, array2, 0, (diagonalMatrix2._data.Length > diagonalMatrix._data.Length) ? diagonalMatrix._data.Length : diagonalMatrix2._data.Length);
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(array, array2, diagonalMatrix2._data);
			}
			else if (other.Storage is DenseColumnMajorMatrixStorage<System.Numerics.Complex> { Data: var data } denseColumnMajorMatrixStorage)
			{
				System.Numerics.Complex[] data2 = _data;
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
				other.Storage.MapIndexedTo(result.Storage, (int num3, int _, System.Numerics.Complex x) => x * _data[num3], Zeros.AllowSkip, ExistingData.Clear);
			}
			else
			{
				result.Clear();
				other.Storage.MapSubMatrixIndexedTo(result.Storage, (int num3, int _, System.Numerics.Complex x) => x * _data[num3], 0, 0, other.RowCount, 0, 0, other.ColumnCount, Zeros.AllowSkip, ExistingData.AssumeZeros);
			}
		}

		protected override void DoConjugateTransposeThisAndMultiply(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			if (other is DiagonalMatrix diagonalMatrix && result is DiagonalMatrix diagonalMatrix2)
			{
				System.Numerics.Complex[] array = new System.Numerics.Complex[diagonalMatrix2._data.Length];
				System.Numerics.Complex[] array2 = new System.Numerics.Complex[diagonalMatrix2._data.Length];
				Array.Copy(_data, 0, array, 0, (diagonalMatrix2._data.Length > _data.Length) ? _data.Length : diagonalMatrix2._data.Length);
				Array.Copy(diagonalMatrix._data, 0, array2, 0, (diagonalMatrix2._data.Length > diagonalMatrix._data.Length) ? diagonalMatrix._data.Length : diagonalMatrix2._data.Length);
				LinearAlgebraControl.Provider.ConjugateArray(array, array);
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(array, array2, diagonalMatrix2._data);
			}
			else if (other.Storage is DenseColumnMajorMatrixStorage<System.Numerics.Complex> { Data: var data } denseColumnMajorMatrixStorage)
			{
				System.Numerics.Complex[] array3 = new System.Numerics.Complex[_data.Length];
				for (int i = 0; i < _data.Length; i++)
				{
					array3[i] = _data[i].Conjugate();
				}
				int num = Math.Min(denseColumnMajorMatrixStorage.RowCount, base.ColumnCount);
				if (num < base.ColumnCount)
				{
					result.ClearSubMatrix(denseColumnMajorMatrixStorage.RowCount, base.ColumnCount - denseColumnMajorMatrixStorage.RowCount, 0, denseColumnMajorMatrixStorage.ColumnCount);
				}
				int num2 = 0;
				for (int j = 0; j < denseColumnMajorMatrixStorage.ColumnCount; j++)
				{
					for (int k = 0; k < num; k++)
					{
						result.At(k, j, data[num2] * array3[k]);
						num2++;
					}
					num2 += denseColumnMajorMatrixStorage.RowCount - num;
				}
			}
			else
			{
				base.DoConjugateTransposeThisAndMultiply(other, result);
			}
		}

		protected override void DoTransposeThisAndMultiply(Vector<System.Numerics.Complex> rightSide, Vector<System.Numerics.Complex> result)
		{
			int num = Math.Min(base.ColumnCount, base.RowCount);
			if (num < base.ColumnCount)
			{
				result.ClearSubVector(base.RowCount, base.ColumnCount - base.RowCount);
			}
			if (num == base.RowCount && rightSide.Storage is DenseVectorStorage<System.Numerics.Complex> denseVectorStorage && result.Storage is DenseVectorStorage<System.Numerics.Complex> denseVectorStorage2)
			{
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(_data, denseVectorStorage.Data, denseVectorStorage2.Data);
				return;
			}
			for (int i = 0; i < num; i++)
			{
				result.At(i, _data[i] * rightSide.At(i));
			}
		}

		protected override void DoConjugateTransposeThisAndMultiply(Vector<System.Numerics.Complex> rightSide, Vector<System.Numerics.Complex> result)
		{
			int num = Math.Min(base.ColumnCount, base.RowCount);
			if (num < base.ColumnCount)
			{
				result.ClearSubVector(base.RowCount, base.ColumnCount - base.RowCount);
			}
			if (num == base.RowCount && rightSide.Storage is DenseVectorStorage<System.Numerics.Complex> denseVectorStorage && result.Storage is DenseVectorStorage<System.Numerics.Complex> denseVectorStorage2)
			{
				LinearAlgebraControl.Provider.ConjugateArray(_data, denseVectorStorage2.Data);
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(denseVectorStorage2.Data, denseVectorStorage.Data, denseVectorStorage2.Data);
				return;
			}
			for (int i = 0; i < num; i++)
			{
				result.At(i, _data[i].Conjugate() * rightSide.At(i));
			}
		}

		protected override void DoDivide(System.Numerics.Complex divisor, Matrix<System.Numerics.Complex> result)
		{
			if (divisor == System.Numerics.Complex.One)
			{
				CopyTo(result);
				return;
			}
			if (result is DiagonalMatrix diagonalMatrix)
			{
				LinearAlgebraControl.Provider.ScaleArray(1.0 / divisor, _data, diagonalMatrix._data);
				return;
			}
			result.Clear();
			for (int i = 0; i < _data.Length; i++)
			{
				result.At(i, i, _data[i] / divisor);
			}
		}

		protected override void DoDivideByThis(System.Numerics.Complex dividend, Matrix<System.Numerics.Complex> result)
		{
			if (result is DiagonalMatrix diagonalMatrix)
			{
				System.Numerics.Complex[] resultData = diagonalMatrix._data;
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

		public override System.Numerics.Complex Determinant()
		{
			if (base.RowCount != base.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			return _data.Aggregate(System.Numerics.Complex.One, (System.Numerics.Complex current, System.Numerics.Complex t) => current * t);
		}

		public override Vector<System.Numerics.Complex> Diagonal()
		{
			return new DenseVector(_data).Clone();
		}

		public override void SetDiagonal(System.Numerics.Complex[] source)
		{
			if (source.Length != _data.Length)
			{
				throw new ArgumentException("The array arguments must have the same length.", "source");
			}
			Array.Copy(source, 0, _data, 0, source.Length);
		}

		public override void SetDiagonal(Vector<System.Numerics.Complex> source)
		{
			if (source is DenseVector denseVector)
			{
				if (_data.Length != denseVector.Values.Length)
				{
					throw new ArgumentException("All vectors must have the same dimensionality.", "source");
				}
				Array.Copy(denseVector.Values, 0, _data, 0, denseVector.Values.Length);
			}
			else
			{
				base.SetDiagonal(source);
			}
		}

		public override double L1Norm()
		{
			return _data.Aggregate(0.0, (double current, System.Numerics.Complex t) => Math.Max(current, t.Magnitude));
		}

		public override double L2Norm()
		{
			return _data.Aggregate(0.0, (double current, System.Numerics.Complex t) => Math.Max(current, t.Magnitude));
		}

		public override double InfinityNorm()
		{
			return L1Norm();
		}

		public override double FrobeniusNorm()
		{
			return Math.Sqrt(_data.Sum((System.Numerics.Complex t) => t.Magnitude * t.Magnitude));
		}

		public override System.Numerics.Complex ConditionNumber()
		{
			double num = double.NegativeInfinity;
			double num2 = double.PositiveInfinity;
			System.Numerics.Complex[] data = _data;
			for (int i = 0; i < data.Length; i++)
			{
				System.Numerics.Complex complex = data[i];
				num = Math.Max(num, complex.Magnitude);
				num2 = Math.Min(num2, complex.Magnitude);
			}
			return num / num2;
		}

		public override Matrix<System.Numerics.Complex> Inverse()
		{
			if (base.RowCount != base.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			DiagonalMatrix diagonalMatrix = (DiagonalMatrix)Clone();
			System.Numerics.Complex[] data = diagonalMatrix._data;
			for (int i = 0; i < _data.Length; i++)
			{
				if (_data[i] != 0.0)
				{
					data[i] = 1.0 / _data[i];
					continue;
				}
				throw new ArgumentException("Matrix must not be singular.");
			}
			return diagonalMatrix;
		}

		public override Matrix<System.Numerics.Complex> LowerTriangle()
		{
			return Clone();
		}

		public override void LowerTriangle(Matrix<System.Numerics.Complex> result)
		{
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<System.Numerics.Complex>.DimensionsDontMatch<ArgumentException>(this, result, "result");
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

		public override Matrix<System.Numerics.Complex> StrictlyLowerTriangle()
		{
			return new DiagonalMatrix(base.RowCount, base.ColumnCount);
		}

		public override void StrictlyLowerTriangle(Matrix<System.Numerics.Complex> result)
		{
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<System.Numerics.Complex>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			result.Clear();
		}

		public override Matrix<System.Numerics.Complex> UpperTriangle()
		{
			return Clone();
		}

		public override void UpperTriangle(Matrix<System.Numerics.Complex> result)
		{
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<System.Numerics.Complex>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			result.Clear();
			for (int i = 0; i < _data.Length; i++)
			{
				result.At(i, i, _data[i]);
			}
		}

		public override Matrix<System.Numerics.Complex> StrictlyUpperTriangle()
		{
			return new DiagonalMatrix(base.RowCount, base.ColumnCount);
		}

		public override void StrictlyUpperTriangle(Matrix<System.Numerics.Complex> result)
		{
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<System.Numerics.Complex>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			result.Clear();
		}

		public override Matrix<System.Numerics.Complex> SubMatrix(int rowIndex, int rowCount, int columnIndex, int columnCount)
		{
			Matrix<System.Numerics.Complex> matrix = ((rowIndex == columnIndex) ? ((Matrix)new DiagonalMatrix(rowCount, columnCount)) : ((Matrix)new SparseMatrix(rowCount, columnCount)));
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

		public sealed override bool IsHermitian()
		{
			for (int i = 0; i < _data.Length; i++)
			{
				if (!_data[i].IsReal())
				{
					return false;
				}
			}
			return true;
		}
	}
}
