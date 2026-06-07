using System;

namespace Lightbug.CharacterControllerPro.Implementation
{
	[Serializable]
	public struct FloatAction
	{
		public float value;

		public void Reset()
		{
			value = 0f;
		}
	}
}
