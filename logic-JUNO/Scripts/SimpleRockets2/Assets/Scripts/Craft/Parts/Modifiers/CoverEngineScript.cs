using Assets.Scripts.Craft.Parts.Modifiers.Fuselage;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class CoverEngineScript : PartModifierScript<CoverEngineData>, IDesignerStart, IGameLoopItem
	{
		private FuselageScript _fuselage;

		void IDesignerStart.DesignerStart(in DesignerFrameData frame)
		{
			_fuselage = base.PartScript.GetModifier<FuselageScript>();
		}

		public override void OnConnectedToPart(PartConnectedEventData e)
		{
			if (!base.Data.CoverEngine || !(_fuselage != null) || e.IsProcessingSymmetry)
			{
				return;
			}
			AttachPoint attachPoint = _fuselage.PartScript.Data.GetAttachPoint("AttachPointBottom");
			AttachPoint attachPoint2 = _fuselage.PartScript.Data.GetAttachPoint("AttachPointBottomLoad");
			if (attachPoint.PartConnections.Count == 0 && attachPoint2.PartConnections.Count == 0)
			{
				GameObject connectedEngine = GetConnectedEngine(e);
				if (connectedEngine != null)
				{
					Bounds bounds = Utilities.CalculateBounds(connectedEngine);
					Vector3 position = attachPoint.AttachPointScript.transform.position;
					float y = bounds.size.y / 2f + 0.1f;
					Vector3 offset = _fuselage.Data.Offset;
					offset.y = y;
					_fuselage.Data.Offset = offset;
					_fuselage.UpdateMeshes(updateNormalSmoothing: true);
					Vector3 vector = attachPoint.AttachPointScript.transform.position - position;
					_fuselage.PartScript.Transform.position += vector;
				}
			}
		}

		private static GameObject GetConnectedEngine(PartConnectedEventData e)
		{
			FuselageScript modifier = e.TargetPart.PartScript.GetModifier<FuselageScript>();
			if (modifier != null)
			{
				AttachPoint loadAttachPoint = modifier.GetLoadAttachPoint(e.TargetAttachPoint.Tag);
				if (loadAttachPoint != null && loadAttachPoint.PartConnections.Count == 1)
				{
					PartData otherPart = loadAttachPoint.PartConnections[0].GetOtherPart(modifier.PartScript.Data);
					if (otherPart != null)
					{
						EngineScript modifier2 = otherPart.PartScript.GetModifier<EngineScript>();
						if (modifier2 != null)
						{
							return modifier2?.PartScript?.GameObject;
						}
						RocketEngineScript modifier3 = otherPart.PartScript.GetModifier<RocketEngineScript>();
						if (modifier3 != null)
						{
							return modifier3?.PartScript?.GameObject;
						}
					}
				}
			}
			return null;
		}
	}
}
