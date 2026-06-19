using Interaction;
using Pug.Conversion;

public class PetConverter : SingleAuthoringComponentConverter<PetAuthoring>
{
	protected override void Convert(PetAuthoring authoring)
	{
		int maxSkins = PetInfosTable.GetTable().GetPetSkinInfo((ObjectID)base.ObjectIndex)?.skins.Count ?? 0;
		AddComponentData(new PetCD
		{
			isFlying = authoring.isFlying,
			happyAnimDuration = authoring.happyAnimDuration,
			maxSkins = maxSkins,
			petType = authoring.petType
		});
		EnsureHasBuffer<PetTalentPoolBuffer>();
		foreach (PetTalent petTalent in authoring.petTalents)
		{
			AddToBuffer(new PetTalentPoolBuffer
			{
				petTalentID = petTalent
			});
		}
		EnsureHasComponent<PlayAnimationStateCD>(componentIsEnabled: false);
		EnsureHasBuffer<AddPetExperienceBuffer>();
		EnsureHasComponent<OwnerReferenceCD>();
		EnsureHasComponent<DontDisableCD>();
		AddComponentData(new InteractionCooldownCD
		{
			cooldownTimer = new TickTimer(2f, (uint)PlatformConfiguration.Instance.SessionConfiguration.SimulationTickRate)
		});
		EnsureHasBuffer<TriggerUseInteractionBuffer>();
	}
}
