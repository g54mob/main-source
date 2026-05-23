using Factory.FieldObject;

namespace Factory.FieldData
{
	public interface IBlendMaterial
	{
		eLuggage HasLuggageId { get; }

		bool IsLuggageFlag(LuggageFlag deflated);
	}
}
