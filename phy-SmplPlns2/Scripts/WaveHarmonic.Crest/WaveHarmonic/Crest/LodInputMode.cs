using UnityEngine;

namespace WaveHarmonic.Crest
{
	public enum LodInputMode
	{
		[Tooltip("Unset is the serialization default.\n\nThis will be replaced with the default mode automatically. Unset can also be used if something is invalid.")]
		Unset = 0,
		[Tooltip("Hand-painted data by the user.")]
		Paint = 1,
		[Tooltip("Driven by a user created spline.")]
		Spline = 2,
		[Tooltip("Attached 'Renderer' (mesh, particle or other) used to drive data.")]
		Renderer = 3,
		[Tooltip("Driven by a mathematical primitive such as a cube or sphere.")]
		Primitive = 4,
		[Tooltip("Covers the entire water area.")]
		Global = 5,
		[Tooltip("Data driven by a user provided texture.")]
		Texture = 6,
		[Tooltip("Renders geometry using a default material.")]
		Geometry = 7
	}
}
