using System.Collections.Generic;
using UnityEngine;

namespace Simulator.Preview3D
{
	public class Preview3DLayout : MonoBehaviour
	{
		[Header("Parameters")]
		[SerializeField]
		protected int m_columnCount;

		[SerializeField]
		protected Vector3 m_size;

		[SerializeField]
		protected Vector2 m_spacing;

		[Header("Bounds")]
		[SerializeField]
		protected bool m_editBounds;

		[Space(10f)]
		[SerializeField]
		[ReadOnly("m_editBounds", true)]
		protected Bounds m_bounds0;

		[SerializeField]
		[ReadOnly("m_editBounds", true)]
		protected Bounds m_bounds1;

		[SerializeField]
		[ReadOnly("m_editBounds", true)]
		protected Bounds m_bounds2;

		[SerializeField]
		[ReadOnly("m_editBounds", true)]
		protected Bounds m_bounds3;

		[SerializeField]
		[ReadOnly("m_editBounds", true)]
		protected Bounds m_bounds4;

		[SerializeField]
		[ReadOnly("m_editBounds", true)]
		protected Bounds m_bounds5;

		[SerializeField]
		[ReadOnly("m_editBounds", true)]
		protected Bounds m_bounds6;

		[SerializeField]
		[ReadOnly("m_editBounds", true)]
		protected Bounds m_bounds7;

		[SerializeField]
		[ReadOnly("m_editBounds", true)]
		protected Bounds m_bounds8;

		[SerializeField]
		[ReadOnly("m_editBounds", true)]
		protected Bounds m_bounds9;

		[SerializeField]
		[ReadOnly("m_editBounds", true)]
		protected Bounds m_bounds10;

		[SerializeField]
		[ReadOnly("m_editBounds", true)]
		protected Bounds m_bounds11;

		[SerializeField]
		[ReadOnly("m_editBounds", true)]
		protected Bounds m_bounds12;

		[SerializeField]
		[ReadOnly("m_editBounds", true)]
		protected Bounds m_bounds13;

		[SerializeField]
		[ReadOnly("m_editBounds", true)]
		protected Bounds m_bounds14;

		[SerializeField]
		[ReadOnly("m_editBounds", true)]
		protected Bounds m_bounds15;

		public virtual int Count => 16;

		public Vector2 Size => m_size;

		public Vector2 Spacing => m_spacing;

		public virtual IEnumerable<Bounds> GetBounds()
		{
			yield return m_bounds0;
			yield return m_bounds1;
			yield return m_bounds2;
			yield return m_bounds3;
			yield return m_bounds4;
			yield return m_bounds5;
			yield return m_bounds6;
			yield return m_bounds7;
			yield return m_bounds8;
			yield return m_bounds9;
			yield return m_bounds10;
			yield return m_bounds11;
			yield return m_bounds12;
			yield return m_bounds13;
			yield return m_bounds14;
			yield return m_bounds15;
		}

		public virtual Bounds GetBounds(int index)
		{
			return index switch
			{
				0 => m_bounds0, 
				1 => m_bounds1, 
				2 => m_bounds2, 
				3 => m_bounds3, 
				4 => m_bounds4, 
				5 => m_bounds5, 
				6 => m_bounds6, 
				7 => m_bounds7, 
				8 => m_bounds8, 
				9 => m_bounds9, 
				10 => m_bounds10, 
				11 => m_bounds11, 
				12 => m_bounds12, 
				13 => m_bounds13, 
				14 => m_bounds14, 
				15 => m_bounds15, 
				_ => m_bounds0, 
			};
		}

		protected virtual void SetBounds(int index, Bounds bounds)
		{
			switch (index)
			{
			case 0:
				m_bounds0 = bounds;
				break;
			case 1:
				m_bounds1 = bounds;
				break;
			case 2:
				m_bounds2 = bounds;
				break;
			case 3:
				m_bounds3 = bounds;
				break;
			case 4:
				m_bounds4 = bounds;
				break;
			case 5:
				m_bounds5 = bounds;
				break;
			case 6:
				m_bounds6 = bounds;
				break;
			case 7:
				m_bounds7 = bounds;
				break;
			case 8:
				m_bounds8 = bounds;
				break;
			case 9:
				m_bounds9 = bounds;
				break;
			case 10:
				m_bounds10 = bounds;
				break;
			case 11:
				m_bounds11 = bounds;
				break;
			case 12:
				m_bounds12 = bounds;
				break;
			case 13:
				m_bounds13 = bounds;
				break;
			case 14:
				m_bounds14 = bounds;
				break;
			case 15:
				m_bounds15 = bounds;
				break;
			}
		}

		public virtual Vector2Int GetCoords(int index)
		{
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < index; i++)
			{
				num++;
				if (num == m_columnCount)
				{
					num = 0;
					num2++;
				}
			}
			return new Vector2Int(num, num2);
		}

		public Rect GetRect(int index)
		{
			Bounds bounds = GetBounds(index);
			Vector2 totalSize = GetTotalSize();
			return new Rect(bounds.min / totalSize, bounds.size / totalSize);
		}

		protected virtual Vector2 GetTotalSize()
		{
			int num = Count / m_columnCount;
			return new Vector2(m_size.x * (float)m_columnCount + m_spacing.x * (float)(m_columnCount - 1), m_size.y * (float)num + m_spacing.y * (float)(num - 1));
		}
	}
}
