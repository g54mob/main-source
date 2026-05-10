using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Misc
{
	public class ToggleableLight : MonoBehaviour
	{
		private enum State
		{
			NotInitialized = 0,
			On = 1,
			Off = 2
		}

		[FormerlySerializedAs("isOn")]
		[SerializeField]
		private bool _isOn;

		[SerializeField]
		[Header("References")]
		protected OptimizedLight[] lightSources;

		[SerializeField]
		protected MeshRenderer[] lightSurfacesMeshes;

		public int MaterialIndex;

		[SerializeField]
		[Header("Materials")]
		protected Material lightOnMat;

		[SerializeField]
		protected Material lightOffMat;

		private State state;

		public bool isOn
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected virtual void Awake()
		{
		}

		public void TurnOn()
		{
		}

		public void TurnOff()
		{
		}

		protected virtual void SetLights()
		{
		}
	}
}
