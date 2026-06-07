using System;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.VFX;

namespace Simulator.GameWorld
{
	public class Stain : Dirt
	{
		[Header("Particles")]
		[SerializeField]
		private VisualEffect m_cleanStartParticles;

		[Header("Settings")]
		[SerializeField]
		private DecalProjector m_decal;

		private CancellationTokenSource m_cancellationTokenSource;

		private float m_currentDirtiness;

		private StainData m_stainData;

		private float MaxDirtiness
		{
			get
			{
				if (!(m_stainData != null))
				{
					return 100f;
				}
				return m_stainData.Dirtiness;
			}
		}

		private float MinDirtiness
		{
			get
			{
				if (!(m_stainData != null))
				{
					return 0f;
				}
				return m_stainData.MinDirtiness;
			}
		}

		private bool HasStartedCleaning => m_currentDirtiness < MaxDirtiness;

		private bool IsClean => m_currentDirtiness <= MinDirtiness;

		private void OnDestroy()
		{
			Dispose();
		}

		protected override void Initialize(DirtData data, int meshIndex = -1)
		{
			base.Initialize(data);
			m_stainData = data as StainData;
			SetDirtiness(MaxDirtiness);
			SetShaderProperty(1f);
		}

		public void StartClean(IStainCleaner stainCleaner)
		{
			if (!IsClean)
			{
				m_cancellationTokenSource = new CancellationTokenSource();
				if (!HasStartedCleaning && m_cleanStartParticles != null)
				{
					m_cleanStartParticles.Play();
				}
				CleaningAsync(stainCleaner.CleaningRate);
			}
		}

		public void StopClean()
		{
			Dispose();
			SetDirtiness(MaxDirtiness);
			if (m_cleanStartParticles != null)
			{
				m_cleanStartParticles.Stop();
			}
		}

		private async void CleaningAsync(float cleaningRate)
		{
			while (!IsClean && !m_cancellationTokenSource.Token.IsCancellationRequested)
			{
				SetDirtiness(m_currentDirtiness - cleaningRate * Time.deltaTime);
				try
				{
					await Awaitable.NextFrameAsync(m_cancellationTokenSource.Token);
				}
				catch (OperationCanceledException)
				{
				}
			}
			m_currentDirtiness = Mathf.Clamp(m_currentDirtiness, MinDirtiness, MaxDirtiness);
			if (IsClean)
			{
				OnCleanComplete();
			}
		}

		public void SetDirtiness(float value)
		{
			m_currentDirtiness = value;
			float shaderProperty = m_currentDirtiness / MaxDirtiness;
			SetShaderProperty(shaderProperty);
		}

		private void OnCleanComplete()
		{
			if (m_cleanStartParticles != null)
			{
				m_cleanStartParticles.transform.SetParent(null);
				m_cleanStartParticles.Stop();
				m_cleanStartParticles.SendEvent("Cleaned");
				UnityEngine.Object.Destroy(m_cleanStartParticles.gameObject, 10f);
			}
			Dispose();
			World.DirtManager.Unregister(this);
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public override void Dispose()
		{
			CancellationTokenSource cancellationTokenSource = m_cancellationTokenSource;
			if (cancellationTokenSource != null)
			{
				cancellationTokenSource.Cancel();
				cancellationTokenSource.Dispose();
				m_cancellationTokenSource = null;
			}
		}

		private void SetShaderProperty(float value)
		{
			m_decal.fadeFactor = value;
		}
	}
}
