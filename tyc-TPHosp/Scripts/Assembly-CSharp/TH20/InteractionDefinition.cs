using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InteractionDefinition
	{
		public enum Socket
		{
			None = 0,
			LeftHand = 1,
			RightHand = 2
		}

		[InspectorTooltip("Interaction is no longer available")]
		public bool Deprecated;

		[InspectorTooltip("Interaction type")]
		public InteractionAttributeModifier.Type Type;

		[InspectorTooltip("Name to identify the interaction")]
		public string Name;

		[InspectorTooltip("Only one interaction with this name can be used")]
		public bool Exclusive;

		[InspectorTooltip("Maximum number of people that can queue at this interaction")]
		public int MaxQueue = 3;

		[InspectorTooltip("Start locations for this interaction")]
		public string[] Sockets;

		[InspectorTooltip("Particle effect to enable for each socket")]
		[FullInspector.InspectorName("Socket Particles")]
		public string[] ParticleEffects;

		[InspectorTooltip("Particle effects to disable when this interaction ends")]
		[FullInspector.InspectorName("End Particle Effects")]
		public string[] GlobalParticleEffects;

		[InspectorTooltip("Character socket to attach the object to")]
		public Socket SocketAttach;

		[InspectorTooltip("Object socket to attach to the character")]
		public string SocketProp;

		[InspectorTooltip("Animation graph to play on the character")]
		public RuntimeAnimatorController[] AnimGraphs;

		[InspectorTooltip("Alternate animation graph to play on the character (if their customisation option dictates)")]
		public RuntimeAnimatorController[] AnimGraphsAlternate;

		[InspectorTooltip("Animation graph to play on the object")]
		public RuntimeAnimatorController ObjectAnimGraph;

		public RuntimeAnimatorController[] ObjectAnimGraphEx;

		[InspectorTooltip("Alternate animation graph to play on the object (if character's customisation option dictates)")]
		public RuntimeAnimatorController ObjectAnimGraphAlternate;

		[InspectorTooltip("Use object animation parameters as master")]
		public bool SyncParametersFromObject = true;

		[InspectorTooltip("Don't sync animation parameters with object")]
		public bool UseObjectParameterSync = true;

		[InspectorTooltip("Additional actors to use in the interaction")]
		public AdditionalActor[] Extras;

		[InspectorTooltip("Can this interaction be interrupted")]
		public bool CanInterrupt = true;

		[InspectorTooltip("Interaction can be placed outside the room")]
		public bool IgnoreRoomCheck;

		[InspectorTooltip("Disable character look at")]
		public bool DisableLookAt;

		[InspectorTooltip("Disable nav agent")]
		public bool DisableNavAgent;

		[InspectorTooltip("Room item has to be in this state for the interaction to be valid")]
		public SharedInstance<RoomItemState> ValidState;

		[InspectorTooltip("Which state to leave the room item in when the interaction ends")]
		public SharedInstance<RoomItemState> EndState;

		[InspectorTooltip("Should this interaction point be included in collision bound")]
		public bool IncludeInBounds;

		[InspectorTooltip("Ignore rotation on start location")]
		public bool IgnoreStartRotation;

		public string DebugUniqueName()
		{
			if (AnimGraphs == null || AnimGraphs.Length == 0)
			{
				return Name;
			}
			return Name + AnimGraphs[0].name;
		}
	}
}
