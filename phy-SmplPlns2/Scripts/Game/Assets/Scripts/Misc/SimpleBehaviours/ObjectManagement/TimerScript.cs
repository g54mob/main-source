using UnityEngine;

namespace Assets.Scripts.Misc.SimpleBehaviours.ObjectManagement
{
	public class TimerScript : MonoBehaviour
	{
		public float DieTime;

		public float TimeAlive { get; set; }

		protected virtual void Update()
		{
			TimeAlive += Time.deltaTime;
			if (DieTime > 0f && TimeAlive >= DieTime)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
