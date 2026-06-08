using UnityEngine;

namespace LaundryBear.PlatformServices
{
	public class ChangeSpriteForPlatform : ChangeForPlatform<Sprite>
	{
		private void Start()
		{
			UpdateSpriteForPlatform();
		}

		public void UpdateSpriteForPlatform()
		{
			if (TryGetComponent<SpriteRenderer>(out var component) && GetPlatformSpecificObject(Utilities.GetCurrentPlatform(), out var obj))
			{
				component.sprite = obj;
			}
		}
	}
}
