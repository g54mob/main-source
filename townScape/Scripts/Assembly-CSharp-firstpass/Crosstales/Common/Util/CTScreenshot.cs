using UnityEngine;

namespace Crosstales.Common.Util
{
	[DisallowMultipleComponent]
	public class CTScreenshot : Singleton<CTScreenshot>
	{
		public string Prefix;

		public int Scale;

		public KeyCode KeyCode;

		public bool ShowFileLocation;

		private Texture2D texture;

		private bool locationShown;

		private void Update()
		{
		}

		public void Capture()
		{
		}
	}
}
