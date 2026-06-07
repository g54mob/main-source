using System;
using System.Collections.Generic;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Flight.Combat.Teams;
using Assets.Scripts.Multiplayer.Events;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class PlayerTarget : Target
	{
		private readonly Dictionary<SignatureType, float> _breakLockProbabilities = new Dictionary<SignatureType, float>();

		private readonly Dictionary<SignatureType, float> _evadeLockProbabilities = new Dictionary<SignatureType, float>();

		public override bool IsDead
		{
			get
			{
				if (base.Player.Aircraft != null)
				{
					return base.Player.Aircraft.CriticallyDamaged;
				}
				if (base.Player.PreviousAircraft != null)
				{
					return base.Player.PreviousAircraft.CriticallyDamaged;
				}
				return false;
			}
		}

		public override Vector3 Position => base.Player.FramePosition;

		public override TargetType TargetType => TargetType.AirAndGround;

		public override Vector3 Velocity => base.Player.Aircraft?.Velocity ?? Vector3.zero;

		public PlayerTarget(FlightScenePlayer player)
			: base(player.TeamId)
		{
			base.Player = player;
			UpdateName();
			if (player.NetworkPlayer != null)
			{
				player.NetworkPlayer.NameChanged += OnNetworkPlayerNameChanged;
			}
			foreach (SignatureType value in Enum.GetValues(typeof(SignatureType)))
			{
				_breakLockProbabilities[value] = 0f;
				_evadeLockProbabilities[value] = 0f;
			}
		}

		public void AddBreakLockProbability(SignatureType signatureType, float delta)
		{
			_breakLockProbabilities.TryGetValue(signatureType, out var value);
			float num = Mathf.Clamp(value + delta, 0f, 0.9f);
			_breakLockProbabilities[signatureType] = (Mathf.Approximately(num, 0f) ? 0f : num);
		}

		public void AddEvadeLockProbability(SignatureType signatureType, float delta)
		{
			_evadeLockProbabilities.TryGetValue(signatureType, out var value);
			float num = Mathf.Clamp01(value + delta);
			_evadeLockProbabilities[signatureType] = (Mathf.Approximately(num, 0f) ? 0f : num);
		}

		public override void Alert(bool locked, ITargetLockSource source, TrackedTarget trackedTarget)
		{
			base.Alert(locked, source, trackedTarget);
			base.Player.GetNetworkAircraft()?.NotifyTargetAlert(locked ? TargetAlertType.Locked : TargetAlertType.Tracking);
			if (source?.Player != null)
			{
				FlightSceneScript.Instance.TeamAggressionManager.SetAggressionLevel(base.TeamId, source.Player.TeamId, AggressionLevel.Hostile);
			}
		}

		public override float GetBreakLockProbability(SignatureType signatureType)
		{
			_breakLockProbabilities.TryGetValue(signatureType, out var value);
			return value;
		}

		public override float GetEvadeLockProbability(SignatureType signatureType)
		{
			_evadeLockProbabilities.TryGetValue(signatureType, out var value);
			return value;
		}

		public override float GetSignature(SignatureType signatureType)
		{
			return signatureType switch
			{
				SignatureType.None => 0f, 
				SignatureType.Infrared => base.Player.Aircraft?.IRSignature ?? 0f, 
				SignatureType.Radar => base.Player.Aircraft?.RadarSignature ?? 0f, 
				SignatureType.Radiation => 100f, 
				SignatureType.Laser => 0f, 
				_ => throw new ArgumentOutOfRangeException("signatureType"), 
			};
		}

		public override void OnUnregistered()
		{
			base.OnUnregistered();
			NetworkPlayerScript networkPlayerScript = base.Player?.NetworkPlayer;
			if ((object)networkPlayerScript != null)
			{
				networkPlayerScript.NameChanged -= OnNetworkPlayerNameChanged;
			}
		}

		private void OnNetworkPlayerNameChanged(object sender, NetworkPlayerNameChangedEventArgs e)
		{
			UpdateName();
		}

		private void UpdateName()
		{
			base.Name = base.Player.NetworkPlayer.Name;
		}
	}
}
