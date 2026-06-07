using System;
using System.Collections.Generic;
using MalbersAnimations.Utilities;

namespace MalbersAnimations.Controller
{
	[Serializable]
	public class TagModifier
	{
		public string AnimationTag;

		public AnimalModifier modifier;

		public List<MesssageItem> tagMessages;

		public int TagHash { get; set; }

		public bool Entered { get; internal set; }
	}
}
