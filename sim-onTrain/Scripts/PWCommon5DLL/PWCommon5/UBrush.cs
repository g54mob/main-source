using System;
using UnityEngine;

namespace PWCommon5
{
	[Serializable]
	public class UBrush
	{
		[SerializeField]
		private int m_size;

		[SerializeField]
		private float[] m_strength;

		[SerializeField]
		private Texture2D m_brush;

		private const int MIN_BRUSH_SIZE = 3;

		private int Size => m_size;

		public static UBrush GetBrush(Texture2D brushTexture, int size)
		{
			UBrush uBrush = new UBrush();
			if (!uBrush.Load(brushTexture, size))
			{
				Debug.LogWarningFormat("Texture for brush is <b>null</b>.");
			}
			return uBrush;
		}

		public UBrush GetInSize(int size)
		{
			UBrush uBrush = new UBrush();
			if (!uBrush.Load(m_brush, size))
			{
				Debug.LogWarningFormat("Texture for brush is <b>null</b>.");
			}
			return uBrush;
		}

		public bool Load(Texture2D brushTex, int size)
		{
			if (m_brush == brushTex && size == m_size && m_strength != null)
			{
				return true;
			}
			if (brushTex != null)
			{
				float num = size;
				m_size = size;
				m_strength = new float[m_size * m_size];
				if (m_size > 3)
				{
					for (int i = 0; i < m_size; i++)
					{
						for (int j = 0; j < m_size; j++)
						{
							m_strength[i * m_size + j] = brushTex.GetPixelBilinear(((float)j + 0.5f) / num, (float)i / num).a;
						}
					}
				}
				else
				{
					for (int k = 0; k < m_strength.Length; k++)
					{
						m_strength[k] = 1f;
					}
				}
				m_brush = brushTex;
				return true;
			}
			m_strength = new float[1];
			m_strength[0] = 1f;
			m_size = 1;
			return false;
		}

		public float GetStrengthAtCoords(int ix, int iy)
		{
			if (ix < 0 || m_size <= ix || iy < 0 || m_size <= iy)
			{
				return 0f;
			}
			return m_strength[iy * m_size + ix];
		}
	}
}
