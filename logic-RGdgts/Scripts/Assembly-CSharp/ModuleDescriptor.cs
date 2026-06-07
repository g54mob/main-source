public struct ModuleDescriptor
{
	public ModuleGestaltVariationEnum variationId;

	public ModuleId id;

	public string displayName;

	public ModuleDescriptor(ModuleGestaltVariationEnum variationId)
	{
		this.variationId = default(ModuleGestaltVariationEnum);
		id = default(ModuleId);
		displayName = null;
	}

	public ModuleDescriptor(ModuleGestaltVariationEnum variationId, ModuleId id)
	{
		this.variationId = default(ModuleGestaltVariationEnum);
		this.id = default(ModuleId);
		displayName = null;
	}

	public override string ToString()
	{
		return null;
	}

	public static bool CheckDisplayNameSyntax(string displayName)
	{
		return false;
	}
}
