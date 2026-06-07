using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public abstract class TSerializableMatrix2D<T> : ISerializationCallbackReceiver
	{
		[NonSerialized]
		protected T[,] m_Matrix;

		[SerializeField]
		private int m_MatrixWidth;

		[SerializeField]
		private T[] m_MatrixUnwrapped;

		public int MatrixWidth => m_Matrix.GetLength(0);

		public int MatrixHeight => m_Matrix.GetLength(1);

		public T this[int index1, int index2]
		{
			get
			{
				return m_Matrix[index1, index2];
			}
			set
			{
				m_Matrix[index1, index2] = value;
			}
		}

		public T this[Vector2Int position]
		{
			get
			{
				return m_Matrix[position.x, position.y];
			}
			set
			{
				m_Matrix[position.x, position.y] = value;
			}
		}

		protected TSerializableMatrix2D()
			: this(0, 0)
		{
		}

		protected TSerializableMatrix2D(int width, int height)
		{
			m_Matrix = new T[width, height];
			m_MatrixWidth = width;
			m_MatrixUnwrapped = new T[width * height];
		}

		public bool TryGet(int index1, int index2, out T value)
		{
			value = default(T);
			if (index1 < 0 || index1 >= m_Matrix.GetLength(0))
			{
				return false;
			}
			if (index2 < 0 || index2 >= m_Matrix.GetLength(1))
			{
				return false;
			}
			value = m_Matrix[index1, index2];
			return true;
		}

		public bool TryGet(Vector2Int position, out T value)
		{
			return TryGet(position.x, position.y, out value);
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			if (AssemblyUtils.IsReloading)
			{
				return;
			}
			int matrixWidth = m_MatrixWidth;
			int num = ((matrixWidth > 0) ? (m_MatrixUnwrapped.Length / m_MatrixWidth) : 0);
			m_Matrix = new T[matrixWidth, num];
			for (int i = 0; i < matrixWidth; i++)
			{
				for (int j = 0; j < num; j++)
				{
					T val = m_MatrixUnwrapped[i + j * matrixWidth];
					m_Matrix[i, j] = val;
				}
			}
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			if (AssemblyUtils.IsReloading)
			{
				return;
			}
			int matrixWidth = MatrixWidth;
			int matrixHeight = MatrixHeight;
			m_MatrixWidth = matrixWidth;
			m_MatrixUnwrapped = new T[m_Matrix.Length];
			for (int i = 0; i < matrixWidth; i++)
			{
				for (int j = 0; j < matrixHeight; j++)
				{
					T val = m_Matrix[i, j];
					m_MatrixUnwrapped[i + j * matrixWidth] = val;
				}
			}
		}
	}
}
