using UnityEngine;

namespace Assets.Scripts.Character.FacialExpression
{
	[RequireComponent(typeof(CharacterFacialAnimator))]
	public class EyeBlinkScript : MonoBehaviour
	{
		[SerializeField]
		private Vector2 _blinkLength = new Vector2(0.15f, 0.4f);

		[SerializeField]
		private Vector2 _blinkRate = new Vector2(12f, 30f);

		[SerializeField]
		private FacialExpression _eyesClosedExpression;

		private CharacterFacialAnimator _facialAnimator;

		private float _lastBlinkLength = 0.1f;

		private float _nextBlinkLength = 0.1f;

		private float _nextBlinkTime;

		private float _timeSinceBlink;

		protected void Awake()
		{
			_facialAnimator = GetComponent<CharacterFacialAnimator>();
			_facialAnimator.RegisterExpression(_eyesClosedExpression);
			RandomizeNextBlink();
		}

		protected void Update()
		{
			_timeSinceBlink += Time.deltaTime;
			if (_timeSinceBlink >= _nextBlinkTime)
			{
				_eyesClosedExpression.Weight += Time.deltaTime / (_nextBlinkLength / 2f);
				if (_eyesClosedExpression.Weight >= 1f)
				{
					_timeSinceBlink = 0f;
					_lastBlinkLength = _nextBlinkLength;
					RandomizeNextBlink();
				}
			}
			else if (_eyesClosedExpression.Weight > 0f)
			{
				_eyesClosedExpression.Weight -= Time.deltaTime / _lastBlinkLength;
			}
		}

		private void RandomizeNextBlink()
		{
			_nextBlinkTime = Random.Range(60f / _blinkRate.x, 60f / _blinkRate.y);
			_nextBlinkLength = Random.Range(_blinkLength.x, _blinkLength.y);
		}
	}
}
