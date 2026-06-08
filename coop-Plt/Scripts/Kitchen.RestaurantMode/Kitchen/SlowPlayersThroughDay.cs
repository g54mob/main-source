using System.Runtime.InteropServices;
using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public class SlowPlayersThroughDay : DaySystem
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct SGlobalEffect : IComponentData
		{
		}

		private const float StartFactor = 1f;

		private const float FinalFactor = 0.5f;

		protected override void OnUpdate()
		{
			if (HasStatus(RestaurantStatus.HalloweenTrickSlowPlayers))
			{
				Entity entity = GetEntity<SGlobalEffect>();
				if (!Has<CSlowPlayer>(entity))
				{
					base.EntityManager.AddComponent<CSlowPlayer>(entity);
				}
				if (!Has<CDestroyApplianceAtNight>(entity))
				{
					base.EntityManager.AddComponent<CDestroyApplianceAtNight>(entity);
				}
				if (!Has<CPosition>(entity))
				{
					base.EntityManager.AddComponent<CPosition>(entity);
				}
				Require<STime>(out var comp);
				CSlowPlayer t = new CSlowPlayer
				{
					Radius = 9999f,
					Factor = 1f + -0.5f * comp.TimeOfDay
				};
				Set(entity, t);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
