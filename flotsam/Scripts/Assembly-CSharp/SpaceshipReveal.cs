using System.Collections;
using UnityEngine;

public class SpaceshipReveal : WorldMapReveal
{
	[Header("Spaceship")]
	[SerializeField]
	private Transform _visual;

	[SerializeField]
	private int _layer = 22;

	[SerializeField]
	private Vector3 _vector;

	[SerializeField]
	private float _distance = 1000f;

	[SerializeField]
	private float _duration = 3f;

	[SerializeField]
	private float _centerOnTownDelay = 2f;

	[SerializeField]
	private ParticleSystem _heat;

	[SerializeField]
	private ParticleSystem _impact;

	private int _originalLayer;

	private Vector3 _originalLocalPosition;

	private Vector3 _offsetLocalPosition;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(_vector * 50f, -_vector * 50f);
	}

	public override void Initialize(WorldMapPointOfInterest poi)
	{
	}

	public override bool InitializeReveal(WorldMapPointOfInterest poi)
	{
		_visual.gameObject.SetActive(value: true);
		_originalLayer = _visual.gameObject.layer;
		_visual.gameObject.SetLayerRecursively(_layer);
		_originalLocalPosition = _visual.localPosition;
		_offsetLocalPosition = _originalLocalPosition + _vector * _distance;
		_visual.localPosition = _offsetLocalPosition;
		_heat?.Play();
		return true;
	}

	public override IEnumerator Reveal(WorldMapPointOfInterest poi)
	{
		float time = 0f;
		while (time < _duration)
		{
			time += GameSpeedManager.UnscaledDeltaTime;
			_visual.localPosition = Vector3.Lerp(_offsetLocalPosition, _originalLocalPosition, Mathf.Clamp01(time / _duration));
			yield return null;
		}
		_heat?.Stop();
		_impact?.Play();
		_visual.localPosition = _originalLocalPosition;
		_visual.gameObject.SetLayerRecursively(_originalLayer);
		poi.Spawner.ClearFogOfWar();
		yield return new WaitForSeconds(_centerOnTownDelay);
	}
}
