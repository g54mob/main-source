using System.Collections;
using PajamaLlama.Generic;
using UnityEngine;

public class CargoCapsuleDebrisReveal : WorldMapReveal
{
	public class Piece
	{
		private GameObject _piece;

		private Transform _pieceTransform;

		private ParticleSystem _impact;

		private Vector3 _fromPosition;

		private Vector3 _toPosition;

		private float _duration;

		private float _time;

		public Piece(GameObject piece, ParticleSystem impact, Quaternion rotation, float distance, float duration)
		{
			_piece = piece;
			_pieceTransform = piece.transform;
			_impact = impact;
			_pieceTransform.rotation = rotation;
			_toPosition = _pieceTransform.position;
			_fromPosition = _toPosition - _pieceTransform.forward * distance;
			_pieceTransform.position = _fromPosition;
			_duration = duration;
			_time = 0f;
			piece.SetActive(value: true);
		}

		public bool Next(float deltaTime)
		{
			if (_time >= _duration)
			{
				return false;
			}
			_time += deltaTime;
			_pieceTransform.position = Vector3.Lerp(_fromPosition, _toPosition, Mathf.Clamp01(_time / _duration));
			if (_time >= _duration)
			{
				_piece.SetActive(value: false);
				_impact?.Play();
			}
			return true;
		}
	}

	[SerializeField]
	private MeshRenderer _visualRenderer;

	[SerializeField]
	private GameObject[] _pieces;

	[SerializeField]
	private ParticleSystem[] _impacts;

	[SerializeField]
	private float _impactRotationX;

	[SerializeField]
	private float _duration;

	[SerializeField]
	private RangedFloat _durationVariation;

	[SerializeField]
	private float _distance;

	[SerializeField]
	private float _centerOnTownDelay = 5f;

	private Piece[] _pieceInstances;

	public override void Initialize(WorldMapPointOfInterest poi)
	{
	}

	public override bool InitializeReveal(WorldMapPointOfInterest poi)
	{
		Quaternion rotation = Quaternion.Euler(_impactRotationX, Random.Range(0f, 1f), 0f);
		_visualRenderer.enabled = false;
		_pieceInstances = new Piece[_pieces.Length];
		for (int i = 0; i < _pieces.Length; i++)
		{
			_pieceInstances[i] = new Piece(_pieces[i], _impacts.GetValueOrNull(i), rotation, _distance, _duration + _durationVariation.ReturnRandom());
		}
		return true;
	}

	public override IEnumerator Reveal(WorldMapPointOfInterest poi)
	{
		while (Next(GameSpeedManager.UnscaledDeltaTime))
		{
			yield return null;
		}
		_visualRenderer.enabled = true;
		yield return new WaitForSeconds(_centerOnTownDelay);
	}

	private bool Next(float deltaTime)
	{
		bool result = false;
		for (int i = 0; i < _pieceInstances.Length; i++)
		{
			if (_pieceInstances[i].Next(deltaTime))
			{
				result = true;
			}
		}
		return result;
	}
}
