namespace DV.UI
{
	public class ManualProvider : AManualProvider
	{
		public override void OpenURL(string url)
		{
			Util.OpenURL(url);
		}
	}
}
