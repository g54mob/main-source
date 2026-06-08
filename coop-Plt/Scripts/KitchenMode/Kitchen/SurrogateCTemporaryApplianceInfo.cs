using Unity.Entities;

namespace Kitchen
{
	public struct SurrogateCTemporaryApplianceInfo : TypeHash.ISurrogate<CTemporaryApplianceInfo>, TypeHash.ISurrogate, IComponentData
	{
		public float RemainingLifetime;

		public IComponentData Convert()
		{
			return new CTemporaryApplianceInfo
			{
				RemainingLifetime = RemainingLifetime
			};
		}
	}
}
