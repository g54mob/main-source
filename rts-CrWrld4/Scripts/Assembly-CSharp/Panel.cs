using UnityEngine;

public class Panel
{
	private PanelsViewer viewer;

	private LandPanel landPanel;

	private CreeperPanel creeperPanel;

	public int sectorX;

	public int sectorY;

	public bool dirty;

	private static Vector3 size;

	public bool isInView;

	private bool _active;

	private Vector3 _position;

	public bool activeSelf => false;

	public Vector3 position
	{
		get
		{
			return default(Vector3);
		}
		set
		{
		}
	}

	public virtual void Init(PanelsViewer viewer, int sx, int sy)
	{
	}

	public LandPanel GetLandPanel()
	{
		return null;
	}

	public CreeperPanel GetCreeperPanel()
	{
		return null;
	}

	public void SetLandPanelDirty(bool dirty, bool skipRecalculateExtras)
	{
	}

	public void SetActive(bool val)
	{
	}

	public Vector3 GetCreeperPanelVertex(int cellX, int cellY)
	{
		return default(Vector3);
	}

	public void Refresh(bool forceRefreshLand, bool forceRefreshCreeper)
	{
	}

	public bool IsInFrustum(Plane[] planes)
	{
		return false;
	}

	public static bool IsInFrustum(Plane[] planes, int sectorX, int sectorY)
	{
		return false;
	}

	private static bool IsPointInPanel(Vector3 point, int sectorX, int sectorY)
	{
		return false;
	}

	public virtual void DestroyPanel()
	{
	}
}
