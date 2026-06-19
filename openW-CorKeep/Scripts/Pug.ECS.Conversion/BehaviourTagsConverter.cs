using Pug.Conversion;

public class BehaviourTagsConverter : SingleAuthoringComponentConverter<BehaviourTagsAuthoring>
{
	protected override void Convert(BehaviourTagsAuthoring authoring)
	{
		AddComponentData(new BehaviourTagsCD
		{
			wantsToAttackTagsBitMask = ObjectCategoryTagsCD.ConvertToBitMask(authoring.wantsToAttackTags),
			cantAttackTagsBitMask = ObjectCategoryTagsCD.ConvertToBitMask(authoring.cantAttackTags),
			eatsTagsBitMask = ObjectCategoryTagsCD.ConvertToBitMask(authoring.eatsTags)
		});
	}
}
