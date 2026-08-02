using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Splines;

namespace sc.modeling.splines.runtime
{
	[Serializable]
	public class Settings
	{
		public enum ColliderType
		{
			Box = 0,
			Mesh = 1
		}

		public enum InterpolationType
		{
			Linear = 0,
			EaseInEaseOut = 1
		}

		[Serializable]
		public class Collision
		{
			[Tooltip("Add a Mesh Collider component and also generate a collision mesh for it")]
			public bool enable;

			[Tooltip("Do not create a visible mesh, but only create the collision mesh")]
			public bool colliderOnly;

			[Tooltip("The \"Box\" type is an automatically created collider mesh, based on the source mesh's bounding box.")]
			public ColliderType type;

			[Min(0f)]
			[Tooltip("Subdivide the collision box, ensures it bends better in curves.")]
			public int boxSubdivisions;

			public Mesh collisionMesh;
		}

		[Serializable]
		public class Distribution
		{
			[Min(1f)]
			public int segments = 1;

			[Tooltip("Automatically calculate the number of segments based on the length of the spline")]
			public bool autoSegmentCount = true;

			[Tooltip("Stretch the segments so that they fit exactly over the entire spline")]
			public bool stretchToFit = true;

			[Tooltip("Ensure the input mesh is repeated evenly, instead of cutting it off when it doesn't fit on the remainder of the spline.")]
			public bool evenOnly;

			[Min(0f)]
			[Tooltip("Shift the mesh X number of units from the start of the spline")]
			public float trimStart;

			[Min(0f)]
			[Tooltip("Shift the mesh X number of units from the end of the spline")]
			public float trimEnd;

			[Tooltip("Space between each mesh segment")]
			public float spacing;
		}

		[Serializable]
		public class Deforming
		{
			[Tooltip("The amount of times a complete rotation is completed over this distance. With a value of 1, a complete roll is created over 1 unit over the spline curve")]
			public enum RollMode
			{
				PerVertex = 0,
				PerSegment = 1
			}

			[Tooltip("Note that offsetting can cause vertices to sort of bunch up.\n\nFor the best results, create a separate spline parallel to the one you are trying to offset from.")]
			[FormerlySerializedAs("offset")]
			public Vector2 curveOffset;

			[Tooltip("Adds a global offset to all vertices, effectively moving its pivot.\n\nNote: if the pivot is already centered, this appears to do exactly the same as the Curve Offset parameter")]
			public Vector2 pivotOffset;

			public Vector3 scale = Vector3.one;

			public PathIndexUnit scalePathIndexUnit;

			[Tooltip("Defines how the data is interpolated from one data point, to the other")]
			public InterpolationType scaleInterpolation;

			[FormerlySerializedAs("ignoreRoll")]
			[Tooltip("Ignore the spline's roll rotation and ensure the geometry stays flat")]
			public bool ignoreKnotRotation;

			[Tooltip("Specify if the rotation roll is calculated for every vertex, or once and applied over the entire segment")]
			public RollMode rollMode;

			[Min(0f)]
			public float rollFrequency = 0.1f;

			[Range(-360f, 360f)]
			public float rollAngle;

			public PathIndexUnit rollPathIndexUnit;
		}

		[Serializable]
		public class UV
		{
			public enum StretchMode
			{
				None = 0,
				[InspectorName("U (X)")]
				U = 1,
				[InspectorName("V (Y)")]
				V = 2
			}

			public Vector2 scale = Vector2.one;

			public Vector2 offset = Vector2.zero;

			[Tooltip("Overwrite the target UV value with that of the vertex position over the spline (normalized 0-1 value)")]
			public StretchMode stretchMode;
		}

		[Serializable]
		public class Color
		{
			public PathIndexUnit pathIndexUnit;
		}

		[Serializable]
		public class Conforming
		{
			[Tooltip("Project the spline curve into the geometry underneath it. Relies on physics raycasts.")]
			public bool enable;

			[Tooltip("A ray is shot this high above every vertex, and reach this much units below it.\n\nIf a spline is dug into the terrain too much, increase this value to still get valid raycast hits.\n\nInternally, the minimum distance is always higher than the mesh's total height.")]
			public float seekDistance = 5f;

			[Tooltip("Ignore raycast hits from colliders that aren't from a Terrain")]
			public bool terrainOnly;

			[Tooltip("Only accept raycast hits from colliders on these layers")]
			public LayerMask layerMask = -1;

			[Tooltip("Rotate the geometry to match the orientation of the surface beneath it")]
			public bool align = true;

			[Tooltip("Reorient the geometry normals to match the surface hit, for correct lighting")]
			public bool blendNormal = true;
		}

		[Serializable]
		public class OutputMesh
		{
			[Tooltip("If enabled, Unity will keep a readable copy of the mesh around in memory. Allowing other scripts to access its data, and possible alter it.")]
			public bool keepReadable;

			[Tooltip("Save relative vertex positions in the (assumingly) unused UV components. If disabled, the source mesh's original values are retained.\n\n[UV0.Z]: (0-1) distance over spline length\n[UV0.W]: (0-1) distance over height of mesh\n\nThis data may be used in shaders for tailored effects, such as animations.")]
			public bool storeGradientsInUV = true;

			[Tooltip("Multiplier for the pack-margin value. A value of 1 equates to 1 texel")]
			[Space]
			[Min(0.01f)]
			public float lightmapUVMarginMultiplier = 1f;

			[Range(15f, 90f)]
			[Tooltip("This angle (in degrees) or greater between triangles will cause UV seam to be created.")]
			public float lightmapUVAngleThreshold = 88f;
		}

		public Collision collision = new Collision();

		public Distribution distribution = new Distribution();

		public Deforming deforming = new Deforming();

		public UV uv = new UV();

		public Color color;

		public Conforming conforming = new Conforming();

		public OutputMesh mesh = new OutputMesh();
	}
}
