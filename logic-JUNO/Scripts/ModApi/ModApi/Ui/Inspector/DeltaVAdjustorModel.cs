using System;
using ModApi.Flight.MapView;
using UnityEngine;

namespace ModApi.Ui.Inspector
{
	public class DeltaVAdjustorModel : ItemModel
	{
		public IManeuverNode ManeuverNode { get; private set; }

		public DeltaVAdjustorModelType Type { get; }

		public DeltaVAdjustorModel(DeltaVAdjustorModelType type)
		{
			Type = type;
		}

		public void AdjustDeltaV(float input)
		{
			if (ManeuverNode != null)
			{
				switch (Type)
				{
				case DeltaVAdjustorModelType.ProgradeRetrograde:
					ManeuverNode.AdjustDeltaV(new Vector3(input, 0f, 0f));
					break;
				case DeltaVAdjustorModelType.NormalAntiNormal:
					ManeuverNode.AdjustDeltaV(new Vector3(0f, input, 0f));
					break;
				case DeltaVAdjustorModelType.RadialOutRadialIn:
					ManeuverNode.AdjustDeltaV(new Vector3(0f, 0f, input));
					break;
				default:
					throw new NotSupportedException($"Invalid Type: {Type}");
				}
			}
		}

		public void OnNodeDeselected()
		{
			ManeuverNode = null;
		}

		public void OnNodeSelected(IManeuverNode node)
		{
			ManeuverNode = node;
		}

		public void SetDeltaV(double value)
		{
			if (ManeuverNode != null)
			{
				value = Mathd.Clamp(value, -999999.0, 999999.0);
				Vector3d deltaV = new Vector3d(ManeuverNode.DeltaVPrograde, ManeuverNode.DeltaVNormal, ManeuverNode.DeltaVRadial);
				switch (Type)
				{
				case DeltaVAdjustorModelType.ProgradeRetrograde:
					deltaV.x = value;
					break;
				case DeltaVAdjustorModelType.NormalAntiNormal:
					deltaV.y = value;
					break;
				case DeltaVAdjustorModelType.RadialOutRadialIn:
					deltaV.z = value;
					break;
				default:
					throw new NotSupportedException($"Invalid Type: {Type}");
				}
				ManeuverNode.SetDeltaV(deltaV);
			}
		}
	}
}
