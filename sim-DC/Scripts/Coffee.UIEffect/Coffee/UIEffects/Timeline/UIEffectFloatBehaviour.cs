using System;

namespace Coffee.UIEffects.Timeline
{
	[Serializable]
	public class UIEffectFloatBehaviour : UIEffectBehaviour, IGetValue<float>
	{
		public float m_Value;

		public float m_From;

		public float Get(float time)
		{
			return 0f;
		}
	}
}
