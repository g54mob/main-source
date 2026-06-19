using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class EditHospitalMenu : MenuBase
	{
		[SerializeField]
		private Button _quitButton;

		[SerializeField]
		private Button _tileMapPreviewButton;

		[SerializeField]
		private Button _buildButton;

		[SerializeField]
		private Button _objectsButton;

		[SerializeField]
		private Button _moveButton;

		[SerializeField]
		private Button _toggleCameraButton;

		[SerializeField]
		private Transform _plotSelectionRoot;

		[SerializeField]
		private TMP_Dropdown _plotLayerDropdown;

		[SerializeField]
		private GameObject _plotSelectionButtonPrefab;

		[SerializeField]
		private Transform _tileSelectionRoot;

		[SerializeField]
		private GameObject _tileSelectionButtonPrefab;

		[SerializeField]
		private TMP_Text _infoText;

		[SerializeField]
		private UILineRenderer _editFrame;

		[SerializeField]
		private Color[] _editFrameColors;

		private HospitalEditEvents _hospitalEditEvents;

		public void Setup(Level level)
		{
			_hospitalEditEvents = level.HospitalEditEvents;
			_infoText.text = "...";
			_tileSelectionRoot.gameObject.SetActive(value: false);
			_quitButton.onClick.AddListener(delegate
			{
				_hospitalEditEvents.OnEnd.InvokeSafe();
			});
			_tileMapPreviewButton.onClick.AddListener(delegate
			{
				_hospitalEditEvents.OnTileMapPreviewToggle.InvokeSafe();
			});
			_buildButton.onClick.AddListener(delegate
			{
				_hospitalEditEvents.OnBeginBuilding.InvokeSafe();
			});
			_moveButton.onClick.AddListener(delegate
			{
				_hospitalEditEvents.OnBeginMovePlot.InvokeSafe();
			});
			_objectsButton.onClick.AddListener(delegate
			{
				_hospitalEditEvents.OnBeginItemPlacement.InvokeSafe();
			});
			_toggleCameraButton.onClick.AddListener(delegate
			{
				level.CameraLogic.ToggleCameraBounds();
			});
			if (level.WorldState.ShouldCreateBaseLandscapeItems())
			{
				_objectsButton.interactable = true;
			}
			else
			{
				_objectsButton.interactable = false;
				_objectsButton.GetComponentInChildren<TMP_Text>().text = "Items Locked";
			}
			HospitalEditEvents hospitalEditEvents = _hospitalEditEvents;
			hospitalEditEvents.OnEndBuilding = (Action)Delegate.Combine(hospitalEditEvents.OnEndBuilding, new Action(OnEndBuilding));
			HospitalEditEvents hospitalEditEvents2 = _hospitalEditEvents;
			hospitalEditEvents2.OnBeginBuilding = (Action)Delegate.Combine(hospitalEditEvents2.OnBeginBuilding, new Action(OnBeginBuilding));
			HospitalEditEvents hospitalEditEvents3 = _hospitalEditEvents;
			hospitalEditEvents3.OnSelectHospitalPlot = (Action<HospitalPlot>)Delegate.Combine(hospitalEditEvents3.OnSelectHospitalPlot, new Action<HospitalPlot>(OnHospitalPlotUpdated));
			HospitalEditEvents hospitalEditEvents4 = _hospitalEditEvents;
			hospitalEditEvents4.OnSelectHospitalPlotLayer = (Action<HospitalPlotLayer>)Delegate.Combine(hospitalEditEvents4.OnSelectHospitalPlotLayer, new Action<HospitalPlotLayer>(OnSelectHospitalPlotLayer));
			HospitalEditEvents hospitalEditEvents5 = _hospitalEditEvents;
			hospitalEditEvents5.OnHospitalPlotUpdated = (Action<HospitalPlot>)Delegate.Combine(hospitalEditEvents5.OnHospitalPlotUpdated, new Action<HospitalPlot>(OnHospitalPlotUpdated));
			for (int num = 0; num < level.WorldState.HospitalPlots.Count; num++)
			{
				HospitalPlot hospitalPlot = level.WorldState.HospitalPlots[num];
				UnityEngine.Object.Instantiate(_plotSelectionButtonPrefab, _plotSelectionRoot, worldPositionStays: false).GetComponent<PlotSelectionItem>().Setup(hospitalPlot, num == 0, _hospitalEditEvents, _editFrameColors);
				if (num == 0)
				{
					OnHospitalPlotUpdated(hospitalPlot);
				}
			}
			for (int num2 = 0; num2 < 7; num2++)
			{
				HospitalMapTile.Type tileType = (HospitalMapTile.Type)num2;
				GameObject obj = UnityEngine.Object.Instantiate(_tileSelectionButtonPrefab, _tileSelectionRoot, worldPositionStays: false);
				Button component = obj.GetComponent<Button>();
				obj.GetComponentInChildren<TMP_Text>().text = tileType.ToString();
				component.onClick.AddListener(delegate
				{
					_hospitalEditEvents.OnTileTypeSelected.InvokeSafe(tileType);
				});
			}
			List<string> list = new List<string>();
			foreach (HospitalPlotLayer value in Enum.GetValues(typeof(HospitalPlotLayer)))
			{
				list.Add(value.ToString());
			}
			_plotLayerDropdown.ClearOptions();
			_plotLayerDropdown.AddOptions(list);
			_plotLayerDropdown.onValueChanged.AddListener(delegate(int layer)
			{
				_hospitalEditEvents.OnSelectHospitalPlotLayer.InvokeSafe((HospitalPlotLayer)layer);
			});
		}

		public override void Destroy()
		{
			HospitalEditEvents hospitalEditEvents = _hospitalEditEvents;
			hospitalEditEvents.OnEndBuilding = (Action)Delegate.Remove(hospitalEditEvents.OnEndBuilding, new Action(OnEndBuilding));
			HospitalEditEvents hospitalEditEvents2 = _hospitalEditEvents;
			hospitalEditEvents2.OnBeginBuilding = (Action)Delegate.Remove(hospitalEditEvents2.OnBeginBuilding, new Action(OnBeginBuilding));
			HospitalEditEvents hospitalEditEvents3 = _hospitalEditEvents;
			hospitalEditEvents3.OnSelectHospitalPlot = (Action<HospitalPlot>)Delegate.Remove(hospitalEditEvents3.OnSelectHospitalPlot, new Action<HospitalPlot>(OnHospitalPlotUpdated));
			HospitalEditEvents hospitalEditEvents4 = _hospitalEditEvents;
			hospitalEditEvents4.OnSelectHospitalPlotLayer = (Action<HospitalPlotLayer>)Delegate.Remove(hospitalEditEvents4.OnSelectHospitalPlotLayer, new Action<HospitalPlotLayer>(OnSelectHospitalPlotLayer));
			HospitalEditEvents hospitalEditEvents5 = _hospitalEditEvents;
			hospitalEditEvents5.OnHospitalPlotUpdated = (Action<HospitalPlot>)Delegate.Remove(hospitalEditEvents5.OnHospitalPlotUpdated, new Action<HospitalPlot>(OnHospitalPlotUpdated));
		}

		private void OnEndBuilding()
		{
			_tileSelectionRoot.gameObject.SetActive(value: false);
		}

		private void OnBeginBuilding()
		{
			_tileSelectionRoot.gameObject.SetActive(value: true);
		}

		private void OnHospitalPlotUpdated(HospitalPlot plot)
		{
			if (plot.HospitalMap != null)
			{
				int num = plot.HospitalMap.FloorPlan.TileCount * MathUtils.Square(2);
				_infoText.text = $"Plot Size: {num} m2";
			}
		}

		private void OnSelectHospitalPlotLayer(HospitalPlotLayer layer)
		{
			_editFrame.color = _editFrameColors[(int)layer];
		}
	}
}
