using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.ActivityFramework.Activities.Races
{
	public class RaceCheckpointScript : MonoBehaviour
	{
		public enum CheckpointState
		{
			Inactive = 0,
			Next = 1,
			SecondNext = 2,
			Passed = 3,
			Skipped = 4
		}

		private RaceCourseScript _course;

		[SerializeField]
		private Material _materialArrows;

		[SerializeField]
		private Material _materialInactive;

		[SerializeField]
		private Material _materialNext;

		[SerializeField]
		private Material _materialNoArrows;

		[SerializeField]
		private Material _materialPassed;

		[SerializeField]
		private Material _materialSkipped;

		[SerializeField]
		private MeshRenderer _meshRenderer;

		private Transform _restartPosition;

		private CheckpointState _state;

		public int CheckpointNumber { get; private set; }

		public Transform RestartPosition => _restartPosition;

		public CheckpointState State
		{
			get
			{
				return _state;
			}
			set
			{
				_state = value;
				switch (value)
				{
				case CheckpointState.Inactive:
					_meshRenderer.enabled = false;
					break;
				case CheckpointState.Next:
					_meshRenderer.enabled = true;
					_meshRenderer.SetMaterials(new List<Material> { _materialNext, _materialArrows });
					break;
				case CheckpointState.SecondNext:
					_meshRenderer.enabled = true;
					_meshRenderer.SetMaterials(new List<Material> { _materialInactive, _materialNoArrows });
					break;
				case CheckpointState.Passed:
					_meshRenderer.enabled = true;
					_meshRenderer.SetMaterials(new List<Material> { _materialPassed, _materialNoArrows });
					break;
				case CheckpointState.Skipped:
					_meshRenderer.enabled = true;
					_meshRenderer.SetMaterials(new List<Material> { _materialSkipped, _materialNoArrows });
					break;
				}
			}
		}

		public void InitializeRace(RaceCourseScript raceCourseScript, RaceCheckpointDataScript checkPointData, int checkpointNumber)
		{
			_course = raceCourseScript;
			CheckpointNumber = checkpointNumber;
			State = CheckpointState.Inactive;
			_restartPosition = checkPointData?.RestartPosition ?? base.transform;
		}

		protected virtual void OnTriggerEnter(Collider other)
		{
			if (_state == CheckpointState.Next || _state == CheckpointState.SecondNext)
			{
				PartScript componentInParent = other.transform.GetComponentInParent<PartScript>(includeInactive: true);
				if (componentInParent != null && !componentInParent.Aircraft.RemoteAircraft && componentInParent.ConnectedToMainCockpit && componentInParent.GetModifier<CockpitScript>() != null)
				{
					_course.OnCheckpointHitByLocalPlayer(componentInParent.Aircraft, this);
				}
			}
		}
	}
}
