using Rhizomatic.MemberBinding;
using UnityEngine;

namespace Rhizomatic
{
	public class TransformMember : Member<Transform>
	{
		public Transform parent
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Vector3 position
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Quaternion rotation
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public Vector3 localPosition
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public Quaternion localRotation
		{
			get
			{
				return default(Quaternion);
			}
			set
			{
			}
		}

		public Vector3 localScale
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}
	}
}
