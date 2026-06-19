using System;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class SpecialVIPCharacterComponent : EntityTickComponent
	{
		protected override Type ValidEntityType()
		{
			return typeof(Character);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			GetOwner<Character>().PostFixName = "(VIP)";
		}

		public override void Destroy()
		{
			GetOwner<Character>().PostFixName = "";
			base.Destroy();
		}

		public override void Tick()
		{
			base.Tick();
			base.Level.StatusIconManager.ShowStatusIcon(GetOwner<Character>(), StatusIcon.Type.SpecialVIP);
		}
	}
}
