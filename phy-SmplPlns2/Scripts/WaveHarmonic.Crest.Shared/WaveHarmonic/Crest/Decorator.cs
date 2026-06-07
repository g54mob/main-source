using System;
using UnityEngine;

namespace WaveHarmonic.Crest
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
	internal abstract class Decorator : PropertyAttribute
	{
	}
}
