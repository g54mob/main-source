using QFSW.MOP2;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using Zenject;

namespace VampireSurvivors.App
{
	public class TestDamagingZones : GameMonoBehaviour
	{
		private GameSessionData _gameSessionData;

		private ObjectPool _explosionPool;

		private DiContainer _diContainer;

		private DamagingZonePool_Ophion _damagingZonePoolOphion;

		private Timer _damagingZonesEvent;

		protected Camera MainCamera => null;

		[Inject]
		private void Construct(GameSessionData gameSessionData, DiContainer diContainer)
		{
		}

		private void TestWeapons()
		{
		}

		private void TestCoffins()
		{
		}

		private void TestTrainees()
		{
		}

		private void TestExplosions()
		{
		}

		private void TestOphion()
		{
		}

		private void CancelOphion()
		{
		}

		private void DamagingZone_Weapons(float xOffset = 0f, bool follow = false, float duration = 10000f)
		{
		}

		private void DamagingZone_Coffins(float xOffset = 0f, bool follow = false, float duration = 10000f)
		{
		}

		private void DamagingZone_Trainees(float yOffset = 0f, bool follow = false, float duration = 5000f)
		{
		}

		private void DamagingZone_Explosions(float yOffset = 0f, bool follow = false, float duration = 5000f)
		{
		}

		private void FireOphion(float delay, float radius, int times)
		{
		}
	}
}
