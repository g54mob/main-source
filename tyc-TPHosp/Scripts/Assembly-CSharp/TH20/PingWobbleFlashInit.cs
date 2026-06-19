using UnityEngine;

namespace TH20
{
	public class PingWobbleFlashInit : PingWobbleInit
	{
		public float FlashSpeed = 2.55f;

		public Color StartColor = Color.green;

		public Color TargetColor = Color.green;

		public GameObject PrefabOverlay;

		public override PingBehaviour CreateBehaviour()
		{
			return new PingWobbleFlash(this);
		}
	}
}
