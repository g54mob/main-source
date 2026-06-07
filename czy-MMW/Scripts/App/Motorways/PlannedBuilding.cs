using System;
using Factory;
using Motorways.Models;
using Motorways.Processes;
using UnityEngine;

namespace Motorways
{
	[System.Serializable]
	public struct PlannedBuilding
	{
		public class Serializer : PrimitiveSerializer
		{
			public override bool Serialize(object obj, ExportContext context)
			{
				if (obj is PlannedBuilding plannedBuilding)
				{
					context.Writer.Write((int)plannedBuilding.type);
					context.Writer.Write(plannedBuilding.groupIndex);
					context.Writer.Write(plannedBuilding.additionalDemandMultiplier);
					context.Writer.Write(plannedBuilding.positionOverride.x);
					context.Writer.Write(plannedBuilding.positionOverride.y);
					context.Writer.Write(plannedBuilding.useFixedParameters);
					context.Writer.Write((int)plannedBuilding.carparkPreference);
					context.Writer.Write((int)plannedBuilding.directionOverride);
					context.Writer.Write((int)plannedBuilding.entranceOverride);
					context.Writer.Write((int)plannedBuilding.grouping);
					context.Writer.Write((int)plannedBuilding.drivewayDirectionOverride);
					context.Writer.Write((int)plannedBuilding.tutorialIdentifier);
					return true;
				}
				return false;
			}

			public override object Deserialize(object existingObj, ImportContext context)
			{
				return new PlannedBuilding
				{
					type = (CityTileType)context.Reader.ReadInt32(),
					groupIndex = context.Reader.ReadInt32(),
					additionalDemandMultiplier = context.Reader.ReadSingle(),
					positionOverride = new Vector2Int(context.Reader.ReadInt32(), context.Reader.ReadInt32()),
					useFixedParameters = context.Reader.ReadBoolean(),
					carparkPreference = (CarparkPreference)context.Reader.ReadInt32(),
					directionOverride = (TileDirection)context.Reader.ReadInt32(),
					entranceOverride = (CarparkEntrance)context.Reader.ReadInt32(),
					grouping = (GroupingStyle)context.Reader.ReadInt32(),
					drivewayDirectionOverride = (TileDirection)context.Reader.ReadInt32(),
					tutorialIdentifier = (TutorialIdentifier)context.Reader.ReadInt32()
				};
			}
		}

		public CityTileType type;

		public int groupIndex;

		[Tooltip("How much extra demand should this destination have? Defaults to zero")]
		public float additionalDemandMultiplier;

		[Tooltip("If Use Fixed Position is true, what position should it be?")]
		public Vector2Int positionOverride;

		[Tooltip("Should we use a fixed position")]
		public bool useFixedPosition;

		public bool useFixedParameters;

		[Tooltip("What is our preference of carpark?")]
		public CarparkPreference carparkPreference;

		[Tooltip("An identifier that can be used to refer to this building in tutorial code")]
		public TutorialIdentifier tutorialIdentifier;

		public TileDirection directionOverride;

		public CarparkEntrance entranceOverride;

		public GroupingStyle grouping;

		public TileDirection drivewayDirectionOverride;

		public bool PrefersDoubleCarpark
		{
			get
			{
				if (carparkPreference != CarparkPreference.Double)
				{
					return carparkPreference == CarparkPreference.ForceDouble;
				}
				return true;
			}
		}
	}
}
