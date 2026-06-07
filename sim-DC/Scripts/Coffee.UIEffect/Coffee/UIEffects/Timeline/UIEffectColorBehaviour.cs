using System;
using UnityEngine;

namespace Coffee.UIEffects.Timeline
{
	[Serializable]
	public class UIEffectColorBehaviour : UIEffectBehaviour, IGetValue<Color>
	{
		[ColorUsage(true, true)]
		public Color m_Value;

		[ColorUsage(true, true)]
		public Color m_From;

		public Color Get(float time)
		{
			return default(Color);
		}
	}
}
