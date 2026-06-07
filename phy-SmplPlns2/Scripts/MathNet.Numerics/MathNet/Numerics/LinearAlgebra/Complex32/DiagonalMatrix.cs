using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Providers.LinearAlgebra;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Complex32
{
	[Serializable]
	[DebuggerDisplay("DiagonalMatrix {RowCount}x{ColumnCount}-Complex32")]
	public class DiagonalMatrix : Matrix
	{
		private readonly MathNet.Numerics.Complex32[] _data;

		public DiagonalMatrix(DiagonalMatrixStorage<MathNet.Numerics.Complex32> storage)
			: base(storage)
		{
			_data = storage.Data;
		}

		public DiagonalMatrix(int order)
			: this(new DiagonalMatrixStorage<MathNet.Numerics.Complex32>(order, order))
		{
		}

		public DiagonalMatrix(int rows, int columns)
			: this(new DiagonalMatrixStorage<MathNet.Numerics.Complex32>(rows, columns))
		{
		}

		public DiagonalMatrix(int rows, int columns, MathNet.Numerics.Complex32 diagonalValue)
			: this(rows, columns)
		{
			for (int i = 0; i < _data.Length; i++)
			{
				_data[i] = diagonalValue;
			}
		}

		public DiagonalMatrix(int rows, int columns, MathNet.Numerics.Complex32[] diagonalStorage)
			: this(new DiagonalMatrixStorage<MathNet.Numerics.Complex32>(rows, columns, diagonalStorage))
		{
		}

		public static DiagonalMatrix OfMatrix(Matrix<MathNet.Numerics.Complex32> matrix)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<MathNet.Numerics.Complex32>.OfMatrix(matrix.Storage));
		}

		public static DiagonalMatrix OfArray(MathNet.Numerics.Complex32[,] array)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<MathNet.Numerics.Complex32>.OfArray(array));
		}

		public static DiagonalMatrix OfIndexedDiagonal(int rows, int columns, IEnumerable<Tuple<int, MathNet.Numerics.Complex32>> diagonal)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<MathNet.Numerics.Complex32>.OfIndexedEnumerable(rows, columns, diagonal));
		}

		public static DiagonalMatrix OfIndexedDiagonal(int rows, int columns, IEnumerable<(int, MathNet.Numerics.Complex32)> diagonal)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<MathNet.Numerics.Complex32>.OfIndexedEnumerable(rows, columns, diagonal));
		}

		public static DiagonalMatrix OfDiagonal(int rows, int columns, IEnumerable<MathNet.Numerics.Complex32> diagonal)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<MathNet.Numerics.Complex32>.OfEnumerable(rows, columns, diagonal));
		}

		public static DiagonalMatrix Create(int rows, int columns, Func<int, MathNet.Numerics.Complex32> init)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<MathNet.Numerics.Complex32>.OfInit(rows, columns, init));
		}

		public static DiagonalMatrix CreateIdentity(int order)
		{
			return new DiagonalMatrix(DiagonalMatrixStorage<MathNet.Numerics.Complex32>.OfValue(order, order, Matrix<MathNet.Numerics.Complex32>.One));
		}

		public static DiagonalMatrix CreateRandom(int rows, int columns, IContinuousDistribution distribution)
		{
			return new DiagonalMatrix(new DiagonalMatrixStorage<MathNet.Numerics.Complex32>(rows, columns, Generate.RandomComplex32(Math.Min(rows, columns), distribution)));
		}

		protected override void DoNegate(Matrix<MathNet.Numerics.Complex32> result)
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

		protected override void DoConjugate(Matrix<MathNet.Numerics.Complex32> result)
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

		protected override void DoAdd(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
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

		protected override void DoSubtract(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
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

		protected override void DoMultiply(MathNet.Numerics.Complex32 scalar, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (scalar.IsZero())
			{
				result.Clear();
			}
			else if (scalar.IsOne())
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

		protected override void DoMultiply(Vector<MathNet.Numerics.Complex32> rightSide, Vector<MathNet.Numerics.Complex32> result)
		{
			int num = Math.Min(base.ColumnCount, base.RowCount);
			if (num < base.RowCount)
			{
				result.ClearSubVector(base.ColumnCount, base.RowCount - base.ColumnCount);
			}
			if (num == base.ColumnCount && rightSide.Storage is DenseVectorStorage<MathNet.Numerics.Complex32> denseVectorStorage && result.Storage is DenseVectorStorage<MathNet.Numerics.Complex32> denseVectorStorage2)
			{
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(_data, denseVectorStorage.Data, denseVectorStorage2.Data);
				return;
			}
			for (int i = 0; i < num; i++)
			{
				result.At(i, _data[i] * rightSide.At(i));
			}
		}

		protected override void DoMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (other is DiagonalMatrix diagonalMatrix && result is DiagonalMatrix diagonalMatrix2)
			{
				MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[diagonalMatrix2._data.Length];
				MathNet.Numerics.Complex32[] array2 = new MathNet.Numerics.Complex32[diagonalMatrix2._data.Length];
				Array.Copy(_data, 0, array, 0, (diagonalMatrix2._data.Length > _data.Length) ? _data.Length : diagonalMatrix2._data.Length);
				Array.Copy(diagonalMatrix._data, 0, array2, 0, (diagonalMatrix2._data.Length > diagonalMatrix._data.Length) ? diagonalMatrix._data.Length : diagonalMatrix2._data.Length);
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(array, array2, diagonalMatrix2._data);
			}
			else if (other.Storage is DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32> { Data: var data } denseColumnMajorMatrixStorage)
			{
				MathNet.Numerics.Complex32[] data2 = _data;
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
				other.Storage.MapIndexedTo(result.Storage, (int num3, int _, MathNet.Numerics.Complex32 x) => x * _data[num3], Zeros.AllowSkip, ExistingData.Clear);
			}
			else
			{
				result.Clear();
				other.Storage.MapSubMatrixIndexedTo(result.Storage, (int num3, int _, MathNet.Numerics.Complex32 x) => x * _data[num3], 0, 0, Math.Min(base.RowCount, other.RowCount), 0, 0, other.ColumnCount, Zeros.AllowSkip, ExistingData.AssumeZeros);
			}
		}

		protected override void DoTransposeAndMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (other is DiagonalMatrix diagonalMatrix && result is DiagonalMatrix diagonalMatrix2)
			{
				MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[diagonalMatrix2._data.Length];
				MathNet.Numerics.Complex32[] array2 = new MathNet.Numerics.Complex32[diagonalMatrix2._data.Length];
				Array.Copy(_data, 0, array, 0, (diagonalMatrix2._data.Length > _data.Length) ? _data.Length : diagonalMatrix2._data.Length);
				Array.Copy(diagonalMatrix._data, 0, array2, 0, (diagonalMatrix2._data.Length > diagonalMatrix._data.Length) ? diagonalMatrix._data.Length : diagonalMatrix2._data.Length);
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(array, array2, diagonalMatrix2._data);
			}
			else if (other.Storage is DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32> { Data: var data } denseColumnMajorMatrixStorage)
			{
				MathNet.Numerics.Complex32[] data2 = _data;
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

		protected override void DoConjugateTransposeAndMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (other is DiagonalMatrix diagonalMatrix && result is DiagonalMatrix diagonalMatrix2)
			{
				MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[diagonalMatrix2._data.Length];
				MathNet.Numerics.Complex32[] array2 = new MathNet.Numerics.Complex32[diagonalMatrix2._data.Length];
				Array.Copy(_data, 0, array, 0, (diagonalMatrix2._data.Length > _data.Length) ? _data.Length : diagonalMatrix2._data.Length);
				Array.Copy(diagonalMatrix._data, 0, array2, 0, (diagonalMatrix2._data.Length > diagonalMatrix._data.Length) ? diagonalMatrix._data.Length : diagonalMatrix2._data.Length);
				LinearAlgebraControl.Provider.ConjugateArray(array2, array2);
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(array, array2, diagonalMatrix2._data);
			}
			else if (other.Storage is DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32> { Data: var data } denseColumnMajorMatrixStorage)
			{
				MathNet.Numerics.Complex32[] data2 = _data;
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

		protected override void DoTransposeThisAndMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (other is DiagonalMatrix diagonalMatrix && result is DiagonalMatrix diagonalMatrix2)
			{
				MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[diagonalMatrix2._data.Length];
				MathNet.Numerics.Complex32[] array2 = new MathNet.Numerics.Complex32[diagonalMatrix2._data.Length];
				Array.Copy(_data, 0, array, 0, (diagonalMatrix2._data.Length > _data.Length) ? _data.Length : diagonalMatrix2._data.Length);
				Array.Copy(diagonalMatrix._data, 0, array2, 0, (diagonalMatrix2._data.Length > diagonalMatrix._data.Length) ? diagonalMatrix._data.Length : diagonalMatrix2._data.Length);
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(array, array2, diagonalMatrix2._data);
			}
			else if (other.Storage is DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32> { Data: var data } denseColumnMajorMatrixStorage)
			{
				MathNet.Numerics.Complex32[] data2 = _data;
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
				other.Storage.MapIndexedTo(result.Storage, (int num3, int _, MathNet.Numerics.Complex32 x) => x * _data[num3], Zeros.AllowSkip, ExistingData.Clear);
			}
			else
			{
				result.Clear();
				other.Storage.MapSubMatrixIndexedTo(result.Storage, (int num3, int _, MathNet.Numerics.Complex32 x) => x * _data[num3], 0, 0, other.RowCount, 0, 0, other.ColumnCount, Zeros.AllowSkip, ExistingData.AssumeZeros);
			}
		}

		protected override void DoConjugateTransposeThisAndMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (other is DiagonalMatrix diagonalMatrix && result is DiagonalMatrix diagonalMatrix2)
			{
				MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[diagonalMatrix2._data.Length];
				MathNet.Numerics.Complex32[] array2 = new MathNet.Numerics.Complex32[diagonalMatrix2._data.Length];
				Array.Copy(_data, 0, array, 0, (diagonalMatrix2._data.Length > _data.Length) ? _data.Length : diagonalMatrix2._data.Length);
				Array.Copy(diagonalMatrix._data, 0, array2, 0, (diagonalMatrix2._data.Length > diagonalMatrix._data.Length) ? diagonalMatrix._data.Length : diagonalMatrix2._data.Length);
				LinearAlgebraControl.Provider.ConjugateArray(array, array);
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(array, array2, diagonalMatrix2._data);
			}
			else if (other.Storage is DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32> { Data: var data } denseColumnMajorMatrixStorage)
			{
				MathNet.Numerics.Complex32[] array3 = new MathNet.Numerics.Complex32[_data.Length];
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

		protected override void DoTransposeThisAndMultiply(Vector<MathNet.Numerics.Complex32> rightSide, Vector<MathNet.Numerics.Complex32> result)
		{
			int num = Math.Min(base.ColumnCount, base.RowCount);
			if (num < base.ColumnCount)
			{
				result.ClearSubVector(base.RowCount, base.ColumnCount - base.RowCount);
			}
			if (num == base.RowCount && rightSide.Storage is DenseVectorStorage<MathNet.Numerics.Complex32> denseVectorStorage && result.Storage is DenseVectorStorage<MathNet.Numerics.Complex32> denseVectorStorage2)
			{
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(_data, denseVectorStorage.Data, denseVectorStorage2.Data);
				return;
			}
			for (int i = 0; i < num; i++)
			{
				result.At(i, _data[i] * rightSide.At(i));
			}
		}

		protected override void DoConjugateTransposeThisAndMultiply(Vector<MathNet.Numerics.Complex32> rightSide, Vector<MathNet.Numerics.Complex32> result)
		{
			int num = Math.Min(base.ColumnCount, base.RowCount);
			if (num < base.ColumnCount)
			{
				result.ClearSubVector(base.RowCount, base.ColumnCount - base.RowCount);
			}
			if (num == base.RowCount && rightSide.Storage is DenseVectorStorage<MathNet.Numerics.Complex32> denseVectorStorage && result.Storage is DenseVectorStorage<MathNet.Numerics.Complex32> denseVectorStorage2)
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

		protected override void DoDivide(MathNet.Numerics.Complex32 divisor, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (divisor == MathNet.Numerics.Complex32.One)
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

		protected override void DoDivideByThis(MathNet.Numerics.Complex32 dividend, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (result is DiagonalMatrix diagonalMatrix)
			{
				MathNet.Numerics.Complex32[] resultData = diagonalMatrix._data;
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

		public override MathNet.Numerics.Complex32 Determinant()
		{
			if (base.RowCount != base.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			return _data.Aggregate(MathNet.Numerics.Complex32.One, (MathNet.Numerics.Complex32 current, MathNet.Numerics.Complex32 t) => current * t);
		}

		public override Vector<MathNet.Numerics.Complex32> Diagonal()
		{
			return new DenseVector(_data).Clone();
		}

		public override void SetDiagonal(MathNet.Numerics.Complex32[] source)
		{
			if (source.Length != _data.Length)
			{
				throw new ArgumentException("The array arguments must have the same length.", "source");
			}
			Array.Copy(source, 0, _data, 0, source.Length);
		}

		public override void SetDiagonal(Vector<MathNet.Numerics.Complex32> source)
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
			return _data.Aggregate(0f, (float current, MathNet.Numerics.Complex32 t) => Math.Max(current, t.Magnitude));
		}

		public override double L2Norm()
		{
			return _data.Aggregate(0f, (float current, MathNet.Numerics.Complex32 t) => Math.Max(current, t.Magnitude));
		}

		public override double InfinityNorm()
		{
			return L1Norm();
		}

		public override double FrobeniusNorm()
		{
			return Math.Sqrt(_data.Sum((MathNet.Numerics.Complex32 t) => t.Magnitude * t.Magnitude));
		}

		public override MathNet.Numerics.Complex32 ConditionNumber()
		{
			float num = float.NegativeInfinity;
			float num2 = float.PositiveInfinity;
			MathNet.Numerics.Complex32[] data = _data;
			for (int i = 0; i < data.Length; i++)
			{
				MathNet.Numerics.Complex32 complex = data[i];
				num = Math.Max(num, complex.Magnitude);
				num2 = Math.Min(num2, complex.Magnitude);
			}
			return num / num2;
		}

		public override Matrix<MathNet.Numerics.Complex32> Inverse()
		{
			if (base.RowCount != base.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			DiagonalMatrix diagonalMatrix = (DiagonalMatrix)Clone();
			MathNet.Numerics.Complex32[] data = diagonalMatrix._data;
			for (int i = 0; i < _data.Length; i++)
			{
				if (_data[i] != 0f)
				{
					data[i] = 1f / _data[i];
					continue;
				}
				throw new ArgumentException("Matrix must not be singular.");
			}
			return diagonalMatrix;
		}

		public override Matrix<MathNet.Numerics.Complex32> LowerTriangle()
		{
			return Clone();
		}

		public override void LowerTriangle(Matrix<MathNet.Numerics.Complex32> result)
		{
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(this, result, "result");
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

		public override Matrix<MathNet.Numerics.Complex32> StrictlyLowerTriangle()
		{
			return new DiagonalMatrix(base.RowCount, base.ColumnCount);
		}

		public override void StrictlyLowerTriangle(Matrix<MathNet.Numerics.Complex32> result)
		{
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			result.Clear();
		}

		public override Matrix<MathNet.Numerics.Complex32> UpperTriangle()
		{
			return Clone();
		}

		public override void UpperTriangle(Matrix<MathNet.Numerics.Complex32> result)
		{
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			result.Clear();
			for (int i = 0; i < _data.Length; i++)
			{
				result.At(i, i, _data[i]);
			}
		}

		public override Matrix<MathNet.Numerics.Complex32> StrictlyUpperTriangle()
		{
			return new DiagonalMatrix(base.RowCount, base.ColumnCount);
		}

		public override void StrictlyUpperTriangle(Matrix<MathNet.Numerics.Complex32> result)
		{
			if (result.RowCount != base.RowCount || result.ColumnCount != base.ColumnCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(this, result, "result");
			}
			result.Clear();
		}

		public override Matrix<MathNet.Numerics.Complex32> SubMatrix(int rowIndex, int rowCount, int columnIndex, int columnCount)
		{
			Matrix<MathNet.Numerics.Complex32> matrix = ((rowIndex == columnIndex) ? ((Matrix)new DiagonalMatrix(rowCount, columnCount)) : ((Matrix)new SparseMatrix(rowCount, columnCount)));
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
