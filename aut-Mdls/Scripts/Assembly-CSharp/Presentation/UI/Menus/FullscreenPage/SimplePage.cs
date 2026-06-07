namespace Presentation.UI.Menus.FullscreenPage
{
	public class SimplePage : FullPage
	{
		public override void Initialize()
		{
		}

		public override void ShowPage()
		{
			base.gameObject.SetActive(value: true);
		}

		public override void HidePage()
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
