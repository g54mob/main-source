using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class DEMO_LegsAnim_CharacterControllerTest : MonoBehaviour
	{
		public CharacterController Controller;

		public FDebug_PerformanceTest performanceTest = new FDebug_PerformanceTest();

		private void Update()
		{
			performanceTest.Start(base.gameObject);
			Controller.Move(Vector3.forward * Time.deltaTime);
			performanceTest.Finish(base.gameObject);
		}
	}
}
