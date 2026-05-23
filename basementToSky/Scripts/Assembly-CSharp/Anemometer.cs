public class Anemometer : Furniture
{
	private void OnEnable()
	{
		GameManager.S.isAnemometerInstalled = true;
	}
}
