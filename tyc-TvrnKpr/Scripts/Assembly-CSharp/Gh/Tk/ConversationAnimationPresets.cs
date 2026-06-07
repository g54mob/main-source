using System;
using System.Collections.Generic;
using Gh.Tk.Story.Conversations;

namespace Gh.Tk
{
	public class ConversationAnimationPresets : SingletonMonoBehaviour<ConversationAnimationPresets>
	{
		[Serializable]
		public class ConversationAnimationPreset
		{
			public string name;

			public List<ConversationAnimation> animations;
		}

		[Serializable]
		public class ConversationAnimation
		{
			public string animation;

			public EmotionalState state;
		}

		public ConversationAnimationPreset[] presets;
	}
}
