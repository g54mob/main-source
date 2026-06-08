using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Shapes
{
	public static class Draw
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct TemporaryColor : IDisposable
		{
			private static Stack<Color> colorStack = new Stack<Color>();

			public TemporaryColor(Color newColor)
			{
				colorStack.Push(Color);
				Color = newColor;
			}

			public TemporaryColor(Color rgb, float opacity)
			{
				colorStack.Push(Color);
				Color = new Color(rgb.r, rgb.g, rgb.b, opacity);
			}

			void IDisposable.Dispose()
			{
				Color = colorStack.Pop();
			}
		}

		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct TemporaryOpacity : IDisposable
		{
			private static Stack<float> opacityStack = new Stack<float>();

			public TemporaryOpacity(float newOpacity)
			{
				opacityStack.Push(Opacity);
				Opacity = newOpacity;
			}

			void IDisposable.Dispose()
			{
				Opacity = opacityStack.Pop();
			}
		}

		private static MpbLine mpbLine;

		private static MpbPolyline mpbPolyline;

		private static MpbPolyline mpbPolylineJoins;

		private static MpbPolygon mpbPolygon;

		private static MpbDisc mpbDisc;

		private static MpbRegularPolygon mpbRegularPolygon;

		private static MpbRectangle mpbRectangle;

		private static MpbTriangle mpbTriangle;

		private static MpbQuad mpbQuad;

		private static readonly MpbSphere metaMpbSphere;

		private static readonly MpbCone mpbCone;

		private static readonly MpbCuboid mpbCuboid;

		private static MpbTorus mpbTorus;

		private static MpbText mpbText;

		private static Matrix4x4 matrix;

		private static bool hasCustomMatrix;

		internal static RenderState renderState;

		public static Color Rgb
		{
			get
			{
				Color color = Color;
				color.a = 1f;
				return color;
			}
			set
			{
				Color = new Color(value.r, value.g, value.b, Color.a);
			}
		}

		public static float Opacity
		{
			get
			{
				return Color.a;
			}
			set
			{
				Color color = Color;
				color.a = value;
				Color = color;
			}
		}

		public static bool HasCustomMatrix => hasCustomMatrix;

		public static Matrix4x4 Matrix
		{
			get
			{
				return matrix;
			}
			set
			{
				matrix = value;
				hasCustomMatrix = value != Matrix4x4.identity;
			}
		}

		public static CompareFunction ZTest
		{
			get
			{
				return renderState.zTest;
			}
			set
			{
				renderState.zTest = value;
			}
		}

		public static float ZOffsetFactor
		{
			get
			{
				return renderState.zOffsetFactor;
			}
			set
			{
				renderState.zOffsetFactor = value;
			}
		}

		public static int ZOffsetUnits
		{
			get
			{
				return renderState.zOffsetUnits;
			}
			set
			{
				renderState.zOffsetUnits = value;
			}
		}

		public static CompareFunction StencilComp
		{
			get
			{
				return renderState.stencilComp;
			}
			set
			{
				renderState.stencilComp = value;
			}
		}

		public static StencilOp StencilOpPass
		{
			get
			{
				return renderState.stencilOpPass;
			}
			set
			{
				renderState.stencilOpPass = value;
			}
		}

		public static byte StencilRefID
		{
			get
			{
				return renderState.stencilRefID;
			}
			set
			{
				renderState.stencilRefID = value;
			}
		}

		public static byte StencilReadMask
		{
			get
			{
				return renderState.stencilReadMask;
			}
			set
			{
				renderState.stencilReadMask = value;
			}
		}

		public static byte StencilWriteMask
		{
			get
			{
				return renderState.stencilWriteMask;
			}
			set
			{
				renderState.stencilWriteMask = value;
			}
		}

		public static Color Color { get; set; }

		public static ShapesBlendMode BlendMode { get; set; }

		public static ScaleMode ScaleMode { get; set; }

		public static DetailLevel DetailLevel { get; set; }

		public static float LineThickness { get; set; }

		public static ThicknessSpace LineThicknessSpace { get; set; }

		public static LineEndCap LineEndCaps { get; set; }

		public static LineGeometry LineGeometry { get; set; }

		public static PolygonTriangulation PolygonTriangulation { get; set; }

		public static ShapeFill PolygonShapeFill { get; set; }

		public static DashStyle LineDashStyle { get; set; }

		public static DashStyle RingDashStyle { get; set; }

		[Obsolete("please use Draw.LineDashStyle.UniformSize or Draw.LineDashStyle.size instead", false)]
		public static float LineDashSize
		{
			get
			{
				return LineDashStyle.UniformSize;
			}
			set
			{
				LineDashStyle.UniformSize = value;
			}
		}

		public static PolylineGeometry PolylineGeometry { get; set; }

		public static PolylineJoins PolylineJoins { get; set; }

		public static float DiscRadius { get; set; }

		public static DiscGeometry DiscGeometry { get; set; }

		public static float RingThickness { get; set; }

		public static ThicknessSpace RingThicknessSpace { get; set; }

		public static ThicknessSpace DiscRadiusSpace { get; set; }

		public static float RegularPolygonRadius { get; set; }

		public static int RegularPolygonSideCount { get; set; }

		public static RegularPolygonGeometry RegularPolygonGeometry { get; set; }

		public static float RegularPolygonThickness { get; set; }

		public static ThicknessSpace RegularPolygonThicknessSpace { get; set; }

		public static ThicknessSpace RegularPolygonRadiusSpace { get; set; }

		public static ShapeFill RegularPolygonShapeFill { get; set; }

		public static float SphereRadius { get; set; }

		public static ThicknessSpace SphereRadiusSpace { get; set; }

		public static ThicknessSpace CuboidSizeSpace { get; set; }

		public static ThicknessSpace TorusThicknessSpace { get; set; }

		public static ThicknessSpace TorusRadiusSpace { get; set; }

		public static ThicknessSpace ConeSizeSpace { get; set; }

		public static TMP_FontAsset Font { get; set; }

		public static float FontSize { get; set; }

		public static TextAlign TextAlign { get; set; }

		public static DrawCommand Command(Camera cam, RenderPassEvent cameraEvent = RenderPassEvent.BeforeRenderingPostProcessing)
		{
			return new DrawCommand(cam, cameraEvent);
		}

		[OvldGenCallTarget]
		private static void Line([OvldDefault("BlendMode")] ShapesBlendMode blendMode, [OvldDefault("LineGeometry")] LineGeometry geometry, [OvldDefault("LineEndCaps")] LineEndCap endCaps, [OvldDefault("LineThicknessSpace")] ThicknessSpace thicknessSpace, Vector3 start, Vector3 end, [OvldDefault("Color")] Color colorStart, [OvldDefault("Color")] Color colorEnd, [OvldDefault("LineThickness")] float thickness, [OvldDefault("LineDashStyle")] DashStyle dashStyle = null)
		{
			using (new IMDrawer(mpbLine, ShapesMaterialUtils.GetLineMat(geometry, endCaps)[blendMode], ShapesMeshUtils.GetLineMesh(geometry, endCaps, DetailLevel)))
			{
				MetaMpb.ApplyDashSettings(mpbLine, dashStyle, thickness);
				mpbLine.color.Add(colorStart);
				mpbLine.colorEnd.Add(colorEnd);
				mpbLine.pointStart.Add(start);
				mpbLine.pointEnd.Add(end);
				mpbLine.thickness.Add(thickness);
				mpbLine.alignment.Add((float)geometry);
				mpbLine.thicknessSpace.Add((float)thicknessSpace);
				mpbLine.scaleMode.Add((float)ScaleMode);
			}
		}

		[OvldGenCallTarget]
		private static void Polyline([OvldDefault("BlendMode")] ShapesBlendMode blendMode, PolylinePath path, [OvldDefault("false")] bool closed, [OvldDefault("PolylineGeometry")] PolylineGeometry geometry, [OvldDefault("PolylineJoins")] PolylineJoins joins, [OvldDefault("LineThickness")] float thickness, [OvldDefault("LineThicknessSpace")] ThicknessSpace thicknessSpace, [OvldDefault("Color")] Color color)
		{
			if (!path.EnsureMeshIsReadyToRender(closed, joins, out var outMesh))
			{
				return;
			}
			switch (path.Count)
			{
			case 0:
				Debug.LogWarning("Tried to draw polyline with no points");
				return;
			case 1:
				Debug.LogWarning("Tried to draw polyline with only one point");
				return;
			}
			using (new IMDrawer(mpbPolyline, ShapesMaterialUtils.GetPolylineMat(joins)[blendMode], outMesh))
			{
				ApplyToMpb(mpbPolyline);
			}
			if (!joins.HasJoinMesh())
			{
				return;
			}
			using (new IMDrawer(mpbPolylineJoins, ShapesMaterialUtils.GetPolylineJoinsMat(joins)[blendMode], outMesh, 1))
			{
				ApplyToMpb(mpbPolylineJoins);
			}
			void ApplyToMpb(MpbPolyline mpb)
			{
				mpb.thickness.Add(thickness);
				mpb.thicknessSpace.Add((float)thicknessSpace);
				mpb.color.Add(color);
				mpb.alignment.Add((float)geometry);
				mpb.scaleMode.Add((float)ScaleMode);
			}
		}

		[OvldGenCallTarget]
		private static void Polygon([OvldDefault("BlendMode")] ShapesBlendMode blendMode, PolygonPath path, [OvldDefault("PolygonTriangulation")] PolygonTriangulation triangulation, [OvldDefault("Color")] Color color, [OvldDefault("PolygonShapeFill")] ShapeFill fill)
		{
			if (!path.EnsureMeshIsReadyToRender(triangulation, out var outMesh))
			{
				return;
			}
			switch (path.Count)
			{
			case 0:
				Debug.LogWarning("Tried to draw polygon with no points");
				return;
			case 1:
				Debug.LogWarning("Tried to draw polygon with only one point");
				return;
			case 2:
				Debug.LogWarning("Tried to draw polygon with only two points");
				return;
			}
			using (new IMDrawer(mpbPolygon, ShapesMaterialUtils.matPolygon[blendMode], outMesh))
			{
				MetaMpb.ApplyColorOrFill(mpbPolygon, fill, color);
			}
		}

		[OvldGenCallTarget]
		private static void Disc(Vector3 pos, [OvldDefault("Quaternion.identity")] Quaternion rot, [OvldDefault("DiscRadius")] float radius, [OvldDefault("Color")] Color colorInnerStart, [OvldDefault("Color")] Color colorOuterStart, [OvldDefault("Color")] Color colorInnerEnd, [OvldDefault("Color")] Color colorOuterEnd)
		{
			DiscCore(BlendMode, DiscRadiusSpace, RingThicknessSpace, hollow: false, sector: false, pos, rot, radius, 0f, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd);
		}

		[OvldGenCallTarget]
		private static void Ring(Vector3 pos, [OvldDefault("Quaternion.identity")] Quaternion rot, [OvldDefault("DiscRadius")] float radius, [OvldDefault("RingThickness")] float thickness, [OvldDefault("Color")] Color colorInnerStart, [OvldDefault("Color")] Color colorOuterStart, [OvldDefault("Color")] Color colorInnerEnd, [OvldDefault("Color")] Color colorOuterEnd, [OvldDefault("RingDashStyle")] DashStyle dashStyle = null)
		{
			DiscCore(BlendMode, DiscRadiusSpace, RingThicknessSpace, hollow: true, sector: false, pos, rot, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, dashStyle);
		}

		[OvldGenCallTarget]
		private static void Pie(Vector3 pos, [OvldDefault("Quaternion.identity")] Quaternion rot, [OvldDefault("DiscRadius")] float radius, [OvldDefault("Color")] Color colorInnerStart, [OvldDefault("Color")] Color colorOuterStart, [OvldDefault("Color")] Color colorInnerEnd, [OvldDefault("Color")] Color colorOuterEnd, float angleRadStart, float angleRadEnd)
		{
			DiscCore(BlendMode, DiscRadiusSpace, RingThicknessSpace, hollow: false, sector: true, pos, rot, radius, 0f, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, null, angleRadStart, angleRadEnd);
		}

		[OvldGenCallTarget]
		private static void Arc(Vector3 pos, [OvldDefault("Quaternion.identity")] Quaternion rot, [OvldDefault("DiscRadius")] float radius, [OvldDefault("RingThickness")] float thickness, [OvldDefault("Color")] Color colorInnerStart, [OvldDefault("Color")] Color colorOuterStart, [OvldDefault("Color")] Color colorInnerEnd, [OvldDefault("Color")] Color colorOuterEnd, float angleRadStart, float angleRadEnd, [OvldDefault("ArcEndCap.None")] ArcEndCap endCaps, [OvldDefault("RingDashStyle")] DashStyle dashStyle = null)
		{
			DiscCore(BlendMode, DiscRadiusSpace, RingThicknessSpace, hollow: true, sector: true, pos, rot, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, dashStyle, angleRadStart, angleRadEnd, endCaps);
		}

		private static void DiscCore(ShapesBlendMode blendMode, ThicknessSpace spaceRadius, ThicknessSpace spaceThickness, bool hollow, bool sector, Vector3 pos, Quaternion rot, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd, DashStyle dashStyle = null, float angleRadStart = 0f, float angleRadEnd = 0f, ArcEndCap arcEndCaps = ArcEndCap.None)
		{
			if (sector && Mathf.Abs(angleRadEnd - angleRadStart) < 0.0001f)
			{
				return;
			}
			using (new IMDrawer(mpbDisc, ShapesMaterialUtils.GetDiscMaterial(hollow, sector)[blendMode], ShapesMeshUtils.QuadMesh[0], pos, rot))
			{
				MetaMpb.ApplyDashSettings(mpbDisc, dashStyle, thickness);
				mpbDisc.radius.Add(radius);
				mpbDisc.radiusSpace.Add((float)spaceRadius);
				mpbDisc.alignment.Add((float)DiscGeometry);
				mpbDisc.thicknessSpace.Add((float)spaceThickness);
				mpbDisc.thickness.Add(thickness);
				mpbDisc.scaleMode.Add((float)ScaleMode);
				mpbDisc.angStart.Add(angleRadStart);
				mpbDisc.angEnd.Add(angleRadEnd);
				mpbDisc.roundCaps.Add((float)arcEndCaps);
				mpbDisc.color.Add(colorInnerStart);
				mpbDisc.colorOuterStart.Add(colorOuterStart);
				mpbDisc.colorInnerEnd.Add(colorInnerEnd);
				mpbDisc.colorOuterEnd.Add(colorOuterEnd);
			}
		}

		[OvldGenCallTarget]
		private static void RegularPolygon([OvldDefault("BlendMode")] ShapesBlendMode blendMode, [OvldDefault("RegularPolygonRadiusSpace")] ThicknessSpace spaceRadius, [OvldDefault("RegularPolygonThicknessSpace")] ThicknessSpace spaceThickness, Vector3 pos, [OvldDefault("Quaternion.identity")] Quaternion rot, [OvldDefault("RegularPolygonSideCount")] int sideCount, [OvldDefault("RegularPolygonRadius")] float radius, [OvldDefault("RegularPolygonThickness")] float thickness, [OvldDefault("Color")] Color color, bool hollow, [OvldDefault("0f")] float roundness, [OvldDefault("0f")] float angle, [OvldDefault("PolygonShapeFill")] ShapeFill fill)
		{
			using (new IMDrawer(mpbRegularPolygon, ShapesMaterialUtils.matRegularPolygon[blendMode], ShapesMeshUtils.QuadMesh[0], pos, rot))
			{
				MetaMpb.ApplyColorOrFill(mpbRegularPolygon, fill, color);
				mpbRegularPolygon.radius.Add(radius);
				mpbRegularPolygon.radiusSpace.Add((float)spaceRadius);
				mpbRegularPolygon.geometry.Add((float)RegularPolygonGeometry);
				mpbRegularPolygon.sides.Add(Mathf.Max(3, sideCount));
				mpbRegularPolygon.angle.Add(angle);
				mpbRegularPolygon.roundness.Add(roundness);
				mpbRegularPolygon.hollow.Add(hollow.AsInt());
				mpbRegularPolygon.thicknessSpace.Add((float)spaceThickness);
				mpbRegularPolygon.thickness.Add(thickness);
				mpbRegularPolygon.scaleMode.Add((float)ScaleMode);
			}
		}

		[OvldGenCallTarget]
		private static void Rectangle([OvldDefault("BlendMode")] ShapesBlendMode blendMode, [OvldDefault("false")] bool hollow, [OvldDefault("Vector3.zero")] Vector3 pos, [OvldDefault("Quaternion.identity")] Quaternion rot, Rect rect, [OvldDefault("Color")] Color color, [OvldDefault("0f")] float thickness = 0f, [OvldDefault("default")] Vector4 cornerRadii = default(Vector4))
		{
			bool rounded = ShapesMath.MaxComp(cornerRadii) >= 0.0001f;
			if (rect.width < 0f)
			{
				rect.x -= (rect.width *= -1f);
			}
			if (rect.height < 0f)
			{
				rect.y -= (rect.height *= -1f);
			}
			if (hollow && thickness * 2f >= Mathf.Min(rect.width, rect.height))
			{
				hollow = false;
			}
			using (new IMDrawer(mpbRectangle, ShapesMaterialUtils.GetRectMaterial(hollow, rounded)[blendMode], ShapesMeshUtils.QuadMesh[0], pos, rot))
			{
				mpbRectangle.color.Add(color);
				mpbRectangle.rect.Add(rect.ToVector4());
				mpbRectangle.cornerRadii.Add(cornerRadii);
				mpbRectangle.thickness.Add(thickness);
				mpbRectangle.scaleMode.Add((float)ScaleMode);
			}
		}

		[OvldGenCallTarget]
		private static void Triangle([OvldDefault("BlendMode")] ShapesBlendMode blendMode, Vector3 a, Vector3 b, Vector3 c, [OvldDefault("Color")] Color colorA, [OvldDefault("Color")] Color colorB, [OvldDefault("Color")] Color colorC)
		{
			using (new IMDrawer(mpbTriangle, ShapesMaterialUtils.matTriangle[blendMode], ShapesMeshUtils.TriangleMesh[0]))
			{
				mpbTriangle.a.Add(a);
				mpbTriangle.b.Add(b);
				mpbTriangle.c.Add(c);
				mpbTriangle.color.Add(colorA);
				mpbTriangle.colorB.Add(colorB);
				mpbTriangle.colorC.Add(colorC);
			}
		}

		[OvldGenCallTarget]
		private static void Quad([OvldDefault("BlendMode")] ShapesBlendMode blendMode, Vector3 a, Vector3 b, Vector3 c, [OvldDefault("a + ( c - b )")] Vector3 d, [OvldDefault("Color")] Color colorA, [OvldDefault("Color")] Color colorB, [OvldDefault("Color")] Color colorC, [OvldDefault("Color")] Color colorD)
		{
			using (new IMDrawer(mpbQuad, ShapesMaterialUtils.matQuad[blendMode], ShapesMeshUtils.QuadMesh[0]))
			{
				mpbQuad.a.Add(a);
				mpbQuad.b.Add(b);
				mpbQuad.c.Add(c);
				mpbQuad.d.Add(d);
				mpbQuad.color.Add(colorA);
				mpbQuad.colorB.Add(colorB);
				mpbQuad.colorC.Add(colorC);
				mpbQuad.colorD.Add(colorD);
			}
		}

		[OvldGenCallTarget]
		private static void Sphere([OvldDefault("BlendMode")] ShapesBlendMode blendMode, [OvldDefault("SphereRadiusSpace")] ThicknessSpace spaceRadius, Vector3 pos, [OvldDefault("SphereRadius")] float radius, [OvldDefault("Color")] Color color)
		{
			using (new IMDrawer(metaMpbSphere, ShapesMaterialUtils.matSphere[blendMode], ShapesMeshUtils.SphereMesh[(int)DetailLevel], pos, Quaternion.identity))
			{
				metaMpbSphere.color.Add(color);
				metaMpbSphere.radius.Add(radius);
				metaMpbSphere.radiusSpace.Add((float)spaceRadius);
			}
		}

		[OvldGenCallTarget]
		private static void Cone([OvldDefault("BlendMode")] ShapesBlendMode blendMode, [OvldDefault("ConeSizeSpace")] ThicknessSpace sizeSpace, Vector3 pos, [OvldDefault("Quaternion.identity")] Quaternion rot, float radius, float length, [OvldDefault("true")] bool fillCap, [OvldDefault("Color")] Color color)
		{
			Mesh sourceMesh = (fillCap ? ShapesMeshUtils.ConeMesh[(int)DetailLevel] : ShapesMeshUtils.ConeMeshUncapped[(int)DetailLevel]);
			using (new IMDrawer(mpbCone, ShapesMaterialUtils.matCone[blendMode], sourceMesh, pos, rot))
			{
				mpbCone.color.Add(color);
				mpbCone.radius.Add(radius);
				mpbCone.length.Add(length);
				mpbCone.sizeSpace.Add((float)sizeSpace);
			}
		}

		[OvldGenCallTarget]
		private static void Cuboid([OvldDefault("BlendMode")] ShapesBlendMode blendMode, [OvldDefault("CuboidSizeSpace")] ThicknessSpace sizeSpace, Vector3 pos, [OvldDefault("Quaternion.identity")] Quaternion rot, Vector3 size, [OvldDefault("Color")] Color color)
		{
			using (new IMDrawer(mpbCuboid, ShapesMaterialUtils.matCuboid[blendMode], ShapesMeshUtils.CuboidMesh[0], pos, rot))
			{
				mpbCuboid.color.Add(color);
				mpbCuboid.size.Add(size);
				mpbCuboid.sizeSpace.Add((float)sizeSpace);
			}
		}

		[OvldGenCallTarget]
		private static void Torus([OvldDefault("BlendMode")] ShapesBlendMode blendMode, [OvldDefault("TorusRadiusSpace")] ThicknessSpace spaceRadius, [OvldDefault("TorusThicknessSpace")] ThicknessSpace spaceThickness, Vector3 pos, [OvldDefault("Quaternion.identity")] Quaternion rot, float radius, float thickness, [OvldDefault("Color")] Color color)
		{
			if (thickness < 0.0001f)
			{
				return;
			}
			if (radius < 1E-05f)
			{
				Sphere(blendMode, spaceThickness, pos, thickness, color);
				return;
			}
			using (new IMDrawer(mpbTorus, ShapesMaterialUtils.matTorus[blendMode], ShapesMeshUtils.TorusMesh[(int)DetailLevel], pos, rot))
			{
				mpbTorus.color.Add(color);
				mpbTorus.radius.Add(radius);
				mpbTorus.thickness.Add(thickness);
				mpbTorus.spaceRadius.Add((float)spaceRadius);
				mpbTorus.spaceThickness.Add((float)spaceThickness);
				mpbTorus.scaleMode.Add((float)ScaleMode);
			}
		}

		[OvldGenCallTarget]
		private static void Text(Vector3 pos, [OvldDefault("Quaternion.identity")] Quaternion rot, string content, [OvldDefault("Font")] TMP_FontAsset font, [OvldDefault("FontSize")] float fontSize, [OvldDefault("TextAlign")] TextAlign align, [OvldDefault("Color")] Color color)
		{
			TextMeshPro tmp = ShapesTextDrawer.Instance.tmp;
			tmp.font = font;
			tmp.color = color;
			tmp.fontSize = fontSize;
			tmp.text = content;
			tmp.alignment = align.GetTMPAlignment();
			tmp.rectTransform.pivot = align.GetPivot();
			tmp.transform.position = pos;
			tmp.rectTransform.rotation = rot;
			tmp.ForceMeshUpdate();
			using (new IMDrawer(mpbText, font.material, tmp.mesh, tmp.transform.position, tmp.transform.rotation, 0, cachedTMP: true))
			{
			}
		}

		public static void SetColorOpacity(Color rgb, float opacity)
		{
			Color = new Color(rgb.r, rgb.g, rgb.b, rgb.a * opacity);
		}

		public static void Line(Vector3 start, Vector3 end)
		{
			Line(BlendMode, LineGeometry, LineEndCaps, LineThicknessSpace, start, end, Color, Color, LineThickness);
		}

		public static void Line(Vector3 start, Vector3 end, Color color)
		{
			Line(BlendMode, LineGeometry, LineEndCaps, LineThicknessSpace, start, end, color, color, LineThickness);
		}

		public static void Line(Vector3 start, Vector3 end, Color colorStart, Color colorEnd)
		{
			Line(BlendMode, LineGeometry, LineEndCaps, LineThicknessSpace, start, end, colorStart, colorEnd, LineThickness);
		}

		public static void Line(Vector3 start, Vector3 end, float thickness)
		{
			Line(BlendMode, LineGeometry, LineEndCaps, LineThicknessSpace, start, end, Color, Color, thickness);
		}

		public static void Line(Vector3 start, Vector3 end, float thickness, Color color)
		{
			Line(BlendMode, LineGeometry, LineEndCaps, LineThicknessSpace, start, end, color, color, thickness);
		}

		public static void Line(Vector3 start, Vector3 end, float thickness, Color colorStart, Color colorEnd)
		{
			Line(BlendMode, LineGeometry, LineEndCaps, LineThicknessSpace, start, end, colorStart, colorEnd, thickness);
		}

		public static void Line(Vector3 start, Vector3 end, LineEndCap endCaps)
		{
			Line(BlendMode, LineGeometry, endCaps, LineThicknessSpace, start, end, Color, Color, LineThickness);
		}

		public static void Line(Vector3 start, Vector3 end, LineEndCap endCaps, Color color)
		{
			Line(BlendMode, LineGeometry, endCaps, LineThicknessSpace, start, end, color, color, LineThickness);
		}

		public static void Line(Vector3 start, Vector3 end, LineEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Line(BlendMode, LineGeometry, endCaps, LineThicknessSpace, start, end, colorStart, colorEnd, LineThickness);
		}

		public static void Line(Vector3 start, Vector3 end, float thickness, LineEndCap endCaps)
		{
			Line(BlendMode, LineGeometry, endCaps, LineThicknessSpace, start, end, Color, Color, thickness);
		}

		public static void Line(Vector3 start, Vector3 end, float thickness, LineEndCap endCaps, Color color)
		{
			Line(BlendMode, LineGeometry, endCaps, LineThicknessSpace, start, end, color, color, thickness);
		}

		public static void Line(Vector3 start, Vector3 end, float thickness, LineEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Line(BlendMode, LineGeometry, endCaps, LineThicknessSpace, start, end, colorStart, colorEnd, thickness);
		}

		public static void LineDashed(Vector3 start, Vector3 end)
		{
			Line(BlendMode, LineGeometry, LineEndCaps, LineThicknessSpace, start, end, Color, Color, LineThickness, LineDashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, Color color)
		{
			Line(BlendMode, LineGeometry, LineEndCaps, LineThicknessSpace, start, end, color, color, LineThickness, LineDashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, Color colorStart, Color colorEnd)
		{
			Line(BlendMode, LineGeometry, LineEndCaps, LineThicknessSpace, start, end, colorStart, colorEnd, LineThickness, LineDashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, float thickness)
		{
			Line(BlendMode, LineGeometry, LineEndCaps, LineThicknessSpace, start, end, Color, Color, thickness, LineDashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, float thickness, Color color)
		{
			Line(BlendMode, LineGeometry, LineEndCaps, LineThicknessSpace, start, end, color, color, thickness, LineDashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, float thickness, Color colorStart, Color colorEnd)
		{
			Line(BlendMode, LineGeometry, LineEndCaps, LineThicknessSpace, start, end, colorStart, colorEnd, thickness, LineDashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, LineEndCap endCaps)
		{
			Line(BlendMode, LineGeometry, endCaps, LineThicknessSpace, start, end, Color, Color, LineThickness, LineDashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, LineEndCap endCaps, Color color)
		{
			Line(BlendMode, LineGeometry, endCaps, LineThicknessSpace, start, end, color, color, LineThickness, LineDashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, LineEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Line(BlendMode, LineGeometry, endCaps, LineThicknessSpace, start, end, colorStart, colorEnd, LineThickness, LineDashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, float thickness, LineEndCap endCaps)
		{
			Line(BlendMode, LineGeometry, endCaps, LineThicknessSpace, start, end, Color, Color, thickness, LineDashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, float thickness, LineEndCap endCaps, Color color)
		{
			Line(BlendMode, LineGeometry, endCaps, LineThicknessSpace, start, end, color, color, thickness, LineDashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, float thickness, LineEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Line(BlendMode, LineGeometry, endCaps, LineThicknessSpace, start, end, colorStart, colorEnd, thickness, LineDashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle)
		{
			Line(BlendMode, LineGeometry, LineEndCaps, LineThicknessSpace, start, end, Color, Color, LineThickness, dashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, Color color)
		{
			Line(BlendMode, LineGeometry, LineEndCaps, LineThicknessSpace, start, end, color, color, LineThickness, dashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, Color colorStart, Color colorEnd)
		{
			Line(BlendMode, LineGeometry, LineEndCaps, LineThicknessSpace, start, end, colorStart, colorEnd, LineThickness, dashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, float thickness)
		{
			Line(BlendMode, LineGeometry, LineEndCaps, LineThicknessSpace, start, end, Color, Color, thickness, dashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, float thickness, Color color)
		{
			Line(BlendMode, LineGeometry, LineEndCaps, LineThicknessSpace, start, end, color, color, thickness, dashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, float thickness, Color colorStart, Color colorEnd)
		{
			Line(BlendMode, LineGeometry, LineEndCaps, LineThicknessSpace, start, end, colorStart, colorEnd, thickness, dashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, LineEndCap endCaps)
		{
			Line(BlendMode, LineGeometry, endCaps, LineThicknessSpace, start, end, Color, Color, LineThickness, dashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, LineEndCap endCaps, Color color)
		{
			Line(BlendMode, LineGeometry, endCaps, LineThicknessSpace, start, end, color, color, LineThickness, dashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, LineEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Line(BlendMode, LineGeometry, endCaps, LineThicknessSpace, start, end, colorStart, colorEnd, LineThickness, dashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, float thickness, LineEndCap endCaps)
		{
			Line(BlendMode, LineGeometry, endCaps, LineThicknessSpace, start, end, Color, Color, thickness, dashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, float thickness, LineEndCap endCaps, Color color)
		{
			Line(BlendMode, LineGeometry, endCaps, LineThicknessSpace, start, end, color, color, thickness, dashStyle);
		}

		public static void LineDashed(Vector3 start, Vector3 end, DashStyle dashStyle, float thickness, LineEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Line(BlendMode, LineGeometry, endCaps, LineThicknessSpace, start, end, colorStart, colorEnd, thickness, dashStyle);
		}

		public static void Polyline(PolylinePath path)
		{
			Polyline(BlendMode, path, closed: false, PolylineGeometry, PolylineJoins, LineThickness, LineThicknessSpace, Color);
		}

		public static void Polyline(PolylinePath path, bool closed)
		{
			Polyline(BlendMode, path, closed, PolylineGeometry, PolylineJoins, LineThickness, LineThicknessSpace, Color);
		}

		public static void Polyline(PolylinePath path, float thickness)
		{
			Polyline(BlendMode, path, closed: false, PolylineGeometry, PolylineJoins, thickness, LineThicknessSpace, Color);
		}

		public static void Polyline(PolylinePath path, bool closed, float thickness)
		{
			Polyline(BlendMode, path, closed, PolylineGeometry, PolylineJoins, thickness, LineThicknessSpace, Color);
		}

		public static void Polyline(PolylinePath path, PolylineJoins joins)
		{
			Polyline(BlendMode, path, closed: false, PolylineGeometry, joins, LineThickness, LineThicknessSpace, Color);
		}

		public static void Polyline(PolylinePath path, bool closed, PolylineJoins joins)
		{
			Polyline(BlendMode, path, closed, PolylineGeometry, joins, LineThickness, LineThicknessSpace, Color);
		}

		public static void Polyline(PolylinePath path, float thickness, PolylineJoins joins)
		{
			Polyline(BlendMode, path, closed: false, PolylineGeometry, joins, thickness, LineThicknessSpace, Color);
		}

		public static void Polyline(PolylinePath path, bool closed, float thickness, PolylineJoins joins)
		{
			Polyline(BlendMode, path, closed, PolylineGeometry, joins, thickness, LineThicknessSpace, Color);
		}

		public static void Polyline(PolylinePath path, Color color)
		{
			Polyline(BlendMode, path, closed: false, PolylineGeometry, PolylineJoins, LineThickness, LineThicknessSpace, color);
		}

		public static void Polyline(PolylinePath path, bool closed, Color color)
		{
			Polyline(BlendMode, path, closed, PolylineGeometry, PolylineJoins, LineThickness, LineThicknessSpace, color);
		}

		public static void Polyline(PolylinePath path, float thickness, Color color)
		{
			Polyline(BlendMode, path, closed: false, PolylineGeometry, PolylineJoins, thickness, LineThicknessSpace, color);
		}

		public static void Polyline(PolylinePath path, bool closed, float thickness, Color color)
		{
			Polyline(BlendMode, path, closed, PolylineGeometry, PolylineJoins, thickness, LineThicknessSpace, color);
		}

		public static void Polyline(PolylinePath path, PolylineJoins joins, Color color)
		{
			Polyline(BlendMode, path, closed: false, PolylineGeometry, joins, LineThickness, LineThicknessSpace, color);
		}

		public static void Polyline(PolylinePath path, bool closed, PolylineJoins joins, Color color)
		{
			Polyline(BlendMode, path, closed, PolylineGeometry, joins, LineThickness, LineThicknessSpace, color);
		}

		public static void Polyline(PolylinePath path, float thickness, PolylineJoins joins, Color color)
		{
			Polyline(BlendMode, path, closed: false, PolylineGeometry, joins, thickness, LineThicknessSpace, color);
		}

		public static void Polyline(PolylinePath path, bool closed, float thickness, PolylineJoins joins, Color color)
		{
			Polyline(BlendMode, path, closed, PolylineGeometry, joins, thickness, LineThicknessSpace, color);
		}

		public static void Polygon(PolygonPath path)
		{
			Polygon(BlendMode, path, PolygonTriangulation, Color, null);
		}

		public static void Polygon(PolygonPath path, Color color)
		{
			Polygon(BlendMode, path, PolygonTriangulation, color, null);
		}

		public static void Polygon(PolygonPath path, PolygonTriangulation triangulation)
		{
			Polygon(BlendMode, path, triangulation, Color, null);
		}

		public static void Polygon(PolygonPath path, PolygonTriangulation triangulation, Color color)
		{
			Polygon(BlendMode, path, triangulation, color, null);
		}

		public static void PolygonFill(PolygonPath path)
		{
			Polygon(BlendMode, path, PolygonTriangulation, Color, PolygonShapeFill);
		}

		public static void PolygonFill(PolygonPath path, ShapeFill fill)
		{
			Polygon(BlendMode, path, PolygonTriangulation, Color, fill);
		}

		public static void PolygonFill(PolygonPath path, PolygonTriangulation triangulation)
		{
			Polygon(BlendMode, path, triangulation, Color, PolygonShapeFill);
		}

		public static void PolygonFill(PolygonPath path, PolygonTriangulation triangulation, ShapeFill fill)
		{
			Polygon(BlendMode, path, triangulation, Color, fill);
		}

		public static void PolygonFillLinear(PolygonPath path, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			Polygon(BlendMode, path, PolygonTriangulation, Color, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void PolygonFillLinear(PolygonPath path, PolygonTriangulation triangulation, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			Polygon(BlendMode, path, triangulation, Color, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void PolygonFillRadial(PolygonPath path, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			Polygon(BlendMode, path, PolygonTriangulation, Color, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void PolygonFillRadial(PolygonPath path, PolygonTriangulation triangulation, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			Polygon(BlendMode, path, triangulation, Color, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygon(Vector3 pos)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, float radius, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, float radius, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, float radius, float angle, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, color, hollow: false, 0f, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, float radius, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, float radius, float angle, float roundness, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, color, hollow: false, roundness, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, int sideCount)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, int sideCount, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, RegularPolygonRadius, RegularPolygonThickness, color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, int sideCount, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, int sideCount, float radius, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, int sideCount, float radius, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, int sideCount, float radius, float angle, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, color, hollow: false, 0f, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, int sideCount, float radius, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, int sideCount, float radius, float angle, float roundness, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, color, hollow: false, roundness, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, Vector3 normal)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, Vector3 normal, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, Vector3 normal, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, Vector3 normal, float radius, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, Vector3 normal, float radius, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, Vector3 normal, float radius, float angle, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, color, hollow: false, 0f, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, Vector3 normal, float radius, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, Vector3 normal, float radius, float angle, float roundness, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, color, hollow: false, roundness, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, Vector3 normal, int sideCount)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, Vector3 normal, int sideCount, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, RegularPolygonRadius, RegularPolygonThickness, color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, Vector3 normal, int sideCount, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, Vector3 normal, int sideCount, float radius, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, color, hollow: false, 0f, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, float roundness, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, color, hollow: false, roundness, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, Quaternion rot)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, Quaternion rot, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, Quaternion rot, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, Quaternion rot, float radius, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, Quaternion rot, float radius, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, Quaternion rot, float radius, float angle, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, color, hollow: false, 0f, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, Quaternion rot, float radius, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, Quaternion rot, float radius, float angle, float roundness, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, color, hollow: false, roundness, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, Quaternion rot, int sideCount)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, Quaternion rot, int sideCount, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, RegularPolygonRadius, RegularPolygonThickness, color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, Quaternion rot, int sideCount, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, Quaternion rot, int sideCount, float radius, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, color, hollow: false, 0f, 0f, null);
		}

		public static void RegularPolygon(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, color, hollow: false, 0f, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, null);
		}

		public static void RegularPolygon(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, float roundness, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, color, hollow: false, roundness, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, float radius, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, float radius, float thickness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, float radius, float thickness, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, thickness, color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, float radius, float thickness, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, float radius, float thickness, float angle, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, thickness, color, hollow: true, 0f, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, float radius, float thickness, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, float radius, float thickness, float angle, float roundness, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, thickness, color, hollow: true, roundness, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, int sideCount)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, int sideCount, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, RegularPolygonRadius, RegularPolygonThickness, color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, int sideCount, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, int sideCount, float radius, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, int sideCount, float radius, float thickness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, thickness, Color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, int sideCount, float radius, float thickness, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, thickness, color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, int sideCount, float radius, float thickness, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, thickness, Color, hollow: true, 0f, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, int sideCount, float radius, float thickness, float angle, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, thickness, color, hollow: true, 0f, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, int sideCount, float radius, float thickness, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, thickness, Color, hollow: true, roundness, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, int sideCount, float radius, float thickness, float angle, float roundness, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, thickness, color, hollow: true, roundness, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, float radius, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, float radius, float thickness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, float radius, float thickness, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, thickness, color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, float radius, float thickness, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, thickness, color, hollow: true, 0f, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, float roundness, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, thickness, color, hollow: true, roundness, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, RegularPolygonRadius, RegularPolygonThickness, color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount, float radius, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, thickness, Color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, thickness, color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, thickness, Color, hollow: true, 0f, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, thickness, color, hollow: true, 0f, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, thickness, Color, hollow: true, roundness, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, float roundness, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, thickness, color, hollow: true, roundness, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, float radius, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, float radius, float thickness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, float radius, float thickness, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, thickness, color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, float radius, float thickness, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, thickness, color, hollow: true, 0f, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, float roundness, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, thickness, color, hollow: true, roundness, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, RegularPolygonRadius, RegularPolygonThickness, color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount, float radius, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, thickness, Color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, thickness, color, hollow: true, 0f, 0f, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, thickness, Color, hollow: true, 0f, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, thickness, color, hollow: true, 0f, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, thickness, Color, hollow: true, roundness, angle, null);
		}

		public static void RegularPolygonHollow(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, float roundness, Color color)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, thickness, color, hollow: true, roundness, angle, null);
		}

		public static void RegularPolygonFill(Vector3 pos)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, float radius, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, float radius, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, float radius, float angle, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, float radius, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, float radius, float angle, float roundness, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, int sideCount)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, int sideCount, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, int sideCount, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, int sideCount, float radius, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, int sideCount, float radius, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, int sideCount, float radius, float angle, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, int sideCount, float radius, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, int sideCount, float radius, float angle, float roundness, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, Vector3 normal)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, float radius, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, float radius, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, float radius, float angle, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, float radius, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, float radius, float angle, float roundness, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, int sideCount)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, int sideCount, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, int sideCount, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, int sideCount, float radius, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, float roundness, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, Quaternion rot)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, float radius, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, float radius, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, float radius, float angle, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, float radius, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, float radius, float angle, float roundness, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, int sideCount)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, int sideCount, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, int sideCount, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, int sideCount, float radius, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, fill);
		}

		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, PolygonShapeFill);
		}

		public static void RegularPolygonFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, float roundness, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, float radius, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, float radius, float thickness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, float radius, float thickness, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, float radius, float thickness, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, float radius, float thickness, float angle, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, float radius, float thickness, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, float radius, float thickness, float angle, float roundness, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount, float radius, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount, float radius, float thickness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, thickness, Color, hollow: true, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount, float radius, float thickness, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, thickness, Color, hollow: true, 0f, 0f, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount, float radius, float thickness, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, thickness, Color, hollow: true, 0f, angle, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount, float radius, float thickness, float angle, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, thickness, Color, hollow: true, 0f, angle, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount, float radius, float thickness, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, thickness, Color, hollow: true, roundness, angle, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, int sideCount, float radius, float thickness, float angle, float roundness, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, thickness, Color, hollow: true, roundness, angle, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, float radius, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, float radius, float thickness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, float radius, float thickness, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, float radius, float thickness, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, float roundness, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount, float radius, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, thickness, Color, hollow: true, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, thickness, Color, hollow: true, 0f, 0f, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, thickness, Color, hollow: true, 0f, angle, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, thickness, Color, hollow: true, 0f, angle, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, thickness, Color, hollow: true, roundness, angle, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, float roundness, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, thickness, Color, hollow: true, roundness, angle, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, float radius, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, float radius, float thickness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, float radius, float thickness, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, float radius, float thickness, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, float roundness, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount, float radius)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount, float radius, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, thickness, Color, hollow: true, 0f, 0f, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, thickness, Color, hollow: true, 0f, 0f, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, thickness, Color, hollow: true, 0f, angle, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, thickness, Color, hollow: true, 0f, angle, fill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, float roundness)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, thickness, Color, hollow: true, roundness, angle, PolygonShapeFill);
		}

		public static void RegularPolygonHollowFill(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, float roundness, ShapeFill fill)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, thickness, Color, hollow: true, roundness, angle, fill);
		}

		public static void RegularPolygonFillLinear(Vector3 pos, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, float radius, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, float radius, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, int sideCount, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, int sideCount, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, int sideCount, float radius, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, int sideCount, float radius, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, Vector3 normal, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, Vector3 normal, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, Vector3 normal, float radius, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, Vector3 normal, float radius, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, Vector3 normal, int sideCount, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, Vector3 normal, int sideCount, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, Quaternion rot, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, Quaternion rot, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, Quaternion rot, float radius, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, Quaternion rot, float radius, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, Quaternion rot, int sideCount, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, Quaternion rot, int sideCount, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillLinear(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, float radius, float thickness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, float radius, float thickness, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, float radius, float thickness, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, int sideCount, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, int sideCount, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, int sideCount, float radius, float thickness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, thickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, int sideCount, float radius, float thickness, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, thickness, Color, hollow: true, 0f, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, int sideCount, float radius, float thickness, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, thickness, Color, hollow: true, roundness, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, float radius, float thickness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, int sideCount, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, int sideCount, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, thickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, thickness, Color, hollow: true, 0f, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, thickness, Color, hollow: true, roundness, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, float radius, float thickness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, int sideCount, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, int sideCount, float radius, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, thickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, thickness, Color, hollow: true, 0f, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillLinear(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, float roundness, Vector3 fillStart, Vector3 fillEnd, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, thickness, Color, hollow: true, roundness, angle, ShapeFill.CreateLinear(fillStart, fillEnd, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, float radius, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, float radius, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, int sideCount, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, int sideCount, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, int sideCount, float radius, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, int sideCount, float radius, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, Vector3 normal, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, Vector3 normal, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, Vector3 normal, float radius, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, Vector3 normal, float radius, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, Vector3 normal, int sideCount, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, Vector3 normal, int sideCount, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, Vector3 normal, int sideCount, float radius, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, Quaternion rot, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, Quaternion rot, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, Quaternion rot, float radius, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, Quaternion rot, float radius, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, Quaternion rot, int sideCount, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, Quaternion rot, int sideCount, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: false, 0f, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonFillRadial(Vector3 pos, Quaternion rot, int sideCount, float radius, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: false, roundness, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, float radius, float thickness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, float radius, float thickness, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, float radius, float thickness, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, int sideCount, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, int sideCount, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, int sideCount, float radius, float thickness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, thickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, int sideCount, float radius, float thickness, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, thickness, Color, hollow: true, 0f, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, int sideCount, float radius, float thickness, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.identity, sideCount, radius, thickness, Color, hollow: true, roundness, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, float radius, float thickness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, float radius, float thickness, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, int sideCount, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, int sideCount, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, thickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, thickness, Color, hollow: true, 0f, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Vector3 normal, int sideCount, float radius, float thickness, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, Quaternion.LookRotation(normal), sideCount, radius, thickness, Color, hollow: true, roundness, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, float radius, float thickness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, thickness, Color, hollow: true, 0f, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, float radius, float thickness, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, RegularPolygonSideCount, radius, thickness, Color, hollow: true, roundness, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, int sideCount, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, RegularPolygonRadius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, int sideCount, float radius, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, RegularPolygonThickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, thickness, Color, hollow: true, 0f, 0f, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, thickness, Color, hollow: true, 0f, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void RegularPolygonHollowFillRadial(Vector3 pos, Quaternion rot, int sideCount, float radius, float thickness, float angle, float roundness, Vector3 fillOrigin, float fillRadius, Color fillColorStart, Color fillColorEnd, FillSpace fillSpace = FillSpace.Local)
		{
			RegularPolygon(BlendMode, RegularPolygonRadiusSpace, RegularPolygonThicknessSpace, pos, rot, sideCount, radius, thickness, Color, hollow: true, roundness, angle, ShapeFill.CreateRadial(fillOrigin, fillRadius, fillColorStart, fillColorEnd, fillSpace));
		}

		public static void Disc(Vector3 pos)
		{
			Disc(pos, Quaternion.identity, DiscRadius, Color, Color, Color, Color);
		}

		public static void Disc(Vector3 pos, Color color)
		{
			Disc(pos, Quaternion.identity, DiscRadius, color, color, color, color);
		}

		public static void Disc(Vector3 pos, float radius)
		{
			Disc(pos, Quaternion.identity, radius, Color, Color, Color, Color);
		}

		public static void Disc(Vector3 pos, float radius, Color color)
		{
			Disc(pos, Quaternion.identity, radius, color, color, color, color);
		}

		public static void Disc(Vector3 pos, Vector3 normal)
		{
			Disc(pos, Quaternion.LookRotation(normal), DiscRadius, Color, Color, Color, Color);
		}

		public static void Disc(Vector3 pos, Vector3 normal, Color color)
		{
			Disc(pos, Quaternion.LookRotation(normal), DiscRadius, color, color, color, color);
		}

		public static void Disc(Vector3 pos, Vector3 normal, float radius)
		{
			Disc(pos, Quaternion.LookRotation(normal), radius, Color, Color, Color, Color);
		}

		public static void Disc(Vector3 pos, Vector3 normal, float radius, Color color)
		{
			Disc(pos, Quaternion.LookRotation(normal), radius, color, color, color, color);
		}

		public static void Disc(Vector3 pos, Quaternion rot)
		{
			Disc(pos, rot, DiscRadius, Color, Color, Color, Color);
		}

		public static void Disc(Vector3 pos, Quaternion rot, Color color)
		{
			Disc(pos, rot, DiscRadius, color, color, color, color);
		}

		public static void Disc(Vector3 pos, Quaternion rot, float radius)
		{
			Disc(pos, rot, radius, Color, Color, Color, Color);
		}

		public static void Disc(Vector3 pos, Quaternion rot, float radius, Color color)
		{
			Disc(pos, rot, radius, color, color, color, color);
		}

		public static void DiscGradientRadial(Vector3 pos, Color colorInner, Color colorOuter)
		{
			Disc(pos, Quaternion.identity, DiscRadius, colorInner, colorOuter, colorInner, colorOuter);
		}

		public static void DiscGradientRadial(Vector3 pos, float radius, Color colorInner, Color colorOuter)
		{
			Disc(pos, Quaternion.identity, radius, colorInner, colorOuter, colorInner, colorOuter);
		}

		public static void DiscGradientRadial(Vector3 pos, Vector3 normal, Color colorInner, Color colorOuter)
		{
			Disc(pos, Quaternion.LookRotation(normal), DiscRadius, colorInner, colorOuter, colorInner, colorOuter);
		}

		public static void DiscGradientRadial(Vector3 pos, Vector3 normal, float radius, Color colorInner, Color colorOuter)
		{
			Disc(pos, Quaternion.LookRotation(normal), radius, colorInner, colorOuter, colorInner, colorOuter);
		}

		public static void DiscGradientRadial(Vector3 pos, Quaternion rot, Color colorInner, Color colorOuter)
		{
			Disc(pos, rot, DiscRadius, colorInner, colorOuter, colorInner, colorOuter);
		}

		public static void DiscGradientRadial(Vector3 pos, Quaternion rot, float radius, Color colorInner, Color colorOuter)
		{
			Disc(pos, rot, radius, colorInner, colorOuter, colorInner, colorOuter);
		}

		public static void DiscGradientAngular(Vector3 pos, Color colorStart, Color colorEnd)
		{
			Disc(pos, Quaternion.identity, DiscRadius, colorStart, colorStart, colorEnd, colorEnd);
		}

		public static void DiscGradientAngular(Vector3 pos, float radius, Color colorStart, Color colorEnd)
		{
			Disc(pos, Quaternion.identity, radius, colorStart, colorStart, colorEnd, colorEnd);
		}

		public static void DiscGradientAngular(Vector3 pos, Vector3 normal, Color colorStart, Color colorEnd)
		{
			Disc(pos, Quaternion.LookRotation(normal), DiscRadius, colorStart, colorStart, colorEnd, colorEnd);
		}

		public static void DiscGradientAngular(Vector3 pos, Vector3 normal, float radius, Color colorStart, Color colorEnd)
		{
			Disc(pos, Quaternion.LookRotation(normal), radius, colorStart, colorStart, colorEnd, colorEnd);
		}

		public static void DiscGradientAngular(Vector3 pos, Quaternion rot, Color colorStart, Color colorEnd)
		{
			Disc(pos, rot, DiscRadius, colorStart, colorStart, colorEnd, colorEnd);
		}

		public static void DiscGradientAngular(Vector3 pos, Quaternion rot, float radius, Color colorStart, Color colorEnd)
		{
			Disc(pos, rot, radius, colorStart, colorStart, colorEnd, colorEnd);
		}

		public static void DiscGradientBilinear(Vector3 pos, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Disc(pos, Quaternion.identity, DiscRadius, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd);
		}

		public static void DiscGradientBilinear(Vector3 pos, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Disc(pos, Quaternion.identity, radius, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd);
		}

		public static void DiscGradientBilinear(Vector3 pos, Vector3 normal, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Disc(pos, Quaternion.LookRotation(normal), DiscRadius, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd);
		}

		public static void DiscGradientBilinear(Vector3 pos, Vector3 normal, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Disc(pos, Quaternion.LookRotation(normal), radius, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd);
		}

		public static void DiscGradientBilinear(Vector3 pos, Quaternion rot, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Disc(pos, rot, DiscRadius, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd);
		}

		public static void DiscGradientBilinear(Vector3 pos, Quaternion rot, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Disc(pos, rot, radius, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd);
		}

		public static void Ring(Vector3 pos)
		{
			Ring(pos, Quaternion.identity, DiscRadius, RingThickness, Color, Color, Color, Color);
		}

		public static void Ring(Vector3 pos, Color color)
		{
			Ring(pos, Quaternion.identity, DiscRadius, RingThickness, color, color, color, color);
		}

		public static void Ring(Vector3 pos, float radius)
		{
			Ring(pos, Quaternion.identity, radius, RingThickness, Color, Color, Color, Color);
		}

		public static void Ring(Vector3 pos, float radius, Color color)
		{
			Ring(pos, Quaternion.identity, radius, RingThickness, color, color, color, color);
		}

		public static void Ring(Vector3 pos, float radius, float thickness)
		{
			Ring(pos, Quaternion.identity, radius, thickness, Color, Color, Color, Color);
		}

		public static void Ring(Vector3 pos, float radius, float thickness, Color color)
		{
			Ring(pos, Quaternion.identity, radius, thickness, color, color, color, color);
		}

		public static void Ring(Vector3 pos, Vector3 normal)
		{
			Ring(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, Color, Color, Color, Color);
		}

		public static void Ring(Vector3 pos, Vector3 normal, Color color)
		{
			Ring(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, color, color, color, color);
		}

		public static void Ring(Vector3 pos, Vector3 normal, float radius)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, RingThickness, Color, Color, Color, Color);
		}

		public static void Ring(Vector3 pos, Vector3 normal, float radius, Color color)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, RingThickness, color, color, color, color);
		}

		public static void Ring(Vector3 pos, Vector3 normal, float radius, float thickness)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, thickness, Color, Color, Color, Color);
		}

		public static void Ring(Vector3 pos, Vector3 normal, float radius, float thickness, Color color)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, thickness, color, color, color, color);
		}

		public static void Ring(Vector3 pos, Quaternion rot)
		{
			Ring(pos, rot, DiscRadius, RingThickness, Color, Color, Color, Color);
		}

		public static void Ring(Vector3 pos, Quaternion rot, Color color)
		{
			Ring(pos, rot, DiscRadius, RingThickness, color, color, color, color);
		}

		public static void Ring(Vector3 pos, Quaternion rot, float radius)
		{
			Ring(pos, rot, radius, RingThickness, Color, Color, Color, Color);
		}

		public static void Ring(Vector3 pos, Quaternion rot, float radius, Color color)
		{
			Ring(pos, rot, radius, RingThickness, color, color, color, color);
		}

		public static void Ring(Vector3 pos, Quaternion rot, float radius, float thickness)
		{
			Ring(pos, rot, radius, thickness, Color, Color, Color, Color);
		}

		public static void Ring(Vector3 pos, Quaternion rot, float radius, float thickness, Color color)
		{
			Ring(pos, rot, radius, thickness, color, color, color, color);
		}

		public static void RingDashed(Vector3 pos)
		{
			Ring(pos, Quaternion.identity, DiscRadius, RingThickness, Color, Color, Color, Color, RingDashStyle);
		}

		public static void RingDashed(Vector3 pos, Color color)
		{
			Ring(pos, Quaternion.identity, DiscRadius, RingThickness, color, color, color, color, RingDashStyle);
		}

		public static void RingDashed(Vector3 pos, float radius)
		{
			Ring(pos, Quaternion.identity, radius, RingThickness, Color, Color, Color, Color, RingDashStyle);
		}

		public static void RingDashed(Vector3 pos, float radius, Color color)
		{
			Ring(pos, Quaternion.identity, radius, RingThickness, color, color, color, color, RingDashStyle);
		}

		public static void RingDashed(Vector3 pos, float radius, float thickness)
		{
			Ring(pos, Quaternion.identity, radius, thickness, Color, Color, Color, Color, RingDashStyle);
		}

		public static void RingDashed(Vector3 pos, float radius, float thickness, Color color)
		{
			Ring(pos, Quaternion.identity, radius, thickness, color, color, color, color, RingDashStyle);
		}

		public static void RingDashed(Vector3 pos, DashStyle dashStyle)
		{
			Ring(pos, Quaternion.identity, DiscRadius, RingThickness, Color, Color, Color, Color, dashStyle);
		}

		public static void RingDashed(Vector3 pos, DashStyle dashStyle, Color color)
		{
			Ring(pos, Quaternion.identity, DiscRadius, RingThickness, color, color, color, color, dashStyle);
		}

		public static void RingDashed(Vector3 pos, DashStyle dashStyle, float radius)
		{
			Ring(pos, Quaternion.identity, radius, RingThickness, Color, Color, Color, Color, dashStyle);
		}

		public static void RingDashed(Vector3 pos, DashStyle dashStyle, float radius, Color color)
		{
			Ring(pos, Quaternion.identity, radius, RingThickness, color, color, color, color, dashStyle);
		}

		public static void RingDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness)
		{
			Ring(pos, Quaternion.identity, radius, thickness, Color, Color, Color, Color, dashStyle);
		}

		public static void RingDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, Color color)
		{
			Ring(pos, Quaternion.identity, radius, thickness, color, color, color, color, dashStyle);
		}

		public static void RingDashed(Vector3 pos, Vector3 normal)
		{
			Ring(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, Color, Color, Color, Color, RingDashStyle);
		}

		public static void RingDashed(Vector3 pos, Vector3 normal, Color color)
		{
			Ring(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, color, color, color, color, RingDashStyle);
		}

		public static void RingDashed(Vector3 pos, Vector3 normal, float radius)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, RingThickness, Color, Color, Color, Color, RingDashStyle);
		}

		public static void RingDashed(Vector3 pos, Vector3 normal, float radius, Color color)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, RingThickness, color, color, color, color, RingDashStyle);
		}

		public static void RingDashed(Vector3 pos, Vector3 normal, float radius, float thickness)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, thickness, Color, Color, Color, Color, RingDashStyle);
		}

		public static void RingDashed(Vector3 pos, Vector3 normal, float radius, float thickness, Color color)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, thickness, color, color, color, color, RingDashStyle);
		}

		public static void RingDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle)
		{
			Ring(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, Color, Color, Color, Color, dashStyle);
		}

		public static void RingDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, Color color)
		{
			Ring(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, color, color, color, color, dashStyle);
		}

		public static void RingDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, RingThickness, Color, Color, Color, Color, dashStyle);
		}

		public static void RingDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, Color color)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, RingThickness, color, color, color, color, dashStyle);
		}

		public static void RingDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, thickness, Color, Color, Color, Color, dashStyle);
		}

		public static void RingDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, Color color)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, thickness, color, color, color, color, dashStyle);
		}

		public static void RingDashed(Vector3 pos, Quaternion rot)
		{
			Ring(pos, rot, DiscRadius, RingThickness, Color, Color, Color, Color, RingDashStyle);
		}

		public static void RingDashed(Vector3 pos, Quaternion rot, Color color)
		{
			Ring(pos, rot, DiscRadius, RingThickness, color, color, color, color, RingDashStyle);
		}

		public static void RingDashed(Vector3 pos, Quaternion rot, float radius)
		{
			Ring(pos, rot, radius, RingThickness, Color, Color, Color, Color, RingDashStyle);
		}

		public static void RingDashed(Vector3 pos, Quaternion rot, float radius, Color color)
		{
			Ring(pos, rot, radius, RingThickness, color, color, color, color, RingDashStyle);
		}

		public static void RingDashed(Vector3 pos, Quaternion rot, float radius, float thickness)
		{
			Ring(pos, rot, radius, thickness, Color, Color, Color, Color, RingDashStyle);
		}

		public static void RingDashed(Vector3 pos, Quaternion rot, float radius, float thickness, Color color)
		{
			Ring(pos, rot, radius, thickness, color, color, color, color, RingDashStyle);
		}

		public static void RingDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle)
		{
			Ring(pos, rot, DiscRadius, RingThickness, Color, Color, Color, Color, dashStyle);
		}

		public static void RingDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, Color color)
		{
			Ring(pos, rot, DiscRadius, RingThickness, color, color, color, color, dashStyle);
		}

		public static void RingDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius)
		{
			Ring(pos, rot, radius, RingThickness, Color, Color, Color, Color, dashStyle);
		}

		public static void RingDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, Color color)
		{
			Ring(pos, rot, radius, RingThickness, color, color, color, color, dashStyle);
		}

		public static void RingDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness)
		{
			Ring(pos, rot, radius, thickness, Color, Color, Color, Color, dashStyle);
		}

		public static void RingDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, Color color)
		{
			Ring(pos, rot, radius, thickness, color, color, color, color, dashStyle);
		}

		public static void RingGradientRadial(Vector3 pos, Color colorInner, Color colorOuter)
		{
			Ring(pos, Quaternion.identity, DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter);
		}

		public static void RingGradientRadial(Vector3 pos, float radius, Color colorInner, Color colorOuter)
		{
			Ring(pos, Quaternion.identity, radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter);
		}

		public static void RingGradientRadial(Vector3 pos, float radius, float thickness, Color colorInner, Color colorOuter)
		{
			Ring(pos, Quaternion.identity, radius, thickness, colorInner, colorOuter, colorInner, colorOuter);
		}

		public static void RingGradientRadial(Vector3 pos, Vector3 normal, Color colorInner, Color colorOuter)
		{
			Ring(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter);
		}

		public static void RingGradientRadial(Vector3 pos, Vector3 normal, float radius, Color colorInner, Color colorOuter)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter);
		}

		public static void RingGradientRadial(Vector3 pos, Vector3 normal, float radius, float thickness, Color colorInner, Color colorOuter)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, thickness, colorInner, colorOuter, colorInner, colorOuter);
		}

		public static void RingGradientRadial(Vector3 pos, Quaternion rot, Color colorInner, Color colorOuter)
		{
			Ring(pos, rot, DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter);
		}

		public static void RingGradientRadial(Vector3 pos, Quaternion rot, float radius, Color colorInner, Color colorOuter)
		{
			Ring(pos, rot, radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter);
		}

		public static void RingGradientRadial(Vector3 pos, Quaternion rot, float radius, float thickness, Color colorInner, Color colorOuter)
		{
			Ring(pos, rot, radius, thickness, colorInner, colorOuter, colorInner, colorOuter);
		}

		public static void RingGradientRadialDashed(Vector3 pos, Color colorInner, Color colorOuter)
		{
			Ring(pos, Quaternion.identity, DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, RingDashStyle);
		}

		public static void RingGradientRadialDashed(Vector3 pos, float radius, Color colorInner, Color colorOuter)
		{
			Ring(pos, Quaternion.identity, radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, RingDashStyle);
		}

		public static void RingGradientRadialDashed(Vector3 pos, float radius, float thickness, Color colorInner, Color colorOuter)
		{
			Ring(pos, Quaternion.identity, radius, thickness, colorInner, colorOuter, colorInner, colorOuter, RingDashStyle);
		}

		public static void RingGradientRadialDashed(Vector3 pos, DashStyle dashStyle, Color colorInner, Color colorOuter)
		{
			Ring(pos, Quaternion.identity, DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, dashStyle);
		}

		public static void RingGradientRadialDashed(Vector3 pos, DashStyle dashStyle, float radius, Color colorInner, Color colorOuter)
		{
			Ring(pos, Quaternion.identity, radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, dashStyle);
		}

		public static void RingGradientRadialDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, Color colorInner, Color colorOuter)
		{
			Ring(pos, Quaternion.identity, radius, thickness, colorInner, colorOuter, colorInner, colorOuter, dashStyle);
		}

		public static void RingGradientRadialDashed(Vector3 pos, Vector3 normal, Color colorInner, Color colorOuter)
		{
			Ring(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, RingDashStyle);
		}

		public static void RingGradientRadialDashed(Vector3 pos, Vector3 normal, float radius, Color colorInner, Color colorOuter)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, RingDashStyle);
		}

		public static void RingGradientRadialDashed(Vector3 pos, Vector3 normal, float radius, float thickness, Color colorInner, Color colorOuter)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, thickness, colorInner, colorOuter, colorInner, colorOuter, RingDashStyle);
		}

		public static void RingGradientRadialDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, Color colorInner, Color colorOuter)
		{
			Ring(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, dashStyle);
		}

		public static void RingGradientRadialDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, Color colorInner, Color colorOuter)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, dashStyle);
		}

		public static void RingGradientRadialDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, Color colorInner, Color colorOuter)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, thickness, colorInner, colorOuter, colorInner, colorOuter, dashStyle);
		}

		public static void RingGradientRadialDashed(Vector3 pos, Quaternion rot, Color colorInner, Color colorOuter)
		{
			Ring(pos, rot, DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, RingDashStyle);
		}

		public static void RingGradientRadialDashed(Vector3 pos, Quaternion rot, float radius, Color colorInner, Color colorOuter)
		{
			Ring(pos, rot, radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, RingDashStyle);
		}

		public static void RingGradientRadialDashed(Vector3 pos, Quaternion rot, float radius, float thickness, Color colorInner, Color colorOuter)
		{
			Ring(pos, rot, radius, thickness, colorInner, colorOuter, colorInner, colorOuter, RingDashStyle);
		}

		public static void RingGradientRadialDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, Color colorInner, Color colorOuter)
		{
			Ring(pos, rot, DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, dashStyle);
		}

		public static void RingGradientRadialDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, Color colorInner, Color colorOuter)
		{
			Ring(pos, rot, radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, dashStyle);
		}

		public static void RingGradientRadialDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, Color colorInner, Color colorOuter)
		{
			Ring(pos, rot, radius, thickness, colorInner, colorOuter, colorInner, colorOuter, dashStyle);
		}

		public static void RingGradientAngular(Vector3 pos, Color colorStart, Color colorEnd)
		{
			Ring(pos, Quaternion.identity, DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd);
		}

		public static void RingGradientAngular(Vector3 pos, float radius, Color colorStart, Color colorEnd)
		{
			Ring(pos, Quaternion.identity, radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd);
		}

		public static void RingGradientAngular(Vector3 pos, float radius, float thickness, Color colorStart, Color colorEnd)
		{
			Ring(pos, Quaternion.identity, radius, thickness, colorStart, colorStart, colorEnd, colorEnd);
		}

		public static void RingGradientAngular(Vector3 pos, Vector3 normal, Color colorStart, Color colorEnd)
		{
			Ring(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd);
		}

		public static void RingGradientAngular(Vector3 pos, Vector3 normal, float radius, Color colorStart, Color colorEnd)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd);
		}

		public static void RingGradientAngular(Vector3 pos, Vector3 normal, float radius, float thickness, Color colorStart, Color colorEnd)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, thickness, colorStart, colorStart, colorEnd, colorEnd);
		}

		public static void RingGradientAngular(Vector3 pos, Quaternion rot, Color colorStart, Color colorEnd)
		{
			Ring(pos, rot, DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd);
		}

		public static void RingGradientAngular(Vector3 pos, Quaternion rot, float radius, Color colorStart, Color colorEnd)
		{
			Ring(pos, rot, radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd);
		}

		public static void RingGradientAngular(Vector3 pos, Quaternion rot, float radius, float thickness, Color colorStart, Color colorEnd)
		{
			Ring(pos, rot, radius, thickness, colorStart, colorStart, colorEnd, colorEnd);
		}

		public static void RingGradientAngularDashed(Vector3 pos, Color colorStart, Color colorEnd)
		{
			Ring(pos, Quaternion.identity, DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, RingDashStyle);
		}

		public static void RingGradientAngularDashed(Vector3 pos, float radius, Color colorStart, Color colorEnd)
		{
			Ring(pos, Quaternion.identity, radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, RingDashStyle);
		}

		public static void RingGradientAngularDashed(Vector3 pos, float radius, float thickness, Color colorStart, Color colorEnd)
		{
			Ring(pos, Quaternion.identity, radius, thickness, colorStart, colorStart, colorEnd, colorEnd, RingDashStyle);
		}

		public static void RingGradientAngularDashed(Vector3 pos, DashStyle dashStyle, Color colorStart, Color colorEnd)
		{
			Ring(pos, Quaternion.identity, DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, dashStyle);
		}

		public static void RingGradientAngularDashed(Vector3 pos, DashStyle dashStyle, float radius, Color colorStart, Color colorEnd)
		{
			Ring(pos, Quaternion.identity, radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, dashStyle);
		}

		public static void RingGradientAngularDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, Color colorStart, Color colorEnd)
		{
			Ring(pos, Quaternion.identity, radius, thickness, colorStart, colorStart, colorEnd, colorEnd, dashStyle);
		}

		public static void RingGradientAngularDashed(Vector3 pos, Vector3 normal, Color colorStart, Color colorEnd)
		{
			Ring(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, RingDashStyle);
		}

		public static void RingGradientAngularDashed(Vector3 pos, Vector3 normal, float radius, Color colorStart, Color colorEnd)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, RingDashStyle);
		}

		public static void RingGradientAngularDashed(Vector3 pos, Vector3 normal, float radius, float thickness, Color colorStart, Color colorEnd)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, thickness, colorStart, colorStart, colorEnd, colorEnd, RingDashStyle);
		}

		public static void RingGradientAngularDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, Color colorStart, Color colorEnd)
		{
			Ring(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, dashStyle);
		}

		public static void RingGradientAngularDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, Color colorStart, Color colorEnd)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, dashStyle);
		}

		public static void RingGradientAngularDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, Color colorStart, Color colorEnd)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, thickness, colorStart, colorStart, colorEnd, colorEnd, dashStyle);
		}

		public static void RingGradientAngularDashed(Vector3 pos, Quaternion rot, Color colorStart, Color colorEnd)
		{
			Ring(pos, rot, DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, RingDashStyle);
		}

		public static void RingGradientAngularDashed(Vector3 pos, Quaternion rot, float radius, Color colorStart, Color colorEnd)
		{
			Ring(pos, rot, radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, RingDashStyle);
		}

		public static void RingGradientAngularDashed(Vector3 pos, Quaternion rot, float radius, float thickness, Color colorStart, Color colorEnd)
		{
			Ring(pos, rot, radius, thickness, colorStart, colorStart, colorEnd, colorEnd, RingDashStyle);
		}

		public static void RingGradientAngularDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, Color colorStart, Color colorEnd)
		{
			Ring(pos, rot, DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, dashStyle);
		}

		public static void RingGradientAngularDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, Color colorStart, Color colorEnd)
		{
			Ring(pos, rot, radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, dashStyle);
		}

		public static void RingGradientAngularDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, Color colorStart, Color colorEnd)
		{
			Ring(pos, rot, radius, thickness, colorStart, colorStart, colorEnd, colorEnd, dashStyle);
		}

		public static void RingGradientBilinear(Vector3 pos, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, Quaternion.identity, DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd);
		}

		public static void RingGradientBilinear(Vector3 pos, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, Quaternion.identity, radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd);
		}

		public static void RingGradientBilinear(Vector3 pos, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, Quaternion.identity, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd);
		}

		public static void RingGradientBilinear(Vector3 pos, Vector3 normal, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd);
		}

		public static void RingGradientBilinear(Vector3 pos, Vector3 normal, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd);
		}

		public static void RingGradientBilinear(Vector3 pos, Vector3 normal, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd);
		}

		public static void RingGradientBilinear(Vector3 pos, Quaternion rot, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, rot, DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd);
		}

		public static void RingGradientBilinear(Vector3 pos, Quaternion rot, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, rot, radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd);
		}

		public static void RingGradientBilinear(Vector3 pos, Quaternion rot, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, rot, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd);
		}

		public static void RingGradientBilinearDashed(Vector3 pos, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, Quaternion.identity, DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, RingDashStyle);
		}

		public static void RingGradientBilinearDashed(Vector3 pos, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, Quaternion.identity, radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, RingDashStyle);
		}

		public static void RingGradientBilinearDashed(Vector3 pos, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, Quaternion.identity, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, RingDashStyle);
		}

		public static void RingGradientBilinearDashed(Vector3 pos, DashStyle dashStyle, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, Quaternion.identity, DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, dashStyle);
		}

		public static void RingGradientBilinearDashed(Vector3 pos, DashStyle dashStyle, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, Quaternion.identity, radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, dashStyle);
		}

		public static void RingGradientBilinearDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, Quaternion.identity, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, dashStyle);
		}

		public static void RingGradientBilinearDashed(Vector3 pos, Vector3 normal, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, RingDashStyle);
		}

		public static void RingGradientBilinearDashed(Vector3 pos, Vector3 normal, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, RingDashStyle);
		}

		public static void RingGradientBilinearDashed(Vector3 pos, Vector3 normal, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, RingDashStyle);
		}

		public static void RingGradientBilinearDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, dashStyle);
		}

		public static void RingGradientBilinearDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, dashStyle);
		}

		public static void RingGradientBilinearDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, Quaternion.LookRotation(normal), radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, dashStyle);
		}

		public static void RingGradientBilinearDashed(Vector3 pos, Quaternion rot, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, rot, DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, RingDashStyle);
		}

		public static void RingGradientBilinearDashed(Vector3 pos, Quaternion rot, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, rot, radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, RingDashStyle);
		}

		public static void RingGradientBilinearDashed(Vector3 pos, Quaternion rot, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, rot, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, RingDashStyle);
		}

		public static void RingGradientBilinearDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, rot, DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, dashStyle);
		}

		public static void RingGradientBilinearDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, rot, radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, dashStyle);
		}

		public static void RingGradientBilinearDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Ring(pos, rot, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, dashStyle);
		}

		public static void Pie(Vector3 pos, float angleRadStart, float angleRadEnd)
		{
			Pie(pos, Quaternion.identity, DiscRadius, Color, Color, Color, Color, angleRadStart, angleRadEnd);
		}

		public static void Pie(Vector3 pos, float angleRadStart, float angleRadEnd, Color color)
		{
			Pie(pos, Quaternion.identity, DiscRadius, color, color, color, color, angleRadStart, angleRadEnd);
		}

		public static void Pie(Vector3 pos, float radius, float angleRadStart, float angleRadEnd)
		{
			Pie(pos, Quaternion.identity, radius, Color, Color, Color, Color, angleRadStart, angleRadEnd);
		}

		public static void Pie(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
			Pie(pos, Quaternion.identity, radius, color, color, color, color, angleRadStart, angleRadEnd);
		}

		public static void Pie(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd)
		{
			Pie(pos, Quaternion.LookRotation(normal), DiscRadius, Color, Color, Color, Color, angleRadStart, angleRadEnd);
		}

		public static void Pie(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color color)
		{
			Pie(pos, Quaternion.LookRotation(normal), DiscRadius, color, color, color, color, angleRadStart, angleRadEnd);
		}

		public static void Pie(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd)
		{
			Pie(pos, Quaternion.LookRotation(normal), radius, Color, Color, Color, Color, angleRadStart, angleRadEnd);
		}

		public static void Pie(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
			Pie(pos, Quaternion.LookRotation(normal), radius, color, color, color, color, angleRadStart, angleRadEnd);
		}

		public static void Pie(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd)
		{
			Pie(pos, rot, DiscRadius, Color, Color, Color, Color, angleRadStart, angleRadEnd);
		}

		public static void Pie(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color color)
		{
			Pie(pos, rot, DiscRadius, color, color, color, color, angleRadStart, angleRadEnd);
		}

		public static void Pie(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd)
		{
			Pie(pos, rot, radius, Color, Color, Color, Color, angleRadStart, angleRadEnd);
		}

		public static void Pie(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
			Pie(pos, rot, radius, color, color, color, color, angleRadStart, angleRadEnd);
		}

		public static void PieGradientRadial(Vector3 pos, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Pie(pos, Quaternion.identity, DiscRadius, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd);
		}

		public static void PieGradientRadial(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Pie(pos, Quaternion.identity, radius, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd);
		}

		public static void PieGradientRadial(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Pie(pos, Quaternion.LookRotation(normal), DiscRadius, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd);
		}

		public static void PieGradientRadial(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Pie(pos, Quaternion.LookRotation(normal), radius, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd);
		}

		public static void PieGradientRadial(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Pie(pos, rot, DiscRadius, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd);
		}

		public static void PieGradientRadial(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Pie(pos, rot, radius, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd);
		}

		public static void PieGradientAngular(Vector3 pos, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Pie(pos, Quaternion.identity, DiscRadius, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd);
		}

		public static void PieGradientAngular(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Pie(pos, Quaternion.identity, radius, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd);
		}

		public static void PieGradientAngular(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Pie(pos, Quaternion.LookRotation(normal), DiscRadius, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd);
		}

		public static void PieGradientAngular(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Pie(pos, Quaternion.LookRotation(normal), radius, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd);
		}

		public static void PieGradientAngular(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Pie(pos, rot, DiscRadius, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd);
		}

		public static void PieGradientAngular(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Pie(pos, rot, radius, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd);
		}

		public static void PieGradientBilinear(Vector3 pos, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Pie(pos, Quaternion.identity, DiscRadius, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd);
		}

		public static void PieGradientBilinear(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Pie(pos, Quaternion.identity, radius, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd);
		}

		public static void PieGradientBilinear(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Pie(pos, Quaternion.LookRotation(normal), DiscRadius, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd);
		}

		public static void PieGradientBilinear(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Pie(pos, Quaternion.LookRotation(normal), radius, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd);
		}

		public static void PieGradientBilinear(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Pie(pos, rot, DiscRadius, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd);
		}

		public static void PieGradientBilinear(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Pie(pos, rot, radius, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd);
		}

		public static void Arc(Vector3 pos, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void Arc(Vector3 pos, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void Arc(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps);
		}

		public static void Arc(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps);
		}

		public static void Arc(Vector3 pos, float radius, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void Arc(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void Arc(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps);
		}

		public static void Arc(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps);
		}

		public static void Arc(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, Quaternion.identity, radius, thickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void Arc(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, Quaternion.identity, radius, thickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void Arc(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, Quaternion.identity, radius, thickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps);
		}

		public static void Arc(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, Quaternion.identity, radius, thickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps);
		}

		public static void Arc(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void Arc(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void Arc(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps);
		}

		public static void Arc(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps);
		}

		public static void Arc(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void Arc(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void Arc(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps);
		}

		public static void Arc(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps);
		}

		public static void Arc(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void Arc(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void Arc(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps);
		}

		public static void Arc(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps);
		}

		public static void Arc(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, rot, DiscRadius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void Arc(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, rot, DiscRadius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void Arc(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, rot, DiscRadius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps);
		}

		public static void Arc(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, rot, DiscRadius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps);
		}

		public static void Arc(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, rot, radius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void Arc(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, rot, radius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void Arc(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, rot, radius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps);
		}

		public static void Arc(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, rot, radius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps);
		}

		public static void Arc(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, rot, radius, thickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void Arc(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, rot, radius, thickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void Arc(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, rot, radius, thickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps);
		}

		public static void Arc(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, rot, radius, thickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcDashed(Vector3 pos, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, Quaternion.identity, radius, thickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, Quaternion.identity, radius, thickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, Quaternion.identity, radius, thickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, Quaternion.identity, radius, thickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, Quaternion.identity, radius, thickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, Quaternion.identity, radius, thickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, Quaternion.identity, radius, thickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, Quaternion.identity, radius, thickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, rot, DiscRadius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, rot, DiscRadius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, rot, DiscRadius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, rot, DiscRadius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, rot, radius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, rot, radius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, rot, radius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, rot, radius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, rot, radius, thickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, rot, radius, thickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, rot, radius, thickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, rot, radius, thickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, rot, DiscRadius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, rot, DiscRadius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, rot, DiscRadius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, rot, DiscRadius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, rot, radius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, rot, radius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, rot, radius, RingThickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, rot, radius, RingThickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd)
		{
			Arc(pos, rot, radius, thickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color color)
		{
			Arc(pos, rot, radius, thickness, color, color, color, color, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps)
		{
			Arc(pos, rot, radius, thickness, Color, Color, Color, Color, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color color)
		{
			Arc(pos, rot, radius, thickness, color, color, color, color, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientRadial(Vector3 pos, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientRadial(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientRadial(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientRadial(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientRadial(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.identity, radius, thickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientRadial(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.identity, radius, thickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientRadial(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientRadial(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientRadial(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientRadial(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientRadial(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientRadial(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientRadial(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, rot, DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientRadial(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, rot, DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientRadial(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, rot, radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientRadial(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, rot, radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientRadial(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, rot, radius, thickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientRadial(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, rot, radius, thickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.identity, radius, thickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.identity, radius, thickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.identity, radius, thickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.identity, radius, thickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, rot, DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, rot, DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, rot, radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, rot, radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, rot, radius, thickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, rot, radius, thickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, rot, DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, rot, DiscRadius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, rot, radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, rot, radius, RingThickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInner, Color colorOuter)
		{
			Arc(pos, rot, radius, thickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientRadialDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInner, Color colorOuter)
		{
			Arc(pos, rot, radius, thickness, colorInner, colorOuter, colorInner, colorOuter, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientAngular(Vector3 pos, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientAngular(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientAngular(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientAngular(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientAngular(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.identity, radius, thickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientAngular(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.identity, radius, thickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientAngular(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientAngular(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientAngular(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientAngular(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientAngular(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientAngular(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientAngular(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, rot, DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientAngular(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, rot, DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientAngular(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, rot, radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientAngular(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, rot, radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientAngular(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, rot, radius, thickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientAngular(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, rot, radius, thickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.identity, radius, thickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.identity, radius, thickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.identity, radius, thickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.identity, radius, thickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, rot, DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, rot, DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, rot, radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, rot, radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, rot, radius, thickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, rot, radius, thickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, rot, DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, rot, DiscRadius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, rot, radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, rot, radius, RingThickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorStart, Color colorEnd)
		{
			Arc(pos, rot, radius, thickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientAngularDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorStart, Color colorEnd)
		{
			Arc(pos, rot, radius, thickness, colorStart, colorStart, colorEnd, colorEnd, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientBilinear(Vector3 pos, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientBilinear(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientBilinear(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientBilinear(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientBilinear(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.identity, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientBilinear(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.identity, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientBilinear(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientBilinear(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientBilinear(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientBilinear(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientBilinear(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientBilinear(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientBilinear(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, rot, DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientBilinear(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, rot, DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientBilinear(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, rot, radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientBilinear(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, rot, radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientBilinear(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, rot, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None);
		}

		public static void ArcGradientBilinear(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, rot, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.identity, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.identity, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.identity, DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.identity, radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.identity, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.identity, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Vector3 normal, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, Quaternion.LookRotation(normal), radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, rot, DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, rot, DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, rot, radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, rot, radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, rot, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None, RingDashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, rot, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps, RingDashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, rot, DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, rot, DiscRadius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, rot, radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, rot, radius, RingThickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, rot, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, ArcEndCap.None, dashStyle);
		}

		public static void ArcGradientBilinearDashed(Vector3 pos, Quaternion rot, DashStyle dashStyle, float radius, float thickness, float angleRadStart, float angleRadEnd, ArcEndCap endCaps, Color colorInnerStart, Color colorOuterStart, Color colorInnerEnd, Color colorOuterEnd)
		{
			Arc(pos, rot, radius, thickness, colorInnerStart, colorOuterStart, colorInnerEnd, colorOuterEnd, angleRadStart, angleRadEnd, endCaps, dashStyle);
		}

		public static void Rectangle(Vector3 pos, Rect rect)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, rect, Color);
		}

		public static void Rectangle(Vector3 pos, Rect rect, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, rect, color);
		}

		public static void Rectangle(Vector3 pos, Rect rect, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, rect, Color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Rect rect, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, rect, color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Rect rect, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, rect, Color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Rect rect, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, rect, color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, Rect rect)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), rect, Color);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, Rect rect, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), rect, color);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, Rect rect, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), rect, Color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, Rect rect, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), rect, color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, Rect rect, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), rect, Color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, Rect rect, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), rect, color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, Rect rect)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, rect, Color);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, Rect rect, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, rect, color);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, Rect rect, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, rect, Color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, Rect rect, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, rect, color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, Rect rect, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, rect, Color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, Rect rect, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, rect, color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Vector2 size)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, RectPivot.Center.GetRect(size), Color);
		}

		public static void Rectangle(Vector3 pos, Vector2 size, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, RectPivot.Center.GetRect(size), color);
		}

		public static void Rectangle(Vector3 pos, Vector2 size, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, RectPivot.Center.GetRect(size), Color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Vector2 size, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, RectPivot.Center.GetRect(size), color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Vector2 size, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, RectPivot.Center.GetRect(size), Color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Vector2 size, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, RectPivot.Center.GetRect(size), color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, float width, float height)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, RectPivot.Center.GetRect(width, height), Color);
		}

		public static void Rectangle(Vector3 pos, float width, float height, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, RectPivot.Center.GetRect(width, height), color);
		}

		public static void Rectangle(Vector3 pos, float width, float height, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, RectPivot.Center.GetRect(width, height), Color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, float width, float height, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, RectPivot.Center.GetRect(width, height), color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, float width, float height, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, RectPivot.Center.GetRect(width, height), Color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, float width, float height, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, RectPivot.Center.GetRect(width, height), color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(size), Color);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(size), color);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(size), Color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(size), color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(size), Color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(size), color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(width, height), Color);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(width, height), color);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(width, height), Color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(width, height), color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(width, height), Color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(width, height), color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, RectPivot.Center.GetRect(size), Color);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, RectPivot.Center.GetRect(size), color);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, RectPivot.Center.GetRect(size), Color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, RectPivot.Center.GetRect(size), color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, RectPivot.Center.GetRect(size), Color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, RectPivot.Center.GetRect(size), color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, RectPivot.Center.GetRect(width, height), Color);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, RectPivot.Center.GetRect(width, height), color);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, RectPivot.Center.GetRect(width, height), Color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, RectPivot.Center.GetRect(width, height), color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, RectPivot.Center.GetRect(width, height), Color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, RectPivot.Center.GetRect(width, height), color, 0f, cornerRadii);
		}

		public static void Rectangle(Rect rect)
		{
			Rectangle(BlendMode, hollow: false, Vector3.zero, Quaternion.identity, rect, Color);
		}

		public static void Rectangle(Rect rect, Color color)
		{
			Rectangle(BlendMode, hollow: false, Vector3.zero, Quaternion.identity, rect, color);
		}

		public static void Rectangle(Rect rect, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: false, Vector3.zero, Quaternion.identity, rect, Color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Rect rect, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: false, Vector3.zero, Quaternion.identity, rect, color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Rect rect, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: false, Vector3.zero, Quaternion.identity, rect, Color, 0f, cornerRadii);
		}

		public static void Rectangle(Rect rect, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: false, Vector3.zero, Quaternion.identity, rect, color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Vector2 size, RectPivot pivot)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, pivot.GetRect(size), Color);
		}

		public static void Rectangle(Vector3 pos, Vector2 size, RectPivot pivot, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, pivot.GetRect(size), color);
		}

		public static void Rectangle(Vector3 pos, Vector2 size, RectPivot pivot, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, pivot.GetRect(size), Color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Vector2 size, RectPivot pivot, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, pivot.GetRect(size), color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Vector2 size, RectPivot pivot, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, pivot.GetRect(size), Color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Vector2 size, RectPivot pivot, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, pivot.GetRect(size), color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, float width, float height, RectPivot pivot)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, pivot.GetRect(width, height), Color);
		}

		public static void Rectangle(Vector3 pos, float width, float height, RectPivot pivot, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, pivot.GetRect(width, height), color);
		}

		public static void Rectangle(Vector3 pos, float width, float height, RectPivot pivot, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, pivot.GetRect(width, height), Color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, float width, float height, RectPivot pivot, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, pivot.GetRect(width, height), color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, float width, float height, RectPivot pivot, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, pivot.GetRect(width, height), Color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, float width, float height, RectPivot pivot, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.identity, pivot.GetRect(width, height), color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), pivot.GetRect(size), Color);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), pivot.GetRect(size), color);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), pivot.GetRect(size), Color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), pivot.GetRect(size), color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), pivot.GetRect(size), Color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), pivot.GetRect(size), color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), pivot.GetRect(width, height), Color);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), pivot.GetRect(width, height), color);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), pivot.GetRect(width, height), Color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), pivot.GetRect(width, height), color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), pivot.GetRect(width, height), Color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, Quaternion.LookRotation(normal), pivot.GetRect(width, height), color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, pivot.GetRect(size), Color);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, pivot.GetRect(size), color);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, pivot.GetRect(size), Color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, pivot.GetRect(size), color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, pivot.GetRect(size), Color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, pivot.GetRect(size), color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, pivot.GetRect(width, height), Color);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, pivot.GetRect(width, height), color);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, pivot.GetRect(width, height), Color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, pivot.GetRect(width, height), color, 0f, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, pivot.GetRect(width, height), Color, 0f, cornerRadii);
		}

		public static void Rectangle(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: false, pos, rot, pivot.GetRect(width, height), color, 0f, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Rect rect, float thickness)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, rect, Color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Rect rect, float thickness, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, rect, color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Rect rect, float thickness, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, rect, Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Rect rect, float thickness, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, rect, color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Rect rect, float thickness, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, rect, Color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Rect rect, float thickness, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, rect, color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, Rect rect, float thickness)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), rect, Color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, Rect rect, float thickness, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), rect, color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, Rect rect, float thickness, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), rect, Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, Rect rect, float thickness, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), rect, color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, Rect rect, float thickness, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), rect, Color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, Rect rect, float thickness, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), rect, color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, Rect rect, float thickness)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, rect, Color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, Rect rect, float thickness, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, rect, color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, Rect rect, float thickness, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, rect, Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, Rect rect, float thickness, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, rect, color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, Rect rect, float thickness, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, rect, Color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, Rect rect, float thickness, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, rect, color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Vector2 size, float thickness)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, RectPivot.Center.GetRect(size), Color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Vector2 size, float thickness, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, RectPivot.Center.GetRect(size), color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Vector2 size, float thickness, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, RectPivot.Center.GetRect(size), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Vector2 size, float thickness, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, RectPivot.Center.GetRect(size), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Vector2 size, float thickness, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, RectPivot.Center.GetRect(size), Color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Vector2 size, float thickness, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, RectPivot.Center.GetRect(size), color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, float width, float height, float thickness)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, RectPivot.Center.GetRect(width, height), Color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, float width, float height, float thickness, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, RectPivot.Center.GetRect(width, height), color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, float width, float height, float thickness, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, RectPivot.Center.GetRect(width, height), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, float width, float height, float thickness, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, RectPivot.Center.GetRect(width, height), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, float width, float height, float thickness, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, RectPivot.Center.GetRect(width, height), Color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, float width, float height, float thickness, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, RectPivot.Center.GetRect(width, height), color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, float thickness)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(size), Color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, float thickness, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(size), color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, float thickness, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(size), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, float thickness, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(size), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, float thickness, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(size), Color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, float thickness, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(size), color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, float thickness)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(width, height), Color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, float thickness, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(width, height), color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, float thickness, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(width, height), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, float thickness, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(width, height), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, float thickness, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(width, height), Color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, float thickness, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), RectPivot.Center.GetRect(width, height), color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, float thickness)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, RectPivot.Center.GetRect(size), Color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, float thickness, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, RectPivot.Center.GetRect(size), color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, float thickness, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, RectPivot.Center.GetRect(size), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, float thickness, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, RectPivot.Center.GetRect(size), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, float thickness, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, RectPivot.Center.GetRect(size), Color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, float thickness, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, RectPivot.Center.GetRect(size), color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, float thickness)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, RectPivot.Center.GetRect(width, height), Color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, float thickness, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, RectPivot.Center.GetRect(width, height), color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, float thickness, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, RectPivot.Center.GetRect(width, height), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, float thickness, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, RectPivot.Center.GetRect(width, height), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, float thickness, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, RectPivot.Center.GetRect(width, height), Color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, float thickness, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, RectPivot.Center.GetRect(width, height), color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Rect rect, float thickness)
		{
			Rectangle(BlendMode, hollow: true, Vector3.zero, Quaternion.identity, rect, Color, thickness);
		}

		public static void RectangleBorder(Rect rect, float thickness, Color color)
		{
			Rectangle(BlendMode, hollow: true, Vector3.zero, Quaternion.identity, rect, color, thickness);
		}

		public static void RectangleBorder(Rect rect, float thickness, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: true, Vector3.zero, Quaternion.identity, rect, Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Rect rect, float thickness, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: true, Vector3.zero, Quaternion.identity, rect, color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Rect rect, float thickness, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: true, Vector3.zero, Quaternion.identity, rect, Color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Rect rect, float thickness, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: true, Vector3.zero, Quaternion.identity, rect, color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Vector2 size, RectPivot pivot, float thickness)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, pivot.GetRect(size), Color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Vector2 size, RectPivot pivot, float thickness, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, pivot.GetRect(size), color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Vector2 size, RectPivot pivot, float thickness, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, pivot.GetRect(size), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Vector2 size, RectPivot pivot, float thickness, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, pivot.GetRect(size), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Vector2 size, RectPivot pivot, float thickness, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, pivot.GetRect(size), Color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Vector2 size, RectPivot pivot, float thickness, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, pivot.GetRect(size), color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, float width, float height, RectPivot pivot, float thickness)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, pivot.GetRect(width, height), Color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, float width, float height, RectPivot pivot, float thickness, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, pivot.GetRect(width, height), color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, float width, float height, RectPivot pivot, float thickness, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, pivot.GetRect(width, height), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, float width, float height, RectPivot pivot, float thickness, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, pivot.GetRect(width, height), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, float width, float height, RectPivot pivot, float thickness, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, pivot.GetRect(width, height), Color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, float width, float height, RectPivot pivot, float thickness, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.identity, pivot.GetRect(width, height), color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float thickness)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), pivot.GetRect(size), Color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float thickness, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), pivot.GetRect(size), color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float thickness, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), pivot.GetRect(size), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float thickness, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), pivot.GetRect(size), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float thickness, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), pivot.GetRect(size), Color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, Vector2 size, RectPivot pivot, float thickness, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), pivot.GetRect(size), color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float thickness)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), pivot.GetRect(width, height), Color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float thickness, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), pivot.GetRect(width, height), color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float thickness, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), pivot.GetRect(width, height), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float thickness, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), pivot.GetRect(width, height), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float thickness, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), pivot.GetRect(width, height), Color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Vector3 normal, float width, float height, RectPivot pivot, float thickness, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, Quaternion.LookRotation(normal), pivot.GetRect(width, height), color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float thickness)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, pivot.GetRect(size), Color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float thickness, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, pivot.GetRect(size), color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float thickness, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, pivot.GetRect(size), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float thickness, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, pivot.GetRect(size), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float thickness, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, pivot.GetRect(size), Color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, Vector2 size, RectPivot pivot, float thickness, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, pivot.GetRect(size), color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float thickness)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, pivot.GetRect(width, height), Color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float thickness, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, pivot.GetRect(width, height), color, thickness);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float thickness, float cornerRadius)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, pivot.GetRect(width, height), Color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float thickness, float cornerRadius, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, pivot.GetRect(width, height), color, thickness, new Vector4(cornerRadius, cornerRadius, cornerRadius, cornerRadius));
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float thickness, Vector4 cornerRadii)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, pivot.GetRect(width, height), Color, thickness, cornerRadii);
		}

		public static void RectangleBorder(Vector3 pos, Quaternion rot, float width, float height, RectPivot pivot, float thickness, Vector4 cornerRadii, Color color)
		{
			Rectangle(BlendMode, hollow: true, pos, rot, pivot.GetRect(width, height), color, thickness, cornerRadii);
		}

		public static void Triangle(Vector3 a, Vector3 b, Vector3 c)
		{
			Triangle(BlendMode, a, b, c, Color, Color, Color);
		}

		public static void Triangle(Vector3 a, Vector3 b, Vector3 c, Color color)
		{
			Triangle(BlendMode, a, b, c, color, color, color);
		}

		public static void Triangle(Vector3 a, Vector3 b, Vector3 c, Color colorA, Color colorB, Color colorC)
		{
			Triangle(BlendMode, a, b, c, colorA, colorB, colorC);
		}

		public static void Quad(Vector3 a, Vector3 b, Vector3 c)
		{
			Quad(BlendMode, a, b, c, a + (c - b), Color, Color, Color, Color);
		}

		public static void Quad(Vector3 a, Vector3 b, Vector3 c, Color color)
		{
			Quad(BlendMode, a, b, c, a + (c - b), color, color, color, color);
		}

		public static void Quad(Vector3 a, Vector3 b, Vector3 c, Color colorA, Color colorB, Color colorC, Color colorD)
		{
			Quad(BlendMode, a, b, c, a + (c - b), colorA, colorB, colorC, colorD);
		}

		public static void Quad(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
		{
			Quad(BlendMode, a, b, c, d, Color, Color, Color, Color);
		}

		public static void Quad(Vector3 a, Vector3 b, Vector3 c, Vector3 d, Color color)
		{
			Quad(BlendMode, a, b, c, d, color, color, color, color);
		}

		public static void Quad(Vector3 a, Vector3 b, Vector3 c, Vector3 d, Color colorA, Color colorB, Color colorC, Color colorD)
		{
			Quad(BlendMode, a, b, c, d, colorA, colorB, colorC, colorD);
		}

		public static void Sphere(Vector3 pos)
		{
			Sphere(BlendMode, SphereRadiusSpace, pos, SphereRadius, Color);
		}

		public static void Sphere(Vector3 pos, float radius)
		{
			Sphere(BlendMode, SphereRadiusSpace, pos, radius, Color);
		}

		public static void Sphere(Vector3 pos, Color color)
		{
			Sphere(BlendMode, SphereRadiusSpace, pos, SphereRadius, color);
		}

		public static void Sphere(Vector3 pos, float radius, Color color)
		{
			Sphere(BlendMode, SphereRadiusSpace, pos, radius, color);
		}

		public static void Cuboid(Vector3 pos, Vector3 size)
		{
			Cuboid(BlendMode, CuboidSizeSpace, pos, Quaternion.identity, size, Color);
		}

		public static void Cuboid(Vector3 pos, Vector3 size, Color color)
		{
			Cuboid(BlendMode, CuboidSizeSpace, pos, Quaternion.identity, size, color);
		}

		public static void Cuboid(Vector3 pos, Vector3 normal, Vector3 size)
		{
			Cuboid(BlendMode, CuboidSizeSpace, pos, Quaternion.LookRotation(normal), size, Color);
		}

		public static void Cuboid(Vector3 pos, Vector3 normal, Vector3 size, Color color)
		{
			Cuboid(BlendMode, CuboidSizeSpace, pos, Quaternion.LookRotation(normal), size, color);
		}

		public static void Cuboid(Vector3 pos, Quaternion rot, Vector3 size)
		{
			Cuboid(BlendMode, CuboidSizeSpace, pos, rot, size, Color);
		}

		public static void Cuboid(Vector3 pos, Quaternion rot, Vector3 size, Color color)
		{
			Cuboid(BlendMode, CuboidSizeSpace, pos, rot, size, color);
		}

		public static void Cube(Vector3 pos, float size)
		{
			Cuboid(BlendMode, CuboidSizeSpace, pos, Quaternion.identity, new Vector3(size, size, size), Color);
		}

		public static void Cube(Vector3 pos, float size, Color color)
		{
			Cuboid(BlendMode, CuboidSizeSpace, pos, Quaternion.identity, new Vector3(size, size, size), color);
		}

		public static void Cube(Vector3 pos, Vector3 normal, float size)
		{
			Cuboid(BlendMode, CuboidSizeSpace, pos, Quaternion.LookRotation(normal), new Vector3(size, size, size), Color);
		}

		public static void Cube(Vector3 pos, Vector3 normal, float size, Color color)
		{
			Cuboid(BlendMode, CuboidSizeSpace, pos, Quaternion.LookRotation(normal), new Vector3(size, size, size), color);
		}

		public static void Cube(Vector3 pos, Quaternion rot, float size)
		{
			Cuboid(BlendMode, CuboidSizeSpace, pos, rot, new Vector3(size, size, size), Color);
		}

		public static void Cube(Vector3 pos, Quaternion rot, float size, Color color)
		{
			Cuboid(BlendMode, CuboidSizeSpace, pos, rot, new Vector3(size, size, size), color);
		}

		public static void Cone(Vector3 pos, float radius, float length)
		{
			Cone(BlendMode, ConeSizeSpace, pos, Quaternion.identity, radius, length, fillCap: true, Color);
		}

		public static void Cone(Vector3 pos, float radius, float length, bool fillCap)
		{
			Cone(BlendMode, ConeSizeSpace, pos, Quaternion.identity, radius, length, fillCap, Color);
		}

		public static void Cone(Vector3 pos, float radius, float length, Color color)
		{
			Cone(BlendMode, ConeSizeSpace, pos, Quaternion.identity, radius, length, fillCap: true, color);
		}

		public static void Cone(Vector3 pos, float radius, float length, bool fillCap, Color color)
		{
			Cone(BlendMode, ConeSizeSpace, pos, Quaternion.identity, radius, length, fillCap, color);
		}

		public static void Cone(Vector3 pos, Vector3 normal, float radius, float length)
		{
			Cone(BlendMode, ConeSizeSpace, pos, Quaternion.LookRotation(normal), radius, length, fillCap: true, Color);
		}

		public static void Cone(Vector3 pos, Vector3 normal, float radius, float length, bool fillCap)
		{
			Cone(BlendMode, ConeSizeSpace, pos, Quaternion.LookRotation(normal), radius, length, fillCap, Color);
		}

		public static void Cone(Vector3 pos, Vector3 normal, float radius, float length, Color color)
		{
			Cone(BlendMode, ConeSizeSpace, pos, Quaternion.LookRotation(normal), radius, length, fillCap: true, color);
		}

		public static void Cone(Vector3 pos, Vector3 normal, float radius, float length, bool fillCap, Color color)
		{
			Cone(BlendMode, ConeSizeSpace, pos, Quaternion.LookRotation(normal), radius, length, fillCap, color);
		}

		public static void Cone(Vector3 pos, Quaternion rot, float radius, float length)
		{
			Cone(BlendMode, ConeSizeSpace, pos, rot, radius, length, fillCap: true, Color);
		}

		public static void Cone(Vector3 pos, Quaternion rot, float radius, float length, bool fillCap)
		{
			Cone(BlendMode, ConeSizeSpace, pos, rot, radius, length, fillCap, Color);
		}

		public static void Cone(Vector3 pos, Quaternion rot, float radius, float length, Color color)
		{
			Cone(BlendMode, ConeSizeSpace, pos, rot, radius, length, fillCap: true, color);
		}

		public static void Cone(Vector3 pos, Quaternion rot, float radius, float length, bool fillCap, Color color)
		{
			Cone(BlendMode, ConeSizeSpace, pos, rot, radius, length, fillCap, color);
		}

		public static void Torus(Vector3 pos, float radius, float thickness)
		{
			Torus(BlendMode, TorusRadiusSpace, TorusThicknessSpace, pos, Quaternion.identity, radius, thickness, Color);
		}

		public static void Torus(Vector3 pos, float radius, float thickness, Color color)
		{
			Torus(BlendMode, TorusRadiusSpace, TorusThicknessSpace, pos, Quaternion.identity, radius, thickness, color);
		}

		public static void Torus(Vector3 pos, Vector3 normal, float radius, float thickness)
		{
			Torus(BlendMode, TorusRadiusSpace, TorusThicknessSpace, pos, Quaternion.LookRotation(normal), radius, thickness, Color);
		}

		public static void Torus(Vector3 pos, Vector3 normal, float radius, float thickness, Color color)
		{
			Torus(BlendMode, TorusRadiusSpace, TorusThicknessSpace, pos, Quaternion.LookRotation(normal), radius, thickness, color);
		}

		public static void Torus(Vector3 pos, Quaternion rot, float radius, float thickness)
		{
			Torus(BlendMode, TorusRadiusSpace, TorusThicknessSpace, pos, rot, radius, thickness, Color);
		}

		public static void Torus(Vector3 pos, Quaternion rot, float radius, float thickness, Color color)
		{
			Torus(BlendMode, TorusRadiusSpace, TorusThicknessSpace, pos, rot, radius, thickness, color);
		}

		public static void Text(Vector3 pos, string content)
		{
			Text(pos, Quaternion.identity, content, Font, FontSize, TextAlign, Color);
		}

		public static void Text(Vector3 pos, string content, TextAlign align)
		{
			Text(pos, Quaternion.identity, content, Font, FontSize, align, Color);
		}

		public static void Text(Vector3 pos, string content, float fontSize)
		{
			Text(pos, Quaternion.identity, content, Font, fontSize, TextAlign, Color);
		}

		public static void Text(Vector3 pos, string content, TextAlign align, float fontSize)
		{
			Text(pos, Quaternion.identity, content, Font, fontSize, align, Color);
		}

		public static void Text(Vector3 pos, string content, TMP_FontAsset font)
		{
			Text(pos, Quaternion.identity, content, font, FontSize, TextAlign, Color);
		}

		public static void Text(Vector3 pos, string content, TextAlign align, TMP_FontAsset font)
		{
			Text(pos, Quaternion.identity, content, font, FontSize, align, Color);
		}

		public static void Text(Vector3 pos, string content, float fontSize, TMP_FontAsset font)
		{
			Text(pos, Quaternion.identity, content, font, fontSize, TextAlign, Color);
		}

		public static void Text(Vector3 pos, string content, TextAlign align, float fontSize, TMP_FontAsset font)
		{
			Text(pos, Quaternion.identity, content, font, fontSize, align, Color);
		}

		public static void Text(Vector3 pos, string content, Color color)
		{
			Text(pos, Quaternion.identity, content, Font, FontSize, TextAlign, color);
		}

		public static void Text(Vector3 pos, string content, TextAlign align, Color color)
		{
			Text(pos, Quaternion.identity, content, Font, FontSize, align, color);
		}

		public static void Text(Vector3 pos, string content, float fontSize, Color color)
		{
			Text(pos, Quaternion.identity, content, Font, fontSize, TextAlign, color);
		}

		public static void Text(Vector3 pos, string content, TextAlign align, float fontSize, Color color)
		{
			Text(pos, Quaternion.identity, content, Font, fontSize, align, color);
		}

		public static void Text(Vector3 pos, string content, TMP_FontAsset font, Color color)
		{
			Text(pos, Quaternion.identity, content, font, FontSize, TextAlign, color);
		}

		public static void Text(Vector3 pos, string content, TextAlign align, TMP_FontAsset font, Color color)
		{
			Text(pos, Quaternion.identity, content, font, FontSize, align, color);
		}

		public static void Text(Vector3 pos, string content, float fontSize, TMP_FontAsset font, Color color)
		{
			Text(pos, Quaternion.identity, content, font, fontSize, TextAlign, color);
		}

		public static void Text(Vector3 pos, string content, TextAlign align, float fontSize, TMP_FontAsset font, Color color)
		{
			Text(pos, Quaternion.identity, content, font, fontSize, align, color);
		}

		public static void Text(Vector3 pos, Vector3 normal, string content)
		{
			Text(pos, Quaternion.LookRotation(normal), content, Font, FontSize, TextAlign, Color);
		}

		public static void Text(Vector3 pos, Vector3 normal, string content, TextAlign align)
		{
			Text(pos, Quaternion.LookRotation(normal), content, Font, FontSize, align, Color);
		}

		public static void Text(Vector3 pos, Vector3 normal, string content, float fontSize)
		{
			Text(pos, Quaternion.LookRotation(normal), content, Font, fontSize, TextAlign, Color);
		}

		public static void Text(Vector3 pos, Vector3 normal, string content, TextAlign align, float fontSize)
		{
			Text(pos, Quaternion.LookRotation(normal), content, Font, fontSize, align, Color);
		}

		public static void Text(Vector3 pos, Vector3 normal, string content, TMP_FontAsset font)
		{
			Text(pos, Quaternion.LookRotation(normal), content, font, FontSize, TextAlign, Color);
		}

		public static void Text(Vector3 pos, Vector3 normal, string content, TextAlign align, TMP_FontAsset font)
		{
			Text(pos, Quaternion.LookRotation(normal), content, font, FontSize, align, Color);
		}

		public static void Text(Vector3 pos, Vector3 normal, string content, float fontSize, TMP_FontAsset font)
		{
			Text(pos, Quaternion.LookRotation(normal), content, font, fontSize, TextAlign, Color);
		}

		public static void Text(Vector3 pos, Vector3 normal, string content, TextAlign align, float fontSize, TMP_FontAsset font)
		{
			Text(pos, Quaternion.LookRotation(normal), content, font, fontSize, align, Color);
		}

		public static void Text(Vector3 pos, Vector3 normal, string content, Color color)
		{
			Text(pos, Quaternion.LookRotation(normal), content, Font, FontSize, TextAlign, color);
		}

		public static void Text(Vector3 pos, Vector3 normal, string content, TextAlign align, Color color)
		{
			Text(pos, Quaternion.LookRotation(normal), content, Font, FontSize, align, color);
		}

		public static void Text(Vector3 pos, Vector3 normal, string content, float fontSize, Color color)
		{
			Text(pos, Quaternion.LookRotation(normal), content, Font, fontSize, TextAlign, color);
		}

		public static void Text(Vector3 pos, Vector3 normal, string content, TextAlign align, float fontSize, Color color)
		{
			Text(pos, Quaternion.LookRotation(normal), content, Font, fontSize, align, color);
		}

		public static void Text(Vector3 pos, Vector3 normal, string content, TMP_FontAsset font, Color color)
		{
			Text(pos, Quaternion.LookRotation(normal), content, font, FontSize, TextAlign, color);
		}

		public static void Text(Vector3 pos, Vector3 normal, string content, TextAlign align, TMP_FontAsset font, Color color)
		{
			Text(pos, Quaternion.LookRotation(normal), content, font, FontSize, align, color);
		}

		public static void Text(Vector3 pos, Vector3 normal, string content, float fontSize, TMP_FontAsset font, Color color)
		{
			Text(pos, Quaternion.LookRotation(normal), content, font, fontSize, TextAlign, color);
		}

		public static void Text(Vector3 pos, Vector3 normal, string content, TextAlign align, float fontSize, TMP_FontAsset font, Color color)
		{
			Text(pos, Quaternion.LookRotation(normal), content, font, fontSize, align, color);
		}

		public static void Text(Vector3 pos, Quaternion rot, string content)
		{
			Text(pos, rot, content, Font, FontSize, TextAlign, Color);
		}

		public static void Text(Vector3 pos, Quaternion rot, string content, TextAlign align)
		{
			Text(pos, rot, content, Font, FontSize, align, Color);
		}

		public static void Text(Vector3 pos, Quaternion rot, string content, float fontSize)
		{
			Text(pos, rot, content, Font, fontSize, TextAlign, Color);
		}

		public static void Text(Vector3 pos, Quaternion rot, string content, TextAlign align, float fontSize)
		{
			Text(pos, rot, content, Font, fontSize, align, Color);
		}

		public static void Text(Vector3 pos, Quaternion rot, string content, TMP_FontAsset font)
		{
			Text(pos, rot, content, font, FontSize, TextAlign, Color);
		}

		public static void Text(Vector3 pos, Quaternion rot, string content, TextAlign align, TMP_FontAsset font)
		{
			Text(pos, rot, content, font, FontSize, align, Color);
		}

		public static void Text(Vector3 pos, Quaternion rot, string content, float fontSize, TMP_FontAsset font)
		{
			Text(pos, rot, content, font, fontSize, TextAlign, Color);
		}

		public static void Text(Vector3 pos, Quaternion rot, string content, TextAlign align, float fontSize, TMP_FontAsset font)
		{
			Text(pos, rot, content, font, fontSize, align, Color);
		}

		public static void Text(Vector3 pos, Quaternion rot, string content, Color color)
		{
			Text(pos, rot, content, Font, FontSize, TextAlign, color);
		}

		public static void Text(Vector3 pos, Quaternion rot, string content, TextAlign align, Color color)
		{
			Text(pos, rot, content, Font, FontSize, align, color);
		}

		public static void Text(Vector3 pos, Quaternion rot, string content, float fontSize, Color color)
		{
			Text(pos, rot, content, Font, fontSize, TextAlign, color);
		}

		public static void Text(Vector3 pos, Quaternion rot, string content, TextAlign align, float fontSize, Color color)
		{
			Text(pos, rot, content, Font, fontSize, align, color);
		}

		public static void Text(Vector3 pos, Quaternion rot, string content, TMP_FontAsset font, Color color)
		{
			Text(pos, rot, content, font, FontSize, TextAlign, color);
		}

		public static void Text(Vector3 pos, Quaternion rot, string content, TextAlign align, TMP_FontAsset font, Color color)
		{
			Text(pos, rot, content, font, FontSize, align, color);
		}

		public static void Text(Vector3 pos, Quaternion rot, string content, float fontSize, TMP_FontAsset font, Color color)
		{
			Text(pos, rot, content, font, fontSize, TextAlign, color);
		}

		public static void Text(Vector3 pos, Quaternion rot, string content, TextAlign align, float fontSize, TMP_FontAsset font, Color color)
		{
			Text(pos, rot, content, font, fontSize, align, color);
		}

		public static void Text(Vector3 pos, float angle, string content)
		{
			Text(pos, Quaternion.Euler(0f, 0f, angle * 57.29578f), content, Font, FontSize, TextAlign, Color);
		}

		public static void Text(Vector3 pos, float angle, string content, TextAlign align)
		{
			Text(pos, Quaternion.Euler(0f, 0f, angle * 57.29578f), content, Font, FontSize, align, Color);
		}

		public static void Text(Vector3 pos, float angle, string content, float fontSize)
		{
			Text(pos, Quaternion.Euler(0f, 0f, angle * 57.29578f), content, Font, fontSize, TextAlign, Color);
		}

		public static void Text(Vector3 pos, float angle, string content, TextAlign align, float fontSize)
		{
			Text(pos, Quaternion.Euler(0f, 0f, angle * 57.29578f), content, Font, fontSize, align, Color);
		}

		public static void Text(Vector3 pos, float angle, string content, TMP_FontAsset font)
		{
			Text(pos, Quaternion.Euler(0f, 0f, angle * 57.29578f), content, font, FontSize, TextAlign, Color);
		}

		public static void Text(Vector3 pos, float angle, string content, TextAlign align, TMP_FontAsset font)
		{
			Text(pos, Quaternion.Euler(0f, 0f, angle * 57.29578f), content, font, FontSize, align, Color);
		}

		public static void Text(Vector3 pos, float angle, string content, float fontSize, TMP_FontAsset font)
		{
			Text(pos, Quaternion.Euler(0f, 0f, angle * 57.29578f), content, font, fontSize, TextAlign, Color);
		}

		public static void Text(Vector3 pos, float angle, string content, TextAlign align, float fontSize, TMP_FontAsset font)
		{
			Text(pos, Quaternion.Euler(0f, 0f, angle * 57.29578f), content, font, fontSize, align, Color);
		}

		public static void Text(Vector3 pos, float angle, string content, Color color)
		{
			Text(pos, Quaternion.Euler(0f, 0f, angle * 57.29578f), content, Font, FontSize, TextAlign, color);
		}

		public static void Text(Vector3 pos, float angle, string content, TextAlign align, Color color)
		{
			Text(pos, Quaternion.Euler(0f, 0f, angle * 57.29578f), content, Font, FontSize, align, color);
		}

		public static void Text(Vector3 pos, float angle, string content, float fontSize, Color color)
		{
			Text(pos, Quaternion.Euler(0f, 0f, angle * 57.29578f), content, Font, fontSize, TextAlign, color);
		}

		public static void Text(Vector3 pos, float angle, string content, TextAlign align, float fontSize, Color color)
		{
			Text(pos, Quaternion.Euler(0f, 0f, angle * 57.29578f), content, Font, fontSize, align, color);
		}

		public static void Text(Vector3 pos, float angle, string content, TMP_FontAsset font, Color color)
		{
			Text(pos, Quaternion.Euler(0f, 0f, angle * 57.29578f), content, font, FontSize, TextAlign, color);
		}

		public static void Text(Vector3 pos, float angle, string content, TextAlign align, TMP_FontAsset font, Color color)
		{
			Text(pos, Quaternion.Euler(0f, 0f, angle * 57.29578f), content, font, FontSize, align, color);
		}

		public static void Text(Vector3 pos, float angle, string content, float fontSize, TMP_FontAsset font, Color color)
		{
			Text(pos, Quaternion.Euler(0f, 0f, angle * 57.29578f), content, font, fontSize, TextAlign, color);
		}

		public static void Text(Vector3 pos, float angle, string content, TextAlign align, float fontSize, TMP_FontAsset font, Color color)
		{
			Text(pos, Quaternion.Euler(0f, 0f, angle * 57.29578f), content, font, fontSize, align, color);
		}

		static Draw()
		{
			mpbLine = new MpbLine();
			mpbPolyline = new MpbPolyline();
			mpbPolylineJoins = new MpbPolyline();
			mpbPolygon = new MpbPolygon();
			mpbDisc = new MpbDisc();
			mpbRegularPolygon = new MpbRegularPolygon();
			mpbRectangle = new MpbRectangle();
			mpbTriangle = new MpbTriangle();
			mpbQuad = new MpbQuad();
			metaMpbSphere = new MpbSphere();
			mpbCone = new MpbCone();
			mpbCuboid = new MpbCuboid();
			mpbTorus = new MpbTorus();
			mpbText = new MpbText();
			matrix = Matrix4x4.identity;
			hasCustomMatrix = false;
			ResetAllDrawStates();
		}

		public static void ResetAllDrawStates()
		{
			ResetMatrix();
			ResetStyle();
		}

		public static void ResetMatrix()
		{
			matrix = Matrix4x4.identity;
			hasCustomMatrix = false;
		}

		public static void ResetStyle()
		{
			Color = Color.white;
			ZTest = ShapeRenderer.DEFAULT_ZTEST;
			ZOffsetFactor = ShapeRenderer.DEFAULT_ZOFS_FACTOR;
			ZOffsetUnits = ShapeRenderer.DEFAULT_ZOFS_UNITS;
			StencilComp = ShapeRenderer.DEFAULT_STENCIL_COMP;
			StencilOpPass = ShapeRenderer.DEFAULT_STENCIL_OP;
			StencilRefID = ShapeRenderer.DEFAULT_STENCIL_REF_ID;
			StencilReadMask = ShapeRenderer.DEFAULT_STENCIL_MASK;
			StencilWriteMask = ShapeRenderer.DEFAULT_STENCIL_MASK;
			BlendMode = ShapesBlendMode.Transparent;
			ScaleMode = ScaleMode.Uniform;
			DetailLevel = DetailLevel.Medium;
			LineThickness = 0.05f;
			LineThicknessSpace = ThicknessSpace.Meters;
			LineDashStyle = DashStyle.DefaultDashStyleLine;
			LineEndCaps = LineEndCap.Round;
			LineGeometry = LineGeometry.Billboard;
			PolygonTriangulation = PolygonTriangulation.EarClipping;
			PolygonShapeFill = new ShapeFill();
			PolylineGeometry = PolylineGeometry.Billboard;
			PolylineJoins = PolylineJoins.Round;
			DiscGeometry = DiscGeometry.Flat2D;
			DiscRadius = 1f;
			RingThickness = 0.05f;
			RingThicknessSpace = ThicknessSpace.Meters;
			DiscRadiusSpace = ThicknessSpace.Meters;
			RingDashStyle = DashStyle.DefaultDashStyleRing;
			RegularPolygonRadius = 1f;
			RegularPolygonSideCount = 6;
			RegularPolygonGeometry = RegularPolygonGeometry.Flat2D;
			RegularPolygonThickness = 0.05f;
			RegularPolygonThicknessSpace = ThicknessSpace.Meters;
			RegularPolygonRadiusSpace = ThicknessSpace.Meters;
			RegularPolygonShapeFill = new ShapeFill();
			SphereRadius = 1f;
			SphereRadiusSpace = ThicknessSpace.Meters;
			CuboidSizeSpace = ThicknessSpace.Meters;
			TorusThicknessSpace = ThicknessSpace.Meters;
			TorusRadiusSpace = ThicknessSpace.Meters;
			ConeSizeSpace = ThicknessSpace.Meters;
			Font = ShapesAssets.Instance.defaultFont;
			FontSize = 1f;
			TextAlign = TextAlign.Center;
		}
	}
}
