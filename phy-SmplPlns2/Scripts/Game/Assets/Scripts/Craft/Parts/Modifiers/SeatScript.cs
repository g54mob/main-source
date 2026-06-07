using System.Collections.Generic;
using Assets.Scripts.Environment.Terrain;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class SeatScript : PartModifierScript
	{
		private SeatData _data;

		private float _defaultReclination;

		private PartScript _part;

		private Transform _reclinerTransform;

		private TerrainTunnelingPreventionScript _tunnelMaster;

		public SeatData Data => _data;

		public bool PrimarySeat
		{
			get
			{
				return _data.PrimarySeat;
			}
			set
			{
				_data.PrimarySeat = value;
				if (value && _part != null)
				{
					_part.Aircraft.MainSeat = _part;
				}
			}
		}

		public Transform ReclinerTransform => _reclinerTransform;

		public void Initialize(SeatData seat)
		{
			_data = seat;
			_part = seat.Part.PartScript;
			if (!string.IsNullOrEmpty(_data.ReclinerPath))
			{
				Transform transform = base.PartScript.transform.Find(_data.ReclinerPath);
				if (transform == null)
				{
					Debug.LogError($"Seat Part-{_data.Part.Id} recliner not found at path {_data.ReclinerPath}.");
				}
				_reclinerTransform = transform;
				_defaultReclination = transform.localEulerAngles.x;
				UpdateReclination();
			}
		}

		public override void OnPartAdded()
		{
			base.OnPartAdded();
			if (base.PartScript.Aircraft.MainSeat == null)
			{
				PrimarySeat = true;
			}
		}

		public void UpdateReclination()
		{
			if (_reclinerTransform != null)
			{
				Vector3 localEulerAngles = _reclinerTransform.localEulerAngles;
				_reclinerTransform.localEulerAngles = new Vector3(_defaultReclination - _data.Reclination, localEulerAngles.y, localEulerAngles.z);
			}
		}

		protected virtual void OnDestroy()
		{
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				base.PartScript.Aircraft.OnAircraftStructureChanged -= OnAircraftStructureChanged;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
		}

		private void CheckIfAntiTunnelingShouldBeEnabled()
		{
			if (!base.PartScript.Aircraft.RemoteAircraft)
			{
				List<BodyJoint> joints = base.PartScript.Body.Joints;
				if ((joints == null || joints.Count == 0) && _tunnelMaster == null)
				{
					_tunnelMaster = TerrainTunnelingPreventionScript.Create(base.PartScript, base.gameObject, null);
				}
			}
		}

		private void OnAircraftStructureChanged()
		{
			CheckIfAntiTunnelingShouldBeEnabled();
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				base.PartScript.Aircraft.OnAircraftStructureChanged += OnAircraftStructureChanged;
				CheckIfAntiTunnelingShouldBeEnabled();
			}
		}
	}
}
