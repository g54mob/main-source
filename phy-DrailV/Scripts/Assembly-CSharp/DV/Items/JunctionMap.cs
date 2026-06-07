using System.Collections.Generic;
using DV.CabControls;
using DV.Signs;
using DV.ThingTypes;
using DV.Utils;
using UnityEngine;

namespace DV.Items
{
	public class JunctionMap : MonoBehaviour
	{
		public enum JunctionMapType
		{
			None = 0,
			Station = 1,
			World = 2,
			All = 3
		}

		public JunctionMapType junctionMapType;

		public BoxCollider junctionTouchCollider;

		[SerializeField]
		private Transform touchscreenTransform;

		private TouchscreenBase touchscreen;

		private JunctionSwitcher junctionSwitcher;

		private int currentPage;

		private PageBook pageBook;

		private JunctionGeneratedDataRuntime junctionData;

		private Dictionary<Vector2Int, Junction.JunctionData>[] junctionDataMap;

		private HashSet<Vector2Int>[] touchableSections;

		public GeneralLicenseType_v2 requiredLicense;

		private bool requiredLicenseAcquired;

		public bool JunctionMapUsageAllowed => requiredLicenseAcquired;

		private void Start()
		{
			if (touchscreenTransform == null)
			{
				Debug.LogError("JunctionMap: TouchscreenBase parent reference is not assigned. Remote switching is not possible.", this);
				return;
			}
			touchscreen = touchscreenTransform.GetComponent<TouchscreenBase>();
			if (touchscreen == null)
			{
				Debug.LogError("JunctionMap: TouchscreenBase component not found. Remote switching is not possible.", this);
				return;
			}
			junctionData = SingletonBehaviour<LevelInfo>.Instance.junctionData;
			if (junctionData == null)
			{
				Debug.LogError("JunctionMap: JunctionGeneratedDataRuntime is not assigned. Remote switching is not possible.", this);
				return;
			}
			JunctionGeneratedDataRuntime.JunctionPageData[] pageData = junctionData.GetPageData(junctionMapType);
			if (pageData == null)
			{
				Debug.LogError(string.Format("{0}: No junction data found for {1}. Remote switching is not possible.", "JunctionMap", junctionMapType), this);
				return;
			}
			int num = pageData.Length;
			junctionDataMap = new Dictionary<Vector2Int, Junction.JunctionData>[num];
			touchableSections = new HashSet<Vector2Int>[num];
			for (int i = 0; i < num; i++)
			{
				junctionDataMap[i] = new Dictionary<Vector2Int, Junction.JunctionData>();
				touchableSections[i] = new HashSet<Vector2Int>();
				foreach (JunctionGeneratedDataRuntime.DataCoord junctionDataCoord in pageData[i].junctionDataCoords)
				{
					Vector2Int coord = junctionDataCoord.coord;
					junctionDataMap[i].Add(coord, junctionDataCoord.data);
					touchableSections[i].Add(coord);
				}
			}
			pageBook = GetComponent<PageBook>();
			currentPage = ((pageBook != null) ? pageBook.currentPage : 0);
			touchscreen.forcedGridSize = junctionData.GetMapGridSize(junctionMapType);
			OnPageFlipped(currentPage);
			junctionSwitcher = base.gameObject.AddComponent<JunctionSwitcher>();
			junctionSwitcher.enabled = false;
			SetupListeners(on: true);
			requiredLicenseAcquired = SingletonBehaviour<LicenseManager>.Instance.IsGeneralLicenseAcquired(requiredLicense);
			if (VRManager.IsVREnabled())
			{
				touchscreen.InteractionAllowed = false;
			}
			if (!requiredLicenseAcquired)
			{
				if (touchscreen.IsInitialized)
				{
					DeactivateTouchscreen();
				}
				else
				{
					touchscreen.Initialized += DeactivateTouchscreen;
				}
				SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired += OnGeneralLicenseAcquired;
			}
		}

		private void DeactivateTouchscreen()
		{
			if (touchscreen != null)
			{
				touchscreen.gameObject.SetActive(value: false);
			}
			touchscreen.Initialized -= DeactivateTouchscreen;
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				if (pageBook != null)
				{
					pageBook.PageFlipped += OnPageFlipped;
				}
				if ((bool)touchscreen)
				{
					touchscreen.SectionTouched += OnTouched;
					touchscreen.SectionUntouched += OnUntouched;
					touchscreen.SectionPressed += OnPressed;
				}
				return;
			}
			if (pageBook != null)
			{
				pageBook.PageFlipped -= OnPageFlipped;
			}
			if (touchscreen != null)
			{
				touchscreen.Initialized -= DeactivateTouchscreen;
				touchscreen.SectionTouched -= OnTouched;
				touchscreen.SectionUntouched -= OnUntouched;
				touchscreen.SectionPressed -= OnPressed;
			}
			if (SingletonBehaviour<LicenseManager>.Instance != null)
			{
				SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired -= OnGeneralLicenseAcquired;
			}
		}

		private void OnPageFlipped(int page)
		{
			currentPage = page;
			touchscreen.validSections = touchableSections[currentPage];
		}

		private void OnGeneralLicenseAcquired(GeneralLicenseType_v2 license)
		{
			if (license == requiredLicense)
			{
				SingletonBehaviour<LicenseManager>.Instance.LicenseAcquired -= OnGeneralLicenseAcquired;
				requiredLicenseAcquired = true;
				touchscreen.Initialized -= DeactivateTouchscreen;
				touchscreen.gameObject.SetActive(value: true);
			}
		}

		private void OnTouched(Vector2Int coord)
		{
			Junction junction = JunctionFromCoord(coord);
			if (!(junction == null) && SingletonBehaviour<JunctionSwitcherManager>.Instance.IsSwitchingAllowed(junction))
			{
				JunctionSwitchRemoteControllable junctionSwitchRemoteControllable = junction.RemoteControllable();
				junctionSwitcher.SetTarget(junctionSwitchRemoteControllable, indirectlyPointing: true);
				SingletonBehaviour<JunctionSwitcherManager>.Instance.ToggleHighlight(on: true, junctionSwitchRemoteControllable, junctionSwitcher);
				junctionSwitchRemoteControllable.SignHover.Hovered(nonScreenSpaceMode: true, ignoreRemoteSignReadingAllowed: true);
			}
		}

		private void OnUntouched(Vector2Int coord)
		{
			Junction junction = JunctionFromCoord(coord);
			if (!(junction == null) && SingletonBehaviour<JunctionSwitcherManager>.Instance.IsSwitchingAllowed(junction))
			{
				junctionSwitcher.SetTarget();
				JunctionSwitchRemoteControllable junctionSwitchRemoteControllable = junction.RemoteControllable();
				SingletonBehaviour<JunctionSwitcherManager>.Instance.ToggleHighlight(on: false, junctionSwitchRemoteControllable, junctionSwitcher);
				junctionSwitchRemoteControllable.SignHover.Unhovered();
			}
		}

		private void OnPressed(Vector2Int coord)
		{
			Junction junction = JunctionFromCoord(coord);
			if (!(junction == null) && SingletonBehaviour<JunctionSwitcherManager>.Instance.IsSwitchingAllowed(junction))
			{
				junctionSwitcher.Use();
				JunctionSignHover signHover = junction.RemoteControllable().SignHover;
				signHover.Unhovered();
				signHover.Hovered(nonScreenSpaceMode: true, ignoreRemoteSignReadingAllowed: true);
			}
		}

		private Junction JunctionFromCoord(Vector2Int coord)
		{
			if (!touchscreen.IsValidGridPosition(coord))
			{
				return null;
			}
			Dictionary<Vector2Int, Junction.JunctionData> dictionary = junctionDataMap[currentPage];
			if (!dictionary.ContainsKey(coord))
			{
				return null;
			}
			int junctionIndex = dictionary[coord].junctionIndex;
			if (!junctionIndex.IsInRange(0, SingletonBehaviour<RailTrackRegistryBase>.Instance.OrderedJunctions.Length - 1))
			{
				Debug.LogError($"Junction index {junctionIndex} is out of bounds. Junctions count: {SingletonBehaviour<RailTrackRegistryBase>.Instance.OrderedJunctions.Length}");
				return null;
			}
			return SingletonBehaviour<RailTrackRegistryBase>.Instance.OrderedJunctions[junctionIndex];
		}

		public Junction JunctionFromPoint(Vector3 point)
		{
			if (junctionData == null)
			{
				return null;
			}
			Vector2Int coord = touchscreen.WorldToGrid(point);
			return JunctionFromCoord(coord);
		}
	}
}
