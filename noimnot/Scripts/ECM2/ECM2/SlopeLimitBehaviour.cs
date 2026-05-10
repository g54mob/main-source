using UnityEngine;

namespace ECM2
{
	public sealed class SlopeLimitBehaviour : MonoBehaviour
	{
		[Tooltip("The desired behaviour.")]
		[SerializeField]
		private SlopeBehaviour _slopeBehaviour;

		[SerializeField]
		private float _slopeLimit;

		[SerializeField]
		[HideInInspector]
		private float _slopeLimitCos;

		public SlopeBehaviour walkableSlopeBehaviour
		{
			get
			{
				return default(SlopeBehaviour);
			}
			set
			{
			}
		}

		public float slopeLimit
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float slopeLimitCos
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void OnValidate()
		{
		}
	}
}
