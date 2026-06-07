using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct RunnerLocationNone : IRunnerLocation
	{
		public static readonly RunnerLocationNone Create;

		Vector3 IRunnerLocation.Position => Vector3.zero;

		Quaternion IRunnerLocation.Rotation => Quaternion.identity;

		Transform IRunnerLocation.Parent => null;
	}
}
