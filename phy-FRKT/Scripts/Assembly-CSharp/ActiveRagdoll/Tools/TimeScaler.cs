using UnityEngine;

namespace ActiveRagdoll.Tools
{
	public class TimeScaler : MonoBehaviour
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float m_timeValue;

		private float phn;

		private float pho;

		private void Awake()
		{
		}

		public void ChangeTime(float time)
		{
		}
	}
}
