namespace TH20
{
	public interface IAttributesInterface
	{
		AttributesManager GetAttributesManager();

		Attributes GetAttributes();

		void GetAttributeNames(out string[] names);

		void GetAttributeHashCodes(out int[] hashCodes);

		float GetAttributeModifierOverTime(string attributeName);

		float GetAttributeMultiplier(int enumValue);
	}
}
