using System;
using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class AttachMaterialEditor : Attribute
	{
		public AttachMaterialEditor(int order = 0)
		{
		}
	}
}
