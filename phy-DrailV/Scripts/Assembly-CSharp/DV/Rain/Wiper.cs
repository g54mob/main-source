using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV.Rain
{
	public class Wiper : MonoBehaviour
	{
		public delegate void WiperDelegate(Wiper wiper);

		public List<Window> windows = new List<Window>();

		public Transform start;

		public Transform end;

		[NonSerialized]
		public bool releaseDroplets;

		[NonSerialized]
		public bool disableCollision;

		[NonSerialized]
		public Vector3 lastStart;

		[NonSerialized]
		public Vector3 lastEnd;

		[NonSerialized]
		public Vector3 currentDirection;

		[NonSerialized]
		public float velocity;

		[NonSerialized]
		public WiperDriver driver;

		public event WiperDelegate OnReleaseDroplets;

		public void ReleaseDroplets()
		{
			releaseDroplets = true;
			this.OnReleaseDroplets?.Invoke(this);
		}
	}
}
