using Pug.Conversion;

public class TileEffectConverter : SingleAuthoringComponentConverter<TileEffectAuthoring>
{
	protected override void Convert(TileEffectAuthoring authoring)
	{
		AddComponentData(new TileEffectCD
		{
			sfxTableDamageId = authoring.sfxTableDamageId.value,
			sfxTableDestroyId = authoring.sfxTableDestroyId.value
		});
		if (authoring.destroyPuffs.Count <= 0)
		{
			return;
		}
		EnsureHasBuffer<TileEffectPuffsBuffer>();
		foreach (PuffParams destroyPuff in authoring.destroyPuffs)
		{
			AddToBuffer(new TileEffectPuffsBuffer
			{
				destroyPuff = destroyPuff
			});
		}
	}
}
