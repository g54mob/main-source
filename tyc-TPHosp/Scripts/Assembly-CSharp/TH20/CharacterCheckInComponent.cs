using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class CharacterCheckInComponent : EntityComponent
	{
		private Character _character;

		private RoomItemReceptionComponent _reception;

		public RoomItemReceptionComponent Reception => _reception;

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_character = GetOwner<Character>();
		}

		public override void Destroy()
		{
			CancelCheckIn();
			base.Destroy();
		}

		public void StartCheckIn(RoomItemReceptionComponent reception)
		{
			if (reception != _reception)
			{
				CancelCheckIn();
				_reception = reception;
				_reception.AddToQueue(_character);
			}
		}

		public void CancelCheckIn()
		{
			if (_reception != null)
			{
				_reception.RemoveFromQueue(_character);
				_reception = null;
			}
		}

		public int GetQueuePosition()
		{
			if (_reception == null)
			{
				return -1;
			}
			return _reception.GetQueuePosition(_character);
		}
	}
}
