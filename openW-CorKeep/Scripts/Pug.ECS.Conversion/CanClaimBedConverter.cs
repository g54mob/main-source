using Pug.Conversion;
using Unity.Entities;

public class CanClaimBedConverter : SingleAuthoringComponentConverter<CanClaimBedAuthoring>
{
	protected override void Convert(CanClaimBedAuthoring authoring)
	{
		if (TryGetActiveComponent<PlayerAuthoring>(authoring, out var _))
		{
			EnsureHasComponent<PlayerClaimedBed>();
		}
		else
		{
			EnsureHasComponent<CharacterClaimedBedCD>();
		}
		EnsureHasComponent<DistanceToPlayerCD>();
		if (base.IsServer)
		{
			Entity entity = CreateAdditionalEntity();
			AddComponentData(entity, new InitializeClaimedBedCD
			{
				entity = base.PrimaryEntity
			});
		}
	}
}
