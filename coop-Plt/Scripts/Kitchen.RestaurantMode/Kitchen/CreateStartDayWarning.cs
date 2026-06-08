using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class CreateStartDayWarning : NightSystem
	{
		protected override void OnUpdate()
		{
			if (!HasSingleton<SStartDayWarnings>())
			{
				Entity entity = base.EntityManager.CreateEntity(typeof(CRequiresView), typeof(CPosition), typeof(SStartDayWarnings), typeof(CCaptureInput), typeof(CCapturePassthrough), typeof(CPlayersReadyToStart));
				base.EntityManager.AddComponentData(entity, new CCaptureInput
				{
					AllUsers = true
				});
				base.EntityManager.AddComponentData(entity, new CRequiresView
				{
					Type = ViewType.StartDayMessage,
					ViewMode = ViewMode.Screen
				});
				base.EntityManager.AddComponentData(entity, new CPosition(new Vector3(0.5f, 0.95f, 0f)));
			}
		}

		public override void BeforeSaving(SaveSystemType system_type)
		{
			if (RequireEntity<SStartDayWarnings>(out var comp))
			{
				base.EntityManager.DestroyEntity(comp);
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
