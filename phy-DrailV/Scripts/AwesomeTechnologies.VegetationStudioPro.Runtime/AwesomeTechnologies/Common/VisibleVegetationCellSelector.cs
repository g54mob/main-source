using System;
using System.Collections.Generic;
using AwesomeTechnologies.Utility.Culling;
using AwesomeTechnologies.VegetationSystem;
using UnityEngine;

namespace AwesomeTechnologies.Common
{
	public class VisibleVegetationCellSelector
	{
		public delegate void MultiOnVegetationCellVisibleDelegate(VegetationCell vegetationCell);

		public delegate void MultiOnVegetationCellInvisibleDelegate(VegetationCell vegetationCell);

		private VegetationSystemPro _vegetationSystemPro;

		public MultiOnVegetationCellVisibleDelegate OnVegetationCellVisibleDelegate;

		public MultiOnVegetationCellInvisibleDelegate OnVegetationCellInvisibleDelegate;

		[NonSerialized]
		public readonly List<SelectedVegetationCell> VisibleSelectorVegetationCellList = new List<SelectedVegetationCell>();

		public void Init(VegetationSystemPro vegetationSystemPro)
		{
			_vegetationSystemPro = vegetationSystemPro;
			VegetationSystemPro vegetationSystemPro2 = _vegetationSystemPro;
			vegetationSystemPro2.OnAddCameraDelegate = (VegetationSystemPro.MultiOnAddCameraDelegate)Delegate.Combine(vegetationSystemPro2.OnAddCameraDelegate, new VegetationSystemPro.MultiOnAddCameraDelegate(OnAddCamera));
			VegetationSystemPro vegetationSystemPro3 = _vegetationSystemPro;
			vegetationSystemPro3.OnAddCameraDelegate = (VegetationSystemPro.MultiOnAddCameraDelegate)Delegate.Combine(vegetationSystemPro3.OnAddCameraDelegate, new VegetationSystemPro.MultiOnAddCameraDelegate(OnRemoveCamera));
			AddVisibleVegetationCells();
		}

		private void AddVisibleVegetationCells()
		{
			for (int i = 0; i <= _vegetationSystemPro.VegetationStudioCameraList.Count - 1; i++)
			{
				VegetationStudioCamera vegetationStudioCamera = _vegetationSystemPro.VegetationStudioCameraList[i];
				OnAddCamera(vegetationStudioCamera);
			}
		}

		private SelectedVegetationCell GetSelectorVegetationCell(VegetationCell vegetationCell)
		{
			for (int i = 0; i <= VisibleSelectorVegetationCellList.Count - 1; i++)
			{
				if (VisibleSelectorVegetationCellList[i].VegetationCell == vegetationCell)
				{
					return VisibleSelectorVegetationCellList[i];
				}
			}
			return null;
		}

		private void AddVisisbleCellsFromCamera(VegetationStudioCamera vegetationStudioCamera)
		{
			JobCullingGroup jobCullingGroup = vegetationStudioCamera.JobCullingGroup;
			if (jobCullingGroup == null)
			{
				return;
			}
			for (int i = 0; i <= jobCullingGroup.VisibleCellIndexList.Length - 1; i++)
			{
				VegetationCell vegetationCell = vegetationStudioCamera.PotentialVisibleVegetationCellList[jobCullingGroup.VisibleCellIndexList[i]];
				SelectedVegetationCell selectorVegetationCell = GetSelectorVegetationCell(vegetationCell);
				if (selectorVegetationCell != null)
				{
					selectorVegetationCell.AddCameraReference(vegetationStudioCamera);
					continue;
				}
				selectorVegetationCell = new SelectedVegetationCell(vegetationCell, vegetationStudioCamera);
				VisibleSelectorVegetationCellList.Add(selectorVegetationCell);
				OnVegetationCellVisibleDelegate?.Invoke(selectorVegetationCell.VegetationCell);
			}
		}

		private void RemoveVisisbleCellsFromCamera(VegetationStudioCamera vegetationStudioCamera)
		{
			JobCullingGroup jobCullingGroup = vegetationStudioCamera.JobCullingGroup;
			if (jobCullingGroup == null)
			{
				return;
			}
			for (int i = 0; i <= jobCullingGroup.VisibleCellIndexList.Length - 1; i++)
			{
				VegetationCell vegetationCell = vegetationStudioCamera.PotentialVisibleVegetationCellList[jobCullingGroup.VisibleCellIndexList[i]];
				SelectedVegetationCell selectorVegetationCell = GetSelectorVegetationCell(vegetationCell);
				if (selectorVegetationCell != null)
				{
					selectorVegetationCell.RemoveCameraReference(vegetationStudioCamera);
					if (selectorVegetationCell.CameraCount == 0)
					{
						VisibleSelectorVegetationCellList.Remove(selectorVegetationCell);
						OnVegetationCellInvisibleDelegate?.Invoke(selectorVegetationCell.VegetationCell);
					}
				}
			}
		}

		private void OnAddCamera(VegetationStudioCamera vegetationStudioCamera)
		{
			vegetationStudioCamera.OnPotentialCellInvisibleDelegate = (VegetationStudioCamera.MultiOnVegetationCellVisibityChangedDelegate)Delegate.Combine(vegetationStudioCamera.OnPotentialCellInvisibleDelegate, new VegetationStudioCamera.MultiOnVegetationCellVisibityChangedDelegate(OnVegetationCellInvisible));
			vegetationStudioCamera.OnVegetationCellDistanceBandChangeDelegate = (VegetationStudioCamera.MultiOnVegetationDistanceBandChangeDelegate)Delegate.Combine(vegetationStudioCamera.OnVegetationCellDistanceBandChangeDelegate, new VegetationStudioCamera.MultiOnVegetationDistanceBandChangeDelegate(OnVegetationCellDistanceBandChanged));
			AddVisisbleCellsFromCamera(vegetationStudioCamera);
		}

		private void OnRemoveCamera(VegetationStudioCamera vegetationStudioCamera)
		{
			vegetationStudioCamera.OnPotentialCellInvisibleDelegate = (VegetationStudioCamera.MultiOnVegetationCellVisibityChangedDelegate)Delegate.Remove(vegetationStudioCamera.OnPotentialCellInvisibleDelegate, new VegetationStudioCamera.MultiOnVegetationCellVisibityChangedDelegate(OnVegetationCellInvisible));
			vegetationStudioCamera.OnVegetationCellDistanceBandChangeDelegate = (VegetationStudioCamera.MultiOnVegetationDistanceBandChangeDelegate)Delegate.Remove(vegetationStudioCamera.OnVegetationCellDistanceBandChangeDelegate, new VegetationStudioCamera.MultiOnVegetationDistanceBandChangeDelegate(OnVegetationCellDistanceBandChanged));
			RemoveVisisbleCellsFromCamera(vegetationStudioCamera);
		}

		public void DrawDebugGizmos()
		{
			for (int i = 0; i <= VisibleSelectorVegetationCellList.Count - 1; i++)
			{
				VegetationCell vegetationCell = VisibleSelectorVegetationCellList[i].VegetationCell;
				Gizmos.color = SelectVegetationCellGizmoColor(VisibleSelectorVegetationCellList[i].CameraCount);
				Gizmos.DrawWireCube(vegetationCell.VegetationCellBounds.center, vegetationCell.VegetationCellBounds.size);
			}
		}

		private static Color SelectVegetationCellGizmoColor(int count)
		{
			switch (count)
			{
			case 0:
				return Color.black;
			case 1:
				return Color.white;
			case 2:
				return Color.yellow;
			case 3:
				return Color.red;
			default:
				return Color.green;
			}
		}

		public void Dispose()
		{
			VegetationSystemPro vegetationSystemPro = _vegetationSystemPro;
			vegetationSystemPro.OnAddCameraDelegate = (VegetationSystemPro.MultiOnAddCameraDelegate)Delegate.Remove(vegetationSystemPro.OnAddCameraDelegate, new VegetationSystemPro.MultiOnAddCameraDelegate(OnAddCamera));
			VegetationSystemPro vegetationSystemPro2 = _vegetationSystemPro;
			vegetationSystemPro2.OnAddCameraDelegate = (VegetationSystemPro.MultiOnAddCameraDelegate)Delegate.Remove(vegetationSystemPro2.OnAddCameraDelegate, new VegetationSystemPro.MultiOnAddCameraDelegate(OnRemoveCamera));
			for (int i = 0; i <= _vegetationSystemPro.VegetationStudioCameraList.Count - 1; i++)
			{
				OnRemoveCamera(_vegetationSystemPro.VegetationStudioCameraList[i]);
			}
		}

		private void OnVegetationCellDistanceBandChanged(VegetationStudioCamera vegetationStudioCamera, VegetationCell vegetationCell, int currentDistanceBand, int previousDistanceBand)
		{
			if (currentDistanceBand == 0)
			{
				OnVegetationCellVisible(vegetationStudioCamera, vegetationCell);
			}
			else if (previousDistanceBand == 0)
			{
				OnVegetationCellInvisible(vegetationStudioCamera, vegetationCell);
			}
		}

		private void OnVegetationCellVisible(VegetationStudioCamera vegetationStudioCamera, VegetationCell vegetationCell)
		{
			SelectedVegetationCell selectorVegetationCell = GetSelectorVegetationCell(vegetationCell);
			if (selectorVegetationCell != null)
			{
				selectorVegetationCell.AddCameraReference(vegetationStudioCamera);
				return;
			}
			selectorVegetationCell = new SelectedVegetationCell(vegetationCell, vegetationStudioCamera);
			VisibleSelectorVegetationCellList.Add(selectorVegetationCell);
			OnVegetationCellVisibleDelegate?.Invoke(selectorVegetationCell.VegetationCell);
		}

		private void OnVegetationCellInvisible(VegetationStudioCamera vegetationStudioCamera, VegetationCell vegetationCell)
		{
			SelectedVegetationCell selectorVegetationCell = GetSelectorVegetationCell(vegetationCell);
			if (selectorVegetationCell != null)
			{
				selectorVegetationCell.RemoveCameraReference(vegetationStudioCamera);
				if (selectorVegetationCell.CameraCount == 0)
				{
					VisibleSelectorVegetationCellList.Remove(selectorVegetationCell);
					OnVegetationCellInvisibleDelegate?.Invoke(selectorVegetationCell.VegetationCell);
				}
			}
		}
	}
}
