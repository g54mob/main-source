using System;
using UnityEngine;

namespace NekoLib.ReactiveProps
{
	[Serializable]
	public class BindbableVector3 : BindableProp<Vector3>
	{
		public BindbableVector3()
			: this(Vector3.zero)
		{
		}

		public BindbableVector3(Vector3 value)
			: base(value)
		{
		}
	}
}
