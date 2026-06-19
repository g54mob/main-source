using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class LockCharacterInRoomComponent : EntityComponent
	{
		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			GetOwner<Character>().LockedInRoom = true;
		}

		public override void Destroy()
		{
			GetOwner<Character>().LockedInRoom = false;
			base.Destroy();
		}
	}
}
