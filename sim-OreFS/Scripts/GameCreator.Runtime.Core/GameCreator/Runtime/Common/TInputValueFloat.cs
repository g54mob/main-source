using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Input Value")]
	public abstract class TInputValueFloat : TInputValue<float>
	{
		public abstract override float Read();
	}
}
