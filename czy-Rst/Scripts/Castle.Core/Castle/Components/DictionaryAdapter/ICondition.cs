namespace Castle.Components.DictionaryAdapter
{
	public interface ICondition
	{
		bool SatisfiedBy(object value);
	}
}
