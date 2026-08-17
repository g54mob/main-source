using System;
using Cpp2ILInjected;

namespace Doozy.Engine.UI.Internal;

[Serializable]
public class UIViewCategoryName
{
	private const string DEFAULT_CATEGORY = "General";

	private const string DEFAULT_NAME = "Unnamed";

	private const bool DEFAULT_INSTANT_ACTION = false;

	public string Category;

	public bool InstantAction;

	public string Name;

	public UIViewCategoryName()
	{
		Reset();
	}

	public UIViewCategoryName(string viewCategory, string viewName)
	{
		Reset();
		Category = viewCategory;
		Name = viewName;
	}

	public UIViewCategoryName(string viewCategory, string viewName, bool instantAction)
	{
		Reset();
		Category = viewCategory;
		Name = viewName;
		InstantAction = instantAction;
	}

	public UIViewCategoryName Copy()
	{
		UIViewCategoryName uIViewCategoryName = new UIViewCategoryName();
		uIViewCategoryName.Reset();
		if (uIViewCategoryName != null)
		{
			uIViewCategoryName.Category = Category;
			uIViewCategoryName.Name = Name;
			uIViewCategoryName.InstantAction = InstantAction;
			return uIViewCategoryName;
		}
		return (UIViewCategoryName)(object)new NullReferenceException();
	}

	public void Reset()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899807C1]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		Category = "General";
		Name = "Unnamed";
		InstantAction = false;
	}
}
