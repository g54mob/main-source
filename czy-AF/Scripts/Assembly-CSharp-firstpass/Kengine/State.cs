using System;
using UnityEngine;

namespace Kengine
{
	[Serializable]
	public class State
	{
		public Vector3 position = Vector3.zero;

		public Vector3 rotation = Vector3.zero;

		public Vector3 scale = Vector3.zero;

		public bool active = true;

		public float time = 1f;

		public string tween = "easeInOutSine";

		public State(Vector3 _position, Vector3 _rotation, Vector3 _scale, bool _active, float _time, string _tween)
		{
			position = _position;
			rotation = _rotation;
			scale = _scale;
			active = _active;
			time = _time;
			tween = _tween;
		}
	}
}
