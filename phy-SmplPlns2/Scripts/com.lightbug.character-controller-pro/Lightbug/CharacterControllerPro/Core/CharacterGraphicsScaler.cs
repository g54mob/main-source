using UnityEngine;

namespace Lightbug.CharacterControllerPro.Core
{
	[AddComponentMenu("Character Controller Pro/Core/Character Graphics/Scaler")]
	[DefaultExecutionOrder(21)]
	public class CharacterGraphicsScaler : CharacterGraphics
	{
		private enum VectorComponent
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		[SerializeField]
		private VectorComponent scaleHeightComponent = VectorComponent.Y;

		private Vector3 initialLocalScale = Vector3.one;

		private void Start()
		{
			initialLocalScale = base.transform.localScale;
		}

		private void Update()
		{
			if (base.CharacterActor.enabled)
			{
				Vector3 localScale = Vector3.one;
				switch (scaleHeightComponent)
				{
				case VectorComponent.X:
					localScale = new Vector3(initialLocalScale.x * (base.CharacterActor.BodySize.y / base.CharacterActor.DefaultBodySize.y), initialLocalScale.y * (base.CharacterActor.BodySize.x / base.CharacterActor.DefaultBodySize.x), initialLocalScale.z * (base.CharacterActor.BodySize.x / base.CharacterActor.DefaultBodySize.x));
					break;
				case VectorComponent.Y:
					localScale = new Vector3(initialLocalScale.x * (base.CharacterActor.BodySize.x / base.CharacterActor.DefaultBodySize.x), initialLocalScale.y * (base.CharacterActor.BodySize.y / base.CharacterActor.DefaultBodySize.y), initialLocalScale.z * (base.CharacterActor.BodySize.x / base.CharacterActor.DefaultBodySize.x));
					break;
				case VectorComponent.Z:
					localScale = new Vector3(initialLocalScale.x * (base.CharacterActor.BodySize.x / base.CharacterActor.DefaultBodySize.x), initialLocalScale.y * (base.CharacterActor.BodySize.x / base.CharacterActor.DefaultBodySize.x), initialLocalScale.z * (base.CharacterActor.BodySize.y / base.CharacterActor.DefaultBodySize.y));
					break;
				}
				base.transform.localScale = localScale;
			}
		}
	}
}
