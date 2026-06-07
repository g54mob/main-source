using System.Runtime.CompilerServices;

[IsReadOnly]
public struct LicenseData : IListDoubleClickable
{
	public readonly SoftwareProduct Product;

	public readonly SoftwareProduct Tool;

	public readonly SoftwareFramework Framework;

	public readonly bool IsTool;

	public string Name
	{
		get
		{
			if (!IsTool)
			{
				return Framework.Name;
			}
			return Tool.Name;
		}
	}

	public float Paid
	{
		get
		{
			return 0f - (IsTool ? Product.GetToolValue(Tool) : Product.FrameworkPayout);
		}
	}

	public float ReversePaid
	{
		get
		{
			if (!IsTool)
			{
				return 0f;
			}
			return Tool.GetToolValue(Product);
		}
	}

	public LicenseData(SoftwareProduct product, SoftwareProduct tool)
	{
		Product = product;
		Tool = tool;
		Framework = null;
		IsTool = true;
	}

	public LicenseData(SoftwareProduct product, SoftwareFramework framework)
	{
		Product = product;
		Tool = null;
		Framework = framework;
		IsTool = false;
	}

	public void ShowDetails()
	{
		if (IsTool)
		{
			HUD.Instance.GetProductWindow(null).ShowProductDetails(Tool);
		}
		else
		{
			HUD.Instance.docWindow.FrameworkDialog.Show(Framework);
		}
	}

	public void OnDoubleClick()
	{
		if (IsTool)
		{
			Tool.OnDoubleClick();
		}
	}
}
