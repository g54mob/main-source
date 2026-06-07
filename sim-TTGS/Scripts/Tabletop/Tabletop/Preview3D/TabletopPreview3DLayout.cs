using System.Collections.Generic;
using Simulator.Preview3D;
using UnityEngine;

namespace Tabletop.Preview3D
{
	public class TabletopPreview3DLayout : Preview3DLayout
	{
		public override int Count => 13;

		protected override Vector2 GetTotalSize()
		{
			int num = 4;
			return new Vector2(m_size.x * (float)m_columnCount + m_spacing.x * (float)(m_columnCount - 1), m_size.y * (float)num + m_spacing.y * (float)(num - 1));
		}

		public override IEnumerable<Bounds> GetBounds()
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
		}

		public override Vector2Int GetCoords(int index)
		{
			return index switch
			{
				0 => new Vector2Int(0, 0), 
				1 => new Vector2Int(1, 0), 
				2 => new Vector2Int(2, 0), 
				3 => new Vector2Int(3, 0), 
				4 => new Vector2Int(0, 1), 
				5 => new Vector2Int(1, 1), 
				6 => new Vector2Int(2, 1), 
				7 => new Vector2Int(3, 1), 
				8 => new Vector2Int(0, 2), 
				9 => new Vector2Int(1, 2), 
				10 => new Vector2Int(0, 3), 
				11 => new Vector2Int(1, 3), 
				12 => new Vector2Int(2, 2), 
				_ => Vector2Int.down, 
			};
		}
	}
}
