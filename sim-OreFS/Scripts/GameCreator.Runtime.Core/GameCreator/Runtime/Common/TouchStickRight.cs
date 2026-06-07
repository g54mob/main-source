using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[AddComponentMenu("")]
	public class TouchStickRight : TTouchStick
	{
		public static GameObject INSTANCE;

		public static ITouchStick Create()
		{
			INSTANCE = new GameObject("Right Stick");
			TouchStickUtils.CreateCanvas(INSTANCE);
			TouchStickUtils.CreateControlsRight(INSTANCE);
			return INSTANCE.GetComponentInChildren<ITouchStick>();
		}
	}
}
