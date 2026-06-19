using System;
using UnityEngine;

namespace TH20
{
	public class TeleportCharacterComponent : EntityTickComponent
	{
		private Vector3 _destination;

		private Character _character;

		private float _distanceToTravel;

		private float _distanceTravelled;

		private float _travelSpeed;

		private Vector3 _travelDelta;

		private RuntimeAnimatorController _animationGraph;

		private const float TravelSpeed = 1f;

		private const float HeightOffset = 2f;

		public Vector3 Destination => _destination;

		protected override Type ValidEntityType()
		{
			return typeof(Character);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_character = GetOwner<Character>();
			_animationGraph = _character.GetTeleportAnimGraph();
			_character.Interrupt();
			_character.Teleporting = true;
			_character.NavPath.BecomeKinematic();
			_character.Visual.EnableUpdateWhenOffscreen();
			if (_character is Staff staff && staff.CurrentJob != null)
			{
				staff.CurrentJob.MakeAvailable();
			}
			if (_animationGraph != null)
			{
				_character.PushAnimationGraph(_animationGraph, 0.5f);
			}
		}

		public void SetDestination(Vector3 destination)
		{
			_destination = destination;
			_travelDelta = _destination - _character.Position;
			_distanceToTravel = _travelDelta.magnitude;
			_travelSpeed = 1f * _distanceToTravel;
			_character.RotationY = MathUtils.YawRotation(_travelDelta);
		}

		public override void Destroy()
		{
			if (_animationGraph != null)
			{
				_character.PopAnimationGraph(_animationGraph, 0.25f);
			}
			_character.Teleporting = false;
			_character.Position = _destination;
			_character.NavPath.StopBeingKinematic();
			_character.NavPath.Warp(_destination);
			_character.Visual.DisableUpdateWhenOffscreen();
			_character.Resume();
			base.Destroy();
		}

		public override void Tick()
		{
			base.Tick();
			if (_animationGraph == null)
			{
				Destroy();
				return;
			}
			Vector3 vector = _travelSpeed * _travelDelta.normalized * Time.deltaTime;
			_distanceTravelled = Mathf.Min(_distanceTravelled + vector.magnitude, _distanceToTravel);
			if (_distanceTravelled < _distanceToTravel)
			{
				Vector3 position = _character.Position + vector;
				position.y = GetYOffset(_distanceTravelled / _distanceToTravel);
				_character.Position = position;
			}
			if (_distanceTravelled >= _distanceToTravel * 0.85f)
			{
				if (_character.Animator.HasParameter("Exit"))
				{
					_character.Animator.SetBool("Exit", value: true);
				}
				if (_character.Animator.IsInState("Exit"))
				{
					Destroy();
				}
			}
		}

		private float GetYOffset(float t)
		{
			return Mathf.Sin(t * (float)Math.PI) * 2f;
		}

		private void DebugDrawPath()
		{
			int num = 10;
			Vector3 vector = _travelDelta / num;
			for (int i = 0; i < num; i++)
			{
				int num2 = i;
				int num3 = i + 1;
				Vector3 start = _destination - num2 * vector;
				Vector3 end = _destination - num3 * vector;
				start.y = GetYOffset((float)num2 / (float)num);
				end.y = GetYOffset((float)num3 / (float)num);
				DebugDrawUtils.Line(start, end, ((num2 & 1) != 0) ? Color.blue : Color.red);
			}
			DebugDrawUtils.Marker(_destination, Color.cyan);
		}
	}
}
