using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Double.Factorization;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Providers.LinearAlgebra;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Double
{
	[Serializable]
	[DebuggerDisplay("DenseMatrix {RowCount}x{ColumnCount}-Double")]
	public class DenseMatrix : Matrix
	{
		private readonly int _rowCount;

		private readonly int _columnCount;

		private readonly double[] _values;

		public double[] Values => _values;

		public DenseMatrix(DenseColumnMajorMatrixStorage<double> storage)
			: base(storage)
		{
			_rowCount = storage.RowCount;
			_columnCount = storage.ColumnCount;
			_values = storage.Data;
		}

		public DenseMatrix(int order)
			: this(new DenseColumnMajorMatrixStorage<double>(order, order))
		{
		}

		public DenseMatrix(int rows, int columns)
			: this(new DenseColumnMajorMatrixStorage<double>(rows, columns))
		{
		}

		public DenseMatrix(int rows, int columns, double[] storage)
			: this(new DenseColumnMajorMatrixStorage<double>(rows, columns, storage))
		{
		}

		public static DenseMatrix OfMatrix(Matrix<double> matrix)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfMatrix(matrix.Storage));
		}

		public static DenseMatrix OfArray(double[,] array)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfArray(array));
		}

		public static DenseMatrix OfIndexed(int rows, int columns, IEnumerable<Tuple<int, int, double>> enumerable)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfIndexedEnumerable(rows, columns, enumerable));
		}

		public static DenseMatrix OfIndexed(int rows, int columns, IEnumerable<(int, int, double)> enumerable)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfIndexedEnumerable(rows, columns, enumerable));
		}

		public static DenseMatrix OfColumnMajor(int rows, int columns, IEnumerable<double> columnMajor)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfColumnMajorEnumerable(rows, columns, columnMajor));
		}

		public static DenseMatrix OfColumns(IEnumerable<IEnumerable<double>> data)
		{
			return OfColumnArrays(data.Select((IEnumerable<double> v) => v.ToArray()).ToArray());
		}

		public static DenseMatrix OfColumns(int rows, int columns, IEnumerable<IEnumerable<double>> data)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfColumnEnumerables(rows, columns, data));
		}

		public static DenseMatrix OfColumnArrays(params double[][] columns)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfColumnArrays(columns));
		}

		public static DenseMatrix OfColumnArrays(IEnumerable<double[]> columns)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfColumnArrays((columns as double[][]) ?? columns.ToArray()));
		}

		public static DenseMatrix OfColumnVectors(params Vector<double>[] columns)
		{
			VectorStorage<double>[] array = new VectorStorage<double>[columns.Length];
			for (int i = 0; i < columns.Length; i++)
			{
				array[i] = columns[i].Storage;
			}
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfColumnVectors(array));
		}

		public static DenseMatrix OfColumnVectors(IEnumerable<Vector<double>> columns)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfColumnVectors(columns.Select((Vector<double> c) => c.Storage).ToArray()));
		}

		public static DenseMatrix OfRows(IEnumerable<IEnumerable<double>> data)
		{
			return OfRowArrays(data.Select((IEnumerable<double> v) => v.ToArray()).ToArray());
		}

		public static DenseMatrix OfRows(int rows, int columns, IEnumerable<IEnumerable<double>> data)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfRowEnumerables(rows, columns, data));
		}

		public static DenseMatrix OfRowArrays(params double[][] rows)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfRowArrays(rows));
		}

		public static DenseMatrix OfRowArrays(IEnumerable<double[]> rows)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfRowArrays((rows as double[][]) ?? rows.ToArray()));
		}

		public static DenseMatrix OfRowVectors(params Vector<double>[] rows)
		{
			VectorStorage<double>[] array = new VectorStorage<double>[rows.Length];
			for (int i = 0; i < rows.Length; i++)
			{
				array[i] = rows[i].Storage;
			}
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfRowVectors(array));
		}

		public static DenseMatrix OfRowVectors(IEnumerable<Vector<double>> rows)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfRowVectors(rows.Select((Vector<double> r) => r.Storage).ToArray()));
		}

		public static DenseMatrix OfDiagonalVector(Vector<double> diagonal)
		{
			DenseMatrix denseMatrix = new DenseMatrix(diagonal.Count, diagonal.Count);
			denseMatrix.SetDiagonal(diagonal);
			return denseMatrix;
		}

		public static DenseMatrix OfDiagonalVector(int rows, int columns, Vector<double> diagonal)
		{
			DenseMatrix denseMatrix = new DenseMatrix(rows, columns);
			denseMatrix.SetDiagonal(diagonal);
			return denseMatrix;
		}

		public static DenseMatrix OfDiagonalArray(double[] diagonal)
		{
			DenseMatrix denseMatrix = new DenseMatrix(diagonal.Length, diagonal.Length);
			denseMatrix.SetDiagonal(diagonal);
			return denseMatrix;
		}

		public static DenseMatrix OfDiagonalArray(int rows, int columns, double[] diagonal)
		{
			DenseMatrix denseMatrix = new DenseMatrix(rows, columns);
			denseMatrix.SetDiagonal(diagonal);
			return denseMatrix;
		}

		public static DenseMatrix Create(int rows, int columns, double value)
		{
			if (value == 0.0)
			{
				return new DenseMatrix(rows, columns);
			}
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfValue(rows, columns, value));
		}

		public static DenseMatrix Create(int rows, int columns, Func<int, int, double> init)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfInit(rows, columns, init));
		}

		public static DenseMatrix CreateDiagonal(int rows, int columns, double value)
		{
			if (value == 0.0)
			{
				return new DenseMatrix(rows, columns);
			}
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfDiagonalInit(rows, columns, (int _) => value));
		}

		public static DenseMatrix CreateDiagonal(int rows, int columns, Func<int, double> init)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfDiagonalInit(rows, columns, init));
		}

		public static DenseMatrix CreateIdentity(int order)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<double>.OfDiagonalInit(order, order, (int _) => Matrix<double>.One));
		}

		public static DenseMatrix CreateRandom(int rows, int columns, IContinuousDistribution distribution)
		{
			return new DenseMatrix(new DenseColumnMajorMatrixStorage<double>(rows, columns, Generate.Random(rows * columns, distribution)));
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

		protected override void DoNegate(Matrix<double> result)
		{
			if (result is DenseMatrix denseMatrix)
			{
				LinearAlgebraControl.Provider.ScaleArray(-1.0, _values, denseMatrix._values);
			}
			else
			{
				base.DoNegate(result);
			}
		}

		protected override void DoAdd(double scalar, Matrix<double> result)
		{
			DenseMatrix denseResult = result as DenseMatrix;
			if (denseResult != null)
			{
				CommonParallel.For(0, _values.Length, 4096, delegate(int a, int b)
				{
					double[] values = denseResult._values;
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

		protected override void DoAdd(Matrix<double> other, Matrix<double> result)
		{
			if (other.Storage is DenseColumnMajorMatrixStorage<double> denseColumnMajorMatrixStorage && result.Storage is DenseColumnMajorMatrixStorage<double> denseColumnMajorMatrixStorage2)
			{
				LinearAlgebraControl.Provider.AddArrays(_values, denseColumnMajorMatrixStorage.Data, denseColumnMajorMatrixStorage2.Data);
			}
			else if (other.Storage is DiagonalMatrixStorage<double> diagonalMatrixStorage)
			{
				base.Storage.CopyToUnchecked(result.Storage, ExistingData.Clear);
				double[] data = diagonalMatrixStorage.Data;
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

		protected override void DoSubtract(double scalar, Matrix<double> result)
		{
			DenseMatrix denseResult = result as DenseMatrix;
			if (denseResult != null)
			{
				CommonParallel.For(0, _values.Length, 4096, delegate(int a, int b)
				{
					double[] values = denseResult._values;
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

		protected override void DoSubtract(Matrix<double> other, Matrix<double> result)
		{
			if (other.Storage is DenseColumnMajorMatrixStorage<double> denseColumnMajorMatrixStorage && result.Storage is DenseColumnMajorMatrixStorage<double> denseColumnMajorMatrixStorage2)
			{
				LinearAlgebraControl.Provider.SubtractArrays(_values, denseColumnMajorMatrixStorage.Data, denseColumnMajorMatrixStorage2.Data);
			}
			else if (other.Storage is DiagonalMatrixStorage<double> diagonalMatrixStorage)
			{
				CopyTo(result);
				double[] data = diagonalMatrixStorage.Data;
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

		protected override void DoMultiply(double scalar, Matrix<double> result)
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

		protected override void DoMultiply(Vector<double> rightSide, Vector<double> result)
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

		protected override void DoMultiply(Matrix<double> other, Matrix<double> result)
		{
			if (other is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.MatrixMultiply(_values, _rowCount, _columnCount, denseMatrix._values, denseMatrix._rowCount, denseMatrix._columnCount, denseMatrix2._values);
			}
			else if (other.Storage is DiagonalMatrixStorage<double> { Data: var data })
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

		protected override void DoTransposeAndMultiply(Matrix<double> other, Matrix<double> result)
		{
			if (other is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.MatrixMultiplyWithUpdate(MathNet.Numerics.Providers.LinearAlgebra.Transpose.DontTranspose, MathNet.Numerics.Providers.LinearAlgebra.Transpose.Transpose, 1.0, _values, _rowCount, _columnCount, denseMatrix._values, denseMatrix._rowCount, denseMatrix._columnCount, 0.0, denseMatrix2._values);
			}
			else if (other.Storage is DiagonalMatrixStorage<double> { Data: var data })
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

		protected override void DoTransposeThisAndMultiply(Vector<double> rightSide, Vector<double> result)
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

		protected override void DoTransposeThisAndMultiply(Matrix<double> other, Matrix<double> result)
		{
			if (other is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.MatrixMultiplyWithUpdate(MathNet.Numerics.Providers.LinearAlgebra.Transpose.Transpose, MathNet.Numerics.Providers.LinearAlgebra.Transpose.DontTranspose, 1.0, _values, _rowCount, _columnCount, denseMatrix._values, denseMatrix._rowCount, denseMatrix._columnCount, 0.0, denseMatrix2._values);
			}
			else if (other.Storage is DiagonalMatrixStorage<double> { Data: var data })
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

		protected override void DoDivide(double divisor, Matrix<double> result)
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

		protected override void DoPointwiseMultiply(Matrix<double> other, Matrix<double> result)
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

		protected override void DoPointwiseDivide(Matrix<double> divisor, Matrix<double> result)
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

		protected override void DoPointwisePower(Matrix<double> exponent, Matrix<double> result)
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

		protected override void DoModulus(double divisor, Matrix<double> result)
		{
			DenseMatrix denseResult = result as DenseMatrix;
			if (denseResult != null)
			{
				if (this != result)
				{
					CopyTo(result);
				}
				CommonParallel.For(0, _values.Length, delegate(int a, int b)
				{
					double[] values = denseResult._values;
					for (int i = a; i < b; i++)
					{
						values[i] = Euclid.Modulus(values[i], divisor);
					}
				});
			}
			else
			{
				base.DoModulus(divisor, result);
			}
		}

		protected override void DoModulusByThis(double dividend, Matrix<double> result)
		{
			DenseMatrix denseResult = result as DenseMatrix;
			if (denseResult != null)
			{
				CommonParallel.For(0, _values.Length, 4096, delegate(int a, int b)
				{
					double[] values = denseResult._values;
					for (int i = a; i < b; i++)
					{
						values[i] = Euclid.Modulus(dividend, _values[i]);
					}
				});
			}
			else
			{
				base.DoModulusByThis(dividend, result);
			}
		}

		protected override void DoRemainder(double divisor, Matrix<double> result)
		{
			DenseMatrix denseResult = result as DenseMatrix;
			if (denseResult != null)
			{
				if (this != result)
				{
					CopyTo(result);
				}
				CommonParallel.For(0, _values.Length, delegate(int a, int b)
				{
					double[] values = denseResult._values;
					for (int i = a; i < b; i++)
					{
						values[i] %= divisor;
					}
				});
			}
			else
			{
				base.DoRemainder(divisor, result);
			}
		}

		protected override void DoRemainderByThis(double dividend, Matrix<double> result)
		{
			DenseMatrix denseResult = result as DenseMatrix;
			if (denseResult != null)
			{
				CommonParallel.For(0, _values.Length, 4096, delegate(int a, int b)
				{
					double[] values = denseResult._values;
					for (int i = a; i < b; i++)
					{
						values[i] = dividend % _values[i];
					}
				});
			}
			else
			{
				base.DoRemainderByThis(dividend, result);
			}
		}

		public override double Trace()
		{
			if (_rowCount != _columnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			double num = 0.0;
			for (int i = 0; i < _rowCount; i++)
			{
				num += _values[i * _rowCount + i];
			}
			return num;
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
				throw Matrix<double>.DimensionsDontMatch<ArgumentOutOfRangeException>(leftSide, rightSide);
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
				throw Matrix<double>.DimensionsDontMatch<ArgumentOutOfRangeException>(leftSide, rightSide);
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

		public static DenseMatrix operator *(DenseMatrix leftSide, double rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (DenseMatrix)leftSide.Multiply(rightSide);
		}

		public static DenseMatrix operator *(double leftSide, DenseMatrix rightSide)
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
				throw Matrix<double>.DimensionsDontMatch<ArgumentOutOfRangeException>(leftSide, rightSide);
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

		public static DenseMatrix operator %(DenseMatrix leftSide, double rightSide)
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

		public override Cholesky<double> Cholesky()
		{
			return DenseCholesky.Create(this);
		}

		public override LU<double> LU()
		{
			return DenseLU.Create(this);
		}

		public override QR<double> QR(QRMethod method = QRMethod.Thin)
		{
			return DenseQR.Create(this, method);
		}

		public override GramSchmidt<double> GramSchmidt()
		{
			return DenseGramSchmidt.Create(this);
		}

		public override Svd<double> Svd(bool computeVectors = true)
		{
			return DenseSvd.Create(this, computeVectors);
		}

		public override Evd<double> Evd(Symmetricity symmetricity = Symmetricity.Unknown)
		{
			return DenseEvd.Create(this, symmetricity);
		}
	}
}
