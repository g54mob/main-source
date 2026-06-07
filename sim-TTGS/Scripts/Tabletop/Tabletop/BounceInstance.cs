using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Tabletop
{
	public class BounceInstance
	{
		private readonly Vector3 m_baseScale;

		public readonly List<BounceData> Bounces;

		public BounceInstance(BounceData data, Transform tr)
		{
			m_baseScale = tr.localScale;
			Bounces = new List<BounceData> { data };
		}

		public bool Update(float delta, Transform tr)
		{
			Vector3 baseScale = m_baseScale;
			for (int num = Bounces.Count - 1; num >= 0; num--)
			{
				BounceData value = Bounces[num];
				value.AddTime(delta);
				baseScale += Vector3.one * value.GetScale();
				if (value.Finished)
				{
					Bounces.RemoveAt(num);
				}
				else
				{
					Bounces[num] = value;
				}
			}
			if (Bounces.Any())
			{
				tr.localScale = baseScale;
				return false;
			}
			tr.localScale = m_baseScale;
			return true;
		}
	}
}
