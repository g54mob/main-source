using ModApi.Flight;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	public class SubStructureRotateScript : MonoBehaviour
	{
		private bool _warp;

		public Vector3 AngularVelocity { get; private set; }

		public void Initialize(Vector3d angularVelocity)
		{
			AngularVelocity = angularVelocity.ToVector3();
		}

		protected virtual void FixedUpdate()
		{
			if (!_warp)
			{
				base.transform.Rotate(AngularVelocity * Time.deltaTime);
			}
		}

		protected virtual void Start()
		{
			FlightSceneScript.Instance.TimeManager.TimeMultiplierModeChanged += OnTimeMultiplierModeChanged;
		}

		private void OnTimeMultiplierModeChanged(TimeMultiplierModeChangedEvent e)
		{
			_warp = e.CurrentMode.WarpMode;
		}
	}
}
