using UnityEngine;

namespace Gh.Tk.Story
{
	public abstract class BaseActorConfig : BaseTargetFilterConfig<ActorData>
	{
		[Header("Actor Config")]
		[Tooltip("If blank the actors name will be generated.")]
		[StoryNodeTranslateFieldContent("Actor Name", "Node")]
		public string actorName;

		public Gender gender;

		public string GetTargetName()
		{
			return null;
		}
	}
}
