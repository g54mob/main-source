using InControl;

public static class GameControls
{
	public static float scrollDeltaMultiplier = 20f;

	public static float scrollDeltaConstructionMultiplier = 2f;

	public static float scrollDeltaFollowCamMultiplier = 2f;

	public static ControlManager.GameActions actions;

	public static float currentScrollMultiplier = 1f;

	public static float currentUIScrollMultiplier = 1f;

	public static bool needsScrollValueCheck = true;

	public static bool isDragUpScrollWheel = true;

	public static bool isDragDownScrollWheel = true;

	public static bool isZoomInScrollWheel = true;

	public static bool isZoomOutScrollWheel = true;

	public static bool isUIScrollUpScrollWheel = true;

	public static bool isUIScrollDownScrollWheel = true;

	public static bool isObjectScaleUpScrollWheel = true;

	public static bool isObjectScaleDownScrollWheel = true;

	public static string storedZoomInString = "";

	public static string storedZoomOutString = "";

	public static bool isLeftStickDefault = true;

	public static void CheckScrollValuesIfNeeded()
	{
		if (needsScrollValueCheck)
		{
			CheckScrollValues();
		}
	}

	public static void StoreZoomStrings()
	{
		for (int i = 0; i < actions.ZoomIn.Bindings.Count; i++)
		{
			if (actions.ZoomIn.Bindings[i].BindingSourceType == BindingSourceType.MouseBindingSource)
			{
				storedZoomInString = actions.ZoomIn.Bindings[i].Name;
				break;
			}
		}
		for (int j = 0; j < actions.ZoomOut.Bindings.Count; j++)
		{
			if (actions.ZoomIn.Bindings[j].BindingSourceType == BindingSourceType.MouseBindingSource)
			{
				storedZoomOutString = actions.ZoomOut.Bindings[j].Name;
				break;
			}
		}
	}

	private static void CheckScrollValues()
	{
		needsScrollValueCheck = false;
		isDragUpScrollWheel = DoesActionHaveScrollBindings(actions.DragUp, storedZoomInString) || DoesActionHaveScrollBindings(actions.DragUp, storedZoomOutString);
		isDragDownScrollWheel = DoesActionHaveScrollBindings(actions.DragDown, storedZoomInString) || DoesActionHaveScrollBindings(actions.DragDown, storedZoomOutString);
		isZoomInScrollWheel = DoesActionHaveScrollBindings(actions.ZoomIn, storedZoomInString) || DoesActionHaveScrollBindings(actions.ZoomIn, storedZoomOutString);
		isZoomOutScrollWheel = DoesActionHaveScrollBindings(actions.ZoomOut, storedZoomInString) || DoesActionHaveScrollBindings(actions.ZoomOut, storedZoomOutString);
		isUIScrollUpScrollWheel = DoesActionHaveScrollBindings(actions.ScrollUIElementUp, storedZoomInString) || DoesActionHaveScrollBindings(actions.ScrollUIElementUp, storedZoomOutString);
		isUIScrollDownScrollWheel = DoesActionHaveScrollBindings(actions.ScrollUIElementDown, storedZoomInString) || DoesActionHaveScrollBindings(actions.ScrollUIElementDown, storedZoomOutString);
		isObjectScaleUpScrollWheel = DoesActionHaveScrollBindings(actions.IncreaseHeldObjectScale, storedZoomInString) || DoesActionHaveScrollBindings(actions.IncreaseHeldObjectScale, storedZoomOutString);
		isObjectScaleDownScrollWheel = DoesActionHaveScrollBindings(actions.DecreaseHeldObjectScale, storedZoomInString) || DoesActionHaveScrollBindings(actions.DecreaseHeldObjectScale, storedZoomOutString);
	}

	private static bool DoesActionHaveScrollBindings(PlayerAction actionRef, string storedStringComparison)
	{
		for (int i = 0; i < actionRef.Bindings.Count; i++)
		{
			if (actionRef.Bindings[i].BindingSourceType == BindingSourceType.MouseBindingSource && actionRef.Bindings[i].Name == storedStringComparison)
			{
				return true;
			}
		}
		return false;
	}
}
