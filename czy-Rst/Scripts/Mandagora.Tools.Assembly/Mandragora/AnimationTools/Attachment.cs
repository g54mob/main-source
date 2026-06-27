using System;
using UnityEngine;

namespace Mandragora.AnimationTools
{
	[Serializable]
	public class Attachment
	{
		public string name;

		public float x;

		public float y;

		public Vector2 position => new Vector2(x, y);

		public Attachment()
		{
		}

		public Attachment(Attachment clone)
		{
			name = clone.name;
			x = clone.x;
			y = clone.y;
		}
	}
}
