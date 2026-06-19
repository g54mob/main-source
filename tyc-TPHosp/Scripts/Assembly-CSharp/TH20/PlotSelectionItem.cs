using System;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class PlotSelectionItem : MonoBehaviour
	{
		[SerializeField]
		private Button _button;

		[SerializeField]
		private TMP_Text _text;

		[SerializeField]
		private Toggle _toggleState;

		[SerializeField]
		private Toggle _toggleVisible;

		[SerializeField]
		private Toggle _toggleLayerBase;

		[SerializeField]
		private Toggle _toggleLayerBuilt;

		[SerializeField]
		private Toggle _toggleLayerUnbuilt;

		private HospitalPlot _plot;

		private HospitalEditEvents _hospitalEditEvents;

		private Color _selectedColor;

		private Color _deselectedColor;

		public void Setup(HospitalPlot hospitalPlot, bool startSelected, HospitalEditEvents hospitalEditEvents, Color[] layerColors)
		{
			_plot = hospitalPlot;
			_hospitalEditEvents = hospitalEditEvents;
			_selectedColor = _button.targetGraphic.color;
			_deselectedColor = _button.targetGraphic.color * 0.75f;
			OnSelectHospitalPlot(startSelected ? _plot : null);
			_text.text = _plot.Definition.NameLocalised.Translation;
			_button.onClick.AddListener(delegate
			{
				_hospitalEditEvents.OnSelectHospitalPlot.InvokeSafe(_plot);
			});
			_toggleLayerBase.targetGraphic.color = layerColors[0];
			_toggleLayerBuilt.targetGraphic.color = layerColors[1];
			_toggleLayerUnbuilt.targetGraphic.color = layerColors[2];
			_toggleVisible.onValueChanged.AddListener(delegate(bool visible)
			{
				_hospitalEditEvents.OnSetHospitalPlotVisible.InvokeSafe(_plot, visible);
			});
			_toggleLayerBase.onValueChanged.AddListener(delegate(bool visible)
			{
				SetPlotLayerVisible(HospitalPlotLayer.Base, visible);
			});
			_toggleLayerBuilt.onValueChanged.AddListener(delegate(bool visible)
			{
				SetPlotLayerVisible(HospitalPlotLayer.Built, visible);
			});
			_toggleLayerUnbuilt.onValueChanged.AddListener(delegate(bool visible)
			{
				SetPlotLayerVisible(HospitalPlotLayer.Unbuilt, visible);
			});
			_toggleState.onValueChanged.AddListener(delegate(bool bought)
			{
				_hospitalEditEvents.OnHospitalPlotStateChanging.InvokeSafe(_plot, param2: true);
				_hospitalEditEvents.OnSetHospitalPlotState.InvokeSafe(_plot, bought);
				_hospitalEditEvents.OnHospitalPlotStateChanging.InvokeSafe(_plot, param2: false);
			});
			ColorBlock colors = _button.colors;
			Color color = _plot.Definition.Color;
			colors.highlightedColor = Color.Lerp(color, Color.white, 0.25f);
			colors.normalColor = color;
			colors.pressedColor = Color.Lerp(Color.black, color, 0.8f);
			colors.disabledColor = Color.Lerp(Color.black, color, 0.5f);
			_button.colors = colors;
			HospitalEditEvents hospitalEditEvents2 = _hospitalEditEvents;
			hospitalEditEvents2.OnSelectHospitalPlot = (Action<HospitalPlot>)Delegate.Combine(hospitalEditEvents2.OnSelectHospitalPlot, new Action<HospitalPlot>(OnSelectHospitalPlot));
		}

		private void OnDestroy()
		{
			HospitalEditEvents hospitalEditEvents = _hospitalEditEvents;
			hospitalEditEvents.OnSelectHospitalPlot = (Action<HospitalPlot>)Delegate.Remove(hospitalEditEvents.OnSelectHospitalPlot, new Action<HospitalPlot>(OnSelectHospitalPlot));
		}

		private void OnSelectHospitalPlot(HospitalPlot hospitalPlot)
		{
			Color color = ((_plot == hospitalPlot) ? _selectedColor : _deselectedColor);
			_text.color = color;
			_button.targetGraphic.color = color;
		}

		private void SetPlotLayerVisible(HospitalPlotLayer layer, bool visible)
		{
			_hospitalEditEvents.OnHospitalPlotStateChanging.InvokeSafe(_plot, param2: true);
			_hospitalEditEvents.OnSetHospitalPlotLayerVisible.InvokeSafe(_plot, layer, visible);
			_hospitalEditEvents.OnHospitalPlotStateChanging.InvokeSafe(_plot, param2: false);
		}
	}
}
