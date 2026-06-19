namespace PugTilemap.Workshop
{
	public interface MultiVariantPseudoTile
	{
		void CycleVariant(Workshop.Modification mod);

		byte GetVariant();

		void SetVariant(byte variant);
	}
}
