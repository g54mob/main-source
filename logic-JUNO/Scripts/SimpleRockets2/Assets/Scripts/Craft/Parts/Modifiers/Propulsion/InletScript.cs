using System;
using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using ModApi.Math;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public class InletScript : PartModifierScript<InletData>, IFlightStart, IGameLoopItem, IFlightUpdate
	{
		private InletAir _inletAir;

		private float _maxArea;

		private float _occlusion;

		private OcclusionSampler _occlusionSampler;

		private Vector3 _openDirection = Vector3.up;

		public override void FlightEnd()
		{
			base.FlightEnd();
			_inletAir = null;
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			ConfigureForFlight();
		}

		void IFlightUpdate.FlightUpdate(in FlightFrameData frame)
		{
			if (_occlusionSampler != null)
			{
				if (!base.PartScript.Data.PartDrag.IsOccluded)
				{
					IPartWaterPhysics waterPhysics = base.PartScript.WaterPhysics;
					if (waterPhysics == null || !(waterPhysics.UnderWaterAmount > 0f))
					{
						if (base.PartScript.Data.Config.OcclusionCalculation == OcclusionCalculationType.Never)
						{
							_occlusion = 0f;
						}
						else
						{
							_occlusionSampler.Update();
							if (_occlusionSampler.Ready)
							{
								_occlusion = _occlusionSampler.Occlusion;
							}
						}
						float air = _maxArea * (1f - _occlusion);
						_inletAir?.AddAir(air);
						return;
					}
				}
				_occlusion = 1f;
			}
			else
			{
				_occlusion = 0f;
			}
		}

		public override void OnCraftLoaded(ICraftScript craftScript, bool movedToNewCraft)
		{
			base.OnCraftLoaded(craftScript, movedToNewCraft);
			if (movedToNewCraft)
			{
				ConfigureForFlight();
			}
		}

		public override void OnCraftStructureChanged(ICraftScript craftScript)
		{
			base.OnCraftStructureChanged(craftScript);
			ConfigureForFlight();
		}

		public override void OnGenerateInspectorModel(PartInspectorModel model)
		{
			base.OnGenerateInspectorModel(model);
			if (_occlusionSampler != null)
			{
				model.Add(new TextModel("Occlusion", () => Units.GetPercentageString(_occlusion)));
			}
		}

		private void ConfigureForFlight()
		{
			FuselageScript modifier = base.PartScript.GetModifier<FuselageScript>();
			_maxArea = MathF.PI * modifier.Data.TopScale.x * modifier.Data.TopScale.y;
			_occlusionSampler = null;
			if (!base.PartScript.Disconnected)
			{
				AttachPoint attachPoint = base.PartScript.Data.GetAttachPoint("AttachPointTop");
				AttachPoint attachPoint2 = base.PartScript.Data.GetAttachPoint("AttachPointBottom");
				if (attachPoint == null || attachPoint.PartConnections.Count <= 0 || attachPoint2 == null || attachPoint2.PartConnections.Count <= 0)
				{
					if ((attachPoint2 != null && attachPoint2.PartConnections.Count > 0) || attachPoint2 == null)
					{
						CreateOcclusionSampler(modifier, reversed: false);
					}
					else if (attachPoint != null && attachPoint.PartConnections.Count > 0)
					{
						CreateOcclusionSampler(modifier, reversed: true);
					}
				}
			}
			FindInletAir();
		}

		private void CreateOcclusionSampler(FuselageScript fuselage, bool reversed)
		{
			Vector2 scale;
			Vector3 localCenter;
			Vector3 vector;
			if (reversed)
			{
				scale = new Vector2(fuselage.Data.BottomScale.x * 2f * 0.9f, fuselage.Data.BottomScale.y * 2f * 0.9f);
				localCenter = -fuselage.Data.Offset;
				vector = -_openDirection;
			}
			else
			{
				scale = new Vector2(fuselage.Data.TopScale.x * 2f * 0.9f, fuselage.Data.TopScale.y * 2f * 0.9f);
				localCenter = fuselage.Data.Offset;
				vector = _openDirection;
			}
			float num = Mathf.Min(fuselage.Data.Offset.y * 0.5f, 0.05f);
			localCenter -= num * vector;
			_occlusionSampler = new OcclusionSampler(scale, 5, base.transform, localCenter, vector);
			_occlusionSampler.MaxDistance = Mathf.Max(_maxArea, 1f) * 2f;
			_occlusionSampler.SkipCorners = true;
			if (base.PartScript.PrimaryCollider != null)
			{
				_occlusionSampler.IgnoreList.Add(base.PartScript.PrimaryCollider.gameObject);
			}
		}

		private void FindInletAir()
		{
			_inletAir = null;
			if (_occlusionSampler != null)
			{
				JetEngineScript jetEngineScript = FindJetEngine(base.PartScript.Data, new PartLookup());
				if (jetEngineScript != null)
				{
					_inletAir = jetEngineScript.DirectAir;
				}
				else if (!base.PartScript.Disconnected)
				{
					_inletAir = base.PartScript.CraftScript.InletAir;
				}
			}
		}

		private JetEngineScript FindJetEngine(PartData part, PartLookup partsVisited)
		{
			JetEngineScript modifier = part.PartScript.GetModifier<JetEngineScript>();
			if (modifier != null)
			{
				return modifier;
			}
			partsVisited.AddPart(part);
			foreach (PartConnection partConnection in part.PartConnections)
			{
				PartData otherPart = partConnection.GetOtherPart(part);
				if (!partsVisited.ContainsPart(otherPart) && otherPart.GetModifier<InletData>() != null)
				{
					modifier = FindJetEngine(otherPart, partsVisited);
					if (modifier != null)
					{
						return modifier;
					}
				}
			}
			return null;
		}
	}
}
