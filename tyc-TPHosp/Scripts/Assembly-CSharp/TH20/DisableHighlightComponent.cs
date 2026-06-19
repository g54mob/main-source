using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class DisableHighlightComponent : EntityComponent
	{
		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			GetOwner<Character>().Highlightable = false;
		}

		public override void Destroy()
		{
			GetOwner<Character>().Highlightable = true;
			base.Destroy();
		}
	}
}
