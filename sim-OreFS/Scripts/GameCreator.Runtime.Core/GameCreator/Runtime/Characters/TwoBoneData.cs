using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public struct TwoBoneData
	{
		[field: NonSerialized]
		public Vector3 WorldPosition { get; set; }

		[field: NonSerialized]
		public Quaternion WorldRotation { get; set; }

		[field: NonSerialized]
		public Vector3 WorldScale { get; set; }

		[field: NonSerialized]
		public Vector3 RootLocalPosition { get; set; }

		[field: NonSerialized]
		public Quaternion RootLocalRotation { get; set; }

		[field: NonSerialized]
		public Vector3 RootLocalScale { get; set; }

		[field: NonSerialized]
		public Vector3 BodyLocalPosition { get; set; }

		[field: NonSerialized]
		public Quaternion BodyLocalRotation { get; set; }

		[field: NonSerialized]
		public Vector3 BodyLocalScale { get; set; }

		[field: NonSerialized]
		public Vector3 HeadLocalPosition { get; set; }

		[field: NonSerialized]
		public Quaternion HeadLocalRotation { get; set; }

		[field: NonSerialized]
		public Vector3 HeadLocalScale { get; set; }

		public Vector3 RootPosition
		{
			get
			{
				return TransformUtils.TransformPoint(RootLocalPosition, WorldPosition, WorldRotation, WorldScale);
			}
			set
			{
				RootLocalPosition = TransformUtils.InverseTransformPoint(value, WorldPosition, WorldRotation, WorldScale);
			}
		}

		public Quaternion RootRotation
		{
			get
			{
				return TransformUtils.TransformRotation(RootLocalRotation, WorldPosition, WorldRotation, WorldScale);
			}
			set
			{
				RootLocalRotation = TransformUtils.InverseTransformRotation(value, WorldPosition, WorldRotation, WorldScale);
			}
		}

		public Vector3 RootScale
		{
			get
			{
				return new Vector3(WorldScale.x * RootLocalScale.x, WorldScale.y * RootLocalScale.y, WorldScale.z * RootLocalScale.z);
			}
			set
			{
				RootLocalScale = new Vector3(value.x / WorldScale.x, value.y / WorldScale.y, value.z / WorldScale.z);
			}
		}

		public Vector3 BodyPosition
		{
			get
			{
				return TransformUtils.TransformPoint(BodyLocalPosition, RootPosition, RootRotation, RootScale);
			}
			set
			{
				BodyLocalPosition = TransformUtils.InverseTransformPoint(value, WorldPosition, WorldRotation, WorldScale);
			}
		}

		public Quaternion BodyRotation
		{
			get
			{
				return TransformUtils.TransformRotation(BodyLocalRotation, RootPosition, RootRotation, RootScale);
			}
			set
			{
				BodyLocalRotation = TransformUtils.InverseTransformRotation(value, RootPosition, RootRotation, RootScale);
			}
		}

		public Vector3 BodyScale
		{
			get
			{
				return new Vector3(RootScale.x * BodyLocalScale.x, RootScale.y * BodyLocalScale.y, RootScale.z * BodyLocalScale.z);
			}
			set
			{
				BodyLocalScale = new Vector3(value.x / RootScale.x, value.y / RootScale.y, value.z / RootScale.z);
			}
		}

		public Vector3 HeadPosition
		{
			get
			{
				return TransformUtils.TransformPoint(HeadLocalPosition, BodyPosition, BodyRotation, BodyScale);
			}
			set
			{
				HeadLocalPosition = TransformUtils.InverseTransformPoint(value, BodyPosition, BodyRotation, BodyScale);
			}
		}

		public Quaternion HeadRotation
		{
			get
			{
				return TransformUtils.TransformRotation(HeadLocalRotation, BodyPosition, BodyRotation, BodyScale);
			}
			set
			{
				HeadLocalRotation = TransformUtils.InverseTransformRotation(value, BodyPosition, BodyRotation, BodyScale);
			}
		}

		public Vector3 HeadScale
		{
			get
			{
				return new Vector3(BodyScale.x * HeadLocalScale.x, BodyScale.y * HeadLocalScale.y, BodyScale.z * HeadLocalScale.z);
			}
			set
			{
				HeadLocalScale = new Vector3(value.x / BodyScale.x, value.y / BodyScale.y, value.z / BodyScale.z);
			}
		}

		public TwoBoneData(Transform root, Transform body, Transform head)
		{
			WorldPosition = ((root.parent != null) ? root.parent.position : Vector3.zero);
			WorldRotation = ((root.parent != null) ? root.parent.rotation : Quaternion.identity);
			WorldScale = ((root.parent != null) ? root.parent.lossyScale : Vector3.one);
			RootLocalPosition = root.localPosition;
			RootLocalRotation = root.localRotation;
			RootLocalScale = root.localScale;
			BodyLocalPosition = body.localPosition;
			BodyLocalRotation = body.localRotation;
			BodyLocalScale = body.localScale;
			HeadLocalPosition = head.localPosition;
			HeadLocalRotation = head.localRotation;
			HeadLocalScale = head.localScale;
		}
	}
}
