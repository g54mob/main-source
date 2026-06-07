using System;
using Assets.Scripts.Flight.Combat.Events;
using Assets.Scripts.Flight.Combat.Teams;
using Assets.Scripts.Flight.WorldObjects.Combat.Targets;

namespace Assets.Scripts.Flight.Combat
{
	public class TrackedTarget
	{
		private bool _tracking;

		public AggressionLevel AggressionLevel { get; set; }

		public float Angle { get; set; }

		public float Distance { get; set; }

		public bool IsAcquiring { get; set; }

		public bool IsFriendly => AggressionLevel == AggressionLevel.Friendly;

		public bool IsHostile => AggressionLevel == AggressionLevel.Hostile;

		public bool IsLocked { get; set; }

		public bool IsLost => !IsLocked;

		public bool IsTracking
		{
			get
			{
				return _tracking;
			}
			set
			{
				if (_tracking != value)
				{
					_tracking = value;
					this.IsTrackingChanged?.Invoke(this, new TrackedTargetEventArgs(this));
				}
			}
		}

		public ExclusiveLock Lock { get; }

		public float LockPercentage { get; set; }

		public bool Occluded { get; set; }

		public bool Selected { get; set; }

		public Target Target { get; }

		public event EventHandler<TrackedTargetEventArgs> IsTrackingChanged;

		public TrackedTarget(Target target, AggressionLevel aggressionLevel = AggressionLevel.Neutral, ExclusiveLock exclusiveLock = null)
		{
			Target = target;
			AggressionLevel = aggressionLevel;
			Lock = exclusiveLock;
		}
	}
}
