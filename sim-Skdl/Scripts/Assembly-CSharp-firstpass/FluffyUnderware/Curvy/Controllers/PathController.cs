using FluffyUnderware.Curvy.Generator;
using FluffyUnderware.DevTools;
using UnityEngine;

namespace FluffyUnderware.Curvy.Controllers
{
	[HelpURL("https://curvyeditor.com/doclink/pathcontroller")]
	[AddComponentMenu("Curvy/Controllers/CG Path Controller")]
	public class PathController : CurvyController
	{
		[CGDataReferenceSelector(typeof(CGPath), Label = "Path/Slot")]
		[SerializeField]
		[Section("General", true, false, 100, Sort = 0)]
		private CGDataReference m_Path;

		public CGDataReference Path
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CGPath PathData => null;

		public override float Length => 0f;

		public override bool IsReady => false;

		protected override float RelativeToAbsolute(float relativeDistance)
		{
			return 0f;
		}

		protected override float AbsoluteToRelative(float worldUnitDistance)
		{
			return 0f;
		}

		protected override Vector3 GetInterpolatedSourcePosition(float tf)
		{
			return default(Vector3);
		}

		protected override void GetInterpolatedSourcePosition(float tf, out Vector3 interpolatedPosition, out Vector3 tangent, out Vector3 up)
		{
			interpolatedPosition = default(Vector3);
			tangent = default(Vector3);
			up = default(Vector3);
		}

		protected override Vector3 GetTangent(float tf)
		{
			return default(Vector3);
		}

		protected override Vector3 GetOrientation(float tf)
		{
			return default(Vector3);
		}

		protected override void Advance(float speed, float deltaTime)
		{
		}

		protected override void SimulateAdvance(ref float tf, ref MovementDirection direction, float speed, float deltaTime)
		{
		}
	}
}
