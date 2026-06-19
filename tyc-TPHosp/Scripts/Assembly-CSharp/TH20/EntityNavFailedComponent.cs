using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class EntityNavFailedComponent : EntityTickComponent
	{
		private float _startTime;

		private int _failedCount;

		public bool Failed => _failedCount >= GameAlgorithms.Config.NavFailWarningTriggerCount;

		public void Init()
		{
			_failedCount++;
			_startTime = GameTime.time;
		}

		public override void Tick()
		{
			base.Tick();
			bool flag = GetOwner() is Character character && character.MovementSpeed > 0.1f;
			if (GameTime.time - _startTime > (float)GameAlgorithms.Config.NavFailTimeOut || flag)
			{
				if (GetOwner() is IStatusIconEmitter emitter)
				{
					base.Level.StatusIconManager.HideStatusIcon(emitter, StatusIcon.Type.NavBlocked);
				}
				Destroy();
			}
			else if (Failed && GetOwner() is IStatusIconEmitter emitter2)
			{
				base.Level.StatusIconManager.ShowStatusIcon(emitter2, StatusIcon.Type.NavBlocked);
			}
		}
	}
}
