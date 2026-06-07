using ModApi.Craft.Parts;
using UnityEngine;

namespace ModApi.Design
{
	public struct PartRaycastResult
	{
		public RaycastHit Hit { get; set; }

		public IPartScript PartScript { get; set; }

		public Ray Ray { get; set; }
	}
}
