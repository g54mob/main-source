using System;
using UnityEngine;

namespace Pug.UnityExtensions
{
	[Serializable]
	public class BooleanMatrix
	{
		[SerializeField]
		private int m_Length;

		[SerializeField]
		private bool[] m_Data;

		public bool this[int x, int y]
		{
			get
			{
				if (x < 0 || m_Length <= x)
				{
					throw new ArgumentOutOfRangeException("x");
				}
				if (y < 0 || m_Length <= y)
				{
					throw new ArgumentOutOfRangeException("y");
				}
				int arrayIndex = GetArrayIndex(x, y, m_Length);
				return m_Data[arrayIndex];
			}
			set
			{
				if (x < 0 || m_Length <= x)
				{
					throw new ArgumentOutOfRangeException("x");
				}
				if (y < 0 || m_Length <= y)
				{
					throw new ArgumentOutOfRangeException("y");
				}
				int arrayIndex = GetArrayIndex(x, y, m_Length);
				m_Data[arrayIndex] = value;
			}
		}

		public int Length
		{
			get
			{
				return m_Length;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("Length");
				}
				if (m_Data != null)
				{
					Resize(value, valueDefault: false);
				}
				else if (0 < value)
				{
					int arrayLength = GetArrayLength(value);
					m_Data = new bool[arrayLength];
					m_Length = value;
				}
			}
		}

		public void Resize(int newLength, bool valueDefault, bool valueKeep = true)
		{
			if (newLength < 0)
			{
				throw new ArgumentOutOfRangeException("newLength");
			}
			int arrayLength = GetArrayLength(newLength);
			if (m_Data.Length != arrayLength)
			{
				if (!valueKeep)
				{
					Array.Resize(ref m_Data, arrayLength);
				}
				else
				{
					int num = Mathf.Min(m_Length, newLength);
					if (m_Length < newLength)
					{
						Array.Resize(ref m_Data, arrayLength);
						int num2 = newLength - 1;
						while (0 <= num2)
						{
							int num3 = newLength - 1;
							while (0 <= num3)
							{
								int arrayIndex = GetArrayIndex(num3, num2, newLength);
								if (num <= num2 || num <= num3)
								{
									m_Data[arrayIndex] = valueDefault;
								}
								else
								{
									int arrayIndex2 = GetArrayIndex(num3, num2, m_Length);
									m_Data[arrayIndex] = m_Data[arrayIndex2];
								}
								num3--;
							}
							num2--;
						}
					}
					else
					{
						for (int i = 0; i < num; i++)
						{
							for (int j = 0; j < num; j++)
							{
								int arrayIndex3 = GetArrayIndex(j, i, m_Length);
								int arrayIndex4 = GetArrayIndex(j, i, newLength);
								m_Data[arrayIndex4] = m_Data[arrayIndex3];
							}
						}
						Array.Resize(ref m_Data, arrayLength);
					}
				}
				m_Length = newLength;
			}
			if (!valueKeep)
			{
				Array.Fill(m_Data, valueDefault);
			}
		}

		public BooleanMatrix()
		{
		}

		public BooleanMatrix(int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			Length = length;
		}

		private static int GetArrayIndex(int x, int y, int length)
		{
			return x + y * length;
		}

		private static int GetArrayLength(int length)
		{
			return length * length;
		}
	}
}
