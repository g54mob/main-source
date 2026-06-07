using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using Assets.Scripts.State;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight.Sim;
using ModApi.Math;
using ModApi.Scripts.State;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.Flight
{
	public class CraftRecovery
	{
		private CraftData _craftData;

		private GameState _gameState;

		public bool CanRecover => string.IsNullOrEmpty(FailMessage);

		public double ClosestDistance { get; } = -1.0;

		public LaunchLocation ClosestLocation { get; }

		public string FailMessage { get; set; }

		public bool IsDestroyed { get; }

		public int NumAstronauts { get; set; }

		public int NumParts { get; }

		public string RecoveryMessage
		{
			get
			{
				string arg = "part" + ((NumParts > 0) ? "s" : string.Empty);
				string text = "<size=125%>RECOVER CRAFT</size>\n\nThe closest recovery location is " + ClosestLocation?.Name + " which is ";
				text = ((!(ClosestDistance < 10.0)) ? (text + Units.GetDistanceString((float)ClosestDistance) + " away.") : (text + "very close."));
				if (TotalPrice >= 0f)
				{
					return text + "\n\n" + $"You can recover {NumParts} {arg} from this craft and recoup " + "<color=#00b7ed>" + Units.GetMoneyString((long)TotalPrice) + "</color>.\n\nDo you want to recover this craft?";
				}
				string text2 = "We recommend you destroy this craft instead.";
				if (NumAstronauts == 1)
				{
					text2 = "There are astronauts on board, so we recommend recovering this craft.";
				}
				else if (NumAstronauts > 0)
				{
					text2 = "There is an astronaut on board, so we recommend recovering this craft.";
				}
				return text + "\n\n" + $"You can recover {NumParts} {arg} from this craft but you will need to pay " + "<color=#e7515a>" + Units.GetMoneyString((long)(0f - TotalPrice)) + "</color>. " + text2 + "\n\nDo you want to recover this craft?";
			}
		}

		public float TotalPrice { get; }

		public CraftRecovery(GameState gameState, CraftData craftData, float craftMass, ICraftNodeData nodeData, IPlanetNode planet, bool isDestroyed = false)
		{
			_gameState = gameState;
			_craftData = craftData;
			Vector3d vector3d = planet.PlanetVectorToSurfaceVector(nodeData.Position);
			Vector3d vector3d2 = planet.SurfaceVectorToPlanetVector(planet.CalculateSurfaceVelocity(vector3d));
			Vector3d vector3d3 = nodeData.Velocity - vector3d2;
			if (isDestroyed)
			{
				IsDestroyed = isDestroyed;
				FailMessage = "This craft does not have any parts to recover.";
			}
			else if (!nodeData.InContactWithPlanet)
			{
				FailMessage = "The craft cannot be recovered because it is not on the ground.";
			}
			else if (vector3d3.magnitude > 5.0)
			{
				FailMessage = "The craft cannot be recovered because it is moving too fast.";
			}
			string planetName = planet.Name;
			_ = nodeData.SurfacePosition;
			planet.GetSurfaceCoordinates(vector3d, out var latitude, out var longitude);
			List<LaunchLocation> list = gameState.LaunchLocations.Where((LaunchLocation x) => x.PlanetName == planetName).ToList();
			List<LaunchLocation> list2 = new List<LaunchLocation>();
			foreach (LaunchLocation item in list)
			{
				if (!Game.Instance.GameState.Validator.IsLaunchLocationLocked(item.Name))
				{
					list2.Add(item);
				}
			}
			LaunchLocation launchLocation = null;
			double num = double.MaxValue;
			float num2 = float.MaxValue;
			foreach (LaunchLocation item2 in list2)
			{
				double num3 = MathUtils.Haversine(item2.Latitude * 0.01745329, item2.Longitude * 0.01745329, latitude, longitude, planet.PlanetData.Radius);
				num3 = Math.Max(0.0, num3 - item2.FreeRecoveryRadius);
				float num4 = (float)(0.02 * num3 * (double)craftMass * Math.Max(1.0, 0.01 * nodeData.WaterDepth * item2.WaterRecoveryBonus));
				if (num4 < num2)
				{
					num = num3;
					launchLocation = item2;
					num2 = num4;
				}
			}
			if (launchLocation == null)
			{
				FailMessage = "There are no recovery locations available on " + planetName + ".";
				return;
			}
			ClosestDistance = num;
			ClosestLocation = launchLocation;
			foreach (PartData part in _craftData.Assembly.Parts)
			{
				if (part.GetModifier<EvaData>() != null)
				{
					NumAstronauts++;
				}
				if (!part.IsDestroyed)
				{
					float num5 = Mathf.Clamp01(1f - part.Damage / 100f);
					TotalPrice += Mathf.Max(0f, part.Price) * num5 * num5;
					int numParts = NumParts;
					NumParts = numParts + 1;
				}
			}
			if (NumParts == 0)
			{
				FailMessage = "This craft does not have any parts to recover.";
			}
			TotalPrice -= num2;
		}

		public void RecoverCraft()
		{
			foreach (PartData part in _craftData.Assembly.Parts)
			{
				part.OnPartRecovered();
			}
			_gameState.Career?.OnRecoverCraft((long)TotalPrice);
		}
	}
}
