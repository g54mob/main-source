using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20.Video
{
	public class SubtitlesDefinition
	{
		public class SubtitleEvent : IComparable<SubtitleEvent>
		{
			public float Time;

			public LocalisedString Text;

			public Color Tint = Color.white;

			public int CompareTo(SubtitleEvent obj)
			{
				if (!(Time - obj.Time > 0f))
				{
					return 0;
				}
				return 1;
			}
		}

		public List<SubtitleEvent> SubtitleEvents;
	}
}
