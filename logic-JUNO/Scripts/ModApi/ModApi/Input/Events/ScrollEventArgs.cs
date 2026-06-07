using System;
using UnityEngine;

namespace ModApi.Input.Events
{
	public class ScrollEventArgs : EventArgs
	{
		public Vector2 Delta { get; set; }
	}
}
