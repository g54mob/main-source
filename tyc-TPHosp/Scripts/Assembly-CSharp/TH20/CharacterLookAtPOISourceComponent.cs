using UnityEngine;

namespace TH20
{
	public class CharacterLookAtPOISourceComponent : LookAtPOISourceComponent
	{
		private Character _character;

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_character = GetOwner<Character>();
		}

		public override Vector3 LookAtPosition()
		{
			if (!(_character.Visual.HeadSocket != null))
			{
				return _character.Position;
			}
			return _character.Visual.HeadSocket.position;
		}

		public override Room GetRoomIn()
		{
			return _character.RoomUsing;
		}
	}
}
