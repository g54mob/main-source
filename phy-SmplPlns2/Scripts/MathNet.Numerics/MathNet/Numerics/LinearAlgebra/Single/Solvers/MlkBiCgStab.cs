using System;
using System.Collections.Generic;
using System.Diagnostics;
using MathNet.Numerics.Distributions;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace MathNet.Numerics.LinearAlgebra.Single.Solvers
{
	public sealed class MlkBiCgStab : IIterativeSolver<float>
	{
		private const int DefaultNumberOfStartingVectors = 50;

		private IList<Vector<float>> _startingVectors;

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

		public IList<Vector<float>> StartingVectors
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

		private static IList<Vector<float>> CreateStartingVectors(int maximumNumberOfStartingVectors, int numberOfVariables)
		{
			int columns = NumberOfStartingVectorsToCreate(maximumNumberOfStartingVectors, numberOfVariables);
			Normal normal = new Normal();
			DenseMatrix denseMatrix = new DenseMatrix(numberOfVariables, columns);
			for (int i = 0; i < denseMatrix.ColumnCount; i++)
			{
				float[] array = new float[denseMatrix.RowCount];
				for (int j = 0; j < denseMatrix.RowCount; j++)
				{
					array[j] = (float)normal.Sample();
				}
				denseMatrix.SetColumn(i, array);
			}
			Matrix<float> q = denseMatrix.GramSchmidt().Q;
			List<Vector<float>> list = new List<Vector<float>>(q.ColumnCount);
			for (int k = 0; k < q.ColumnCount; k++)
			{
				list.Add(q.Column(k));
				list[k].Multiply(1f / (float)list[k].L2Norm(), list[k]);
			}
			return list;
		}

		private static Vector<float>[] CreateVectorArray(int arraySize, int vectorSize)
		{
			Vector<float>[] array = new Vector<float>[arraySize];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new DenseVector(vectorSize);
			}
			return array;
		}

		private static void CalculateTrueResidual(Matrix<float> matrix, Vector<float> residual, Vector<float> x, Vector<float> b)
		{
			matrix.Multiply(x, residual);
			residual.Multiply(-1f, residual);
			residual.Add(b, residual);
		}

		public void Solve(Matrix<float> matrix, Vector<float> input, Vector<float> result, Iterator<float> iterator, IPreconditioner<float> preconditioner)
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
				throw Matrix<float>.DimensionsDontMatch<ArgumentException>(input, matrix);
			}
			if (iterator == null)
			{
				iterator = new Iterator<float>();
			}
			if (preconditioner == null)
			{
				preconditioner = new UnitPreconditioner<float>();
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
			float[] array = new float[count];
			DenseVector denseVector3 = new DenseVector(denseVector2.Count);
			DenseVector denseVector4 = new DenseVector(denseVector2.Count);
			DenseVector denseVector5 = new DenseVector(denseVector2.Count);
			DenseVector denseVector6 = new DenseVector(denseVector2.Count);
			DenseVector denseVector7 = new DenseVector(denseVector2.Count);
			DenseVector denseVector8 = new DenseVector(denseVector2.Count);
			DenseVector denseVector9 = new DenseVector(denseVector2.Count);
			DenseVector denseVector10 = new DenseVector(denseVector2.Count);
			DenseVector denseVector11 = new DenseVector(denseVector2.Count);
			Vector<float>[] array2 = CreateVectorArray(_startingVectors.Count, denseVector2.Count);
			Vector<float>[] array3 = CreateVectorArray(_startingVectors.Count, denseVector2.Count);
			denseVector2.CopyTo(array3[count - 1]);
			Vector<float>[] array4 = CreateVectorArray(_startingVectors.Count, denseVector2.Count);
			for (int i = 0; iterator.DetermineStatus(i, denseVector, input, denseVector2) == IterationStatus.Continue; i++)
			{
				preconditioner.Approximate(array3[count - 1], denseVector3);
				matrix.Multiply(denseVector3, array4[count - 1]);
				array[count - 1] = _startingVectors[0].DotProduct(array4[count - 1]);
				if (array[count - 1].AlmostEqualNumbersBetween(0f, 1))
				{
					throw new NumericalBreakdownException();
				}
				float num = _startingVectors[0].DotProduct(denseVector2) / array[count - 1];
				array4[count - 1].Multiply(0f - num, denseVector6);
				denseVector2.Add(denseVector6, denseVector4);
				preconditioner.Approximate(denseVector4, denseVector7);
				denseVector7.CopyTo(denseVector5);
				matrix.Multiply(denseVector7, denseVector6);
				float num2 = denseVector6.DotProduct(denseVector6);
				if (num2.AlmostEqualNumbersBetween(0f, 1))
				{
					num2 = 1f;
				}
				num2 = (0f - denseVector4.DotProduct(denseVector6)) / num2;
				denseVector4.CopyTo(denseVector2);
				denseVector6.Multiply(num2, denseVector6);
				denseVector2.Add(denseVector6, denseVector8);
				denseVector8.CopyTo(denseVector2);
				denseVector5.Multiply(0f - num2, denseVector6);
				denseVector.Add(denseVector6, denseVector8);
				denseVector8.CopyTo(denseVector);
				denseVector3.Multiply(num, denseVector3);
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
					float scalar;
					if (i >= 1)
					{
						for (int k = j; k < count - 1; k++)
						{
							scalar = (0f - _startingVectors[k + 1].DotProduct(denseVector9)) / array[k];
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
					scalar = num2 * array[count - 1];
					if (scalar.AlmostEqualNumbersBetween(0f, 1))
					{
						throw new NumericalBreakdownException();
					}
					denseVector11.Multiply(num2, denseVector8);
					denseVector2.Add(denseVector8, denseVector6);
					scalar = (0f - _startingVectors[0].DotProduct(denseVector6)) / scalar;
					array3[count - 1].Multiply(scalar, denseVector6);
					denseVector10.Add(denseVector6, denseVector8);
					denseVector8.CopyTo(denseVector10);
					array4[count - 1].Multiply(scalar, denseVector6);
					denseVector11.Add(denseVector6, denseVector8);
					denseVector8.CopyTo(denseVector11);
					denseVector11.Multiply(num2, denseVector11);
					denseVector2.Add(denseVector11, denseVector9);
					for (int l = 0; l < j - 1; l++)
					{
						scalar = (0f - _startingVectors[l + 1].DotProduct(denseVector9)) / array[l];
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
						array[j] = _startingVectors[j + 1].DotProduct(array2[j]);
						if (array[j].AlmostEqualNumbersBetween(0f, 1))
						{
							throw new NumericalBreakdownException();
						}
						num = _startingVectors[j + 1].DotProduct(denseVector4) / array[j];
						array2[j].Multiply(0f - num, denseVector6);
						denseVector4.Add(denseVector6, denseVector8);
						denseVector8.CopyTo(denseVector4);
						preconditioner.Approximate(array3[j], denseVector3);
						denseVector3.Multiply(num2 * num, denseVector6);
						denseVector.Add(denseVector6, denseVector8);
						denseVector8.CopyTo(denseVector);
						matrix.Multiply(denseVector3, array4[j]);
						array4[j].Multiply((0f - num2) * num, denseVector6);
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
