using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Complex.Factorization;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Providers.LinearAlgebra;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Complex
{
	[Serializable]
	[DebuggerDisplay("DenseMatrix {RowCount}x{ColumnCount}-Complex")]
	public class DenseMatrix : Matrix
	{
		private readonly int _rowCount;

		private readonly int _columnCount;

		private readonly System.Numerics.Complex[] _values;

		public System.Numerics.Complex[] Values => _values;

		public DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex> storage)
			: base(storage)
		{
			_rowCount = storage.RowCount;
			_columnCount = storage.ColumnCount;
			_values = storage.Data;
		}

		public DenseMatrix(int order)
			: this(new DenseColumnMajorMatrixStorage<System.Numerics.Complex>(order, order))
		{
		}

		public DenseMatrix(int rows, int columns)
			: this(new DenseColumnMajorMatrixStorage<System.Numerics.Complex>(rows, columns))
		{
		}

		public DenseMatrix(int rows, int columns, System.Numerics.Complex[] storage)
			: this(new DenseColumnMajorMatrixStorage<System.Numerics.Complex>(rows, columns, storage))
		{
		}

		public static DenseMatrix OfMatrix(Matrix<System.Numerics.Complex> matrix)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfMatrix(matrix.Storage));
		}

		public static DenseMatrix OfArray(System.Numerics.Complex[,] array)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfArray(array));
		}

		public static DenseMatrix OfIndexed(int rows, int columns, IEnumerable<Tuple<int, int, System.Numerics.Complex>> enumerable)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfIndexedEnumerable(rows, columns, enumerable));
		}

		public static DenseMatrix OfIndexed(int rows, int columns, IEnumerable<(int, int, System.Numerics.Complex)> enumerable)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfIndexedEnumerable(rows, columns, enumerable));
		}

		public static DenseMatrix OfColumnMajor(int rows, int columns, IEnumerable<System.Numerics.Complex> columnMajor)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfColumnMajorEnumerable(rows, columns, columnMajor));
		}

		public static DenseMatrix OfColumns(IEnumerable<IEnumerable<System.Numerics.Complex>> data)
		{
			return OfColumnArrays(data.Select((IEnumerable<System.Numerics.Complex> v) => v.ToArray()).ToArray());
		}

		public static DenseMatrix OfColumns(int rows, int columns, IEnumerable<IEnumerable<System.Numerics.Complex>> data)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfColumnEnumerables(rows, columns, data));
		}

		public static DenseMatrix OfColumnArrays(params System.Numerics.Complex[][] columns)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfColumnArrays(columns));
		}

		public static DenseMatrix OfColumnArrays(IEnumerable<System.Numerics.Complex[]> columns)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfColumnArrays((columns as System.Numerics.Complex[][]) ?? columns.ToArray()));
		}

		public static DenseMatrix OfColumnVectors(params Vector<System.Numerics.Complex>[] columns)
		{
			VectorStorage<System.Numerics.Complex>[] array = new VectorStorage<System.Numerics.Complex>[columns.Length];
			for (int i = 0; i < columns.Length; i++)
			{
				array[i] = columns[i].Storage;
			}
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfColumnVectors(array));
		}

		public static DenseMatrix OfColumnVectors(IEnumerable<Vector<System.Numerics.Complex>> columns)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfColumnVectors(columns.Select((Vector<System.Numerics.Complex> c) => c.Storage).ToArray()));
		}

		public static DenseMatrix OfRows(IEnumerable<IEnumerable<System.Numerics.Complex>> data)
		{
			return OfRowArrays(data.Select((IEnumerable<System.Numerics.Complex> v) => v.ToArray()).ToArray());
		}

		public static DenseMatrix OfRows(int rows, int columns, IEnumerable<IEnumerable<System.Numerics.Complex>> data)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfRowEnumerables(rows, columns, data));
		}

		public static DenseMatrix OfRowArrays(params System.Numerics.Complex[][] rows)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfRowArrays(rows));
		}

		public static DenseMatrix OfRowArrays(IEnumerable<System.Numerics.Complex[]> rows)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfRowArrays((rows as System.Numerics.Complex[][]) ?? rows.ToArray()));
		}

		public static DenseMatrix OfRowVectors(params Vector<System.Numerics.Complex>[] rows)
		{
			VectorStorage<System.Numerics.Complex>[] array = new VectorStorage<System.Numerics.Complex>[rows.Length];
			for (int i = 0; i < rows.Length; i++)
			{
				array[i] = rows[i].Storage;
			}
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfRowVectors(array));
		}

		public static DenseMatrix OfRowVectors(IEnumerable<Vector<System.Numerics.Complex>> rows)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfRowVectors(rows.Select((Vector<System.Numerics.Complex> r) => r.Storage).ToArray()));
		}

		public static DenseMatrix OfDiagonalVector(Vector<System.Numerics.Complex> diagonal)
		{
			DenseMatrix denseMatrix = new DenseMatrix(diagonal.Count, diagonal.Count);
			denseMatrix.SetDiagonal(diagonal);
			return denseMatrix;
		}

		public static DenseMatrix OfDiagonalVector(int rows, int columns, Vector<System.Numerics.Complex> diagonal)
		{
			DenseMatrix denseMatrix = new DenseMatrix(rows, columns);
			denseMatrix.SetDiagonal(diagonal);
			return denseMatrix;
		}

		public static DenseMatrix OfDiagonalArray(System.Numerics.Complex[] diagonal)
		{
			DenseMatrix denseMatrix = new DenseMatrix(diagonal.Length, diagonal.Length);
			denseMatrix.SetDiagonal(diagonal);
			return denseMatrix;
		}

		public static DenseMatrix OfDiagonalArray(int rows, int columns, System.Numerics.Complex[] diagonal)
		{
			DenseMatrix denseMatrix = new DenseMatrix(rows, columns);
			denseMatrix.SetDiagonal(diagonal);
			return denseMatrix;
		}

		public static DenseMatrix Create(int rows, int columns, System.Numerics.Complex value)
		{
			if (value == System.Numerics.Complex.Zero)
			{
				return new DenseMatrix(rows, columns);
			}
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfValue(rows, columns, value));
		}

		public static DenseMatrix Create(int rows, int columns, Func<int, int, System.Numerics.Complex> init)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfInit(rows, columns, init));
		}

		public static DenseMatrix CreateDiagonal(int rows, int columns, System.Numerics.Complex value)
		{
			if (value == System.Numerics.Complex.Zero)
			{
				return new DenseMatrix(rows, columns);
			}
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfDiagonalInit(rows, columns, (int _) => value));
		}

		public static DenseMatrix CreateDiagonal(int rows, int columns, Func<int, System.Numerics.Complex> init)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfDiagonalInit(rows, columns, init));
		}

		public static DenseMatrix CreateIdentity(int order)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<System.Numerics.Complex>.OfDiagonalInit(order, order, (int _) => Matrix<System.Numerics.Complex>.One));
		}

		public static DenseMatrix CreateRandom(int rows, int columns, IContinuousDistribution distribution)
		{
			return new DenseMatrix(new DenseColumnMajorMatrixStorage<System.Numerics.Complex>(rows, columns, Generate.RandomComplex(rows * columns, distribution)));
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

		protected override void DoNegate(Matrix<System.Numerics.Complex> result)
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

		protected override void DoConjugate(Matrix<System.Numerics.Complex> result)
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

		protected override void DoAdd(System.Numerics.Complex scalar, Matrix<System.Numerics.Complex> result)
		{
			DenseMatrix denseResult = result as DenseMatrix;
			if (denseResult != null)
			{
				CommonParallel.For(0, _values.Length, 4096, delegate(int a, int b)
				{
					System.Numerics.Complex[] values = denseResult._values;
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

		protected override void DoAdd(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			if (other.Storage is DenseColumnMajorMatrixStorage<System.Numerics.Complex> denseColumnMajorMatrixStorage && result.Storage is DenseColumnMajorMatrixStorage<System.Numerics.Complex> denseColumnMajorMatrixStorage2)
			{
				LinearAlgebraControl.Provider.AddArrays(_values, denseColumnMajorMatrixStorage.Data, denseColumnMajorMatrixStorage2.Data);
			}
			else if (other.Storage is DiagonalMatrixStorage<System.Numerics.Complex> diagonalMatrixStorage)
			{
				base.Storage.CopyToUnchecked(result.Storage, ExistingData.Clear);
				System.Numerics.Complex[] data = diagonalMatrixStorage.Data;
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

		protected override void DoSubtract(System.Numerics.Complex scalar, Matrix<System.Numerics.Complex> result)
		{
			DenseMatrix denseResult = result as DenseMatrix;
			if (denseResult != null)
			{
				CommonParallel.For(0, _values.Length, 4096, delegate(int a, int b)
				{
					System.Numerics.Complex[] values = denseResult._values;
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

		protected override void DoSubtract(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			if (other.Storage is DenseColumnMajorMatrixStorage<System.Numerics.Complex> denseColumnMajorMatrixStorage && result.Storage is DenseColumnMajorMatrixStorage<System.Numerics.Complex> denseColumnMajorMatrixStorage2)
			{
				LinearAlgebraControl.Provider.SubtractArrays(_values, denseColumnMajorMatrixStorage.Data, denseColumnMajorMatrixStorage2.Data);
			}
			else if (other.Storage is DiagonalMatrixStorage<System.Numerics.Complex> diagonalMatrixStorage)
			{
				CopyTo(result);
				System.Numerics.Complex[] data = diagonalMatrixStorage.Data;
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

		protected override void DoMultiply(System.Numerics.Complex scalar, Matrix<System.Numerics.Complex> result)
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

		protected override void DoMultiply(Vector<System.Numerics.Complex> rightSide, Vector<System.Numerics.Complex> result)
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

		protected override void DoMultiply(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			if (other is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.MatrixMultiply(_values, _rowCount, _columnCount, denseMatrix._values, denseMatrix._rowCount, denseMatrix._columnCount, denseMatrix2._values);
			}
			else if (other.Storage is DiagonalMatrixStorage<System.Numerics.Complex> { Data: var data })
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

		protected override void DoTransposeAndMultiply(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			if (other is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.MatrixMultiplyWithUpdate(MathNet.Numerics.Providers.LinearAlgebra.Transpose.DontTranspose, MathNet.Numerics.Providers.LinearAlgebra.Transpose.Transpose, 1.0, _values, _rowCount, _columnCount, denseMatrix._values, denseMatrix._rowCount, denseMatrix._columnCount, 0.0, denseMatrix2._values);
			}
			else if (other.Storage is DiagonalMatrixStorage<System.Numerics.Complex> { Data: var data })
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

		protected override void DoConjugateTransposeAndMultiply(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			if (other is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.MatrixMultiplyWithUpdate(MathNet.Numerics.Providers.LinearAlgebra.Transpose.DontTranspose, MathNet.Numerics.Providers.LinearAlgebra.Transpose.ConjugateTranspose, 1.0, _values, _rowCount, _columnCount, denseMatrix._values, denseMatrix._rowCount, denseMatrix._columnCount, 0.0, denseMatrix2._values);
			}
			else if (other.Storage is DiagonalMatrixStorage<System.Numerics.Complex> { Data: var data })
			{
				System.Numerics.Complex[] array = new System.Numerics.Complex[data.Length];
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

		protected override void DoTransposeThisAndMultiply(Vector<System.Numerics.Complex> rightSide, Vector<System.Numerics.Complex> result)
		{
			if (rightSide is DenseVector denseVector && result is DenseVector denseVector2)
			{
				LinearAlgebraControl.Provider.MatrixMultiplyWithUpdate(MathNet.Numerics.Providers.LinearAlgebra.Transpose.Transpose, MathNet.Numerics.Providers.LinearAlgebra.Transpose.DontTranspose, 1.0, _values, _rowCount, _columnCount, denseVector.Values, denseVector.Count, 1, 0.0, denseVector2.Values);
			}
			else
			{
				base.DoTransposeThisAndMultiply(rightSide, result);
			}
		}

		protected override void DoConjugateTransposeThisAndMultiply(Vector<System.Numerics.Complex> rightSide, Vector<System.Numerics.Complex> result)
		{
			if (rightSide is DenseVector denseVector && result is DenseVector denseVector2)
			{
				LinearAlgebraControl.Provider.MatrixMultiplyWithUpdate(MathNet.Numerics.Providers.LinearAlgebra.Transpose.ConjugateTranspose, MathNet.Numerics.Providers.LinearAlgebra.Transpose.DontTranspose, 1.0, _values, _rowCount, _columnCount, denseVector.Values, denseVector.Count, 1, 0.0, denseVector2.Values);
			}
			else
			{
				base.DoConjugateTransposeThisAndMultiply(rightSide, result);
			}
		}

		protected override void DoTransposeThisAndMultiply(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			if (other is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.MatrixMultiplyWithUpdate(MathNet.Numerics.Providers.LinearAlgebra.Transpose.Transpose, MathNet.Numerics.Providers.LinearAlgebra.Transpose.DontTranspose, 1.0, _values, _rowCount, _columnCount, denseMatrix._values, denseMatrix._rowCount, denseMatrix._columnCount, 0.0, denseMatrix2._values);
			}
			else if (other.Storage is DiagonalMatrixStorage<System.Numerics.Complex> { Data: var data })
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

		protected override void DoConjugateTransposeThisAndMultiply(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
		{
			if (other is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.MatrixMultiplyWithUpdate(MathNet.Numerics.Providers.LinearAlgebra.Transpose.ConjugateTranspose, MathNet.Numerics.Providers.LinearAlgebra.Transpose.DontTranspose, 1.0, _values, _rowCount, _columnCount, denseMatrix._values, denseMatrix._rowCount, denseMatrix._columnCount, 0.0, denseMatrix2._values);
			}
			else if (other.Storage is DiagonalMatrixStorage<System.Numerics.Complex> { Data: var data })
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

		protected override void DoDivide(System.Numerics.Complex divisor, Matrix<System.Numerics.Complex> result)
		{
			if (result is DenseMatrix denseMatrix)
			{
				LinearAlgebraControl.Provider.ScaleArray(1.0 / divisor, _values, denseMatrix._values);
			}
			else
			{
				base.DoDivide(divisor, result);
			}
		}

		protected override void DoPointwiseMultiply(Matrix<System.Numerics.Complex> other, Matrix<System.Numerics.Complex> result)
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

		protected override void DoPointwiseDivide(Matrix<System.Numerics.Complex> divisor, Matrix<System.Numerics.Complex> result)
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

		protected override void DoPointwisePower(Matrix<System.Numerics.Complex> exponent, Matrix<System.Numerics.Complex> result)
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

		public override System.Numerics.Complex Trace()
		{
			if (_rowCount != _columnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			System.Numerics.Complex zero = System.Numerics.Complex.Zero;
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
				throw Matrix<System.Numerics.Complex>.DimensionsDontMatch<ArgumentOutOfRangeException>(leftSide, rightSide);
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
				throw Matrix<System.Numerics.Complex>.DimensionsDontMatch<ArgumentOutOfRangeException>(leftSide, rightSide);
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

		public static DenseMatrix operator *(DenseMatrix leftSide, System.Numerics.Complex rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (DenseMatrix)leftSide.Multiply(rightSide);
		}

		public static DenseMatrix operator *(System.Numerics.Complex leftSide, DenseMatrix rightSide)
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
				throw Matrix<System.Numerics.Complex>.DimensionsDontMatch<ArgumentException>(leftSide, rightSide);
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

		public static DenseMatrix operator %(DenseMatrix leftSide, System.Numerics.Complex rightSide)
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

		public override Cholesky<System.Numerics.Complex> Cholesky()
		{
			return DenseCholesky.Create(this);
		}

		public override LU<System.Numerics.Complex> LU()
		{
			return DenseLU.Create(this);
		}

		public override QR<System.Numerics.Complex> QR(QRMethod method = QRMethod.Thin)
		{
			return DenseQR.Create(this, method);
		}

		public override GramSchmidt<System.Numerics.Complex> GramSchmidt()
		{
			return DenseGramSchmidt.Create(this);
		}

		public override Svd<System.Numerics.Complex> Svd(bool computeVectors = true)
		{
			return DenseSvd.Create(this, computeVectors);
		}

		public override Evd<System.Numerics.Complex> Evd(Symmetricity symmetricity = Symmetricity.Unknown)
		{
			return DenseEvd.Create(this, symmetricity);
		}
	}
}
