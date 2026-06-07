using Brewery.Face;
using UnityEngine;

namespace Brewery.EmoteSystem
{
	[CreateAssetMenu(menuName = "Brewery/Emote Definition", order = 100)]
	public class EmoteDefinition : ScriptableObject
	{
		[Header("Identity")]
		public string emoteName;

		[SerializeField]
		private string emoteNameKey;

		public Sprite icon;

		[Header("Animation")]
		[Tooltip("Animator parameter name. Used as a Trigger for one-shot emotes, or a Bool for looping emotes.")]
		public string animatorTrigger;

		[Tooltip("Animator layer index this emote plays on. Create layers with different Avatar Masks for different body part combinations.")]
		public int animatorLayerIndex;

		[Tooltip("Duration in seconds. Ignored for looping emotes (they loop until cancelled).")]
		public float duration;

		[Tooltip("If true, uses a Bool parameter instead of a Trigger so the animation loops until cancelled by movement, combat, or another emote.")]
		public bool isLooping;

		[Header("Behavior")]
		[Tooltip("If true, this emote won't cancel when the player moves")]
		public bool canUseWhileMoving;

		[Tooltip("If true, this emote can be randomly selected as an idle emote")]
		public bool canBeIdleEmote;

		[Header("Face")]
		[Tooltip("Optional facial expression played alongside this emote.")]
		public FaceExpression faceExpression;

		[Tooltip("How the face expression plays: Hold = static pose held; OneShot = curves play once at start; Loop = curves loop while emote active.")]
		public FaceExpressionPlayMode facePlayMode;

		public string GetLocalizedName()
		{
			return null;
		}
	}
}
