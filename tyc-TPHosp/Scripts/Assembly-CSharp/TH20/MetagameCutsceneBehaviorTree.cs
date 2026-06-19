using UnityEngine;

namespace TH20
{
	[AddComponentMenu("TH20/Metagame Cutscene Behavior Tree")]
	public class MetagameCutsceneBehaviorTree : MetagameBehaviorTree
	{
		public CutsceneCameraLogic CutsceneCamera { get; set; }
	}
}
