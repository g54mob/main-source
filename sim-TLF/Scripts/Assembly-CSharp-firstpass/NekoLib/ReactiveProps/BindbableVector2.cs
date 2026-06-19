using System;
using UnityEngine;

namespace NekoLib.ReactiveProps
{
	[Serializable]
	public class BindbableVector2 : BindableProp<Vector2>
	{
		public BindbableVector2()
			: this(Vector2.zero)
		{
		}

		public BindbableVector2(Vector2 value)
			: base(value)
		{
		}
	}
}
