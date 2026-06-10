using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.BuildingComponents;
using NSMedieval.Construction;
using NSMedieval.Enums;
using NSMedieval.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	[Serializable]
	public class SelectionExtraMeshVariation : SelectionExtraWindowView
	{
		[SerializeField]
		private LayoutGroupView variationsContent;

		[SerializeField]
		private Button rotateLeft;

		[SerializeField]
		private Button rotateRight;

		[SerializeField]
		private Button rotate180;

		[SerializeField]
		private Button flipX;

		[SerializeField]
		private Button flipZ;

		[SerializeField]
		private InvertGateDirectionEntry defaultGateDirection;

		[SerializeField]
		private InvertGateDirectionEntry invertGateDirection;

		[SerializeField]
		private Color bgColorLighter;

		[SerializeField]
		private CustomToggle automaticMeshVariationLoadingToggle;

		[SerializeField]
		private GameObject automaticMeshVariationLoadingParent;

		private InfoPanelMeshVariations infoPanelMeshVariations;

		private List<MeshVariation> meshVariations;

		private List<MeshVariationList> listByEntryIndex = new List<MeshVariationList>();

		private List<MeshVariationListEntry> meshVariationEntries = new List<MeshVariationListEntry>();

		private List<BaseBuildingInstance> selectedObjects = new List<BaseBuildingInstance>();

		private bool automaticMeshLoading;

		private bool canRotate;

		private bool canRotate180;

		private bool canFlipX;

		private bool canFlipZ;

		private bool canInvertGateRotation;

		public void UpdatePanel(InfoPanelMeshVariations infoPanelMeshVariations)
		{
			this.infoPanelMeshVariations = infoPanelMeshVariations;
			meshVariations = GetMeshVariationsFromSelection();
			automaticMeshLoading = selectedObjects.Any((BaseBuildingInstance x) => x.AutomaticMeshVariationLoading);
			automaticMeshVariationLoadingToggle.SetIsOnWithoutNotify(automaticMeshLoading);
			SetupInvertGateRotationButton();
			Show();
			SetupMeshVariations();
			SetupButtons();
		}

		public override void Hide()
		{
			base.Hide();
			selectedObjects?.Clear();
			meshVariations?.Clear();
			listByEntryIndex?.Clear();
		}

		private List<MeshVariation> GetMeshVariationsFromSelection()
		{
			selectedObjects.Clear();
			listByEntryIndex.Clear();
			canRotate180 = true;
			canRotate = true;
			canFlipX = true;
			canFlipZ = true;
			List<MeshVariation> list = new List<MeshVariation>();
			HashSet<string> hashSet = new HashSet<string>();
			foreach (BaseBuildingInstance item in infoPanelMeshVariations.Selection)
			{
				if (item?.Blueprint == null)
				{
					continue;
				}
				if (!item.Blueprint.MeshVariationCanRotate180)
				{
					canRotate180 = false;
				}
				if (!item.Blueprint.MeshVariationCanRotate)
				{
					canRotate = false;
				}
				if (!item.Blueprint.MeshVariationCanFlipX)
				{
					canFlipX = false;
				}
				if (!item.Blueprint.MeshVariationCanFlipZ)
				{
					canFlipZ = false;
				}
				selectedObjects.Add(item);
				foreach (MeshVariationList variationList in item.Blueprint.VariationLists)
				{
					if (variationList.HideInUI)
					{
						continue;
					}
					foreach (MeshVariation variation in variationList.Variations)
					{
						if (hashSet.Add(variation.Name))
						{
							list.Add(variation);
							listByEntryIndex.Add(variationList);
						}
					}
				}
			}
			return list;
		}

		private void SetupButtons()
		{
			automaticMeshVariationLoadingToggle.onValueChanged.RemoveAllListeners();
			automaticMeshVariationLoadingToggle.onValueChanged.AddListener(OnAutomaticMeshVariationLoadingToggle);
			automaticMeshVariationLoadingParent.gameObject.SetActive(selectedObjects.Any((BaseBuildingInstance item) => !item.HasDisposed && !item.Blueprint.HideAutomaticMeshCheckbox));
			rotateLeft.onClick.RemoveAllListeners();
			rotateRight.onClick.RemoveAllListeners();
			rotate180.onClick.RemoveAllListeners();
			flipX.onClick.RemoveAllListeners();
			flipZ.onClick.RemoveAllListeners();
			defaultGateDirection.Toggle.onClick.RemoveAllListeners();
			invertGateDirection.Toggle.onClick.RemoveAllListeners();
			rotateLeft.gameObject.SetActive(canRotate);
			rotateRight.gameObject.SetActive(canRotate);
			rotate180.gameObject.SetActive(canRotate180);
			if (canRotate)
			{
				rotateLeft.onClick.AddListener(delegate
				{
					foreach (BaseBuildingInstance selectedObject in selectedObjects)
					{
						if (selectedObject != null && !selectedObject.HasDisposed)
						{
							selectedObject.AddToMeshRotation(90f);
						}
					}
					automaticMeshVariationLoadingToggle.SetValue(isOn: false);
				});
				rotateRight.onClick.AddListener(delegate
				{
					foreach (BaseBuildingInstance selectedObject2 in selectedObjects)
					{
						if (selectedObject2 != null && !selectedObject2.HasDisposed)
						{
							selectedObject2.AddToMeshRotation(-90f);
						}
					}
					automaticMeshVariationLoadingToggle.SetValue(isOn: false);
				});
			}
			if (canRotate180)
			{
				rotate180.onClick.AddListener(delegate
				{
					foreach (BaseBuildingInstance selectedObject3 in selectedObjects)
					{
						if (selectedObject3 != null && !selectedObject3.HasDisposed)
						{
							selectedObject3.AddToMeshRotation(180f);
						}
					}
					automaticMeshVariationLoadingToggle.SetValue(isOn: false);
				});
			}
			if (!canFlipX)
			{
				flipX.gameObject.SetActive(value: false);
			}
			else
			{
				flipX.gameObject.SetActive(value: true);
				flipX.onClick.AddListener(delegate
				{
					foreach (BaseBuildingInstance selectedObject4 in selectedObjects)
					{
						if (selectedObject4 != null && !selectedObject4.HasDisposed)
						{
							selectedObject4.MeshVariationFlipX();
						}
					}
					automaticMeshVariationLoadingToggle.SetValue(isOn: false);
				});
			}
			if (!canFlipZ)
			{
				flipZ.gameObject.SetActive(value: false);
			}
			else
			{
				flipZ.gameObject.SetActive(value: true);
				flipZ.onClick.AddListener(delegate
				{
					foreach (BaseBuildingInstance selectedObject5 in selectedObjects)
					{
						if (selectedObject5 != null && !selectedObject5.HasDisposed)
						{
							selectedObject5.MeshVariationFlipZ();
						}
					}
					automaticMeshVariationLoadingToggle.SetValue(isOn: false);
				});
			}
			if (!canInvertGateRotation)
			{
				defaultGateDirection.gameObject.SetActive(value: false);
				invertGateDirection.gameObject.SetActive(value: false);
				return;
			}
			defaultGateDirection.gameObject.SetActive(value: true);
			defaultGateDirection.Toggle.onClick.AddListener(delegate
			{
				foreach (BaseBuildingInstance selectedObject6 in selectedObjects)
				{
					if (selectedObject6 != null && !selectedObject6.HasDisposed)
					{
						selectedObject6.GetComponentInstance<DoorComponentInstance>()?.SetDefaultGateDirection();
					}
				}
				SetupGateDirectionInversionCheckbox();
			});
			invertGateDirection.gameObject.SetActive(value: true);
			invertGateDirection.Toggle.onClick.AddListener(delegate
			{
				foreach (BaseBuildingInstance selectedObject7 in selectedObjects)
				{
					if (selectedObject7 != null && !selectedObject7.HasDisposed)
					{
						selectedObject7.GetComponentInstance<DoorComponentInstance>()?.InvertGateDirection();
					}
				}
				SetupGateDirectionInversionCheckbox();
			});
		}

		private void RefreshCheckboxes()
		{
			for (int i = 0; i < meshVariations.Count; i++)
			{
				MeshVariation meshVariation = meshVariations[i];
				MeshVariationListEntry meshVariationListEntry = meshVariationEntries[i];
				MeshVariationList hasList = listByEntryIndex[i];
				if (meshVariationEntries.Count > i && meshVariation != null && !(meshVariationListEntry == null))
				{
					bool flag = IsAppliedOnOne(meshVariation, hasList);
					bool flag2 = false;
					if (flag)
					{
						flag2 = IsAppliedOnAll(meshVariation, hasList);
					}
					meshVariationListEntry.SetCheckboxGraphic(flag, !flag2);
				}
			}
		}

		private bool IsAppliedOnAll(MeshVariation meshVariation, MeshVariationList hasList)
		{
			int i = 0;
			for (int count = selectedObjects.Count; i < count; i++)
			{
				BaseBuildingInstance baseBuildingInstance = selectedObjects[i];
				if (!baseBuildingInstance.Blueprint.VariationsSet.Contains(hasList))
				{
					return false;
				}
				bool flag = false;
				IReadOnlyList<string> variationsApplied = baseBuildingInstance.VariationsApplied;
				int j = 0;
				for (int count2 = variationsApplied.Count; j < count2; j++)
				{
					if (variationsApplied[j].Equals(meshVariation.Name))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			return true;
		}

		private bool IsAppliedOnOne(MeshVariation meshVariation, MeshVariationList hasList)
		{
			foreach (BaseBuildingInstance selectedObject in selectedObjects)
			{
				if (selectedObject.Blueprint.VariationsSet.Contains(hasList) && selectedObject.IsMeshVariationApplied(meshVariation))
				{
					return true;
				}
			}
			return false;
		}

		private void SetupGateDirectionInversionCheckbox()
		{
			bool flag = IsGateDirectionAppliedOnOne(GateDirection.Default);
			bool flag2 = false;
			if (flag)
			{
				flag2 = IsGateDirectionAppliedOnAll(GateDirection.Default);
			}
			defaultGateDirection.SetCheckboxGraphic(flag, !flag2);
			bool flag3 = IsGateDirectionAppliedOnOne(GateDirection.Inverted);
			bool flag4 = false;
			if (flag3)
			{
				flag4 = IsGateDirectionAppliedOnAll(GateDirection.Inverted);
			}
			invertGateDirection.SetCheckboxGraphic(flag3, !flag4);
		}

		private void SetupInvertGateRotationButton()
		{
			canInvertGateRotation = true;
			foreach (BaseBuildingInstance selectedObject in selectedObjects)
			{
				DoorComponentInstance componentInstance = selectedObject.GetComponentInstance<DoorComponentInstance>();
				if (componentInstance == null || componentInstance.HasDisposed || componentInstance.Blueprint.DoorType == DoorType.Regular)
				{
					canInvertGateRotation = false;
					break;
				}
			}
			if (canInvertGateRotation)
			{
				SetupGateDirectionInversionCheckbox();
			}
		}

		private bool IsGateDirectionAppliedOnAll(GateDirection gateDirection)
		{
			if (!canInvertGateRotation)
			{
				return false;
			}
			bool result = true;
			foreach (BaseBuildingInstance selectedObject in selectedObjects)
			{
				DoorComponentInstance componentInstance = selectedObject.GetComponentInstance<DoorComponentInstance>();
				if (componentInstance != null && !componentInstance.HasDisposed && componentInstance.Blueprint.CanChangeDirection && componentInstance.GateDirection != gateDirection)
				{
					result = false;
					break;
				}
			}
			return result;
		}

		private bool IsGateDirectionAppliedOnOne(GateDirection gateDirection)
		{
			if (!canInvertGateRotation)
			{
				return false;
			}
			bool result = false;
			foreach (BaseBuildingInstance selectedObject in selectedObjects)
			{
				DoorComponentInstance componentInstance = selectedObject.GetComponentInstance<DoorComponentInstance>();
				if (componentInstance != null && !componentInstance.HasDisposed && componentInstance.Blueprint.CanChangeDirection && componentInstance.GateDirection == gateDirection)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		private void SetupMeshVariations()
		{
			int num = 0;
			foreach (MeshVariation meshVariation in meshVariations)
			{
				MeshVariationListEntry entry = meshVariationEntries.GetAt(variationsContent, num);
				entry.Init(meshVariation, bgColorLighter, listByEntryIndex[num]);
				entry.Toggle.onClick.RemoveAllListeners();
				entry.Toggle.onClick.AddListener(delegate
				{
					foreach (BaseBuildingInstance selectedObject in selectedObjects)
					{
						if (selectedObject.Blueprint.ContainsMeshVariation(entry.Variation.Name))
						{
							selectedObject.RemoveMeshVariation(entry.MeshVariationList);
							selectedObject.ApplyMeshVariation(entry.Variation);
						}
					}
					automaticMeshVariationLoadingToggle.SetValue(isOn: false);
					RefreshCheckboxes();
					MonoSingleton<AudioManager>.Instance?.PlaySound("UI_ButtonClick");
				});
				num++;
			}
			meshVariationEntries.SetActiveFromIndex(num, active: false);
			RefreshCheckboxes();
		}

		private void OnAutomaticMeshVariationLoadingToggle(bool toggleValue)
		{
			foreach (BaseBuildingInstance selectedObject in selectedObjects)
			{
				selectedObject.ToggleAutomaticMeshVariationLoading(toggleValue);
				if (toggleValue)
				{
					if (selectedObject.BuildingType == BuildingType.Fence)
					{
						selectedObject.Map.FenceAutomaticMeshVariationManager.RefreshMeshVariations(selectedObject);
					}
					else if (selectedObject.BuildingType == BuildingType.Wall)
					{
						selectedObject.Map.WallAutomaticMeshVariationManager.RefreshMeshVariations(selectedObject);
					}
					else if (selectedObject.BuildingType == BuildingType.Floor)
					{
						selectedObject.Map.FloorAutomaticMeshVariationManager.RefreshMeshVariations(selectedObject);
					}
					else if (selectedObject.BuildingType == BuildingType.Roof)
					{
						selectedObject.Map.RoofMeshVariationManager.RefreshMeshVariations(selectedObject);
					}
					else if (selectedObject.BuildingType == BuildingType.Merlon)
					{
						selectedObject.Map.MerlonRotationManager.RefreshMeshVariations(selectedObject);
					}
				}
			}
		}
	}
}
