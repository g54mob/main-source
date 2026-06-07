using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Complex32.Factorization;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Providers.LinearAlgebra;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Complex32
{
	[Serializable]
	[DebuggerDisplay("DenseMatrix {RowCount}x{ColumnCount}-Complex32")]
	public class DenseMatrix : Matrix
	{
		private readonly int _rowCount;

		private readonly int _columnCount;

		private readonly MathNet.Numerics.Complex32[] _values;

		public MathNet.Numerics.Complex32[] Values => _values;

		public DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32> storage)
			: base(storage)
		{
			_rowCount = storage.RowCount;
			_columnCount = storage.ColumnCount;
			_values = storage.Data;
		}

		public DenseMatrix(int order)
			: this(new DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>(order, order))
		{
		}

		public DenseMatrix(int rows, int columns)
			: this(new DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>(rows, columns))
		{
		}

		public DenseMatrix(int rows, int columns, MathNet.Numerics.Complex32[] storage)
			: this(new DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>(rows, columns, storage))
		{
		}

		public static DenseMatrix OfMatrix(Matrix<MathNet.Numerics.Complex32> matrix)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfMatrix(matrix.Storage));
		}

		public static DenseMatrix OfArray(MathNet.Numerics.Complex32[,] array)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfArray(array));
		}

		public static DenseMatrix OfIndexed(int rows, int columns, IEnumerable<Tuple<int, int, MathNet.Numerics.Complex32>> enumerable)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfIndexedEnumerable(rows, columns, enumerable));
		}

		public static DenseMatrix OfIndexed(int rows, int columns, IEnumerable<(int, int, MathNet.Numerics.Complex32)> enumerable)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfIndexedEnumerable(rows, columns, enumerable));
		}

		public static DenseMatrix OfColumnMajor(int rows, int columns, IEnumerable<MathNet.Numerics.Complex32> columnMajor)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfColumnMajorEnumerable(rows, columns, columnMajor));
		}

		public static DenseMatrix OfColumns(IEnumerable<IEnumerable<MathNet.Numerics.Complex32>> data)
		{
			return OfColumnArrays(data.Select((IEnumerable<MathNet.Numerics.Complex32> v) => v.ToArray()).ToArray());
		}

		public static DenseMatrix OfColumns(int rows, int columns, IEnumerable<IEnumerable<MathNet.Numerics.Complex32>> data)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfColumnEnumerables(rows, columns, data));
		}

		public static DenseMatrix OfColumnArrays(params MathNet.Numerics.Complex32[][] columns)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfColumnArrays(columns));
		}

		public static DenseMatrix OfColumnArrays(IEnumerable<MathNet.Numerics.Complex32[]> columns)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfColumnArrays((columns as MathNet.Numerics.Complex32[][]) ?? columns.ToArray()));
		}

		public static DenseMatrix OfColumnVectors(params Vector<MathNet.Numerics.Complex32>[] columns)
		{
			VectorStorage<MathNet.Numerics.Complex32>[] array = new VectorStorage<MathNet.Numerics.Complex32>[columns.Length];
			for (int i = 0; i < columns.Length; i++)
			{
				array[i] = columns[i].Storage;
			}
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfColumnVectors(array));
		}

		public static DenseMatrix OfColumnVectors(IEnumerable<Vector<MathNet.Numerics.Complex32>> columns)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfColumnVectors(columns.Select((Vector<MathNet.Numerics.Complex32> c) => c.Storage).ToArray()));
		}

		public static DenseMatrix OfRows(IEnumerable<IEnumerable<MathNet.Numerics.Complex32>> data)
		{
			return OfRowArrays(data.Select((IEnumerable<MathNet.Numerics.Complex32> v) => v.ToArray()).ToArray());
		}

		public static DenseMatrix OfRows(int rows, int columns, IEnumerable<IEnumerable<MathNet.Numerics.Complex32>> data)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfRowEnumerables(rows, columns, data));
		}

		public static DenseMatrix OfRowArrays(params MathNet.Numerics.Complex32[][] rows)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfRowArrays(rows));
		}

		public static DenseMatrix OfRowArrays(IEnumerable<MathNet.Numerics.Complex32[]> rows)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfRowArrays((rows as MathNet.Numerics.Complex32[][]) ?? rows.ToArray()));
		}

		public static DenseMatrix OfRowVectors(params Vector<MathNet.Numerics.Complex32>[] rows)
		{
			VectorStorage<MathNet.Numerics.Complex32>[] array = new VectorStorage<MathNet.Numerics.Complex32>[rows.Length];
			for (int i = 0; i < rows.Length; i++)
			{
				array[i] = rows[i].Storage;
			}
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfRowVectors(array));
		}

		public static DenseMatrix OfRowVectors(IEnumerable<Vector<MathNet.Numerics.Complex32>> rows)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfRowVectors(rows.Select((Vector<MathNet.Numerics.Complex32> r) => r.Storage).ToArray()));
		}

		public static DenseMatrix OfDiagonalVector(Vector<MathNet.Numerics.Complex32> diagonal)
		{
			DenseMatrix denseMatrix = new DenseMatrix(diagonal.Count, diagonal.Count);
			denseMatrix.SetDiagonal(diagonal);
			return denseMatrix;
		}

		public static DenseMatrix OfDiagonalVector(int rows, int columns, Vector<MathNet.Numerics.Complex32> diagonal)
		{
			DenseMatrix denseMatrix = new DenseMatrix(rows, columns);
			denseMatrix.SetDiagonal(diagonal);
			return denseMatrix;
		}

		public static DenseMatrix OfDiagonalArray(MathNet.Numerics.Complex32[] diagonal)
		{
			DenseMatrix denseMatrix = new DenseMatrix(diagonal.Length, diagonal.Length);
			denseMatrix.SetDiagonal(diagonal);
			return denseMatrix;
		}

		public static DenseMatrix OfDiagonalArray(int rows, int columns, MathNet.Numerics.Complex32[] diagonal)
		{
			DenseMatrix denseMatrix = new DenseMatrix(rows, columns);
			denseMatrix.SetDiagonal(diagonal);
			return denseMatrix;
		}

		public static DenseMatrix Create(int rows, int columns, MathNet.Numerics.Complex32 value)
		{
			if (value == MathNet.Numerics.Complex32.Zero)
			{
				return new DenseMatrix(rows, columns);
			}
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfValue(rows, columns, value));
		}

		public static DenseMatrix Create(int rows, int columns, Func<int, int, MathNet.Numerics.Complex32> init)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfInit(rows, columns, init));
		}

		public static DenseMatrix CreateDiagonal(int rows, int columns, MathNet.Numerics.Complex32 value)
		{
			if (value == MathNet.Numerics.Complex32.Zero)
			{
				return new DenseMatrix(rows, columns);
			}
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfDiagonalInit(rows, columns, (int _) => value));
		}

		public static DenseMatrix CreateDiagonal(int rows, int columns, Func<int, MathNet.Numerics.Complex32> init)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfDiagonalInit(rows, columns, init));
		}

		public static DenseMatrix CreateIdentity(int order)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>.OfDiagonalInit(order, order, (int _) => Matrix<MathNet.Numerics.Complex32>.One));
		}

		public static DenseMatrix CreateRandom(int rows, int columns, IContinuousDistribution distribution)
		{
			return new DenseMatrix(new DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32>(rows, columns, Generate.RandomComplex32(rows * columns, distribution)));
		}

		public override double L1Norm()
		{
			return LinearAlgebraControl.Provider.MatrixNorm(Norm.OneNorm, _rowCount, _columnCount, _values);
		}

		public override double InfinityNorm()
		{
			return LinearAlgebraControl.Provider.MatrixNorm(Norm.InfinityNorm, _rowCount, _columnCount, _values);
		}

		public override double FrobeniusNorm()
		{
			return LinearAlgebraControl.Provider.MatrixNorm(Norm.FrobeniusNorm, _rowCount, _columnCount, _values);
		}

		protected override void DoNegate(Matrix<MathNet.Numerics.Complex32> result)
		{
			if (result is DenseMatrix denseMatrix)
			{
				LinearAlgebraControl.Provider.ScaleArray(-1, _values, denseMatrix._values);
			}
			else
			{
				base.DoNegate(result);
			}
		}

		protected override void DoConjugate(Matrix<MathNet.Numerics.Complex32> result)
		{
			if (result is DenseMatrix denseMatrix)
			{
				LinearAlgebraControl.Provider.ConjugateArray(_values, denseMatrix._values);
			}
			else
			{
				base.DoConjugate(result);
			}
		}

		protected override void DoAdd(MathNet.Numerics.Complex32 scalar, Matrix<MathNet.Numerics.Complex32> result)
		{
			DenseMatrix denseResult = result as DenseMatrix;
			if (denseResult != null)
			{
				CommonParallel.For(0, _values.Length, 4096, delegate(int a, int b)
				{
					MathNet.Numerics.Complex32[] values = denseResult._values;
					for (int i = a; i < b; i++)
					{
						values[i] = _values[i] + scalar;
					}
				});
			}
			else
			{
				base.DoAdd(scalar, result);
			}
		}

		protected override void DoAdd(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (other.Storage is DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32> denseColumnMajorMatrixStorage && result.Storage is DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32> denseColumnMajorMatrixStorage2)
			{
				LinearAlgebraControl.Provider.AddArrays(_values, denseColumnMajorMatrixStorage.Data, denseColumnMajorMatrixStorage2.Data);
			}
			else if (other.Storage is DiagonalMatrixStorage<MathNet.Numerics.Complex32> diagonalMatrixStorage)
			{
				base.Storage.CopyToUnchecked(result.Storage, ExistingData.Clear);
				MathNet.Numerics.Complex32[] data = diagonalMatrixStorage.Data;
				for (int i = 0; i < data.Length; i++)
				{
					result.At(i, i, result.At(i, i) + data[i]);
				}
			}
			else
			{
				base.DoAdd(other, result);
			}
		}

		protected override void DoSubtract(MathNet.Numerics.Complex32 scalar, Matrix<MathNet.Numerics.Complex32> result)
		{
			DenseMatrix denseResult = result as DenseMatrix;
			if (denseResult != null)
			{
				CommonParallel.For(0, _values.Length, 4096, delegate(int a, int b)
				{
					MathNet.Numerics.Complex32[] values = denseResult._values;
					for (int i = a; i < b; i++)
					{
						values[i] = _values[i] - scalar;
					}
				});
			}
			else
			{
				base.DoSubtract(scalar, result);
			}
		}

		protected override void DoSubtract(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (other.Storage is DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32> denseColumnMajorMatrixStorage && result.Storage is DenseColumnMajorMatrixStorage<MathNet.Numerics.Complex32> denseColumnMajorMatrixStorage2)
			{
				LinearAlgebraControl.Provider.SubtractArrays(_values, denseColumnMajorMatrixStorage.Data, denseColumnMajorMatrixStorage2.Data);
			}
			else if (other.Storage is DiagonalMatrixStorage<MathNet.Numerics.Complex32> diagonalMatrixStorage)
			{
				CopyTo(result);
				MathNet.Numerics.Complex32[] data = diagonalMatrixStorage.Data;
				for (int i = 0; i < data.Length; i++)
				{
					result.At(i, i, result.At(i, i) - data[i]);
				}
			}
			else
			{
				base.DoSubtract(other, result);
			}
		}

		protected override void DoMultiply(MathNet.Numerics.Complex32 scalar, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (result is DenseMatrix denseMatrix)
			{
				LinearAlgebraControl.Provider.ScaleArray(scalar, _values, denseMatrix._values);
			}
			else
			{
				base.DoMultiply(scalar, result);
			}
		}

		protected override void DoMultiply(Vector<MathNet.Numerics.Complex32> rightSide, Vector<MathNet.Numerics.Complex32> result)
		{
			if (rightSide is DenseVector denseVector && result is DenseVector denseVector2)
			{
				LinearAlgebraControl.Provider.MatrixMultiply(_values, _rowCount, _columnCount, denseVector.Values, denseVector.Count, 1, denseVector2.Values);
			}
			else
			{
				base.DoMultiply(rightSide, result);
			}
		}

		protected override void DoMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (other is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.MatrixMultiply(_values, _rowCount, _columnCount, denseMatrix._values, denseMatrix._rowCount, denseMatrix._columnCount, denseMatrix2._values);
			}
			else if (other.Storage is DiagonalMatrixStorage<MathNet.Numerics.Complex32> { Data: var data })
			{
				int num = Math.Min(base.ColumnCount, other.ColumnCount);
				if (num < other.ColumnCount)
				{
					result.ClearSubMatrix(0, base.RowCount, base.ColumnCount, other.ColumnCount - base.ColumnCount);
				}
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					for (int j = 0; j < base.RowCount; j++)
					{
						result.At(j, i, _values[num2] * data[i]);
						num2++;
					}
				}
			}
			else
			{
				base.DoMultiply(other, result);
			}
		}

		protected override void DoTransposeAndMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (other is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.MatrixMultiplyWithUpdate(MathNet.Numerics.Providers.LinearAlgebra.Transpose.DontTranspose, MathNet.Numerics.Providers.LinearAlgebra.Transpose.Transpose, 1f, _values, _rowCount, _columnCount, denseMatrix._values, denseMatrix._rowCount, denseMatrix._columnCount, 0f, denseMatrix2._values);
			}
			else if (other.Storage is DiagonalMatrixStorage<MathNet.Numerics.Complex32> { Data: var data })
			{
				int num = Math.Min(base.ColumnCount, other.RowCount);
				if (num < other.RowCount)
				{
					result.ClearSubMatrix(0, base.RowCount, base.ColumnCount, other.RowCount - base.ColumnCount);
				}
				int num2 = 0;
				for (int i = 0; i < num; i++)
				{
					for (int j = 0; j < base.RowCount; j++)
					{
						result.At(j, i, _values[num2] * data[i]);
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
			if (other is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.MatrixMultiplyWithUpdate(MathNet.Numerics.Providers.LinearAlgebra.Transpose.DontTranspose, MathNet.Numerics.Providers.LinearAlgebra.Transpose.ConjugateTranspose, 1f, _values, _rowCount, _columnCount, denseMatrix._values, denseMatrix._rowCount, denseMatrix._columnCount, 0f, denseMatrix2._values);
			}
			else if (other.Storage is DiagonalMatrixStorage<MathNet.Numerics.Complex32> { Data: var data })
			{
				MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[data.Length];
				for (int i = 0; i < data.Length; i++)
				{
					array[i] = data[i].Conjugate();
				}
				int num = Math.Min(base.ColumnCount, other.RowCount);
				if (num < other.RowCount)
				{
					result.ClearSubMatrix(0, base.RowCount, base.ColumnCount, other.RowCount - base.ColumnCount);
				}
				int num2 = 0;
				for (int j = 0; j < num; j++)
				{
					for (int k = 0; k < base.RowCount; k++)
					{
						result.At(k, j, _values[num2] * array[j]);
						num2++;
					}
				}
			}
			else
			{
				base.DoConjugateTransposeAndMultiply(other, result);
			}
		}

		protected override void DoTransposeThisAndMultiply(Vector<MathNet.Numerics.Complex32> rightSide, Vector<MathNet.Numerics.Complex32> result)
		{
			if (rightSide is DenseVector denseVector && result is DenseVector denseVector2)
			{
				LinearAlgebraControl.Provider.MatrixMultiplyWithUpdate(MathNet.Numerics.Providers.LinearAlgebra.Transpose.Transpose, MathNet.Numerics.Providers.LinearAlgebra.Transpose.DontTranspose, 1f, _values, _rowCount, _columnCount, denseVector.Values, denseVector.Count, 1, 0f, denseVector2.Values);
			}
			else
			{
				base.DoTransposeThisAndMultiply(rightSide, result);
			}
		}

		protected override void DoConjugateTransposeThisAndMultiply(Vector<MathNet.Numerics.Complex32> rightSide, Vector<MathNet.Numerics.Complex32> result)
		{
			if (rightSide is DenseVector denseVector && result is DenseVector denseVector2)
			{
				LinearAlgebraControl.Provider.MatrixMultiplyWithUpdate(MathNet.Numerics.Providers.LinearAlgebra.Transpose.ConjugateTranspose, MathNet.Numerics.Providers.LinearAlgebra.Transpose.DontTranspose, 1f, _values, _rowCount, _columnCount, denseVector.Values, denseVector.Count, 1, 0f, denseVector2.Values);
			}
			else
			{
				base.DoConjugateTransposeThisAndMultiply(rightSide, result);
			}
		}

		protected override void DoTransposeThisAndMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (other is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.MatrixMultiplyWithUpdate(MathNet.Numerics.Providers.LinearAlgebra.Transpose.Transpose, MathNet.Numerics.Providers.LinearAlgebra.Transpose.DontTranspose, 1f, _values, _rowCount, _columnCount, denseMatrix._values, denseMatrix._rowCount, denseMatrix._columnCount, 0f, denseMatrix2._values);
			}
			else if (other.Storage is DiagonalMatrixStorage<MathNet.Numerics.Complex32> { Data: var data })
			{
				int num = Math.Min(base.RowCount, other.ColumnCount);
				if (num < other.ColumnCount)
				{
					result.ClearSubMatrix(0, base.ColumnCount, base.RowCount, other.ColumnCount - base.RowCount);
				}
				int num2 = 0;
				for (int i = 0; i < base.ColumnCount; i++)
				{
					for (int j = 0; j < num; j++)
					{
						result.At(i, j, _values[num2] * data[j]);
						num2++;
					}
					num2 += base.RowCount - num;
				}
			}
			else
			{
				base.DoTransposeThisAndMultiply(other, result);
			}
		}

		protected override void DoConjugateTransposeThisAndMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (other is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.MatrixMultiplyWithUpdate(MathNet.Numerics.Providers.LinearAlgebra.Transpose.ConjugateTranspose, MathNet.Numerics.Providers.LinearAlgebra.Transpose.DontTranspose, 1f, _values, _rowCount, _columnCount, denseMatrix._values, denseMatrix._rowCount, denseMatrix._columnCount, 0f, denseMatrix2._values);
			}
			else if (other.Storage is DiagonalMatrixStorage<MathNet.Numerics.Complex32> { Data: var data })
			{
				int num = Math.Min(base.RowCount, other.ColumnCount);
				if (num < other.ColumnCount)
				{
					result.ClearSubMatrix(0, base.ColumnCount, base.RowCount, other.ColumnCount - base.RowCount);
				}
				int num2 = 0;
				for (int i = 0; i < base.ColumnCount; i++)
				{
					for (int j = 0; j < num; j++)
					{
						result.At(i, j, _values[num2].Conjugate() * data[j]);
						num2++;
					}
					num2 += base.RowCount - num;
				}
			}
			else
			{
				base.DoConjugateTransposeThisAndMultiply(other, result);
			}
		}

		protected override void DoDivide(MathNet.Numerics.Complex32 divisor, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (result is DenseMatrix denseMatrix)
			{
				LinearAlgebraControl.Provider.ScaleArray(1f / divisor, _values, denseMatrix._values);
			}
			else
			{
				base.DoDivide(divisor, result);
			}
		}

		protected override void DoPointwiseMultiply(Matrix<MathNet.Numerics.Complex32> other, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (other is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.PointWiseMultiplyArrays(_values, denseMatrix._values, denseMatrix2._values);
			}
			else
			{
				base.DoPointwiseMultiply(other, result);
			}
		}

		protected override void DoPointwiseDivide(Matrix<MathNet.Numerics.Complex32> divisor, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (divisor is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.PointWiseDivideArrays(_values, denseMatrix._values, denseMatrix2._values);
			}
			else
			{
				base.DoPointwiseDivide(divisor, result);
			}
		}

		protected override void DoPointwisePower(Matrix<MathNet.Numerics.Complex32> exponent, Matrix<MathNet.Numerics.Complex32> result)
		{
			if (exponent is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.PointWisePowerArrays(_values, denseMatrix._values, denseMatrix2._values);
			}
			else
			{
				base.DoPointwisePower(exponent, result);
			}
		}

		public override MathNet.Numerics.Complex32 Trace()
		{
			if (_rowCount != _columnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			MathNet.Numerics.Complex32 zero = MathNet.Numerics.Complex32.Zero;
			for (int i = 0; i < _rowCount; i++)
			{
				zero += _values[i * _rowCount + i];
			}
			return zero;
		}

		public static DenseMatrix operator +(DenseMatrix leftSide, DenseMatrix rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			if (leftSide._rowCount != rightSide._rowCount || leftSide._columnCount != rightSide._columnCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentOutOfRangeException>(leftSide, rightSide);
			}
			return (DenseMatrix)leftSide.Add(rightSide);
		}

		public static DenseMatrix operator +(DenseMatrix rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			return (DenseMatrix)rightSide.Clone();
		}

		public static DenseMatrix operator -(DenseMatrix leftSide, DenseMatrix rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			if (leftSide._rowCount != rightSide._rowCount || leftSide._columnCount != rightSide._columnCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentOutOfRangeException>(leftSide, rightSide);
			}
			return (DenseMatrix)leftSide.Subtract(rightSide);
		}

		public static DenseMatrix operator -(DenseMatrix rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			return (DenseMatrix)rightSide.Negate();
		}

		public static DenseMatrix operator *(DenseMatrix leftSide, MathNet.Numerics.Complex32 rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (DenseMatrix)leftSide.Multiply(rightSide);
		}

		public static DenseMatrix operator *(MathNet.Numerics.Complex32 leftSide, DenseMatrix rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			return (DenseMatrix)rightSide.Multiply(leftSide);
		}

		public static DenseMatrix operator *(DenseMatrix leftSide, DenseMatrix rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			if (leftSide._columnCount != rightSide._rowCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(leftSide, rightSide);
			}
			return (DenseMatrix)leftSide.Multiply(rightSide);
		}

		public static DenseVector operator *(DenseMatrix leftSide, DenseVector rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (DenseVector)leftSide.Multiply(rightSide);
		}

		public static DenseVector operator *(DenseVector leftSide, DenseMatrix rightSide)
		{
			if (rightSide == null)
			{
				throw new ArgumentNullException("rightSide");
			}
			return (DenseVector)rightSide.LeftMultiply(leftSide);
		}

		public static DenseMatrix operator %(DenseMatrix leftSide, MathNet.Numerics.Complex32 rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (DenseMatrix)leftSide.Remainder(rightSide);
		}

		public override bool IsSymmetric()
		{
			if (base.RowCount != base.ColumnCount)
			{
				return false;
			}
			for (int i = 0; i < base.ColumnCount; i++)
			{
				int num = i * base.RowCount;
				for (int j = i + 1; j < base.RowCount; j++)
				{
					if (_values[j * base.ColumnCount + i] != _values[num + j])
					{
						return false;
					}
				}
			}
			return true;
		}

		public override bool IsHermitian()
		{
			if (base.RowCount != base.ColumnCount)
			{
				return false;
			}
			int num = base.RowCount + 1;
			for (int i = 0; i < _values.Length; i += num)
			{
				if (!_values[i].IsReal())
				{
					return false;
				}
			}
			for (int j = 0; j < base.ColumnCount; j++)
			{
				int num2 = j * base.RowCount;
				for (int k = j + 1; k < base.RowCount; k++)
				{
					if (_values[k * base.ColumnCount + j] != _values[num2 + k].Conjugate())
					{
						return false;
					}
				}
			}
			return true;
		}

		public override Cholesky<MathNet.Numerics.Complex32> Cholesky()
		{
			return DenseCholesky.Create(this);
		}

		public override LU<MathNet.Numerics.Complex32> LU()
		{
			return DenseLU.Create(this);
		}

		public override QR<MathNet.Numerics.Complex32> QR(QRMethod method = QRMethod.Thin)
		{
			return DenseQR.Create(this, method);
		}

		public override GramSchmidt<MathNet.Numerics.Complex32> GramSchmidt()
		{
			return DenseGramSchmidt.Create(this);
		}

		public override Svd<MathNet.Numerics.Complex32> Svd(bool computeVectors = true)
		{
			return DenseSvd.Create(this, computeVectors);
		}

		public override Evd<MathNet.Numerics.Complex32> Evd(Symmetricity symmetricity = Symmetricity.Unknown)
		{
			return DenseEvd.Create(this, symmetricity);
		}
	}
}
