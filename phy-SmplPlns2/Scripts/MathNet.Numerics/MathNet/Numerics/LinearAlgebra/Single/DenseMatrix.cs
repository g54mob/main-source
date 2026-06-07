using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Factorization;
using MathNet.Numerics.LinearAlgebra.Single.Factorization;
using MathNet.Numerics.LinearAlgebra.Storage;
using MathNet.Numerics.Providers.LinearAlgebra;
using MathNet.Numerics.Threading;

namespace MathNet.Numerics.LinearAlgebra.Single
{
	[Serializable]
	[DebuggerDisplay("DenseMatrix {RowCount}x{ColumnCount}-Single")]
	public class DenseMatrix : Matrix
	{
		private readonly int _rowCount;

		private readonly int _columnCount;

		private readonly float[] _values;

		public float[] Values => _values;

		public DenseMatrix(DenseColumnMajorMatrixStorage<float> storage)
			: base(storage)
		{
			_rowCount = storage.RowCount;
			_columnCount = storage.ColumnCount;
			_values = storage.Data;
		}

		public DenseMatrix(int order)
			: this(new DenseColumnMajorMatrixStorage<float>(order, order))
		{
		}

		public DenseMatrix(int rows, int columns)
			: this(new DenseColumnMajorMatrixStorage<float>(rows, columns))
		{
		}

		public DenseMatrix(int rows, int columns, float[] storage)
			: this(new DenseColumnMajorMatrixStorage<float>(rows, columns, storage))
		{
		}

		public static DenseMatrix OfMatrix(Matrix<float> matrix)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfMatrix(matrix.Storage));
		}

		public static DenseMatrix OfArray(float[,] array)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfArray(array));
		}

		public static DenseMatrix OfIndexed(int rows, int columns, IEnumerable<Tuple<int, int, float>> enumerable)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfIndexedEnumerable(rows, columns, enumerable));
		}

		public static DenseMatrix OfIndexed(int rows, int columns, IEnumerable<(int, int, float)> enumerable)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfIndexedEnumerable(rows, columns, enumerable));
		}

		public static DenseMatrix OfColumnMajor(int rows, int columns, IEnumerable<float> columnMajor)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfColumnMajorEnumerable(rows, columns, columnMajor));
		}

		public static DenseMatrix OfColumns(IEnumerable<IEnumerable<float>> data)
		{
			return OfColumnArrays(data.Select((IEnumerable<float> v) => v.ToArray()).ToArray());
		}

		public static DenseMatrix OfColumns(int rows, int columns, IEnumerable<IEnumerable<float>> data)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfColumnEnumerables(rows, columns, data));
		}

		public static DenseMatrix OfColumnArrays(params float[][] columns)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfColumnArrays(columns));
		}

		public static DenseMatrix OfColumnArrays(IEnumerable<float[]> columns)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfColumnArrays((columns as float[][]) ?? columns.ToArray()));
		}

		public static DenseMatrix OfColumnVectors(params Vector<float>[] columns)
		{
			VectorStorage<float>[] array = new VectorStorage<float>[columns.Length];
			for (int i = 0; i < columns.Length; i++)
			{
				array[i] = columns[i].Storage;
			}
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfColumnVectors(array));
		}

		public static DenseMatrix OfColumnVectors(IEnumerable<Vector<float>> columns)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfColumnVectors(columns.Select((Vector<float> c) => c.Storage).ToArray()));
		}

		public static DenseMatrix OfRows(IEnumerable<IEnumerable<float>> data)
		{
			return OfRowArrays(data.Select((IEnumerable<float> v) => v.ToArray()).ToArray());
		}

		public static DenseMatrix OfRows(int rows, int columns, IEnumerable<IEnumerable<float>> data)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfRowEnumerables(rows, columns, data));
		}

		public static DenseMatrix OfRowArrays(params float[][] rows)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfRowArrays(rows));
		}

		public static DenseMatrix OfRowArrays(IEnumerable<float[]> rows)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfRowArrays((rows as float[][]) ?? rows.ToArray()));
		}

		public static DenseMatrix OfRowVectors(params Vector<float>[] rows)
		{
			VectorStorage<float>[] array = new VectorStorage<float>[rows.Length];
			for (int i = 0; i < rows.Length; i++)
			{
				array[i] = rows[i].Storage;
			}
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfRowVectors(array));
		}

		public static DenseMatrix OfRowVectors(IEnumerable<Vector<float>> rows)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfRowVectors(rows.Select((Vector<float> r) => r.Storage).ToArray()));
		}

		public static DenseMatrix OfDiagonalVector(Vector<float> diagonal)
		{
			DenseMatrix denseMatrix = new DenseMatrix(diagonal.Count, diagonal.Count);
			denseMatrix.SetDiagonal(diagonal);
			return denseMatrix;
		}

		public static DenseMatrix OfDiagonalVector(int rows, int columns, Vector<float> diagonal)
		{
			DenseMatrix denseMatrix = new DenseMatrix(rows, columns);
			denseMatrix.SetDiagonal(diagonal);
			return denseMatrix;
		}

		public static DenseMatrix OfDiagonalArray(float[] diagonal)
		{
			DenseMatrix denseMatrix = new DenseMatrix(diagonal.Length, diagonal.Length);
			denseMatrix.SetDiagonal(diagonal);
			return denseMatrix;
		}

		public static DenseMatrix OfDiagonalArray(int rows, int columns, float[] diagonal)
		{
			DenseMatrix denseMatrix = new DenseMatrix(rows, columns);
			denseMatrix.SetDiagonal(diagonal);
			return denseMatrix;
		}

		public static DenseMatrix Create(int rows, int columns, float value)
		{
			if (value == 0f)
			{
				return new DenseMatrix(rows, columns);
			}
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfValue(rows, columns, value));
		}

		public static DenseMatrix Create(int rows, int columns, Func<int, int, float> init)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfInit(rows, columns, init));
		}

		public static DenseMatrix CreateDiagonal(int rows, int columns, float value)
		{
			if (value == 0f)
			{
				return new DenseMatrix(rows, columns);
			}
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfDiagonalInit(rows, columns, (int _) => value));
		}

		public static DenseMatrix CreateDiagonal(int rows, int columns, Func<int, float> init)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfDiagonalInit(rows, columns, init));
		}

		public static DenseMatrix CreateIdentity(int order)
		{
			return new DenseMatrix(DenseColumnMajorMatrixStorage<float>.OfDiagonalInit(order, order, (int _) => Matrix<float>.One));
		}

		public static DenseMatrix CreateRandom(int rows, int columns, IContinuousDistribution distribution)
		{
			return new DenseMatrix(new DenseColumnMajorMatrixStorage<float>(rows, columns, Generate.RandomSingle(rows * columns, distribution)));
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

		protected override void DoNegate(Matrix<float> result)
		{
			if (result is DenseMatrix denseMatrix)
			{
				LinearAlgebraControl.Provider.ScaleArray(-1f, _values, denseMatrix._values);
			}
			else
			{
				base.DoNegate(result);
			}
		}

		protected override void DoAdd(float scalar, Matrix<float> result)
		{
			DenseMatrix denseResult = result as DenseMatrix;
			if (denseResult != null)
			{
				CommonParallel.For(0, _values.Length, 4096, delegate(int a, int b)
				{
					float[] values = denseResult._values;
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

		protected override void DoAdd(Matrix<float> other, Matrix<float> result)
		{
			if (other.Storage is DenseColumnMajorMatrixStorage<float> denseColumnMajorMatrixStorage && result.Storage is DenseColumnMajorMatrixStorage<float> denseColumnMajorMatrixStorage2)
			{
				LinearAlgebraControl.Provider.AddArrays(_values, denseColumnMajorMatrixStorage.Data, denseColumnMajorMatrixStorage2.Data);
			}
			else if (other.Storage is DiagonalMatrixStorage<float> diagonalMatrixStorage)
			{
				base.Storage.CopyToUnchecked(result.Storage, ExistingData.Clear);
				float[] data = diagonalMatrixStorage.Data;
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

		protected override void DoSubtract(float scalar, Matrix<float> result)
		{
			DenseMatrix denseResult = result as DenseMatrix;
			if (denseResult != null)
			{
				CommonParallel.For(0, _values.Length, 4096, delegate(int a, int b)
				{
					float[] values = denseResult._values;
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

		protected override void DoSubtract(Matrix<float> other, Matrix<float> result)
		{
			if (other.Storage is DenseColumnMajorMatrixStorage<float> denseColumnMajorMatrixStorage && result.Storage is DenseColumnMajorMatrixStorage<float> denseColumnMajorMatrixStorage2)
			{
				LinearAlgebraControl.Provider.SubtractArrays(_values, denseColumnMajorMatrixStorage.Data, denseColumnMajorMatrixStorage2.Data);
			}
			else if (other.Storage is DiagonalMatrixStorage<float> diagonalMatrixStorage)
			{
				CopyTo(result);
				float[] data = diagonalMatrixStorage.Data;
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

		protected override void DoMultiply(float scalar, Matrix<float> result)
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

		protected override void DoMultiply(Vector<float> rightSide, Vector<float> result)
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

		protected override void DoMultiply(Matrix<float> other, Matrix<float> result)
		{
			if (other is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.MatrixMultiply(_values, _rowCount, _columnCount, denseMatrix._values, denseMatrix._rowCount, denseMatrix._columnCount, denseMatrix2._values);
			}
			else if (other.Storage is DiagonalMatrixStorage<float> { Data: var data })
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

		protected override void DoTransposeAndMultiply(Matrix<float> other, Matrix<float> result)
		{
			if (other is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.MatrixMultiplyWithUpdate(MathNet.Numerics.Providers.LinearAlgebra.Transpose.DontTranspose, MathNet.Numerics.Providers.LinearAlgebra.Transpose.Transpose, 1f, _values, _rowCount, _columnCount, denseMatrix._values, denseMatrix._rowCount, denseMatrix._columnCount, 0f, denseMatrix2._values);
			}
			else if (other.Storage is DiagonalMatrixStorage<float> { Data: var data })
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

		protected override void DoTransposeThisAndMultiply(Vector<float> rightSide, Vector<float> result)
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

		protected override void DoTransposeThisAndMultiply(Matrix<float> other, Matrix<float> result)
		{
			if (other is DenseMatrix denseMatrix && result is DenseMatrix denseMatrix2)
			{
				LinearAlgebraControl.Provider.MatrixMultiplyWithUpdate(MathNet.Numerics.Providers.LinearAlgebra.Transpose.Transpose, MathNet.Numerics.Providers.LinearAlgebra.Transpose.DontTranspose, 1f, _values, _rowCount, _columnCount, denseMatrix._values, denseMatrix._rowCount, denseMatrix._columnCount, 0f, denseMatrix2._values);
			}
			else if (other.Storage is DiagonalMatrixStorage<float> { Data: var data })
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

		protected override void DoDivide(float divisor, Matrix<float> result)
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

		protected override void DoPointwiseMultiply(Matrix<float> other, Matrix<float> result)
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

		protected override void DoPointwiseDivide(Matrix<float> divisor, Matrix<float> result)
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

		protected override void DoPointwisePower(Matrix<float> exponent, Matrix<float> result)
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

		protected override void DoModulus(float divisor, Matrix<float> result)
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
					float[] values = denseResult._values;
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

		protected override void DoModulusByThis(float dividend, Matrix<float> result)
		{
			DenseMatrix denseResult = result as DenseMatrix;
			if (denseResult != null)
			{
				CommonParallel.For(0, _values.Length, 4096, delegate(int a, int b)
				{
					float[] values = denseResult._values;
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

		protected override void DoRemainder(float divisor, Matrix<float> result)
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
					float[] values = denseResult._values;
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

		protected override void DoRemainderByThis(float dividend, Matrix<float> result)
		{
			DenseMatrix denseResult = result as DenseMatrix;
			if (denseResult != null)
			{
				CommonParallel.For(0, _values.Length, 4096, delegate(int a, int b)
				{
					float[] values = denseResult._values;
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

		public override float Trace()
		{
			if (_rowCount != _columnCount)
			{
				throw new ArgumentException("Matrix must be square.");
			}
			float num = 0f;
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
				throw Matrix<float>.DimensionsDontMatch<ArgumentOutOfRangeException>(leftSide, rightSide);
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
				throw Matrix<float>.DimensionsDontMatch<ArgumentOutOfRangeException>(leftSide, rightSide);
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

		public static DenseMatrix operator *(DenseMatrix leftSide, float rightSide)
		{
			if (leftSide == null)
			{
				throw new ArgumentNullException("leftSide");
			}
			return (DenseMatrix)leftSide.Multiply(rightSide);
		}

		public static DenseMatrix operator *(float leftSide, DenseMatrix rightSide)
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
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(leftSide, rightSide);
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

		public static DenseMatrix operator %(DenseMatrix leftSide, float rightSide)
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

		public override Cholesky<float> Cholesky()
		{
			return DenseCholesky.Create(this);
		}

		public override LU<float> LU()
		{
			return DenseLU.Create(this);
		}

		public override QR<float> QR(QRMethod method = QRMethod.Thin)
		{
			return DenseQR.Create(this, method);
		}

		public override GramSchmidt<float> GramSchmidt()
		{
			return DenseGramSchmidt.Create(this);
		}

		public override Svd<float> Svd(bool computeVectors = true)
		{
			return DenseSvd.Create(this, computeVectors);
		}

		public override Evd<float> Evd(Symmetricity symmetricity = Symmetricity.Unknown)
		{
			return DenseEvd.Create(this, symmetricity);
		}
	}
}
