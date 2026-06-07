using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[Title("Input Vector2")]
	public abstract class TInputValueVector2 : TInputValue<Vector2>
	{
		public abstract override Vector2 Read();
	}
}
