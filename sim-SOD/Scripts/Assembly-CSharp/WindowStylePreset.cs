using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "windowstyle_data", menuName = "Database/Window Style")]
public class WindowStylePreset : SoCustomComparison
{
	[Header("Interaction")]
	public bool closable;

	public bool pinnable;

	[Tooltip("If true this will always and only be able to be a world interaction")]
	public bool forceWorldInteraction;

	[Tooltip("Use window focus mode (black screen behind the window)")]
	public bool useWindowFocusMode;

	[Header("Resizing")]
	public bool resizable;

	public Vector2 defaultSize;

	public Vector2 minSize;

	public Vector2 maxSize;

	[Space(7f)]
	[InfoBox("Used to make the window size relative to DDS document sizes: Adds this on to the document size to make the window size.", EInfoBoxType.Normal)]
	public Vector2 DDSadditionalSize;

	[Header("Icons")]
	public Sprite overrideIcon;

	[Header("Tabs")]
	public List<WindowTabPreset> tabs;
}
