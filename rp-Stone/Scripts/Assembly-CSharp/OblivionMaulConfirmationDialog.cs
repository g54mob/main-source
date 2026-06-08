public class OblivionMaulConfirmationDialog : LimitedTimeBundleConfirmationDialog
{
	private int defaultIconPivotY = int.MinValue;

	protected override void RecalculateHeight()
	{
		base.RecalculateHeight();
		if (defaultIconPivotY == int.MinValue)
		{
			defaultIconPivotY = icon.pivotY;
		}
		icon.pivotY = defaultIconPivotY;
		if (specialDescription.lineCount >= 6)
		{
			icon.pivotY--;
		}
	}
}
