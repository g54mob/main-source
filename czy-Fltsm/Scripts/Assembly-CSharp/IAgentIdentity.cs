public interface IAgentIdentity
{
	string Name { get; }

	Agent.EGender Gender { get; }

	bool IsDead { get; }

	VoicePackProperties VoicePack { get; }

	float VoicePitch { get; }

	DrifterLookProperties LookProperties { get; }

	DrifterLookProperties.Indices LookIndices { get; }

	bool IsRefugee { get; }

	DrifterAttributesEffect PastBackground { get; }

	DrifterAttributesEffect PresentBackground { get; }
}
