using NaughtyAttributes;
using UnityEngine;

namespace Data.FactoryFloor.Resources
{
	public abstract class ResourceDataSO : ScriptableObject
	{
		[field: SerializeField]
		[field: ReadOnly]
		public int ID { get; set; }

		[field: SerializeField]
		public string AnalyticsName { get; set; }

		protected virtual void Reset()
		{
			AnalyticsName = base.name;
		}
	}
}
