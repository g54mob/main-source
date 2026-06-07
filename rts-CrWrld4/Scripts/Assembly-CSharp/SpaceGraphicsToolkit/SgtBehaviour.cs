using System;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	public abstract class SgtBehaviour : MonoBehaviour
	{
		[NonSerialized]
		protected bool quitting;

		protected virtual void OnApplicationQuit()
		{
		}
	}
}
