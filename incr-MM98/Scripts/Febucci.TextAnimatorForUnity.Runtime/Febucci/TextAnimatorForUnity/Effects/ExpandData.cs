using System;
using Febucci.TextAnimatorCore.BuiltIn;

namespace Febucci.TextAnimatorForUnity.Effects
{
	[Serializable]
	internal class ExpandData
	{
		public ExpandType mode = ExpandType.HorizontallyFromCenter;

		public float amplitude = 1f;
	}
}
