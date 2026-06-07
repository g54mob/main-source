using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Core
{
	[AddComponentMenu("Character Controller Pro/Core/Character Graphics/Rotation Lerper")]
	[DefaultExecutionOrder(20)]
	public class CharacterRotationLerper : CharacterGraphics
	{
		[Condition("lerpRotation", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[SerializeField]
		private float rotationLerpSpeed = 25f;

		private Quaternion previousRotation;

		private bool teleportFlag;

		protected override void OnValidate()
		{
			base.OnValidate();
			CustomUtilities.SetPositive(ref rotationLerpSpeed);
		}

		private void Start()
		{
			previousRotation = base.transform.rotation;
		}

		private void OnEnable()
		{
			base.CharacterActor.OnTeleport += OnTeleport;
		}

		private void OnDisable()
		{
			base.CharacterActor.OnTeleport -= OnTeleport;
		}

		private void Update()
		{
			if (base.CharacterActor == null)
			{
				base.enabled = false;
				return;
			}
			float deltaTime = Time.deltaTime;
			HandleRotation(deltaTime);
			if (teleportFlag)
			{
				teleportFlag = false;
			}
		}

		private void OnTeleport(Vector3 position, Quaternion rotation)
		{
			teleportFlag = true;
		}

		private void HandleRotation(float dt)
		{
			if (teleportFlag)
			{
				base.transform.localRotation = Quaternion.identity;
				previousRotation = base.transform.rotation;
			}
			else
			{
				base.transform.rotation = Quaternion.Slerp(previousRotation, base.CharacterActor.Rotation, rotationLerpSpeed * dt);
				previousRotation = base.transform.rotation;
			}
		}
	}
}
