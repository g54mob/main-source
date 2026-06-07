using UI.Elements;
using UnityEngine;

namespace UI.Apps
{
	public class TestApp : MultiToolApp
	{
		[SerializeField]
		private UIColoredButton betterB;

		[SerializeField]
		private UIColorMapperController myC;

		public override void Init()
		{
		}

		public void Prova()
		{
		}

		public override void AppStart()
		{
		}

		public override void AppStop()
		{
		}

		public override bool NeedGadget()
		{
			return false;
		}
	}
}
