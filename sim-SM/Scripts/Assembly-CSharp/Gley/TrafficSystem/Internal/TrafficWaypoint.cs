using System;
using System.Collections.Generic;
using Gley.UrbanSystem.Internal;
using UnityEngine;

namespace Gley.TrafficSystem.Internal
{
	[Serializable]
	public class TrafficWaypoint : Waypoint
	{
		private List<IIntersection> _associatedIntersections;

		[SerializeField]
		private VehicleTypes[] _allowedVehicles;

		[SerializeField]
		private int[] _giveWayList;

		[SerializeField]
		private int[] _otherLanes;

		[SerializeField]
		private string _eventData;

		[SerializeField]
		private float _laneWidth;

		[SerializeField]
		private int _maxSpeed;

		[SerializeField]
		private bool _giveWay;

		[SerializeField]
		private bool _complexGiveWay;

		[SerializeField]
		private bool _zipperGiveWay;

		[SerializeField]
		private bool _triggerEvent;

		[SerializeField]
		private bool _enter;

		[SerializeField]
		private bool _exit;

		[SerializeField]
		private bool _stop;

		public int[] GiveWayList => null;

		public VehicleTypes[] AllowedVehicles => null;

		public int[] OtherLanes => null;

		public int MaxSpeed => 0;

		public float LaneWidth => 0f;

		public bool ComplexGiveWay => false;

		public bool ZipperGiveWay => false;

		public bool Enter => false;

		public bool Exit => false;

		public List<IIntersection> AssociatedIntersections => null;

		public bool Stop
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool GiveWay
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool TriggerEvent
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public string EventData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public TrafficWaypoint(string name, int listIndex, Vector3 position, List<VehicleTypes> allowedVehicles, int[] neighbors, int[] prev, int[] otherLanes, int maxSpeed, bool giveWay, bool complexGiveWay, bool zipperGiveWay, bool triggerEvent, float laneWidth, string eventData, int[] giveWayList)
			: base(null, 0, default(Vector3), null, null)
		{
		}

		public void SetIntersection(IIntersection intersection, bool giveWay, bool stop, bool enter, bool exit)
		{
		}
	}
}
