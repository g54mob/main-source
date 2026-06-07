using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace VampireSurvivors.Framework.Particles
{
	[Serializable]
	public class ParticleSystemConfig
	{
		public enum ScaleMode
		{
			Initial = 0,
			Lifetime = 1
		}

		public ParticleSystem.MinMaxCurve _x;

		public ParticleSystem.MinMaxCurve _y;

		[CanBeNull]
		public List<string> _frame;

		public int _fps;

		public ParticleSystem.MinMaxCurve _angle;

		public int _angleSteps;

		public ParticleSystem.MinMaxCurve? _speed;

		public ParticleSystem.MinMaxCurve? _speedX;

		public ParticleSystem.MinMaxCurve? _speedY;

		public int? _quantity;

		public float? _frequency;

		public ParticleSystem.MinMaxCurve _rotate;

		public ParticleSystem.MinMaxCurve _lifespan;

		public ParticleSystem.MinMaxCurve? _alpha;

		public Easing _alphaEase;

		public ParticleSystem.MinMaxCurve? _scale;

		public ParticleSystem.MinMaxCurve? _scaleX;

		public ParticleSystem.MinMaxCurve? _scaleY;

		public ScaleMode? _scaleMode;

		public Easing _scaleEase;

		public ParticleSystem.MinMaxCurve _gravity;

		public uint? _tint;

		public uint[] _tintRandom;

		public bool _on;

		public BlendMode? _blendMode;

		public ParticleSystem.MinMaxCurve? _bounce;

		public Rect? _bounds;

		public Bounds? _boundsWorld;

		public bool? _collideTop;

		public bool? _collideBottom;

		public bool? _collideLeft;

		public bool? _collideRight;

		[CanBeNull]
		public EmitZone _emitZone;

		public ParticleSystemSimulationSpace? _simulationSpace;

		public bool _circleCollision;

		public float _circleCollisionRadius;

		public string Texture { get; }

		public ParticleSystemConfig(string texture)
		{
		}
	}
}
