using System;
using UnityEngine;

namespace Mandragora.AnimationTools
{
	[Serializable]
	public class Frame
	{
		public float x;

		public float y;

		public float time;

		public Sprite img;

		public string eventName = string.Empty;

		[HideInInspector]
		public Attachment[] attachments;
	}
}
