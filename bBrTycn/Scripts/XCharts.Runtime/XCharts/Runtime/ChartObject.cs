using UnityEngine;

namespace XCharts.Runtime
{
	public class ChartObject
	{
		protected GameObject m_GameObject;

		public virtual void Destroy()
		{
			Object.Destroy(m_GameObject);
		}
	}
}
