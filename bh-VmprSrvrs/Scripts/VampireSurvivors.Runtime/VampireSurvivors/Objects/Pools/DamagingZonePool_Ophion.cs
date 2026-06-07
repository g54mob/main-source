using QFSW.MOP2;
using VampireSurvivors.App.Scripts.Objects;

namespace VampireSurvivors.Objects.Pools
{
	public class DamagingZonePool_Ophion : Group
	{
		private ObjectPool _pool;

		public DamagingZonePool_Ophion(int capacity = 50)
			: base(0)
		{
		}

		public DamagingZoneOphion SpawnAt(float x, float y, float radius, float damage, float duration, float hitboxDelay)
		{
			return null;
		}

		public void Return(DamagingZoneOphion element)
		{
		}

		public void Destroy()
		{
		}
	}
}
