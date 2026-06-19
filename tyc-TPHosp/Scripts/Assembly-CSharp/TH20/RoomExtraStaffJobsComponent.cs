using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomExtraStaffJobsComponent : EntityComponent
	{
		[SerializeField]
		private int _maxExtraJobs;

		[SerializeField]
		private StaffRequired _staffRequired;

		private Room _room;

		private StaffWorkScheduler _staffWorkScheduler;

		private List<Job> _jobs;

		public int NumExtraStaff => _jobs.Count;

		public List<Job> Jobs => _jobs;

		protected override Type ValidEntityType()
		{
			return typeof(Room);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_room = GetOwner<Room>();
			_staffWorkScheduler = _room.Level.StaffWorkScheduler;
			_jobs = new List<Job>();
		}

		public void AddJob()
		{
			if (_jobs.Count < _maxExtraJobs)
			{
				Job job = _room.CreateJob(_staffRequired);
				_room.AddOptionalStaffJob(_staffRequired);
				_staffWorkScheduler.AddJob(job);
				_jobs.Add(job);
			}
		}

		public void RemoveJob()
		{
			if (_jobs.Count <= 0)
			{
				return;
			}
			Job job = null;
			foreach (Job job2 in _jobs)
			{
				if (job2.Available())
				{
					job = job2;
					break;
				}
			}
			if (job == null)
			{
				job = _jobs.RandomItem();
			}
			_room.RemoveOptionalStaffJob(_staffRequired);
			_staffWorkScheduler.RemoveJob(job, complete: false);
			_jobs.Remove(job);
		}

		public void AddOptionalJobsToRoom(Room room)
		{
			for (int i = 0; i < _jobs.Count; i++)
			{
				room.AddOptionalStaffJob(_staffRequired);
			}
		}
	}
}
