namespace DV.Interaction
{
	public interface IItemUse
	{
		bool HandleHover(ItemUseTarget target);

		bool HandleUse(ItemUseTarget target);

		bool IsHoverCompatible(ItemUseTarget target);

		bool IsUseCompatible(ItemUseTarget target);
	}
}
