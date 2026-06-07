using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using ModApi;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Solar
{
	public class SolarPanelScript : PartModifierScript<SolarPanelData>, IAnalyzePerformance, IFlightUpdate, IGameLoopItem
	{
		private float _area;

		private IFuelSource _battery;

		private float _efficiency;

		private Mesh _mesh;

		private Transform _panel;

		private float _rechargeEfficiency;

		private float _rechargeRate;

		public bool UsesMachNumber => false;

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			_rechargeRate = 0f;
			_rechargeEfficiency = 0f;
			if (base.PartScript.CommandPod != null && _battery != null)
			{
				ICraftFlightData flightData = base.PartScript.CraftScript.FlightData;
				_efficiency = base.Data.Efficiency;
				_rechargeRate = (float)flightData.SolarRadiationIntensity * _efficiency * _area;
				if (_rechargeRate > 0f)
				{
					_rechargeEfficiency = Mathf.Max(0f, Vector3.Dot(_panel.up, -flightData.SolarRadiationFrameDirection));
					_rechargeRate *= _rechargeEfficiency;
				}
				else
				{
					_rechargeEfficiency = 0f;
				}
				_battery.AddFuel((double)_rechargeRate * frame.DeltaTimeWorld * 0.0010000000474974513);
			}
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			base.OnCraftLoaded(craftScript, movedToNewCraft);
			OnCraftStructureChanged(craftScript);
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			_battery = base.PartScript.BatteryFuelSource;
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			model.Add(new TextModel("Recharge Rate", () => Units.GetPowerString(_rechargeRate)));
			model.Add(new TextModel("Pointing Efficiency", () => Units.GetPercentageString(_rechargeEfficiency)));
			model.Add(new TextModel("Panel Efficiency", () => Units.GetPercentageString(_efficiency)));
		}

		public void OnGeneratePerformanceAnalysisModel(GroupModel groupModel)
		{
			groupModel.Add(new TextModel("Panel Efficiency", () => Units.GetPercentageString(base.Data.Efficiency), null, "The efficiency of the solar panel."));
			groupModel.Add(new TextModel("Peak Power", () => Units.GetPowerString((float)((double)(base.Data.Efficiency * _area) * MathUtils.SolarEnergyFlux(Game.Instance.Designer.PerformanceAnalysis.Star, Math.Pow(Game.Instance.Designer.PerformanceAnalysis.StarDistance, 2.0)))), null, "The peak power generated when facing the sun directly in the selected planet."));
		}

		public void UpdateScale()
		{
			foreach (AttachPointScript attachPointScript in base.PartScript.AttachPointScripts)
			{
				attachPointScript.AttachPoint.Scale = 1f * Mathf.Min(base.Data.Width, base.Data.Length);
			}
			float x = base.Data.Width / _panel.localScale.x;
			float y = base.Data.Length / _panel.localScale.z;
			MultiplyDetailUvs(x, y);
			_panel.localScale = new Vector3(base.Data.Width, _panel.localScale.y, base.Data.Length);
			_area = base.Data.CalculatePanelArea();
		}

		protected override void OnInitialized()
		{
			Setup();
			UpdateScale();
		}

		private void MultiplyDetailUvs(float x, float y)
		{
			List<Vector4> list = new List<Vector4>();
			_mesh.GetUVs(0, list);
			for (int i = 0; i < list.Count; i++)
			{
				Vector4 value = list[i];
				value.x *= x;
				value.y *= y;
				list[i] = value;
			}
			_mesh.SetUVs(0, list);
		}

		private void Setup()
		{
			_panel = Utilities.FindFirstGameObjectMyselfOrChildren("Panel", base.gameObject).transform;
			_mesh = _panel.GetComponentInChildren<MeshFilter>().mesh;
		}
	}
}
