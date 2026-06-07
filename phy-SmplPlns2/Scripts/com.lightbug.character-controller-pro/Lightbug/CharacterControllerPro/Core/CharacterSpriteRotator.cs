using UnityEngine;

namespace Lightbug.CharacterControllerPro.Core
{
	[AddComponentMenu("Character Controller Pro/Core/Character Graphics/Sprite Rotator")]
	[DefaultExecutionOrder(20)]
	public class CharacterSpriteRotator : CharacterGraphics
	{
		private enum VectorComponent
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		[SerializeField]
		private VectorComponent scaleAffectedComponent;

		private Vector3 initialScale;

		private Vector3 initialForward;

		private void HandleRotation(float dt)
		{
			base.transform.rotation = Quaternion.LookRotation(initialForward, base.CharacterActor.Up);
			bool flag = Vector3.SignedAngle(base.CharacterActor.Forward, base.CharacterActor.Up, Vector3.forward) > 0f;
			switch (scaleAffectedComponent)
			{
			case VectorComponent.X:
				base.transform.localScale = new Vector3(flag ? initialScale.x : (0f - initialScale.x), base.transform.localScale.y, base.transform.localScale.z);
				break;
			case VectorComponent.Y:
				base.transform.localScale = new Vector3(base.transform.localScale.x, flag ? initialScale.y : (0f - initialScale.y), base.transform.localScale.z);
				break;
			case VectorComponent.Z:
				base.transform.localScale = new Vector3(base.transform.localScale.x, base.transform.localScale.y, flag ? initialScale.z : (0f - initialScale.z));
				break;
			}
		}

		protected override void OnValidate()
		{
			base.OnValidate();
			if (!base.CharacterBody.Is2D)
			{
				Debug.Log("Warning: CharacterBody is not 2D. This component is intended to be used with a 2D physics character.");
			}
			if (GetComponentInChildren<SkinnedMeshRenderer>() != null)
			{
				Debug.Log("Warning: \"Scale\" facing direction mode is intended to work with sprites, not with humanoid characters, choose \"Rotation\" instead.");
			}
		}

		protected override void Awake()
		{
			base.Awake();
			if (!base.CharacterBody.Is2D)
			{
				base.enabled = false;
			}
		}

		private void Start()
		{
			initialScale = base.transform.localScale;
			initialForward = base.transform.forward;
		}

		private void LateUpdate()
		{
			float deltaTime = Time.deltaTime;
			HandleRotation(deltaTime);
		}
	}
}
