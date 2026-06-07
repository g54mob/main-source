using UnityEngine;

public class CoolButtonMgr : MonoBehaviour
{
	public static CoolButtonMgr I;

	public CoolButtonViz VizDefault;

	public CoolButtonViz VizPressed;

	public CoolButtonViz VizGridBtnNormal;

	public CoolButtonViz VizGridBtnHighlighted;

	public CoolButtonViz VizSidebarDefault;

	public CoolButtonViz VizSidebarSelected;

	private void Awake()
	{
	}
}
