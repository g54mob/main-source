using System;
using System.Xml.Linq;
using Assets.Scripts.Flight.AI;
using Assets.Scripts.Flight.AI.ControlSystems;
using Assets.Scripts.Flight.StartLocations;
using Assets.Scripts.Tutorials.Requirements.Attributes;
using UnityEngine;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("SpawnAI")]
	public class SpawnAIRequirement : TutorialRequirement
	{
		private bool _spawnComplete;

		public string AircraftId { get; set; }

		public bool Hostile { get; set; }

		public float InitialVelocity { get; set; }

		public AiCsSandboxAirTraffic.AiMode Mode { get; set; }

		public string Name { get; set; }

		public Vector3 Position { get; set; }

		public bool PositionRelativeToPlayer { get; set; }

		public Vector3 Rotation { get; set; }

		protected override float DefaultRequiredMetDuration => 0f;

		public SpawnAIRequirement()
		{
		}

		public SpawnAIRequirement(string aircraftId, Vector3 position, Vector3 rotation, bool positionRelativeToPlayer, float initialVelocity, bool hostile, AiCsSandboxAirTraffic.AiMode mode = AiCsSandboxAirTraffic.AiMode.Default, string name = null)
		{
			AircraftId = aircraftId;
			Position = position;
			Rotation = rotation;
			PositionRelativeToPlayer = positionRelativeToPlayer;
			InitialVelocity = initialVelocity;
			Hostile = hostile;
			Mode = mode;
			Name = name;
		}

		public override void OnStepStarted()
		{
			base.OnStepStarted();
			Vector3 vector = Position;
			Vector3 vector2 = Rotation;
			if (PositionRelativeToPlayer)
			{
				vector = base.PlayerAircraft.GlobalPosition + Quaternion.Euler(base.PlayerAircraft.Rotation) * vector;
				vector2 = (Quaternion.Euler(base.PlayerAircraft.Rotation) * Quaternion.Euler(vector2)).eulerAngles;
			}
			StartLocation location = new StartLocation(vector, vector2, InitialVelocity, null);
			ushort teamId = (ushort)(Hostile ? 1 : 3);
			AiManagerScript.Instance.SpawnSandboxAi(AircraftId, autoDespawn: false, forceSpawnEvenIfUnflyable: true, location, Mode, Hostile, teamId, delegate(AiControlledAircraftScript ai)
			{
				OnSpawnComplete();
				if (!string.IsNullOrWhiteSpace(Name))
				{
					ai.AiAircraftScript.Aircraft.Name = Name;
				}
			});
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("aircraftId", AircraftId);
			xml.SetAttributeValue("position", Position.ToXAttributeValue());
			xml.SetAttributeValue("rotation", Rotation.ToXAttributeValue());
			xml.SetAttributeValue("positionRelativeToPlayer", PositionRelativeToPlayer);
			xml.SetAttributeValue("initialVelocity", InitialVelocity);
			xml.SetAttributeValue("hostile", Hostile);
			xml.SetAttributeValue("mode", (Mode == AiCsSandboxAirTraffic.AiMode.Default) ? null : Mode.ToString());
			xml.SetAttributeValue("name", Name);
			base.GenerateXml(xml);
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			if (!_spawnComplete)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			return TutorialRequirementState.RequirementMet;
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			AircraftId = (string)xml.Attribute("aircraftId");
			Position = xml.GetVector3Attribute("position", Vector3.zero);
			Rotation = xml.GetVector3Attribute("rotation", Vector3.zero);
			PositionRelativeToPlayer = (bool?)xml.Attribute("positionRelativeToPlayer") == true;
			InitialVelocity = ((float?)xml.Attribute("initialVelocity")).GetValueOrDefault();
			Hostile = (bool?)xml.Attribute("hostile") == true;
			Mode = xml.GetEnumAttribute("mode", AiCsSandboxAirTraffic.AiMode.Default);
			Name = (string)xml.Attribute("name");
		}

		private void OnSpawnComplete()
		{
			_spawnComplete = true;
		}
	}
}
