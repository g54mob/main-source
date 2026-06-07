using Unity.Entities;
using UnityEngine;

namespace DV.DopplerEffects
{
	public class DopplerFixedUpdateCaller : MonoBehaviour
	{
		private DopplerFixedUpdateSystem dopplerFixedUpdateSystem;

		private void Awake()
		{
			dopplerFixedUpdateSystem = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<DopplerFixedUpdateSystem>();
		}

		private void FixedUpdate()
		{
			dopplerFixedUpdateSystem.Update();
		}
	}
}
