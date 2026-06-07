using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.Craft.Parts.Modifiers;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Craft.Decals
{
	public class DecalPartIntersectionReceiver : EventDrivenPartIntersectionReceiver<PartScript>
	{
		private static class Profile
		{
			public const string Prefix = "DecalPartIntersectionReceiver";

			public static readonly ProfilerMarker OnUpdate = new ProfilerMarker("DecalPartIntersectionReceiver.OnUpdate");
		}

		private ICraftDecal _decal;

		private Transform _transform;

		public override bool Enabled => _decal.PartTargeting.TargetMode == PartTargetingMode.MultipleParts;

		public DecalPartIntersectionReceiver(DesignerPartIntersectionManager manager, ICraftDecal decal, Transform transform)
			: base(manager)
		{
			_transform = transform;
			_decal = decal;
			base.OnIntersectionAdded += delegate(PartScript part)
			{
				part.AssignDecal(_decal);
			};
			base.OnIntersectionRemoved += delegate(PartScript part)
			{
				part.UnassignDecal(_decal);
			};
		}

		public override (Vector3 Center, Vector3 HalfExtents, Quaternion Rotation) GetBox()
		{
			Transform transform = _transform;
			Vector3 item = transform.TransformPoint(new Vector3(0f, 0f, _decal.Size.z * 0.5f));
			Vector3 item2 = _decal.Size * 0.5f;
			Quaternion rotation = transform.rotation;
			return (Center: item, HalfExtents: item2, Rotation: rotation);
		}

		public override void OnUpdate()
		{
			using (Profile.OnUpdate.Auto())
			{
				if (_transform == null)
				{
					Dispose();
					return;
				}
				_decal.OnUpdate(_transform);
				if (_decal.PartTargeting.TargetPart != null)
				{
					PartScript partScript = _decal.PartTargeting.TargetPart.PartScript;
					SetSingleItem(partScript);
				}
			}
		}

		public void SetCustomParts(List<PartScript> parts)
		{
			SetMultipleItems(parts);
		}

		protected override void GetItemsFromHit(Collider hitCollider, HashSet<PartScript> resultSet)
		{
			if (!hitCollider.TryGetComponent<DecalTargetColliderScript>(out var component))
			{
				return;
			}
			foreach (DecalTargetScript decalTarget in component.DecalTargets)
			{
				resultSet.Add(decalTarget.PartScript);
			}
		}
	}
}
