using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	public abstract class BrainBase : ScriptableObject
	{
		[Tooltip("Enable disable Task or Decisions")]
		public bool active = true;

		[Space]
		[TextArea(3, 10)]
		public string Description = "Type Description Here";

		public virtual void DrawGizmos(MAnimalBrain brain)
		{
		}
	}
}
