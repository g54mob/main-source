using Unity.Mathematics;

namespace DV.DopplerEffects
{
	public class SimpleDopplerListener : ADopplerListener
	{
		public override Doppler.UpdateMode UpdateMode => Doppler.UpdateMode.LateUpdate;

		public override float3 GetPosition()
		{
			return base.transform.position;
		}
	}
}
