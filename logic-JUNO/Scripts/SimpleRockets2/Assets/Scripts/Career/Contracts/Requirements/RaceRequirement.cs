using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi.Audio;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class RaceRequirement : ContractRequirement
	{
		public enum CheckpointStyleType
		{
			Sphere = 0,
			Ring = 1,
			Cylinder = 2
		}

		public enum DistanceModeType
		{
			Line = 0,
			GreatCircle = 1
		}

		public class Checkpoint
		{
			public Vector3d LatLonAgl { get; set; }

			public string Name { get; set; }

			public double Range { get; set; }

			public CheckpointStyleType Style { get; set; }
		}

		private ButtonInformation _buttonInfo;

		private int _checkpointIndex;

		private List<Checkpoint> _checkpoints = new List<Checkpoint>();

		private bool _complete;

		private Checkpoint _currentCheckpoint;

		private DistanceModeType _distanceMode;

		private Checkpoint _firstCheckpoint;

		private int _laps;

		private int _lapsComplete;

		private LocationNode _node;

		private string _planetName;

		private double _planetRadius;

		private double _time;

		private double _timeLeft;

		public override ButtonInformation ButtonInfo
		{
			get
			{
				if (_node != null)
				{
					if (_buttonInfo == null)
					{
						_buttonInfo = new ButtonInformation("Target Location", "Ui/Sprites/Flight/IconTargetLocation");
					}
				}
				else
				{
					_buttonInfo = null;
				}
				return _buttonInfo;
			}
		}

		public int CheckpointIndex => _checkpointIndex;

		public override string DisplayValue
		{
			get
			{
				if (IsStarted)
				{
					if (_laps <= 1)
					{
						return $"{_checkpointIndex + 1}/{_checkpoints.Count + 1}";
					}
					return $"Lap {_lapsComplete + 1}  |  {_checkpointIndex + 1}/{_checkpoints.Count + 1}";
				}
				return "Not started";
			}
		}

		public override string FlightDescription
		{
			get
			{
				if (IsStarted)
				{
					if (_time == 0.0)
					{
						return "Go through all the checkpoints";
					}
					if (_laps > 1)
					{
						return $"You have {Units.GetStopwatchTimeString(_timeLeft)} left to complete {_laps} laps";
					}
					return "You have " + Units.GetStopwatchTimeString(_timeLeft) + " left";
				}
				return "Get to the Start Checkpoint";
			}
		}

		public bool IsStarted => _checkpointIndex >= 0;

		public int LapsComplete => _lapsComplete;

		public RaceRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			_time = xml.GetDoubleAttribute("time");
			_timeLeft = xml.GetDoubleAttribute("t", _time);
			_checkpointIndex = xml.GetIntAttribute("checkpoint", -1);
			_laps = xml.GetIntAttribute("laps");
			_lapsComplete = xml.GetIntAttribute("lapsComplete");
			_complete = xml.GetBoolAttribute("complete");
			_planetRadius = xml.GetDoubleAttribute("planetRadius");
			_distanceMode = xml.GetEnumAttribute("distanceMode", DistanceModeType.Line);
			CheckpointStyleType enumAttribute = xml.GetEnumAttribute("style", CheckpointStyleType.Cylinder);
			foreach (XElement item in xml.Elements("Race.Checkpoint"))
			{
				Checkpoint checkpoint = new Checkpoint
				{
					Style = item.GetEnumAttribute("style", enumAttribute)
				};
				string stringAttribute = item.GetStringAttribute("locationId");
				ContractLocation contractLocation = (string.IsNullOrWhiteSpace(stringAttribute) ? null : base.Contract.Context.GetContractLocation(stringAttribute));
				if (contractLocation != null)
				{
					checkpoint.LatLonAgl = contractLocation.LatLonAgl;
					checkpoint.Range = contractLocation.Range;
					checkpoint.Name = contractLocation.Name;
				}
				else
				{
					checkpoint.LatLonAgl = item.GetVector3dAttribute("latLonAgl");
					checkpoint.Range = item.GetDoubleAttribute("range");
					checkpoint.Name = item.GetStringAttribute("name");
				}
				_checkpoints.Add(checkpoint);
			}
			if (string.IsNullOrWhiteSpace(base.Description))
			{
				double num = EstimateTrackDistance();
				if (_laps <= 1)
				{
					base.Description = "Go through all checkpoints";
				}
				else
				{
					base.Description = $"Complete {_laps} laps";
				}
				if (_time > 0.0)
				{
					base.Description = base.Description + " in under " + Units.GetStopwatchTimeString(_time) + ".";
				}
				else
				{
					base.Description += ".";
				}
				if (num > 0.0)
				{
					base.Description = base.Description + " Track distance is " + Units.GetDistanceString((float)num) + ".";
				}
			}
			_firstCheckpoint = _checkpoints[0];
			_checkpoints.RemoveAt(0);
			if (_laps > 0)
			{
				_checkpoints.Add(_firstCheckpoint);
			}
			InitializeCurrentCheckpoint();
		}

		public override void OnClick(Action refreshUI)
		{
			if (_node != null)
			{
				_node?.SetAsTarget();
			}
		}

		public override void OnFlightEnd()
		{
			base.OnFlightEnd();
			DestroyNode();
		}

		public override void OnRequirementsCreated()
		{
			base.OnRequirementsCreated();
			PlanetRequirement parentRequirement = GetParentRequirement<PlanetRequirement>();
			if (parentRequirement != null)
			{
				_planetName = parentRequirement.PlanetName;
				return;
			}
			throw new ContractException("Race requirement requires a parent Planet requirement.");
		}

		public override void SaveStatusToXml()
		{
			base.SaveStatusToXml();
			base.Xml.SetAttributeValue("t", _timeLeft);
			base.Xml.SetAttributeValue("lapsComplete", _lapsComplete);
			base.Xml.SetAttributeValue("checkpoint", _checkpointIndex);
			base.Xml.SetAttributeValue("complete", _complete);
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			if (!_complete)
			{
				if (IsStarted && _time > 0.0)
				{
					_timeLeft -= base.FlightContext.DeltaTime;
					if (_timeLeft < 0.0)
					{
						MarkAsFailed();
						return false;
					}
				}
				if (_node == null)
				{
					ContractLocation contractLocation = new ContractLocation();
					contractLocation.LatLonAgl = _currentCheckpoint.LatLonAgl;
					contractLocation.PlanetName = _planetName;
					contractLocation.VisibleInMapView = true;
					contractLocation.Shared = false;
					contractLocation.Grounded = true;
					contractLocation.Style = _currentCheckpoint.Style;
					contractLocation.Range = _currentCheckpoint.Range;
					if (_currentCheckpoint.Name != null)
					{
						contractLocation.Name = _currentCheckpoint.Name;
					}
					else if (_checkpointIndex == -1 || (_checkpointIndex == _checkpoints.Count - 1 && _laps > 0))
					{
						contractLocation.Name = "Start Checkpoint";
					}
					else
					{
						contractLocation.Name = $"Checkpoint {_checkpointIndex + 2}";
					}
					_node = base.FlightContext.CreateLocationNode(contractLocation, "StructureNode");
					_node.Register(base.FlightContext);
					_node.SetAsTarget();
				}
				double num = 0.0;
				if (_distanceMode == DistanceModeType.Line)
				{
					num = _node.CalculateDistanceToPosition(craftNode.Position);
				}
				else if (_distanceMode == DistanceModeType.GreatCircle)
				{
					Vector2d latLon = craftNode.LatLon;
					num = MathUtils.Haversine(latLon.x, latLon.y, _currentCheckpoint.LatLonAgl.x * 0.01745329, _currentCheckpoint.LatLonAgl.y * 0.01745329, craftNode.Parent.PlanetData.Radius);
				}
				if (num <= _currentCheckpoint.Range)
				{
					AdvanceCheckpoint();
					Game.Instance.AudioPlayer.PlaySound(AudioLibrary.Career.CompleteMilestone);
				}
			}
			if (_complete)
			{
				if (!(_timeLeft >= 0.0))
				{
					return _time == 0.0;
				}
				return true;
			}
			return false;
		}

		protected override void OnStatusChanged()
		{
			base.OnStatusChanged();
			if (base.Status != RequirementStatus.Pass && base.Status != RequirementStatus.Active && _node != null)
			{
				DestroyNode();
			}
		}

		protected override void ResetRequirementStatus()
		{
			base.ResetRequirementStatus();
			_timeLeft = _time;
			_checkpointIndex = -1;
			_lapsComplete = 0;
			_complete = false;
			InitializeCurrentCheckpoint();
		}

		private void AdvanceCheckpoint()
		{
			_checkpointIndex++;
			if (_checkpointIndex >= _checkpoints.Count)
			{
				_checkpointIndex = 0;
				_lapsComplete++;
				_complete = _lapsComplete >= _laps;
			}
			DestroyNode();
			_currentCheckpoint = _checkpoints[_checkpointIndex];
		}

		private void DestroyNode()
		{
			_node?.Unregister();
			_node = null;
		}

		private double EstimateTrackDistance()
		{
			double num = 0.0;
			if (_planetRadius > 0.0)
			{
				Checkpoint checkpoint = null;
				if (_laps > 0)
				{
					checkpoint = _checkpoints.Last();
				}
				foreach (Checkpoint checkpoint2 in _checkpoints)
				{
					if (checkpoint != null)
					{
						num += MathUtils.Haversine(checkpoint2.LatLonAgl.x * 0.01745329, checkpoint2.LatLonAgl.y * 0.01745329, checkpoint.LatLonAgl.x * 0.01745329, checkpoint.LatLonAgl.y * 0.01745329, _planetRadius);
					}
					checkpoint = checkpoint2;
				}
			}
			return num;
		}

		private void InitializeCurrentCheckpoint()
		{
			if (_checkpointIndex == -1)
			{
				_currentCheckpoint = _firstCheckpoint;
			}
			else
			{
				_currentCheckpoint = _checkpoints[_checkpointIndex];
			}
		}
	}
}
