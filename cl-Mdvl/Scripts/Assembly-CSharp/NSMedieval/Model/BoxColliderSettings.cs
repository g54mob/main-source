using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Model
{
	[Serializable]
	public class BoxColliderSettings : NSEipix.Base.Model
	{
		[SerializeField]
		private Vector3 centerOffset;

		[SerializeField]
		private Vector3 sizeOffset;

		public Vector3 SizeOffset => sizeOffset;

		public Vector3 CenterOffset => centerOffset;

		public bool IsValid
		{
			get
			{
				if (!(centerOffset != Vector3.zero))
				{
					return sizeOffset != Vector3.zero;
				}
				return true;
			}
		}

		public void ApplyToBoxCollider(BoxCollider b)
		{
			b.center += centerOffset;
			b.size += sizeOffset;
		}

		public override string GetID()
		{
			return string.Empty;
		}
	}
}
