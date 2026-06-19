using MotionSmoothing.Authoring;
using Pug.Conversion;

namespace MotionSmoothing.Converters
{
	public class MotionSmoothingConverter : SingleAuthoringComponentConverter<MotionSmoothingAuthoring>
	{
		protected override void Convert(MotionSmoothingAuthoring authoring)
		{
			((Converter)this).EnsureHasComponent<PhysicsVelocitySmoothedCD>();
			((Converter)this).EnsureHasComponent<PhysicsVelocityInterpolatedValuesCD>();
			((Converter)this).EnsureHasComponent<PhysicsAccelerationSmoothedCD>();
			((Converter)this).EnsureHasComponent<PhysicsAccelerationInterpolatedValuesCD>();
		}
	}
}
