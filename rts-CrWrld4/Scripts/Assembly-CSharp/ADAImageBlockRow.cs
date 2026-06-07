using UnityEngine;
using UnityEngine.UI;

public class ADAImageBlockRow : ADABlockRow
{
	public LayoutElement imageContainerLE;

	public RectTransform paddedContainer;

	public RawImage rawImage;

	public AspectRatioFitter rawImageARF;

	public Dropdown builtInDropdown;

	public InputField maxHeightInputField;

	private void LateUpdate()
	{
	}

	public override void Start()
	{
	}

	public override void Refresh()
	{
	}

	public void OnSetMaxHeight()
	{
	}

	private Texture2D GetBuiltinImage(string name)
	{
		return null;
	}

	public void SetBuiltinImage()
	{
	}

	public void OnLoadImage()
	{
	}

	public void LoadImageFromFile()
	{
	}

	private void LoadImageBrowserOutput(string path)
	{
	}

	private Texture2D CreateTexture(byte[] data, bool scale = false)
	{
		return null;
	}

	private void FileBrowserWindowClosed()
	{
	}
}
