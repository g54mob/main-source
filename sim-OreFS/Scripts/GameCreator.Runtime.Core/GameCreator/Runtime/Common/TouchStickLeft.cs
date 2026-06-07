using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[AddComponentMenu("")]
	public class TouchStickLeft : TTouchStick
	{
		public static GameObject INSTANCE;

		public static ITouchStick Create()
		{
			INSTANCE = new GameObject("Left Stick");
			TouchStickUtils.CreateCanvas(INSTANCE);
			TouchStickUtils.CreateControlsLeft(INSTANCE);
			return INSTANCE.GetComponentInChildren<ITouchStick>();
		}
	}
}
