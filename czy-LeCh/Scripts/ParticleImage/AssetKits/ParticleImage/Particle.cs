using System;
using System.Collections.Generic;
using AssetKits.ParticleImage.Enumerations;
using Unity.Collections;
using UnityEngine;

namespace AssetKits.ParticleImage
{
	public class Particle
	{
		public struct TrailPoint
		{
			public Vector2 point;

			public float time;

			public TrailPoint(Vector2 p, float t)
			{
				point = p;
				time = t;
			}
		}

		private ParticleImage _source;

		private Transform _transform;

		private Vector2 _modifiedPosition;

		private Vector2 _position;

		private Vector2 _startVelocity;

		private Vector2 _gravityVelocity;

		private Vector2 _velocity;

		private Vector3 _startRotation;

		private Vector3 _startSize;

		private float _time;

		private float _normalizedTime;

		private Color _startColor;

		private float _lifetime;

		private Vector3 _size;

		private Color _color;

		private Vector3 _rotation;

		private float _sizeLerp;

		private float _colorLerp;

		private float _rotateLerp;

		private float _attractorLerp;

		private float _gravityLerp;

		private float _vortexLerp;

		private float _frameOverTimeLerp;

		private float _velocityLerp;

		private float _speedLerp;

		private float _startFrameLerp;

		private float _ratioRandom;

		private Vector2 _attractorTargetPoint;

		private Vector3 _lastTransformPosition;

		private Quaternion _lastTransformRotation;

		private Vector3 _transformDeltaRotation;

		private Vector2 _lastPosition;

		private Vector2 _deltaPosition;

		private Vector3 _direction;

		private Vector2 _trailLastPos;

		private Vector2 _trailDeltaPos;

		private bool _hasTrail;

		private float _frameDelta;

		private int _frameId;

		private int _sheetId;

		private List<TrailPoint> _trailPoints = new List<TrailPoint>(128);

		private Vector2[] _points = new Vector2[4];

		private Vector2[] _rotations = new Vector2[4];

		private Vector2 lastTrailPoint;

		public List<TrailPoint> trailPoints => _trailPoints;

		public Vector2[] points => _points;

		public int GetSheetId
		{
			get
			{
				if (_source.textureSheetEnabled)
				{
					return _sheetId;
				}
				return 0;
			}
		}

		public Vector2 Position => _position;

		public Vector2 Velocity => _velocity;

		public Vector2 Size => _size;

		public float TimeSinceBorn => _time;

		public float Lifetime => _lifetime;

		public Color Color => _color;

		public Particle(ParticleImage source)
		{
			_source = source;
			_transform = source.transform;
			_trailLastPos = _position;
		}

		public void Initialize(Vector2 startPosition, Vector2 startVelocity, Vector3 startRotation, Color startColor, Vector3 startSize, float lifetime, float startTime = 0f)
		{
			_sizeLerp = UnityEngine.Random.value;
			_colorLerp = UnityEngine.Random.value;
			_rotateLerp = UnityEngine.Random.value;
			_attractorLerp = UnityEngine.Random.value;
			_gravityLerp = UnityEngine.Random.value;
			_vortexLerp = UnityEngine.Random.value;
			_startFrameLerp = UnityEngine.Random.value;
			_frameOverTimeLerp = UnityEngine.Random.value;
			_velocityLerp = UnityEngine.Random.value;
			_speedLerp = UnityEngine.Random.value;
			_ratioRandom = UnityEngine.Random.value;
			_attractorTargetPoint = new Vector2(UnityEngine.Random.value, UnityEngine.Random.value);
			_position = startPosition;
			_startVelocity = startVelocity;
			_startColor = startColor;
			_startSize = startSize;
			_startRotation = startRotation;
			_lifetime = lifetime;
			_rotation = _startRotation;
			_lastTransformPosition = _transform.position;
			_modifiedPosition = _position;
			_velocity = Vector2.zero;
			_gravityVelocity = Vector2.zero;
			_deltaPosition = Vector2.zero;
			_transformDeltaRotation = Vector3.zero;
			_direction = Vector3.zero;
			_color = _startColor;
			_size = _startSize;
			_lastPosition = _position;
			_time = startTime;
			_normalizedTime = 0f;
			_frameId = 0;
			_frameId += (int)_source.textureSheetStartFrame.Evaluate(_time.Remap(0f, _lifetime, 0f, 1f), _startFrameLerp);
			_rotations[0] = new Vector2(_size.x / 2f, _size.y / 2f);
			_rotations[1] = new Vector2((0f - _size.x) / 2f, _size.y / 2f);
			_rotations[2] = new Vector2((0f - _size.x) / 2f, (0f - _size.y) / 2f);
			_rotations[3] = new Vector2(_size.x / 2f, (0f - _size.y) / 2f);
			if (_source.trailsEnabled)
			{
				_trailPoints.Clear();
				_trailPoints.Add(new TrailPoint(_position, 0f));
				lastTrailPoint = _position;
				_hasTrail = _ratioRandom <= _source.trailRatio;
			}
		}

		public void Simulate(float deltaTime)
		{
			_time += deltaTime;
			_normalizedTime = _time.Remap(0f, _lifetime, 0f, 1f);
			_velocity = _startVelocity * _source.speedOverLifetime.Evaluate(_normalizedTime, _speedLerp);
			if (_source.space == Simulation.World)
			{
				Vector3 vector = _transform.InverseTransformPoint(_lastTransformPosition);
				_modifiedPosition += new Vector2(vector.x, vector.y);
				_transformDeltaRotation = Quaternion.Inverse(_transform.rotation).eulerAngles - Quaternion.Inverse(_lastTransformRotation).eulerAngles;
				_modifiedPosition = RotatePointAroundCenter(_modifiedPosition, _transformDeltaRotation);
				_startVelocity = RotatePointAroundCenter(_startVelocity, _transformDeltaRotation);
				_lastTransformPosition = _transform.position;
				_lastTransformRotation = _transform.rotation;
			}
			if (_source.velocityEnabled)
			{
				if (_source.velocitySpace == Simulation.World)
				{
					_velocity += RotatePointAroundCenter(_source.velocityOverLifetime.Evaluate(_normalizedTime, _velocityLerp), Quaternion.Inverse(_transform.rotation).eulerAngles);
				}
				else
				{
					_velocity += _source.velocityOverLifetime.EvaluateXY(_normalizedTime, _velocityLerp);
				}
			}
			if (_source.gravityEnabled)
			{
				_gravityVelocity += RotatePointAroundCenter(new Vector2(0f, _source.gravity.Evaluate(_normalizedTime, _gravityLerp)), Quaternion.Inverse(_transform.rotation).eulerAngles) * deltaTime;
			}
			if (_source.noiseEnabled)
			{
				float num = 0f;
				if (_source.space == Simulation.Local)
				{
					num = _source.noise.GetNoise(_position.x + _source.noiseOffset.x, _position.y + _source.noiseOffset.y);
				}
				else
				{
					Vector3 localPosition = _transform.localPosition;
					Vector2 vector2 = _position + new Vector2(localPosition.x, localPosition.y);
					num = _source.noise.GetNoise(vector2.x + _source.noiseOffset.x, vector2.y + _source.noiseOffset.y);
				}
				_velocity += new Vector2(Mathf.Cos(num * MathF.PI), Mathf.Sin(num * MathF.PI)) * _source.noiseStrength;
			}
			_velocity += _gravityVelocity;
			_modifiedPosition += _velocity * (deltaTime * 100f);
			if (_source.vortexEnabled)
			{
				_modifiedPosition = RotatePointAroundCenter(_modifiedPosition, new Vector3(0f, 0f, _source.vortexStrength.Evaluate(_normalizedTime, _vortexLerp) * deltaTime * 100f));
			}
			if (_source.attractorEnabled && (bool)_source.attractorTarget)
			{
				Vector3 b;
				if (_source.attractorTarget is RectTransform)
				{
					b = _transform.InverseTransformPoint(_source.attractorTarget.position);
				}
				else
				{
					Vector3 vector3 = _source.WorldToViewportPoint(_source.attractorTarget.position);
					_source.attractorType = AttractorType.Pivot;
					b = ((_source.canvas.renderMode != RenderMode.ScreenSpaceCamera) ? new Vector3((vector3.x.Remap(0.5f, 1.5f, 0f, _source.canvasRect.rect.width) - _source.canvasRect.InverseTransformPoint(_transform.position).x) / _transform.lossyScale.x * _source.canvasRect.localScale.x, (vector3.y.Remap(0.5f, 1.5f, 0f, _source.canvasRect.rect.height) - _source.canvasRect.InverseTransformPoint(_transform.position).y) / _transform.lossyScale.y * _source.canvasRect.localScale.y, 0f) : new Vector3((vector3.x.Remap(0.5f, 1.5f, 0f, _source.canvasRect.rect.width) - _source.canvasRect.InverseTransformPoint(_transform.position).x + _source.canvasRect.localPosition.x) / _transform.lossyScale.x * _source.canvasRect.localScale.x, (vector3.y.Remap(0.5f, 1.5f, 0f, _source.canvasRect.rect.height) - _source.canvasRect.InverseTransformPoint(_transform.position).y + _source.canvasRect.localPosition.y) / _transform.lossyScale.y * _source.canvasRect.localScale.y, 0f));
				}
				if (_source.attractorType == AttractorType.Pivot)
				{
					_position = Vector3.LerpUnclamped(_modifiedPosition, b, _source.attractorLerp.Evaluate(_normalizedTime, _attractorLerp));
				}
				else
				{
					RectTransform rectTransform = _source.attractorTarget as RectTransform;
					_position = Vector3.LerpUnclamped(_modifiedPosition, new Vector2(b.x + _attractorTargetPoint.x.Remap(0f, 1f, (0f - rectTransform.sizeDelta.x) / 2f, rectTransform.sizeDelta.x / 2f), b.y + _attractorTargetPoint.y.Remap(0f, 1f, (0f - rectTransform.sizeDelta.y) / 2f, rectTransform.sizeDelta.y / 2f)), _source.attractorLerp.Evaluate(_normalizedTime, _attractorLerp));
				}
			}
			else
			{
				_position = _modifiedPosition;
			}
			_deltaPosition = _position - _lastPosition;
			_lastPosition = _position;
			float num2 = _deltaPosition.magnitude * (1f / deltaTime) / 100f;
			if (float.IsNaN(num2))
			{
				num2 = 0f;
			}
			Color color = _source.colorOverLifetime.Evaluate(_normalizedTime, _colorLerp);
			_color = _startColor * color * _source.colorBySpeed.Evaluate(num2.Remap(_source.colorSpeedRange.from, _source.colorSpeedRange.to, 0f, 1f));
			Vector3 b2 = _source.sizeOverLifetime.Evaluate(_normalizedTime, _sizeLerp);
			Vector3 a = _source.sizeBySpeed.Evaluate(num2.Remap(_source.sizeSpeedRange.from, _source.sizeSpeedRange.to, 0f, 1f), _sizeLerp);
			_size = Vector3.Scale(_startSize, Vector3.Scale(a, b2));
			_direction = _deltaPosition;
			if (_direction.magnitude == 0f)
			{
				_direction = _velocity;
			}
			_direction = _direction.normalized;
			Vector3 vector4 = Vector3.zero;
			if (_source.rotationOverLifetime.separated)
			{
				float num3 = 0f;
				float num4 = 0f;
				float num5 = 0f;
				num3 = ((_source.rotationOverLifetime.xCurve.mode != ParticleSystemCurveMode.Constant && _source.rotationOverLifetime.xCurve.mode != ParticleSystemCurveMode.TwoConstants) ? _source.rotationOverLifetime.xCurve.Evaluate(_normalizedTime, _rotateLerp) : _time.Remap(0f, _lifetime, 0f, _source.rotationOverLifetime.xCurve.Evaluate(_rotateLerp, _rotateLerp)));
				num4 = ((_source.rotationOverLifetime.yCurve.mode != ParticleSystemCurveMode.Constant && _source.rotationOverLifetime.yCurve.mode != ParticleSystemCurveMode.TwoConstants) ? _source.rotationOverLifetime.yCurve.Evaluate(_normalizedTime, _rotateLerp) : _time.Remap(0f, _lifetime, 0f, _source.rotationOverLifetime.yCurve.Evaluate(_rotateLerp, _rotateLerp)));
				num5 = ((_source.rotationOverLifetime.zCurve.mode != ParticleSystemCurveMode.Constant && _source.rotationOverLifetime.zCurve.mode != ParticleSystemCurveMode.TwoConstants) ? _source.rotationOverLifetime.zCurve.Evaluate(_normalizedTime, _rotateLerp) : _time.Remap(0f, _lifetime, 0f, _source.rotationOverLifetime.zCurve.Evaluate(_rotateLerp, _rotateLerp)));
				vector4 = new Vector3(num3, num4, num5);
				if (!_source.alignToDirection)
				{
					vector4 += Quaternion.Inverse(_source.transform.rotation).eulerAngles;
				}
			}
			else
			{
				switch (_source.rotationOverLifetime.mainCurve.mode)
				{
				case ParticleSystemCurveMode.Constant:
				case ParticleSystemCurveMode.TwoConstants:
					vector4 = new Vector3(0f, 0f, _time.Remap(0f, _lifetime, 0f, _source.rotationOverLifetime.mainCurve.Evaluate(_normalizedTime, _rotateLerp)));
					break;
				case ParticleSystemCurveMode.Curve:
				case ParticleSystemCurveMode.TwoCurves:
					vector4 = new Vector3(0f, 0f, _source.rotationOverLifetime.mainCurve.Evaluate(_normalizedTime, _rotateLerp));
					break;
				}
				if (!_source.alignToDirection)
				{
					vector4 += new Vector3(0f, 0f, Quaternion.Inverse(_source.transform.rotation).eulerAngles.z);
				}
			}
			Vector3 vector5 = ((!_source.rotationBySpeed.separated) ? _source.rotationBySpeed.EvaluateZ(num2.Remap(_source.rotationSpeedRange.from, _source.rotationSpeedRange.to, 0f, 1f), _rotateLerp) : _source.rotationBySpeed.Evaluate(num2.Remap(_source.rotationSpeedRange.from, _source.rotationSpeedRange.to, 0f, 1f), _rotateLerp));
			if (_source.alignToDirection)
			{
				Quaternion quaternion = Quaternion.FromToRotation(Vector3.up, _direction);
				_rotation = _startRotation + Quaternion.Euler(new Vector3(0f, 0f, quaternion.eulerAngles.z)).eulerAngles;
			}
			else
			{
				_rotation = _startRotation;
			}
			_rotation += vector4 + vector5;
			if (_source.trailsEnabled && _trailPoints.Count > 0)
			{
				NativeArray<Vector3> nativeArray = new NativeArray<Vector3>(_trailPoints.Count * 2, Allocator.Temp);
				NativeArray<Color> cols = new NativeArray<Color>(_trailPoints.Count * 2, Allocator.Temp);
				NativeArray<int> tris = new NativeArray<int>((_trailPoints.Count - 1) * 6, Allocator.Temp);
				if (_time < _lifetime)
				{
					TrailPoint value = new TrailPoint(_position, _time);
					_trailPoints[_trailPoints.Count - 1] = value;
				}
				if (trailPoints.Count > 1)
				{
					TrailPoint value2 = _trailPoints[0];
					value2.point = Vector2.Lerp(trailPoints[1].point, lastTrailPoint, Mathf.Abs(_time.Remap(_trailPoints[0].time + _source.trailLifetime, _trailPoints[1].time + _source.trailLifetime, 0f, 1f)));
					_trailPoints[0] = value2;
				}
				float to = Vector3.Distance(_trailPoints[0].point, _position);
				for (int i = 0; i < _trailPoints.Count; i++)
				{
					Vector2 vector6 = _trailPoints[i].point;
					float time = ((i > 0) ? Vector3.Distance(_trailPoints[0].point, _trailPoints[i].point).Remap(0f, to, 1f, 0f) : 1f);
					float num6 = _size.x * _source.trailWidth.Evaluate(time, _sizeLerp);
					if (_trailPoints.Count > 1)
					{
						vector6 = ((i >= _trailPoints.Count - 1) ? (_trailPoints[i].point - _trailPoints[i - 1].point) : (_trailPoints[i + 1].point - _trailPoints[i].point));
					}
					Vector2 point = _trailPoints[i].point;
					Vector2 vector7 = Vector2.Perpendicular(vector6.normalized);
					Color value3 = _source.trailColorOverTrail.Evaluate(time, _colorLerp) * _source.trailColorOverLifetime.Evaluate(_normalizedTime, _colorLerp);
					if (_source.inheritParticleColor)
					{
						value3 *= _color;
					}
					nativeArray[i * 2 + 1] = point + vector7 * num6 / 2f;
					nativeArray[i * 2] = point - vector7 * num6 / 2f;
					cols[i * 2] = value3;
					cols[i * 2 + 1] = value3;
				}
				for (int j = 0; j < trailPoints.Count - 1; j++)
				{
					tris[j * 6] = j * 2;
					tris[j * 6 + 1] = j * 2 + 1;
					tris[j * 6 + 2] = j * 2 + 2;
					tris[j * 6 + 3] = j * 2 + 2;
					tris[j * 6 + 4] = j * 2 + 1;
					tris[j * 6 + 5] = j * 2 + 3;
				}
				_source.particleTrailRenderer.UpdateMeshData(nativeArray, tris, cols);
				if (_time >= _trailPoints[0].time + _source.trailLifetime)
				{
					_trailPoints.RemoveAt(0);
					lastTrailPoint = _trailPoints[0].point;
				}
				if (_time < _lifetime && _hasTrail)
				{
					_trailDeltaPos = _trailLastPos - _position;
					if (_trailDeltaPos.magnitude > _source.minimumVertexDistance)
					{
						_trailLastPos = _position;
						_trailPoints.Add(new TrailPoint(_position, _time));
					}
				}
			}
			NativeArray<SpriteSheet> sheetsArray = _source.sheetsArray;
			switch (_source.textureSheetType)
			{
			case SheetType.Speed:
				_frameId = (int)_velocity.magnitude.Remap(_source.textureSheetFrameSpeedRange.from, _source.textureSheetFrameSpeedRange.to, 0f, sheetsArray.Length);
				break;
			case SheetType.Lifetime:
				_frameId = (int)(_source.textureSheetFrameOverTime.Evaluate(_normalizedTime, _frameOverTimeLerp) * (float)_source.textureSheetCycles) + (int)_source.textureSheetStartFrame.Evaluate(_normalizedTime, _startFrameLerp);
				break;
			case SheetType.FPS:
			{
				float num7 = 1f / (float)_source.textureSheetFPS;
				_frameDelta += deltaTime;
				while (_frameDelta >= num7)
				{
					_frameDelta -= num7;
					_frameId++;
				}
				break;
			}
			}
			_sheetId = (int)Mathf.Repeat(_frameId, sheetsArray.Length);
			_rotations[0] = new Vector3(_size.x / 2f, _size.y / 2f);
			_rotations[1] = new Vector3((0f - _size.x) / 2f, _size.y / 2f);
			_rotations[2] = new Vector3((0f - _size.x) / 2f, (0f - _size.y) / 2f);
			_rotations[3] = new Vector3(_size.x / 2f, (0f - _size.y) / 2f);
			RotatePointsAroundCenter(_rotations, _rotation);
			_points[0] = _position + _rotations[0];
			_points[1] = _position + _rotations[1];
			_points[2] = _position + _rotations[2];
			_points[3] = _position + _rotations[3];
		}

		private void RotatePointsAroundCenter(Vector2[] points, Vector3 angles)
		{
			Quaternion quaternion = Quaternion.Euler(angles);
			for (int i = 0; i < points.Length; i++)
			{
				points[i] = quaternion * points[i];
			}
		}

		private Vector2 RotatePointAroundCenter(Vector2 point, Vector3 angles)
		{
			return Quaternion.Euler(angles) * point;
		}
	}
}
