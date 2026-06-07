using UnityEngine;

namespace VRTK
{
	[AddComponentMenu("VRTK/Scripts/Locomotion/VRTK_HeightAdjustTeleport")]
	public class VRTK_HeightAdjustTeleport : VRTK_BasicTeleport
	{
		[Header("Height Adjust Settings")]
		[Tooltip("If this is checked, then the teleported Y position will snap to the nearest available below floor. If it is unchecked, then the teleported Y position will be where ever the destination Y position is.")]
		public bool snapToNearestFloor = true;

		[Tooltip("If this is checked then the teleported Y position will also be offset by the play area parent Transform Y position (if the play area has a parent).")]
		public bool applyPlayareaParentOffset;

		[Tooltip("A custom raycaster to use when raycasting to find floors.")]
		public VRTK_CustomRaycast customRaycast;

		protected override void OnEnable()
		{
			base.OnEnable();
			adjustYForTerrain = true;
			AdjustForParentOffset();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
		}

		protected override Vector3 GetNewPosition(Vector3 tipPosition, Transform target, bool returnOriginalPosition)
		{
			Vector3 newPosition = base.GetNewPosition(tipPosition, target, returnOriginalPosition);
			if (!returnOriginalPosition)
			{
				newPosition.y = GetTeleportY(target, tipPosition);
			}
			return newPosition;
		}

		protected virtual void AdjustForParentOffset()
		{
			if (snapToNearestFloor && applyPlayareaParentOffset && playArea != null && playArea.parent != null && VRTK_CustomRaycast.Raycast(ray: new Ray(playArea.parent.position, -playArea.up), customCast: customRaycast, hitData: out var hitData, ignoreLayers: 4, length: float.PositiveInfinity, affectTriggers: QueryTriggerInteraction.Ignore))
			{
				playArea.position = new Vector3(playArea.position.x, playArea.position.y + hitData.point.y, playArea.position.z);
			}
		}

		protected virtual float GetParentOffset()
		{
			if (!applyPlayareaParentOffset || !(playArea.parent != null))
			{
				return 0f;
			}
			return playArea.parent.transform.localPosition.y;
		}

		protected virtual float GetTeleportY(Transform target, Vector3 tipPosition)
		{
			float parentOffset = GetParentOffset();
			if (!snapToNearestFloor || !ValidRigObjects())
			{
				return tipPosition.y + parentOffset;
			}
			float num = playArea.position.y;
			float num2 = 0.1f;
			Vector3 vector = Vector3.up * num2;
			Ray ray = new Ray(tipPosition + vector, -playArea.up);
			if (target != null && VRTK_CustomRaycast.Raycast(customRaycast, ray, out var hitData, 4, float.PositiveInfinity, QueryTriggerInteraction.Ignore))
			{
				num = tipPosition.y - hitData.distance + num2;
			}
			return num + parentOffset;
		}
	}
}
