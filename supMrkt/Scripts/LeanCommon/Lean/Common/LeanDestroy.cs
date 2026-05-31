using UnityEngine;

namespace Lean.Common
{
	[HelpURL("https://carloswilkes.com/Documentation/LeanCommon#LeanDestroy")]
	[AddComponentMenu("Lean/Common/Lean Destroy")]
	public class LeanDestroy : MonoBehaviour
	{
		public enum ExecuteType
		{
			OnFirstFrame = 0,
			AfterDelay = 1,
			AfterDelayUnscaled = 2,
			Manually = 3
		}

		[SerializeField]
		private ExecuteType execute;

		[SerializeField]
		private GameObject target;

		[SerializeField]
		private float seconds;

		public ExecuteType Execute
		{
			get
			{
				return default(ExecuteType);
			}
			set
			{
			}
		}

		public GameObject Target
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float Seconds
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected virtual void Update()
		{
		}

		public void DestroyNow()
		{
		}
	}
}
