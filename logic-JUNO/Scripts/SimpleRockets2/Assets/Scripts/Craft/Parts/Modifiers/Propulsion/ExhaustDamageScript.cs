using System;
using System.Collections.Generic;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Modifiers.Propulsion;
using ModApi.GameLoop;
using ModApi.GameLoop.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public class ExhaustDamageScript : MonoBehaviourBase, IFlightStart, IGameLoopItem, IFlightFixedUpdate, IHeatSource
	{
		private float _baseExpansion;

		private float _currentExpansion;

		private Vector3 _currentPointing;

		private float _directDamage;

		private ExhaustSystemScript _exhaustSystem;

		private float _heatTransfer;

		private PartScript _part;

		private IReactionEngine _reactionEngine;

		private float _referenceTemperature;

		private float _size;

		private List<PartScript> _thingsInside = new List<PartScript>();

		public float Temperature { get; private set; }

		void IFlightFixedUpdate.FlightFixedUpdate(in FlightFrameData frame)
		{
			if (base.isActiveAndEnabled)
			{
				float num = _reactionEngine.CurrentThrust / (Mathf.Max(1f, _exhaustSystem.ExpansionRatio * _exhaustSystem.ExpansionRatio) * _exhaustSystem.NozzleRadius * _exhaustSystem.NozzleRadius * 42f);
				float num2 = _exhaustSystem.NozzleRadius * _exhaustSystem.NozzleRadius * MathF.PI;
				_currentExpansion = Mathf.Max(1f, _exhaustSystem.ExpansionRatio) * _exhaustSystem.Intensity;
				_currentPointing = -base.transform.up;
				Temperature = _referenceTemperature * 0.5f * (1f + _exhaustSystem.Intensity);
				{
					foreach (PartScript item in _thingsInside)
					{
						if (item.BodyScript != null)
						{
							float num3 = Mathf.Clamp01(item.Data.PartDrag.TotalArea / (6f * num2));
							Vector3 vector = item.CachedPosition - _part.CachedPosition;
							item.BodyScript.RigidBody.AddForceAtPosition(num3 * num * Vector3.Normalize(vector) / Mathf.Max(1f, Vector3.Magnitude(vector)), _part.CachedPosition + Vector3.Project(vector, _currentPointing), ForceMode.Force);
						}
					}
					return;
				}
			}
			Temperature = 0f;
			_currentExpansion = 0f;
		}

		void IFlightStart.FlightStart(in FlightFrameData frame)
		{
			_part = base.transform.parent.parent.parent.GetComponent<PartScript>();
			_reactionEngine = _part.GetComponentInChildren<IReactionEngine>();
			_exhaustSystem = _part.GetComponentInChildren<ExhaustSystemScript>();
			RocketEngineData modifier = _part.Data.GetModifier<RocketEngineData>();
			_size = modifier.Size * _part.Data.Config.PartScale.y;
			_baseExpansion = _size * _exhaustSystem.NozzleRadius;
			_referenceTemperature = modifier.FuelType.CombustionTemperature;
			_heatTransfer = modifier.HeatTransferOverride;
			_directDamage = modifier.DirectDamage;
		}

		float IHeatSource.GetHeatTransferRate(PartScript part)
		{
			return _heatTransfer / Mathf.Max(1f, 0.5f * (_currentExpansion - 1f) * Vector3.Magnitude(_part.CachedPosition - part.CachedPosition));
		}

		protected virtual void OnDestroy()
		{
			RemoveAllParts();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			RemoveAllParts();
		}

		private void OnPartDestroyed(IPartScript partScript)
		{
			PartScript partScript2 = (PartScript)partScript;
			partScript2.PartDestroyed -= OnPartDestroyed;
			_thingsInside.Remove(partScript2);
		}

		private void OnTriggerEnter(Collider other)
		{
			switch (other.transform.name)
			{
			case "LaunchFX(Clone)":
				return;
			case "LaunchPadRaised(Clone)":
				return;
			case "Cube":
				return;
			case "ExhaustCollider":
				return;
			}
			PartScript componentInParent = other.GetComponentInParent<PartScript>();
			if (componentInParent != null && componentInParent != _part && !_thingsInside.Contains(componentInParent))
			{
				_thingsInside.Add(componentInParent);
				componentInParent.OnEnterHeatSource(this);
				componentInParent.PartDestroyed += OnPartDestroyed;
				if (_directDamage > 0f)
				{
					componentInParent.TakeDamage(_directDamage);
				}
				_ = _part.CachedPosition;
				_ = componentInParent.CachedPosition;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			switch (other.transform.name)
			{
			case "LaunchFX(Clone)":
				return;
			case "LaunchPadRaised(Clone)":
				return;
			case "Cube":
				return;
			case "ExhaustCollider":
				return;
			}
			PartScript componentInParent = other.GetComponentInParent<PartScript>();
			if (componentInParent != null)
			{
				RemovePartFromHeatSource(componentInParent);
			}
		}

		private void RemoveAllParts()
		{
			while (_thingsInside.Count > 0)
			{
				PartScript part = _thingsInside[0];
				RemovePartFromHeatSource(part);
			}
		}

		private void RemovePartFromHeatSource(PartScript part)
		{
			part.PartDestroyed -= OnPartDestroyed;
			part.OnExitHeatSource(this);
			_thingsInside.Remove(part);
		}
	}
}
