namespace TMPEffects.Tags
{
	internal interface ITagCacher<T> where T : ITagWrapper
	{
		T CacheTag(TMPEffectTag tag, TMPEffectTagIndices indices);
	}
}
