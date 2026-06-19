namespace Loxodon.Framework.Views
{
	public class LoadingWindow : Window
	{
		protected override void OnCreate(IBundle bundle)
		{
			base.WindowType = WindowType.PROGRESS;
		}
	}
}
