using UnityEngine;

public class PanelsViewer : MonoBehaviour
{
	public Camera worldCamera;

	public Transform landPanelsContainer;

	public Transform creeperPanelsContainer;

	public GameObject landPanelPrefab;

	public GameObject creeperPanelPrefab;

	private Plane basePlane;

	private Panel[,] panels;

	private int manageCount;

	private bool skippedLastTime;

	private void Awake()
	{
	}

	public virtual void Init()
	{
	}

	public void MyLateUpdate()
	{
	}

	public void ForceShowWithUpdate()
	{
	}

	public void ManagePanels(bool showAllPanels, bool forceRefreshLand, bool forceRefreshCreeper)
	{
	}

	public Panel GetPanelForSector(int sx, int sy)
	{
		return null;
	}
}
