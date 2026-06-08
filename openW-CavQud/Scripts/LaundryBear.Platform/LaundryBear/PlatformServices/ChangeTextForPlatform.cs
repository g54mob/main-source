using UnityEngine.UI;

namespace LaundryBear.PlatformServices
{
	public class ChangeTextForPlatform : ChangeForPlatform<string>
	{
		private void Start()
		{
			UpdateTextForPlatform();
		}

		public void UpdateTextForPlatform()
		{
			if (TryGetComponent<Text>(out var component) && GetPlatformSpecificObject(Utilities.GetCurrentPlatform(), out var obj))
			{
				component.text = obj;
			}
		}
	}
}
