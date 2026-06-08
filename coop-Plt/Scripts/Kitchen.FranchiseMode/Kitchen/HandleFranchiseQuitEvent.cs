using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class HandleFranchiseQuitEvent : FranchiseSystem
	{
		private EntityQuery Quits;

		protected override void Initialise()
		{
			base.Initialise();
			Quits = GetEntityQuery(typeof(CRequestQuitEvent));
			RequireForUpdate(Quits);
		}

		protected override void OnUpdate()
		{
			base.EntityManager.DestroyEntity(Quits);
			Debug.LogWarning("Quitting: user request");
			Session.SoftExit();
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
