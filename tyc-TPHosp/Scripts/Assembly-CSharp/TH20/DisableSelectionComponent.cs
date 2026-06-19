using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class DisableSelectionComponent : EntityComponent
	{
		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			GetOwner<Character>().Selectable = false;
		}

		public override void Destroy()
		{
			GetOwner<Character>().Selectable = true;
			base.Destroy();
		}
	}
}
