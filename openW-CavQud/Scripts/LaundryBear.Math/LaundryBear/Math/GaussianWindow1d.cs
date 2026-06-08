using System;
using UnityEngine;

namespace LaundryBear.Math
{
	public abstract class GaussianWindow1d<T>
	{
		protected T[] m_data;

		protected float[] m_kernel;

		protected float m_kernelSum;

		protected int m_currentPos;

		public float Sigma { get; private set; }

		public int KernelSize => m_kernel.Length;

		public int BufferLength => m_data.Length;

		private void GenerateKernel(float sigma, int maxKernelRadius)
		{
			int num = Mathf.Min(maxKernelRadius, Mathf.FloorToInt(Mathf.Abs(sigma) * 2.5f));
			m_kernel = new float[2 * num + 1];
			m_kernelSum = 0f;
			if (num == 0)
			{
				m_kernelSum = (m_kernel[0] = 1f);
			}
			else
			{
				for (int i = -num; i <= num; i++)
				{
					m_kernel[i + num] = Mathf.Exp((float)(-(i * i)) / (2f * sigma * sigma)) / Mathf.Sqrt(MathF.PI * 2f * sigma);
					m_kernelSum += m_kernel[i + num];
				}
			}
			Sigma = sigma;
		}

		protected abstract T Compute(int windowPos);

		public GaussianWindow1d(float sigma, int maxKernelRadius = 10)
		{
			GenerateKernel(sigma, maxKernelRadius);
			m_currentPos = 0;
		}

		public void Reset()
		{
			m_data = null;
		}

		public bool IsEmpty()
		{
			return m_data == null;
		}

		public void AddValue(T v)
		{
			if (m_data == null)
			{
				m_data = new T[KernelSize];
				for (int i = 0; i < KernelSize; i++)
				{
					m_data[i] = v;
				}
				m_currentPos = Mathf.Min(1, KernelSize - 1);
			}
			m_data[m_currentPos] = v;
			if (++m_currentPos == KernelSize)
			{
				m_currentPos = 0;
			}
		}

		public T Filter(T v)
		{
			if (KernelSize < 3)
			{
				return v;
			}
			AddValue(v);
			return Value();
		}

		public T Value()
		{
			return Compute(m_currentPos);
		}

		public void SetBufferValue(int index, T value)
		{
			m_data[index] = value;
		}

		public T GetBufferValue(int index)
		{
			return m_data[index];
		}
	}
}
