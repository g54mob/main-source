using System;
using System.Collections.Generic;
using UnityEngine;

public static class cwf
{
	[Serializable]
	public class Cutout
	{
		[Serializable]
		public class Standard
		{
			private class cvx
			{
				public int wpa;

				public int wpb;

				public int wpc;

				public int wpd;

				public int wpe;

				public int wpf;

				public int wpg;

				public int wph;

				public int wpi;

				public int wpj;

				public int wpk;

				public int wpl;

				public int wpm;

				public int wpn;

				public int wpo;

				public int wpp;

				public int wpq;

				public int wpr;

				public int wps;

				public int wpt;

				public int wpu;

				public int wpv;

				public int wpw;

				public int wpx;

				public int wpy;

				public int wpz;

				public cvx(int a)
				{
				}
			}

			public enum Property
			{
				Clip = 0,
				Map1 = 1,
				Map1Tiling = 2,
				Map1Offset = 3,
				Map1Scroll = 4,
				Map1Intensity = 5,
				Map1Channel = 6,
				Map1Invert = 7,
				Map2 = 8,
				Map2Tiling = 9,
				Map2Offset = 10,
				Map2Scroll = 11,
				Map2Intensity = 12,
				Map2Channel = 13,
				Map2Invert = 14,
				Map3 = 15,
				Map3Tiling = 16,
				Map3Offset = 17,
				Map3Scroll = 18,
				Map3Intensity = 19,
				Map3Channel = 20,
				Map3Invert = 21,
				MapsBlendType = 22,
				TriplanarMappingSpace = 23,
				ScreenSpaceUVScale = 24,
				BaseInvert = 25
			}

			public enum MapsBlendType
			{
				Multiply = 0,
				Add = 1
			}

			public enum TriplanarMappingSpace
			{
				World = 0,
				Local = 1
			}

			public enum ScreenSpaceUVScale
			{
				Constant = 0,
				CameraRelative = 1
			}

			public enum MapChannel
			{
				Red = 0,
				Green = 1,
				Blue = 2,
				Alpha = 3
			}

			private static cvx[] wqa;

			[Range(0f, 1f)]
			public float clip;

			[Space(10f)]
			public Texture2D map1;

			public Vector3 map1Tiling;

			public Vector3 map1Offset;

			public Vector3 map1Scroll;

			[Range(0f, 1f)]
			public float map1Intensity;

			public MapChannel map1Channel;

			public bool map1Invert;

			[Space(10f)]
			public Texture2D map2;

			public Vector3 map2Tiling;

			public Vector3 map2Offset;

			public Vector3 map2Scroll;

			[Range(0f, 1f)]
			public float map2Intensity;

			public MapChannel map2Channel;

			public bool map2Invert;

			[Space(10f)]
			public Texture2D map3;

			public Vector3 map3Tiling;

			public Vector3 map3Offset;

			public Vector3 map3Scroll;

			[Range(0f, 1f)]
			public float map3Intensity;

			public MapChannel map3Channel;

			public bool map3Invert;

			[Space(10f)]
			public MapsBlendType mapsBlendType;

			public TriplanarMappingSpace triplanarMappingSpace;

			public ScreenSpaceUVScale screenSpaceUVScale;

			public bool baseInvert;

			public void pak(List<Material> a)
			{
			}

			public void pal(Material a)
			{
			}

			public void pam(cvw.GlobalControlID a)
			{
			}

			public static void pan(Material a, Property b, object c)
			{
			}

			public static void pao(cvw.GlobalControlID a, Property b, object c)
			{
			}
		}

		[Serializable]
		public class Geometric
		{
			private class cvy
			{
				public int wqb;

				public int wqc;

				public int wqd;

				public int wqe;

				public int wqf;

				public int wqg;

				public int wqh;

				public int wqi;

				public int wqj;

				public int wqk;

				public int wql;

				public int wqm;

				public int wqn;

				public int wqo;

				public int wqp;

				public int wqq;

				public int wqr;

				public int wqs;

				public int wqt;

				public int wqu;

				public int wqv;

				public int wqw;

				public int wqx;

				public int wqy;

				public int wqz;

				public int wra;

				public int wrb;

				public int wrc;

				public int wrd;

				public int wre;

				public int wrf;

				public cvy(int a)
				{
				}
			}

			public enum Property
			{
				XYZAxis = 0,
				XYZStyle = 1,
				XYZSpace = 2,
				XYZRollout = 3,
				XYZPosition = 4,
				Position1 = 5,
				Normal1 = 6,
				Radius1 = 7,
				Height1 = 8,
				Size1 = 9,
				MatrixTRS1 = 10,
				Position2 = 11,
				Normal2 = 12,
				Radius2 = 13,
				Height2 = 14,
				Size2 = 15,
				MatrixTRS2 = 16,
				Position3 = 17,
				Normal3 = 18,
				Radius3 = 19,
				Height3 = 20,
				Size3 = 21,
				MatrixTRS3 = 22,
				Position4 = 23,
				Normal4 = 24,
				Radius4 = 25,
				Height4 = 26,
				Size4 = 27,
				MatrixTRS4 = 28,
				Invert = 29,
				Noise = 30
			}

			public enum XYZAxis
			{
				X = 0,
				Y = 1,
				Z = 2
			}

			public enum XYZStyle
			{
				Linear = 0,
				Rollout = 1
			}

			public enum XYZSpace
			{
				World = 0,
				Local = 1
			}

			public static class cvz
			{
				public static void pat(Material a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d, float e)
				{
				}

				public static void pav(Material a, bool b)
				{
				}

				public static void fvd(Material a, cvw.CutoutGeometricCount b, Vector3 c, Quaternion d, Vector3 e)
				{
				}

				public static void pas(Material a, cvw.CutoutGeometricCount b, Vector3 c, Quaternion d, Vector3 e)
				{
				}

				public static void epi(Material a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d, float e)
				{
				}

				public static void era(Material a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d, float e)
				{
				}

				public static void czz(Material a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d)
				{
				}

				public static void oow(Material a, float b)
				{
				}

				public static void bgn(Material a, float b)
				{
				}

				public static void mhr(Material a, float b)
				{
				}

				public static void hxd(Material a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d)
				{
				}

				public static void ebg(Material a, bool b)
				{
				}

				public static void ctv(Material a, cvw.CutoutGeometricCount b, Vector3 c, Quaternion d, Vector3 e)
				{
				}

				public static void mub(Material a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d, float e)
				{
				}

				public static void par(Material a, cvw.CutoutGeometricCount b, Vector3 c, float d)
				{
				}

				public static void kup(Material a, bool b)
				{
				}

				public static void paq(Material a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d)
				{
				}

				public static void pau(Material a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d, float e)
				{
				}

				public static void mul(Material a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d, float e)
				{
				}

				public static void fkz(Material a, bool b)
				{
				}

				public static void iqn(Material a, cvw.CutoutGeometricCount b, Vector3 c, Quaternion d, Vector3 e)
				{
				}

				public static void pap(Material a, XYZAxis b, XYZStyle c, XYZSpace d, float e, Vector3 f)
				{
				}

				public static void esn(Material a, cvw.CutoutGeometricCount b, Vector3 c, Quaternion d, Vector3 e)
				{
				}

				public static void jv(Material a, float b)
				{
				}

				public static void gdq(Material a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d)
				{
				}

				public static void paw(Material a, float b)
				{
				}

				public static void exw(Material a, XYZAxis b, XYZStyle c, XYZSpace d, float e, Vector3 f)
				{
				}
			}

			public static class cwa
			{
				public static void paz(cvw.GlobalControlID a, cvw.CutoutGeometricCount b, Vector3 c, float d)
				{
				}

				public static void dis(cvw.GlobalControlID a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d)
				{
				}

				public static void kwi(cvw.GlobalControlID a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d, float e)
				{
				}

				public static void pax(cvw.GlobalControlID a, XYZAxis b, XYZStyle c, XYZSpace d, float e, Vector3 f)
				{
				}

				public static void pbb(cvw.GlobalControlID a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d, float e)
				{
				}

				public static void giu(cvw.GlobalControlID a, bool b)
				{
				}

				public static void hfx(cvw.GlobalControlID a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d, float e)
				{
				}

				public static void pbc(cvw.GlobalControlID a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d, float e)
				{
				}

				public static void gfr(cvw.GlobalControlID a, cvw.CutoutGeometricCount b, Vector3 c, Quaternion d, Vector3 e)
				{
				}

				public static void jau(cvw.GlobalControlID a, float b)
				{
				}

				public static void pay(cvw.GlobalControlID a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d)
				{
				}

				public static void pba(cvw.GlobalControlID a, cvw.CutoutGeometricCount b, Vector3 c, Quaternion d, Vector3 e)
				{
				}

				public static void blc(cvw.GlobalControlID a, bool b)
				{
				}

				public static void etx(cvw.GlobalControlID a, XYZAxis b, XYZStyle c, XYZSpace d, float e, Vector3 f)
				{
				}

				public static void jwr(cvw.GlobalControlID a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d, float e)
				{
				}

				public static void pbe(cvw.GlobalControlID a, float b)
				{
				}

				public static void nvj(cvw.GlobalControlID a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d, float e)
				{
				}

				public static void pbd(cvw.GlobalControlID a, bool b)
				{
				}

				public static void htz(cvw.GlobalControlID a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d, float e)
				{
				}

				public static void doz(cvw.GlobalControlID a, XYZAxis b, XYZStyle c, XYZSpace d, float e, Vector3 f)
				{
				}

				public static void bva(cvw.GlobalControlID a, bool b)
				{
				}

				public static void mj(cvw.GlobalControlID a, XYZAxis b, XYZStyle c, XYZSpace d, float e, Vector3 f)
				{
				}

				public static void kil(cvw.GlobalControlID a, cvw.CutoutGeometricCount b, Vector3 c, Quaternion d, Vector3 e)
				{
				}

				public static void eub(cvw.GlobalControlID a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d, float e)
				{
				}

				public static void myu(cvw.GlobalControlID a, cvw.CutoutGeometricCount b, Vector3 c, Quaternion d, Vector3 e)
				{
				}

				public static void fmz(cvw.GlobalControlID a, float b)
				{
				}

				public static void ncz(cvw.GlobalControlID a, float b)
				{
				}

				public static void mtb(cvw.GlobalControlID a, cvw.CutoutGeometricCount b, Vector3 c, Vector3 d)
				{
				}
			}

			private static cvy[] wrg;

			private static void pbf(Material a, Property b, object c)
			{
			}

			private static void pbg(cvw.GlobalControlID a, Property b, object c)
			{
			}
		}
	}

	[Serializable]
	public class Edge
	{
		[Serializable]
		public class Base
		{
			private class cwb
			{
				public int wrh;

				public int wri;

				public int wrj;

				public int wrk;

				public int wrl;

				public int wrm;

				public cwb(int a)
				{
				}
			}

			public enum Property
			{
				WidthStandard = 0,
				WidthGeometric = 1,
				Shape = 2,
				Color = 3,
				ColorTransparency = 4,
				ColorIntensity = 5
			}

			public enum Shape
			{
				Solid = 0,
				Smooth = 1,
				Smoother = 2
			}

			private static cwb[] wrn;

			[Range(0f, 1f)]
			public float widthCutoutStandard;

			[Range(0f, 1f)]
			public float widthCutoutGeometric;

			public Shape shape;

			[Space(10f)]
			[ColorUsage(false)]
			public Color color;

			[Range(0f, 1f)]
			public float colorTransparency;

			public float colorIntensity;

			public void pbh(List<Material> a)
			{
			}

			public void pbi(Material a)
			{
			}

			public void pbj(cvw.GlobalControlID a)
			{
			}

			public static void pbk(Material a, Property b, object c)
			{
			}

			public static void pbl(cvw.GlobalControlID a, Property b, object c)
			{
			}
		}

		[Serializable]
		public class AdditionalColor
		{
			private class cwc
			{
				public int wro;

				public int wrp;

				public int wrq;

				public int wrr;

				public int wrs;

				public int wrt;

				public int wru;

				public int wrv;

				public int wrw;

				public int wrx;

				public int wry;

				public int wrz;

				public cwc(int a)
				{
				}
			}

			public enum Property
			{
				Map = 0,
				MapTiling = 1,
				MapOffset = 2,
				MapScroll = 3,
				MapReverse = 4,
				MapMipmap = 5,
				PhaseOffset = 6,
				AlphaOffset = 7,
				Color = 8,
				ColorTransparency = 9,
				ColorIntensity = 10,
				ClipInterpolation = 11
			}

			private static cwc[] wsa;

			public Texture2D map;

			public Vector2 mapTiling;

			public Vector2 mapOffset;

			public Vector2 mapScroll;

			public bool mapReverse;

			[Range(0f, 10f)]
			public int mapMipmap;

			public float phaseOffset;

			[Range(-1f, 1f)]
			public float alphaOffset;

			[Space(10f)]
			[ColorUsage(false)]
			public Color color;

			[Range(0f, 1f)]
			public float colorTransparency;

			public float colorIntensity;

			[Space(10f)]
			public bool clipInterpolation;

			public void pbm(List<Material> a)
			{
			}

			public void pbn(Material a)
			{
			}

			public void pbo(cvw.GlobalControlID a)
			{
			}

			public static void pbp(Material a, Property b, object c)
			{
			}

			public static void pbq(cvw.GlobalControlID a, Property b, object c)
			{
			}
		}

		[Serializable]
		public class UVDistortion
		{
			private class cwd
			{
				public int wsb;

				public int wsc;

				public int wsd;

				public int wse;

				public int wsf;

				public cwd(int a)
				{
				}
			}

			public enum Property
			{
				Map = 0,
				MapTiling = 1,
				MapOffset = 2,
				MapScroll = 3,
				Strength = 4
			}

			private static cwd[] wsg;

			public Texture2D map;

			public Vector2 mapTiling;

			public Vector2 mapOffset;

			public Vector2 mapScroll;

			public float strength;

			public void pbr(List<Material> a)
			{
			}

			public void pbs(Material a)
			{
			}

			public void pbt(cvw.GlobalControlID a)
			{
			}

			public static void pbu(Material a, Property b, object c)
			{
			}

			public static void pbv(cvw.GlobalControlID a, Property b, object c)
			{
			}
		}

		[Serializable]
		public class GlobalIllumination
		{
			private class cwe
			{
				public int wsh;

				public cwe(int a)
				{
				}
			}

			private static cwe[] wsi;

			public float metaPassMultiplier;

			public void pbw(List<Material> a)
			{
			}

			public void pbx(Material a)
			{
			}

			public void pby(cvw.GlobalControlID a)
			{
			}

			public static void pbz(Material a, float b)
			{
			}

			public static void pca(cvw.GlobalControlID a, float b)
			{
			}
		}
	}
}
