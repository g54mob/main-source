using Motorways.Constants;
using UnityEngine;

namespace Motorways.Views
{
	[ExecuteAlways]
	public class BoatTrail : MonoBehaviour
	{
		[Range(0f, 0.5f)]
		public float waveWidth;

		[Range(0f, 0.5f)]
		public float waveLength;

		[Range(0f, 1f)]
		public float opacityThreshold = 0.5f;

		[SerializeField]
		private VehicleTrailRenderer _boatTrailRenderer;

		[SerializeField]
		private Renderer _boatTrail;

		private float _currentOverallOpacity = 1f;

		private VisualConstantsData _visualConstantsData;

		private float _trailRendererTime;

		public void SetVisualConstantsData(VisualConstantsData data)
		{
			_visualConstantsData = data;
		}

		public void UpdateBoatTrail(float scaledDelta, float distanceToTarget)
		{
			_currentOverallOpacity = (Mathf.Clamp(distanceToTarget, _visualConstantsData.boatTrailDistanceFromTargetVisible, _visualConstantsData.boatTrailDistanceFromTargetFadeIn) - _visualConstantsData.boatTrailDistanceFromTargetVisible) / (_visualConstantsData.boatTrailDistanceFromTargetFadeIn - _visualConstantsData.boatTrailDistanceFromTargetVisible);
			_trailRendererTime = _visualConstantsData.boatNormalTrailRendererTime;
			if (_trailRendererTime >= 0f)
			{
				_boatTrailRenderer.SetLifetime(_trailRendererTime);
			}
			_boatTrailRenderer.Tick(scaledDelta);
		}

		private void UpdatePosition()
		{
			_boatTrail.sharedMaterial.SetFloat(ShaderConstants.TrailTimeEnd, _boatTrailRenderer.GetTimeForPoint(_boatTrailRenderer.GetTailIndex()));
			_boatTrail.sharedMaterial.SetFloat(ShaderConstants.TrailTime, _boatTrailRenderer.GetTimeForPoint(_boatTrailRenderer.GetHeadIndex()));
			_boatTrail.sharedMaterial.SetFloat(ShaderConstants.OverallOpacity, _currentOverallOpacity);
			_boatTrail.sharedMaterial.SetFloat(ShaderConstants.WaveWidth, waveWidth);
			_boatTrail.sharedMaterial.SetFloat(ShaderConstants.WaveLength, waveLength);
			_boatTrail.sharedMaterial.SetFloat(ShaderConstants.OpacityThreshold, opacityThreshold);
		}

		private void OnEnable()
		{
			UpdatePosition();
			_currentOverallOpacity = 1f;
			_trailRendererTime = ((_visualConstantsData != null) ? _visualConstantsData.boatNormalTrailRendererTime : 0f);
		}

		private void Update()
		{
			UpdatePosition();
		}
	}
}
