using System.Collections.Generic;
using System.Linq;
using ManagementScripts;
using SimulationScripts.BibiteScripts;
using UIScripts.UIReferences.LineagePanel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utility;

namespace UIScripts
{
	public class LineageMeshPanel : UIPanel
	{
		[Header("Object References")]
		public GameObject lineageHolder;

		public GameObject graphElementHolder;

		public LineageWindow lineageWindow;

		public GraphicRaycaster overlayRaycaster;

		public GraphicRaycaster raycaster;

		private EventSystem eventSystem;

		[Header("Prefabs")]
		public GameObject speciesMeshPrefab;

		private RectTransform lineageHolderRT;

		private RectTransform graphTransform;

		private float viewportWidth;

		private float viewportHeight;

		private int index;

		private LineageMesh selectedMesh;

		public Dictionary<Species, LineageMesh> speciesMeshes = new Dictionary<Species, LineageMesh>();

		private List<UIMeshEventHandler> lastInteractedMeshes = new List<UIMeshEventHandler>();

		private List<LineageMesh> activeLineageMeshes = new List<LineageMesh>();

		private List<LineageMesh> lineageMeshPool = new List<LineageMesh>();

		private bool hideExtinctLineages;

		private bool showFavorites;

		private bool popupUp;

		private LogLikeFormat[] formats;

		private int maxN;

		private float defaultStep = 50f;

		private float sidePadding = 150f;

		private float totalWeight;

		public bool empty => speciesMeshes.Count < 1;

		private void UpdatePopupUp(bool val)
		{
			popupUp = val;
		}

		public override void InitPanel()
		{
			if (!hasInit)
			{
				base.InitPanel();
				eventSystem = EventSystem.current;
				graphTransform = graphElementHolder.GetComponent<RectTransform>();
				lineageWindow.onViewportSizeChange.AddListener(UpdateViewportDimensions);
				UpdateViewportDimensions(lineageWindow.viewportDimensions);
				popupUp = false;
				PopupManager.onPopupPresent.AddListener(UpdatePopupUp);
				LineagePanelSettingsManager.hideExtinctLineages.Subscribe(UpdateHideExtinctLineages);
				LineagePanelSettingsManager.showLineagesOfFavorite.Subscribe(UpdateShowFavorites);
				hideExtinctLineages = LineagePanelSettingsManager.hideExtinctLineages.val;
				showFavorites = LineagePanelSettingsManager.showLineagesOfFavorite.val;
			}
		}

		private void UpdateViewportDimensions(Vector2 size)
		{
			viewportWidth = size.x;
			viewportHeight = size.y;
		}

		public override void OpenPanel()
		{
			base.OpenPanel();
			lineageWindow.SetDefaultStep(defaultStep);
			GenerateMesh();
		}

		public override void ClosePanel()
		{
			base.ClosePanel();
			ResetState();
		}

		public override void FillPanel()
		{
		}

		public override void ResetState()
		{
			foreach (LineageMesh item in activeLineageMeshes.ToList())
			{
				ReturnLineageMeshToPool(item);
			}
			foreach (KeyValuePair<Species, LineageMesh> speciesMesh in speciesMeshes)
			{
				speciesMesh.Deconstruct(out var _, out var value);
				value.Retire();
			}
			speciesMeshes.Clear();
		}

		private void UpdateHideExtinctLineages(bool val)
		{
			hideExtinctLineages = val;
			if (base.isActiveAndEnabled)
			{
				Species species = ((selectedMesh != null) ? selectedMesh.species : null);
				ResetState();
				GenerateMesh();
				if (species != null && speciesMeshes.ContainsKey(species))
				{
					SelectAndFocusSpecies(species);
				}
				else
				{
					SpeciesPanel.instance.SelectAndFocusSpecies(null);
				}
			}
		}

		private void UpdateShowFavorites(bool val)
		{
			showFavorites = val;
			if (base.isActiveAndEnabled)
			{
				Species species = ((selectedMesh != null) ? selectedMesh.species : null);
				ResetState();
				GenerateMesh();
				if (species != null && speciesMeshes.ContainsKey(species))
				{
					SelectAndFocusSpecies(species);
				}
				else
				{
					SpeciesPanel.instance.SelectAndFocusSpecies(null);
				}
			}
		}

		protected override void UpdatePanel()
		{
			PointerEventData pointerEventData = new PointerEventData(eventSystem)
			{
				position = Input.mousePosition
			};
			List<RaycastResult> list = new List<RaycastResult>();
			overlayRaycaster.Raycast(pointerEventData, list);
			bool flag = list.Count > 0;
			List<RaycastResult> list2 = new List<RaycastResult>();
			raycaster.Raycast(pointerEventData, list2);
			List<UIMeshEventHandler> interactedMeshes = new List<UIMeshEventHandler>();
			foreach (RaycastResult item in list2)
			{
				if (flag || popupUp)
				{
					break;
				}
				if ((4 & (1 << item.gameObject.layer)) <= 0)
				{
					UIMeshEventHandler component = item.gameObject.GetComponent<UIMeshEventHandler>();
					if (component == null)
					{
						break;
					}
					pointerEventData.pointerCurrentRaycast = item;
					if (component.CheckInteraction(pointerEventData))
					{
						interactedMeshes.Add(component);
					}
				}
			}
			lastInteractedMeshes.ForEach(delegate(UIMeshEventHandler m)
			{
				if (!interactedMeshes.Contains(m))
				{
					m.CheckExitBounds();
				}
			});
			lastInteractedMeshes = interactedMeshes;
		}

		public void SelectAndFocusSpecies(Species species = null)
		{
			if (base.isActiveAndEnabled)
			{
				if (selectedMesh != null)
				{
					selectedMesh.FocusMesh(val: false);
				}
				selectedMesh = activeLineageMeshes.FirstOrDefault((LineageMesh m) => m.species == species);
				if (!(selectedMesh == null))
				{
					graphTransform.position -= selectedMesh.centerPoint;
					selectedMesh.FocusMesh(val: true);
				}
			}
		}

		public void GenerateMesh()
		{
			List<Species> recordedSpecies = GlobalLineageManager.Instance.recordedSpecies.Where((Species s) => s.speciesData.totalIndexOfApparition != s.speciesData.totalIndexOfDisappearance).ToList();
			List<Species> list;
			if (hideExtinctLineages)
			{
				list = new List<Species>();
				List<Species> list2 = recordedSpecies.Where((Species s) => s.count > 0 || (showFavorites && s.favorite)).ToList();
				while (list2.Count > 0)
				{
					Species species = list2[0];
					while (species != null && !list.Contains(species))
					{
						list.Add(species);
						species = species.parentSpecies;
					}
					list2.RemoveAt(0);
				}
				list = list.OrderBy((Species s) => recordedSpecies.IndexOf(s)).ToList();
			}
			else
			{
				list = recordedSpecies;
			}
			if (list.Count < 1)
			{
				return;
			}
			maxN = list.Max((Species s) => s.speciesData.totalIndexOfApparition) + 1;
			float maxEnergy = GlobalLineageManager.Instance.maxEnergy;
			lineageWindow.SetMaxN(maxN);
			List<Species> list3 = list.Where((Species s) => s.speciesData.totalIndexOfDisappearance < 0).ToList();
			float num = list3.Sum((Species s) => s.energy);
			int totalRungCount = list3.Sum((Species s) => s.count);
			float num2 = (viewportWidth - 2f * sidePadding) * Mathf.Pow(3f, Mathf.Log10(num / maxEnergy));
			float num3 = (viewportWidth - 2f * sidePadding - num2) / 2f;
			foreach (Species item in list3)
			{
				LineageMesh meshOfSpecies = GetMeshOfSpecies(item);
				if (item.count < 1)
				{
					meshOfSpecies.AddBottomCap(num3, 0f, 0);
					continue;
				}
				float num4 = num2 * item.energy / num;
				SpeciesDataPoint value = new SpeciesDataPoint(item);
				meshOfSpecies.AddRung(0f, num3, num3 + num4, -1, value, num, totalRungCount);
				num3 += num4;
			}
			int i;
			for (i = 0; i <= maxN; i++)
			{
				float y = lineageWindow.HeightOfPoint(i);
				List<Species> list4 = list.Where((Species s) => s.speciesData.totalIndexOfDisappearance <= i && s.speciesData.totalIndexOfApparition + 1 >= i).ToList();
				num = list4.Sum((Species s) => s.speciesData[i].energy);
				totalRungCount = list4.Sum((Species s) => s.speciesData[i].count);
				num2 = (viewportWidth - 2f * sidePadding) * Mathf.Pow(3f, Mathf.Log10(num / maxEnergy));
				num3 = (viewportWidth - 2f * sidePadding - num2) / 2f;
				List<Species> list5 = new List<Species>();
				totalRungCount = Mathf.Max(1, totalRungCount);
				num = Mathf.Max(1f, num);
				foreach (Species item2 in list4)
				{
					LineageMesh meshOfSpecies2 = GetMeshOfSpecies(item2);
					if (item2.speciesData.totalIndexOfDisappearance == i)
					{
						meshOfSpecies2.AddBottomCap(num3, y, i);
						continue;
					}
					if (i == item2.speciesData.totalIndexOfApparition + 1)
					{
						meshOfSpecies2.AddTopCap(num3, y, i);
						list5.Add(meshOfSpecies2.species);
						continue;
					}
					SpeciesDataPoint value2 = item2.speciesData[i];
					float num5 = num2 * (value2.energy / num);
					meshOfSpecies2.AddRung(y, num3, num3 + num5, i, value2, num, totalRungCount);
					num3 += num5;
				}
				foreach (Species item3 in list5)
				{
					list.Remove(item3);
				}
			}
			foreach (var (species3, lineageMesh2) in speciesMeshes)
			{
				if (species3.parentSpecies != null && speciesMeshes.ContainsKey(species3.parentSpecies))
				{
					speciesMeshes[species3.parentSpecies].AddMaxFadeEnd(lineageMesh2.topHeight);
				}
				foreach (Species child in species3.children)
				{
					if (speciesMeshes.ContainsKey(child))
					{
						speciesMeshes[child].AddMaxFadeEnd(lineageMesh2.bottomHeight);
					}
				}
			}
			SpeciesPanel.instance.UpdateDisplayedSpecies((from s in speciesMeshes
				select s.Key into s
				orderby s.speciesData.totalIndexOfApparition descending
				select s).ToList());
			float num6 = Mathf.Max(lineageWindow.HeightOfPoint(maxN), viewportHeight);
			lineageWindow.SetDimension(null, num6);
			lineageWindow.SetMinMaxZoom(viewportHeight / num6, 1.5f);
		}

		private void OnDestroy()
		{
			LineagePanelSettingsManager.hideExtinctLineages.UnSubscribe(UpdateHideExtinctLineages);
			LineagePanelSettingsManager.showLineagesOfFavorite.UnSubscribe(UpdateShowFavorites);
			PopupManager.onPopupPresent.RemoveListener(UpdatePopupUp);
		}

		private LineageMesh GetMeshOfSpecies(Species species)
		{
			if (speciesMeshes.TryGetValue(species, out var value))
			{
				return value;
			}
			LineageMesh lineageMesh = RequestLineageMeshFromPool();
			lineageMesh.AssignSpecies(species);
			speciesMeshes.Add(species, lineageMesh);
			return lineageMesh;
		}

		private LineageMesh RequestLineageMeshFromPool()
		{
			if (lineageMeshPool.Count > 0)
			{
				LineageMesh lineageMesh = lineageMeshPool.First();
				lineageMeshPool.Remove(lineageMesh);
				activeLineageMeshes.Add(lineageMesh);
				lineageMesh.WakeUp();
				return lineageMesh;
			}
			LineageMesh component = Object.Instantiate(speciesMeshPrefab, lineageHolder.transform, worldPositionStays: false).GetComponent<LineageMesh>();
			component.InitializeUILineageMesh();
			activeLineageMeshes.Add(component);
			return component;
		}

		private void ReturnLineageMeshToPool(LineageMesh lineageMesh)
		{
			lineageMeshPool.Add(lineageMesh);
			activeLineageMeshes.Remove(lineageMesh);
			lineageMesh.Retire();
			lineageMesh.gameObject.SetActive(value: false);
		}
	}
}
