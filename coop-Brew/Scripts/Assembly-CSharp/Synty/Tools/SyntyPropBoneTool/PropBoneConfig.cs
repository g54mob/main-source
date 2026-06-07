using UnityEngine;

namespace Synty.Tools.SyntyPropBoneTool
{
	[CreateAssetMenu(menuName = "Synty/Animation/Synty Prop Bone Config", order = 1)]
	public class PropBoneConfig : ScriptableObject
	{
		[Tooltip("The rig used to create the animations. Rig must be in T Pose.")]
		public GameObject sourceRig;

		[Tooltip("The rig to play the animations on in Unity. Rig must be in T Pose.")]
		public GameObject targetRig;

		[Tooltip("Parameters that define where prop bones will generate and how to constrain them")]
		public PropBoneDefinition[] propBoneDefinitions;

		[ContextMenu("Calculate Offset Values")]
		public void CalculateOffsetValues()
		{
		}
	}
}
