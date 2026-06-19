using System;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class StaffFailedToStartJobComponent : EntityTickComponent
	{
		private float _startTime;

		protected override Type ValidEntityType()
		{
			return typeof(Staff);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_startTime = GameTime.time;
		}

		public override void Tick()
		{
			base.Tick();
			if (GameTime.time - _startTime > GameAlgorithms.Config.FailedtoStartJobTimeOut)
			{
				Destroy();
			}
		}
	}
}
