using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class TurnToFaceComponent : EntityTickComponent
	{
		private const float BlendSpeed = 4f;

		private const float ReactionSpeed = 5f;

		private Character _character;

		private float _weight;

		private Vector3 _targetPosition;

		protected override Type ValidEntityType()
		{
			return typeof(Character);
		}

		internal override void InitializeComponent()
		{
			base.InitializeComponent();
			_character = GetOwner<Character>();
			RuntimeAnimatorController runtimeAnimatorController = _character.FindAnimationGraph(ref _character.Definition._turnToFaceAnimGraph);
			if (runtimeAnimatorController != null)
			{
				_character.PushAnimationGraph(runtimeAnimatorController, 0.25f);
			}
		}

		public override void Destroy()
		{
			RuntimeAnimatorController runtimeAnimatorController = _character.FindAnimationGraph(ref _character.Definition._turnToFaceAnimGraph);
			if (runtimeAnimatorController != null)
			{
				_character.PopAnimationGraph(runtimeAnimatorController, 0.25f);
			}
			base.Destroy();
		}

		public void SetTarget(Vector3 position)
		{
			_targetPosition = position;
		}

		public override void LateTick()
		{
			base.LateTick();
			float movementSpeed = _character.MovementSpeed;
			float rotationY = _character.RotationY;
			float target = MathUtils.YawRotation(_targetPosition - _character.Position);
			float num = Mathf.DeltaAngle(rotationY, target);
			float num2 = ((movementSpeed > 0.4f) ? 0f : 1f);
			_weight = MathUtils.InterpolateTo(_weight, num2, 4f, Time.deltaTime);
			rotationY += num * Time.deltaTime * _weight * 5f;
			_character.RotationY = rotationY % 360f;
			if (_character.NavPath.IsNavigating() || Mathf.Abs(num) < 5f || (num2 < 1f && _weight < 0.1f))
			{
				Destroy();
			}
		}
	}
}
