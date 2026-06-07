using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Complex32.Solvers
{
	public sealed class MlkBiCgStab : IIterativeSolver<MathNet.Numerics.Complex32>
	{
		private const int DefaultNumberOfStartingVectors = 50;

		private IList<Vector<MathNet.Numerics.Complex32>> _startingVectors;

		private int _numberOfStartingVectors = 50;

		public int NumberOfStartingVectors
		{
			[DebuggerStepThrough]
			get
			{
				return _numberOfStartingVectors;
			}
			[DebuggerStepThrough]
			set
			{
				if (value <= 1)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_numberOfStartingVectors = value;
			}
		}

		public IList<Vector<MathNet.Numerics.Complex32>> StartingVectors
		{
			[DebuggerStepThrough]
			get
			{
				return _startingVectors;
			}
			[DebuggerStepThrough]
			set
			{
				if (value == null || value.Count == 0)
				{
					_startingVectors = null;
				}
				else
				{
					_startingVectors = value;
				}
			}
		}

		public void ResetNumberOfStartingVectors()
		{
			_numberOfStartingVectors = 50;
		}

		private static int NumberOfStartingVectorsToCreate(int maximumNumberOfStartingVectors, int numberOfVariables)
		{
			return Math.Min(maximumNumberOfStartingVectors, numberOfVariables - 1);
		}

		private static IList<Vector<MathNet.Numerics.Complex32>> CreateStartingVectors(int maximumNumberOfStartingVectors, int numberOfVariables)
		{
			int columns = NumberOfStartingVectorsToCreate(maximumNumberOfStartingVectors, numberOfVariables);
			Normal normal = new Normal();
			DenseMatrix denseMatrix = new DenseMatrix(numberOfVariables, columns);
			for (int i = 0; i < denseMatrix.ColumnCount; i++)
			{
				MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[denseMatrix.RowCount];
				double[] array2 = normal.Samples().Take(denseMatrix.RowCount).ToArray();
				double[] array3 = normal.Samples().Take(denseMatrix.RowCount).ToArray();
				for (int j = 0; j < denseMatrix.RowCount; j++)
				{
					array[j] = new MathNet.Numerics.Complex32((float)array2[j], (float)array3[j]);
				}
				denseMatrix.SetColumn(i, array);
			}
			Matrix<MathNet.Numerics.Complex32> q = denseMatrix.GramSchmidt().Q;
			List<Vector<MathNet.Numerics.Complex32>> list = new List<Vector<MathNet.Numerics.Complex32>>(q.ColumnCount);
			for (int k = 0; k < q.ColumnCount; k++)
			{
				list.Add(q.Column(k));
				list[k].Multiply(1f / (float)list[k].L2Norm(), list[k]);
			}
			return list;
		}

		private static Vector<MathNet.Numerics.Complex32>[] CreateVectorArray(int arraySize, int vectorSize)
		{
			Vector<MathNet.Numerics.Complex32>[] array = new Vector<MathNet.Numerics.Complex32>[arraySize];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new DenseVector(vectorSize);
			}
			return array;
		}

		private static void CalculateTrueResidual(Matrix<MathNet.Numerics.Complex32> matrix, Vector<MathNet.Numerics.Complex32> residual, Vector<MathNet.Numerics.Complex32> x, Vector<MathNet.Numerics.Complex32> b)
		{
			matrix.Multiply(x, residual);
			residual.Multiply(-1, residual);
			residual.Add(b, residual);
		}

		public void Solve(Matrix<MathNet.Numerics.Complex32> matrix, Vector<MathNet.Numerics.Complex32> input, Vector<MathNet.Numerics.Complex32> result, Iterator<MathNet.Numerics.Complex32> iterator, IPreconditioner<MathNet.Numerics.Complex32> preconditioner)
		{
			if (matrix.RowCount != matrix.ColumnCount)
			{
				throw new ArgumentException("Matrix must be square.", "matrix");
			}
			if (result.Count != input.Count)
			{
				throw new ArgumentException("All vectors must have the same dimensionality.");
			}
			if (input.Count != matrix.RowCount)
			{
				throw Matrix<MathNet.Numerics.Complex32>.DimensionsDontMatch<ArgumentException>(input, matrix);
			}
			if (iterator == null)
			{
				iterator = new Iterator<MathNet.Numerics.Complex32>();
			}
			if (preconditioner == null)
			{
				preconditioner = new UnitPreconditioner<MathNet.Numerics.Complex32>();
			}
			preconditioner.Initialize(matrix);
			DenseVector denseVector = new DenseVector(input.Count);
			bool flag = false;
			if (_startingVectors != null && _startingVectors.Count <= NumberOfStartingVectorsToCreate(_numberOfStartingVectors, input.Count) && _startingVectors[0].Count == input.Count)
			{
				flag = true;
			}
			_startingVectors = (flag ? _startingVectors : CreateStartingVectors(_numberOfStartingVectors, input.Count));
			int count = _startingVectors.Count;
			DenseVector denseVector2 = new DenseVector(matrix.RowCount);
			CalculateTrueResidual(matrix, denseVector2, denseVector, input);
			MathNet.Numerics.Complex32[] array = new MathNet.Numerics.Complex32[count];
			DenseVector denseVector3 = new DenseVector(denseVector2.Count);
			DenseVector denseVector4 = new DenseVector(denseVector2.Count);
			DenseVector denseVector5 = new DenseVector(denseVector2.Count);
			DenseVector denseVector6 = new DenseVector(denseVector2.Count);
			DenseVector denseVector7 = new DenseVector(denseVector2.Count);
			DenseVector denseVector8 = new DenseVector(denseVector2.Count);
			DenseVector denseVector9 = new DenseVector(denseVector2.Count);
			DenseVector denseVector10 = new DenseVector(denseVector2.Count);
			DenseVector denseVector11 = new DenseVector(denseVector2.Count);
			Vector<MathNet.Numerics.Complex32>[] array2 = CreateVectorArray(_startingVectors.Count, denseVector2.Count);
			Vector<MathNet.Numerics.Complex32>[] array3 = CreateVectorArray(_startingVectors.Count, denseVector2.Count);
			denseVector2.CopyTo(array3[count - 1]);
			Vector<MathNet.Numerics.Complex32>[] array4 = CreateVectorArray(_startingVectors.Count, denseVector2.Count);
			for (int i = 0; iterator.DetermineStatus(i, denseVector, input, denseVector2) == IterationStatus.Continue; i++)
			{
				preconditioner.Approximate(array3[count - 1], denseVector3);
				matrix.Multiply(denseVector3, array4[count - 1]);
				array[count - 1] = _startingVectors[0].ConjugateDotProduct(array4[count - 1]);
				if (array[count - 1].Real.AlmostEqualNumbersBetween(0f, 1) && array[count - 1].Imaginary.AlmostEqualNumbersBetween(0f, 1))
				{
					throw new NumericalBreakdownException();
				}
				MathNet.Numerics.Complex32 complex = _startingVectors[0].ConjugateDotProduct(denseVector2) / array[count - 1];
				array4[count - 1].Multiply(-complex, denseVector6);
				denseVector2.Add(denseVector6, denseVector4);
				preconditioner.Approximate(denseVector4, denseVector7);
				denseVector7.CopyTo(denseVector5);
				matrix.Multiply(denseVector7, denseVector6);
				MathNet.Numerics.Complex32 complex2 = denseVector6.ConjugateDotProduct(denseVector6);
				if (complex2.Real.AlmostEqualNumbersBetween(0f, 1) && complex2.Imaginary.AlmostEqualNumbersBetween(0f, 1))
				{
					complex2 = 1f;
				}
				complex2 = -denseVector4.ConjugateDotProduct(denseVector6) / complex2;
				denseVector4.CopyTo(denseVector2);
				denseVector6.Multiply(complex2, denseVector6);
				denseVector2.Add(denseVector6, denseVector8);
				denseVector8.CopyTo(denseVector2);
				denseVector5.Multiply(-complex2, denseVector6);
				denseVector.Add(denseVector6, denseVector8);
				denseVector8.CopyTo(denseVector);
				denseVector3.Multiply(complex, denseVector3);
				denseVector.Add(denseVector3, denseVector8);
				denseVector8.CopyTo(denseVector);
				if (iterator.DetermineStatus(i, denseVector, input, denseVector2) != IterationStatus.Continue)
				{
					CalculateTrueResidual(matrix, denseVector2, denseVector, input);
					if (iterator.DetermineStatus(i, denseVector, input, denseVector2) != IterationStatus.Continue)
					{
						break;
					}
				}
				for (int j = 0; j < count; j++)
				{
					denseVector4.CopyTo(denseVector9);
					denseVector2.CopyTo(denseVector10);
					denseVector11.Clear();
					MathNet.Numerics.Complex32 scalar;
					if (i >= 1)
					{
						for (int k = j; k < count - 1; k++)
						{
							scalar = -_startingVectors[k + 1].ConjugateDotProduct(denseVector9) / array[k];
							array2[k].Multiply(scalar, denseVector6);
							denseVector9.Add(denseVector6, denseVector8);
							denseVector8.CopyTo(denseVector9);
							array3[k].Multiply(scalar, denseVector6);
							denseVector10.Add(denseVector6, denseVector8);
							denseVector8.CopyTo(denseVector10);
							array4[k].Multiply(scalar, denseVector6);
							denseVector11.Add(denseVector6, denseVector8);
							denseVector8.CopyTo(denseVector11);
						}
					}
					scalar = complex2 * array[count - 1];
					if (scalar.Real.AlmostEqualNumbersBetween(0f, 1) && scalar.Imaginary.AlmostEqualNumbersBetween(0f, 1))
					{
						throw new NumericalBreakdownException();
					}
					denseVector11.Multiply(complex2, denseVector8);
					denseVector2.Add(denseVector8, denseVector6);
					scalar = -_startingVectors[0].ConjugateDotProduct(denseVector6) / scalar;
					array3[count - 1].Multiply(scalar, denseVector6);
					denseVector10.Add(denseVector6, denseVector8);
					denseVector8.CopyTo(denseVector10);
					array4[count - 1].Multiply(scalar, denseVector6);
					denseVector11.Add(denseVector6, denseVector8);
					denseVector8.CopyTo(denseVector11);
					denseVector11.Multiply(complex2, denseVector11);
					denseVector2.Add(denseVector11, denseVector9);
					for (int l = 0; l < j - 1; l++)
					{
						scalar = -_startingVectors[l + 1].ConjugateDotProduct(denseVector9) / array[l];
						array2[l].Multiply(scalar, denseVector6);
						denseVector9.Add(denseVector6, denseVector8);
						denseVector8.CopyTo(denseVector9);
						array3[l].Multiply(scalar, denseVector6);
						denseVector10.Add(denseVector6, denseVector8);
						denseVector8.CopyTo(denseVector10);
					}
					denseVector9.Subtract(denseVector4, array2[j]);
					denseVector10.Add(denseVector11, array3[j]);
					if (j < count - 1)
					{
						array[j] = _startingVectors[j + 1].ConjugateDotProduct(array2[j]);
						if (array[j].Real.AlmostEqualNumbersBetween(0f, 1) && array[j].Imaginary.AlmostEqualNumbersBetween(0f, 1))
						{
							throw new NumericalBreakdownException();
						}
						complex = _startingVectors[j + 1].ConjugateDotProduct(denseVector4) / array[j];
						array2[j].Multiply(-complex, denseVector6);
						denseVector4.Add(denseVector6, denseVector8);
						denseVector8.CopyTo(denseVector4);
						preconditioner.Approximate(array3[j], denseVector3);
						denseVector3.Multiply(complex2 * complex, denseVector6);
						denseVector.Add(denseVector6, denseVector8);
						denseVector8.CopyTo(denseVector);
						matrix.Multiply(denseVector3, array4[j]);
						array4[j].Multiply(-complex2 * complex, denseVector6);
						denseVector2.Add(denseVector6, denseVector8);
						denseVector8.CopyTo(denseVector2);
						if (iterator.DetermineStatus(i, denseVector, input, denseVector2) != IterationStatus.Continue)
						{
							CalculateTrueResidual(matrix, denseVector2, denseVector, input);
						}
					}
				}
			}
			denseVector.CopyTo(result);
		}
	}
}
