using System;
using FluffyUnderware.Curvy.Generator;
using UnityEngine;

namespace FluffyUnderware.Curvy
{
	public class CurvyCGEventArgs : EventArgs
	{
		public readonly MonoBehaviour Sender;

		public readonly CurvyGenerator Generator;

		public readonly CGModule Module;

		public CurvyCGEventArgs(CGModule module)
		{
		}

		public CurvyCGEventArgs(CurvyGenerator generator, CGModule module)
		{
		}
	}
}
