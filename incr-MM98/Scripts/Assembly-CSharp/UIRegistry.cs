using System;

[Serializable]
public struct UIRegistry
{
	public TaskbarRegistry taskbar;

	public ResourcesRegistry resources;

	public ViewRegistry view;

	public FooterRegistry footer;

	public StartMenuRegistry startMenu;

	public CameraRegistry cameras;

	public PopupRegistry popup;
}
