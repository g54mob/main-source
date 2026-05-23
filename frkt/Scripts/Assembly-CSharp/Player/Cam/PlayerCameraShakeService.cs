using System;
using Data.Player.CameraShake;
using UnityEngine;
using Zenject;

namespace Player.Cam
{
	public class PlayerCameraShakeService : MonoBehaviour, om, hn, hj, IInitializable, IDisposable
	{
		[SerializeField]
		private FPSCameraShake m_shake;

		private Transform quo;

		private FPSCameraShake qup;

		private float quq;

		private Vector3 qur;

		private ok qus;

		private Vector3 qut;

		private Quaternion quu;

		private float quv;

		private he quw;

		[Inject]
		private void fuf(ok a, hd b)
		{
		}

		public void Initialize()
		{
		}

		public void ekg()
		{
		}

		public void Dispose()
		{
		}

		public virtual void fug(float a = 0.3f)
		{
		}

		protected virtual void fuh()
		{
		}

		private static bool fui(float a)
		{
			return false;
		}

		private static float fuj(float a, float b)
		{
			return 0f;
		}
	}
}
