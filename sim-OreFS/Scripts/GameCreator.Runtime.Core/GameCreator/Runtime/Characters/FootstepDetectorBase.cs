using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.Characters
{
	[Serializable]
	[Title("Footstep Detector")]
	[Image(typeof(IconFootprint), ColorTheme.Type.TextLight)]
	public abstract class FootstepDetectorBase : TPolymorphicItem<FootstepDetectorBase>
	{
		public abstract void OnEnable(Character character);

		public abstract void OnDisable(Character character);

		public abstract void OnUpdate(Character character);

		public abstract void OnGizmos(Character character);
	}
}
