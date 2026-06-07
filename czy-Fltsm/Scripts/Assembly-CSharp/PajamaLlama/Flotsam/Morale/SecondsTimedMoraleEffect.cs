using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	public abstract class SecondsTimedMoraleEffect : MoraleEffect
	{
		[Serializable]
		public class SecondsTimedPersistentData : BasePersistentData
		{
			public float CurrentTimer;

			public bool Active;

			public SecondsTimedPersistentData(SecondsTimedMoraleEffect moraleEffect)
				: base(moraleEffect)
			{
				CurrentTimer = moraleEffect.CurrentTimer;
				Active = moraleEffect.Active;
			}
		}

		public float Seconds = 900f;

		public float CurrentTimer { get; private set; }

		public bool Active { get; private set; }

		public override void Update()
		{
			base.Update();
			if (IsActive())
			{
				CurrentTimer += Time.deltaTime;
				if (CurrentTimer >= Seconds)
				{
					Deactivate();
				}
			}
		}

		protected override void Activate()
		{
			CurrentTimer = 0f;
			Active = true;
			base.Activate();
		}

		protected override void Deactivate()
		{
			Active = false;
			base.Deactivate();
		}

		public override bool IsActive()
		{
			if (Active)
			{
				return CurrentTimer < Seconds;
			}
			return false;
		}

		public override void Restore(BasePersistentData persistentData)
		{
			if (persistentData.TryReturnCast<SecondsTimedPersistentData>(out var persistentData2))
			{
				CurrentTimer = persistentData2.CurrentTimer;
				Active = persistentData2.Active;
				return;
			}
			throw new NotImplementedException();
		}

		public override BasePersistentData ReturnPersistentData()
		{
			return new SecondsTimedPersistentData(this);
		}
	}
}
