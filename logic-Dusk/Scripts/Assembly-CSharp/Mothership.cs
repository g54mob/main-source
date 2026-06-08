using System;
using System.Linq;
using UnityEngine;

public class Mothership : MonoBehaviour
{
	public const float PLAYER_SHIP_Z_HEIGHT = -15f;

	public float ShortRangeScannerRadius = 50f;

	public float LongRangeScannerRadius = 125f;

	private GameObject shipPlaneObject;

	private GameObject scannerFarObject;

	private GameObject scannerNearObject;

	public static Mothership Instance { get; private set; }

	public static StarSystemInfo CurrentStarSystem { get; private set; }

	private void Awake()
	{
		Instance = this;
		shipPlaneObject = base.transform.Find("ShipPlane").gameObject;
		scannerFarObject = base.transform.Find("ShipScanOuter").gameObject;
		scannerNearObject = base.transform.Find("ShipScanInner").gameObject;
	}

	private void Start()
	{
		if (!UniverseMapManager.Instance.IsReadOnlyGalaxy)
		{
			scannerFarObject.GetComponent<Renderer>().enabled = GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.LongRangeScanner);
		}
		else
		{
			scannerNearObject.GetComponent<Renderer>().enabled = false;
			scannerFarObject.GetComponent<Renderer>().enabled = false;
			shipPlaneObject.SetActive(false);
		}
		EventManager.Instance.SubscribeInstant(GeneralEventType.ShipUpgradeUninstalled, HandleShipUpgradeUninstalled);
		EventManager.Instance.SubscribeInstant(GeneralEventType.ShipUpgradeInstalled, HandleShipUpgradeInstalled);
	}

	private void OnDestroy()
	{
		shipPlaneObject = null;
		scannerFarObject = null;
		scannerNearObject = null;
	}

	public void Stop()
	{
		EventManager.Instance.UnSubscribe(GeneralEventType.ShipUpgradeUninstalled, HandleShipUpgradeUninstalled);
		EventManager.Instance.UnSubscribe(GeneralEventType.ShipUpgradeInstalled, HandleShipUpgradeInstalled);
	}

	public void GalaxyView()
	{
		Vector3 localScale = shipPlaneObject.transform.localScale;
		localScale.x = 0.125f;
		localScale.y = 0.1f;
		localScale.z = 0.075f;
		shipPlaneObject.transform.localScale = localScale;
		if (!UniverseMapManager.Instance.IsReadOnlyGalaxy)
		{
			if (GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.LongRangeScanner))
			{
				scannerFarObject.GetComponent<Renderer>().enabled = true;
			}
			scannerNearObject.GetComponent<Renderer>().enabled = true;
			shipPlaneObject.SetActive(true);
		}
	}

	public void StarSystemView(bool hide)
	{
		if (!hide && !UniverseMapManager.Instance.IsReadOnlyGalaxy)
		{
			Vector3 localScale = shipPlaneObject.transform.localScale;
			localScale.x = 0.25f;
			localScale.y = 0.1f;
			localScale.z = 0.15f;
			shipPlaneObject.transform.localScale = localScale;
			shipPlaneObject.SetActive(true);
		}
		else
		{
			shipPlaneObject.SetActive(false);
		}
		scannerFarObject.GetComponent<Renderer>().enabled = false;
		scannerNearObject.GetComponent<Renderer>().enabled = false;
	}

	public void HideShip()
	{
		shipPlaneObject.SetActive(false);
	}

	public void HideScanObjects()
	{
		scannerFarObject.GetComponent<Renderer>().enabled = false;
		scannerNearObject.GetComponent<Renderer>().enabled = false;
	}

	public void ShowShip()
	{
		shipPlaneObject.SetActive(true);
	}

	public void ShowNearScanObject()
	{
		scannerNearObject.GetComponent<Renderer>().enabled = true;
	}

	public void ShowFarScanObject()
	{
		scannerFarObject.GetComponent<Renderer>().enabled = true;
	}

	public void LeaveSystem()
	{
		if (CurrentStarSystem != null && CurrentStarSystem.galaxyNode != null)
		{
			CurrentStarSystem.galaxyNode.SetSelected(false);
		}
	}

	public void TravelToStarSystem(StarSystemInfo starSystem)
	{
		base.transform.position = new Vector3(starSystem.Coordinates.x - 5f, starSystem.Coordinates.y + 5f, -15f);
		StarSystemInfo currentStarSystem = CurrentStarSystem;
		CurrentStarSystem = starSystem;
		if (currentStarSystem != null && currentStarSystem.galaxyNode != null)
		{
			currentStarSystem.galaxyNode.SetSelected(false);
		}
		PostTravel();
		SystemOverlayUI.Instance.SetSystemProperties(starSystem, starSystem == GlobalSettings.GameState.ThePlayer.CurrentStarSystem);
	}

	public void ScanStarSystem(StarSystemInfo starSystem)
	{
		ScanStarSystem(starSystem, false);
	}

	public void ScanStarSystem(StarSystemInfo starSystem, bool forceUseDefault)
	{
		Vector3 coordinates = starSystem.Coordinates;
		float scanDist = ((!GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.LongRangeScanner)) ? ShortRangeScannerRadius : LongRangeScannerRadius);
		if (!forceUseDefault)
		{
			scanDist = GetScanDistanceFromData(starSystem);
		}
		Scan(scanDist, coordinates, starSystem);
	}

	public void PostTravel()
	{
		if (GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.LongRangeScanner))
		{
			LongRangeScan();
		}
		else
		{
			ShortRangeScan();
		}
	}

	public void InstallLongRangeScannerForced()
	{
		if (!GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.LongRangeScanner))
		{
			BaseShipUpgrade upgrade = ShipUpgradeFactory.CreateUpgrade(ShipUpgradeType.LongRangeScanner);
			GlobalSettings.GameState.ThePlayer.InstallShipUpgrade(upgrade, false);
		}
	}

	public void RemoveLongRangeScanner()
	{
		while (GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.LongRangeScanner))
		{
			GlobalSettings.GameState.ThePlayer.UninstallShipUpgrade((BaseShipUpgrade)GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.ItemsCopy.First((IInventoryItem x) => x != null && ((BaseShipUpgrade)x).UpgradeType == ShipUpgradeType.LongRangeScanner));
		}
	}

	public void ShortRangeScan()
	{
		if (!UniverseMapManager.Instance.IsReadOnlyGalaxy)
		{
			if (CurrentStarSystem != null && GetScanTypeFromData(CurrentStarSystem) == 0)
			{
				GalaxySaveFile.Save(CurrentStarSystem.GroupKey, "SCNTYPE", 0);
			}
			Scan(ShortRangeScannerRadius);
		}
	}

	public void LongRangeScan()
	{
		if (!UniverseMapManager.Instance.IsReadOnlyGalaxy)
		{
			if (CurrentStarSystem != null)
			{
				GalaxySaveFile.Save(CurrentStarSystem.GroupKey, "SCNTYPE", 1);
			}
			Scan(LongRangeScannerRadius);
		}
	}

	private void Scan(float scanDist)
	{
		Scan(scanDist, base.transform.position, CurrentStarSystem);
	}

	private void Scan(float scanDist, Vector3 point, StarSystemInfo systemToReveal)
	{
		if (GlobalSettings.GameState.StarSystems == null)
		{
			return;
		}
		foreach (StarSystemInfo starSystem in GlobalSettings.GameState.StarSystems)
		{
			if (!(starSystem.galaxyNode != null) || starSystem.galaxyNode.IsVisible)
			{
				continue;
			}
			float num = Vector3.Distance(point, starSystem.galaxyNode.transform.position);
			if (!(num <= scanDist) || starSystem.galaxyNode.IsVisible)
			{
				continue;
			}
			if (starSystem.Id == 0)
			{
				int num2 = GalaxySaveFile.Get(starSystem.GroupKey, "ID", 0);
				if (num2 == 0)
				{
					num2 = GlobalSettings.GameState.NextSystemId++;
				}
				starSystem.Id = num2;
			}
			starSystem.galaxyNode.Scan();
		}
		if (GlobalSettings.GenerateGalaxyMapFromImage && systemToReveal != null && (systemToReveal.ScannedBackground == StarSystemBackgroundScanEnum.NotScanned || (systemToReveal.ScannedBackground == StarSystemBackgroundScanEnum.ShortRangeScanDone && GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.LongRangeScanner))))
		{
			int scanTypeFromData = GetScanTypeFromData(systemToReveal);
			StarField.Instance.RevealBackground(systemToReveal.TrueImageCoords, (scanTypeFromData != 0) ? true : false);
			systemToReveal.ScannedBackground = ((scanTypeFromData != 1) ? StarSystemBackgroundScanEnum.ShortRangeScanDone : StarSystemBackgroundScanEnum.LongRangeScanDone);
		}
	}

	public void ExternalUninstallScanner()
	{
		scannerFarObject.GetComponent<Renderer>().enabled = false;
		ShortRangeScan();
	}

	private void HandleShipUpgradeUninstalled(object sender, EventArgs args)
	{
		GeneralEventArgs e = null;
		BaseShipUpgrade baseShipUpgrade = null;
		if (args != null)
		{
			e = (GeneralEventArgs)args;
		}
		if (e != null)
		{
			baseShipUpgrade = (BaseShipUpgrade)e.Data;
		}
		if (baseShipUpgrade.UpgradeType == ShipUpgradeType.LongRangeScanner && !GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.LongRangeScanner))
		{
			scannerFarObject.GetComponent<Renderer>().enabled = false;
			ShortRangeScan();
		}
	}

	private void HandleShipUpgradeInstalled(object sender, EventArgs args)
	{
		if (UniverseMapManager.Instance.IsReadOnlyGalaxy)
		{
			return;
		}
		GeneralEventArgs e = (GeneralEventArgs)args;
		BaseShipUpgrade baseShipUpgrade = (BaseShipUpgrade)e.Data;
		if (baseShipUpgrade.UpgradeType == ShipUpgradeType.LongRangeScanner)
		{
			if (GalaxyMapManager.Instance.CurrentMapState == GalaxyMapState.StarSystems)
			{
				scannerFarObject.GetComponent<Renderer>().enabled = true;
				LongRangeScan();
			}
			if (GlobalSettings.GameState.ThePlayer != null)
			{
				GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory.AgeInventoryItems(1, true);
			}
		}
	}

	private int GetScanTypeFromData(StarSystemInfo starSystem)
	{
		int num = GalaxySaveFile.Get(starSystem.GroupKey, "SCNTYPE", -1);
		if (num >= 0)
		{
			return num;
		}
		if (GlobalSettings.GameState.ThePlayer.HasShipUpgradeInstalled(ShipUpgradeType.LongRangeScanner))
		{
			return 1;
		}
		return 0;
	}

	private float GetScanDistanceFromData(StarSystemInfo starSystem)
	{
		float result = 0f;
		switch (GetScanTypeFromData(starSystem))
		{
		case 0:
			result = ShortRangeScannerRadius;
			break;
		case 1:
			result = LongRangeScannerRadius;
			break;
		}
		return result;
	}
}
