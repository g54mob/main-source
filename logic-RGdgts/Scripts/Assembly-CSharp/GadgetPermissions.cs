public class GadgetPermissions
{
	public enum Category
	{
		Webcam = 0,
		Network = 1
	}

	private SerializedGadgetMetaData metadata;

	private GadgetPrefsController.GadgetPref gadgetPrefs;

	public bool dialogDisplayed
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public GadgetPermissions(SerializedGadgetMetaData metadata)
	{
	}

	public bool IsGranted(Category category)
	{
		return false;
	}

	public void SetGrant(Category category, bool grant)
	{
	}

	public void GrantAll()
	{
	}

	public ulong GetMask()
	{
		return 0uL;
	}
}
