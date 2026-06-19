using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class StaffNotificationUI : NotificationMessageUI
	{
		[SerializeField]
		private RawImage _mugshotImage;

		private CharacterMugShot _characterMugShot;

		protected void SetStaff(Staff staff)
		{
			_characterMugShot = CharacterMugShot.FromCharacterVisual(staff.Visual, 256, 256, staff.Level.HUD.GetConfig().MugshotConfig);
			_mugshotImage.texture = _characterMugShot.Texture;
		}

		public override void Destroy()
		{
			_characterMugShot.Destroy();
		}
	}
}
