using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class AchievementFireRecovery : AchievementRequiresEndDay<AchievementFireRecovery.SState>
	{
		public struct SState : IComponentData
		{
			public float FireTime;

			public bool IsSatisfied;
		}

		public const float RequiredTime = 15f;

		private EntityQuery Fires;

		protected override string Identifier => "FIRE_RECOVERY";

		protected override void Initialise()
		{
			base.Initialise();
			Fires = GetEntityQuery(typeof(CFire));
		}

		protected override bool IsSatisfied(SState data)
		{
			return data.IsSatisfied;
		}

		protected override void Reset(ref SState data)
		{
			data.FireTime = 0f;
			data.IsSatisfied = false;
		}

		protected override void Check(ref SState data)
		{
			if (Fires.IsEmpty)
			{
				data.FireTime = 0f;
			}
			else
			{
				data.FireTime += base.Time.DeltaTime;
			}
			if (data.FireTime > 15f)
			{
				if (!data.IsSatisfied)
				{
					Debug.LogWarning(Identifier + " ready to unlock!");
				}
				data.IsSatisfied = true;
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
