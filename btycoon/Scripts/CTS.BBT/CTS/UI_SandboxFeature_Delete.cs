namespace CTS
{
	public class UI_SandboxFeature_Delete : UI_SandboxFeature
	{
		public void DeleteProfile()
		{
			if (!(_profile.CurrentProfile == null))
			{
				_profile.CurrentProfile.Profile.BackupAndClear();
				_profile.CurrentProfile.Load();
				_profile.Repaint();
			}
		}

		protected override void OnRepaint()
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
