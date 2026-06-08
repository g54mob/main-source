public interface IToggleVisibilityInSchematic
{
	bool IsInvisibleDueToToggle { get; set; }

	void SetSchematicVisibility(bool show);
}
