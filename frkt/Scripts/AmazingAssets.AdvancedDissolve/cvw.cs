using System.Collections.Generic;
using UnityEngine;

public static class cvw
{
	public enum State
	{
		Disabled = 0,
		Enabled = 1
	}

	public enum CutoutStandardSource
	{
		None = 0,
		BaseAlpha = 1,
		CustomMap = 2,
		TwoCustomMaps = 3,
		ThreeCustomMaps = 4,
		UserDefined = 5
	}

	public enum CutoutStandardSourceMapsMappingType
	{
		Default = 0,
		Triplanar = 1,
		ScreenSpace = 2
	}

	public enum CutoutGeometricType
	{
		None = 0,
		XYZAxis = 1,
		Plane = 2,
		Sphere = 3,
		Cube = 4,
		Capsule = 5,
		ConeSmooth = 6
	}

	public enum CutoutGeometricCount
	{
		One = 0,
		Two = 1,
		Three = 2,
		Four = 3
	}

	public enum EdgeBaseSource
	{
		None = 0,
		CutoutStandard = 1,
		CutoutGeometric = 2,
		All = 3
	}

	public enum EdgeAdditionalColorSource
	{
		None = 0,
		BaseColor = 1,
		CustomMap = 2,
		GradientMap = 3,
		GradientColor = 4,
		UserDefined = 5
	}

	public enum EdgeUVDistortionSource
	{
		Default = 0,
		CustomMap = 1
	}

	public enum GlobalControlID
	{
		None = 0,
		One = 1,
		Two = 2,
		Three = 3,
		Four = 4
	}

	private enum EnumID
	{
		State = 0,
		CutoutStandardSource = 1,
		CutoutStandardSourceMapsMappingType = 2,
		CutoutGeometricType = 3,
		CutoutGeometricCount = 4,
		EdgeBaseSource = 5,
		EdgeAdditionalColorSource = 6,
		EdgeUVDistortionSource = 7,
		GlobalControlID = 8
	}

	private static string[][] woy;

	private static int[] woz;

	public static void inu(List<Material> a, CutoutStandardSourceMapsMappingType b, bool c)
	{
	}

	public static string ofy(EdgeAdditionalColorSource a)
	{
		return null;
	}

	public static void dpv(List<Material> a, EdgeAdditionalColorSource b, bool c)
	{
	}

	public static void ozv(List<Material> a, EdgeUVDistortionSource b, bool c)
	{
	}

	public static void ozh(Material a, out CutoutGeometricType b)
	{
		b = default(CutoutGeometricType);
	}

	public static void ozj(List<Material> a, CutoutGeometricType b, bool c)
	{
	}

	public static void ozg(List<Material> a, CutoutStandardSourceMapsMappingType b, bool c)
	{
	}

	public static string pab(CutoutStandardSourceMapsMappingType a)
	{
		return null;
	}

	public static void oyx(Material a)
	{
	}

	public static void ozf(Material a, CutoutStandardSourceMapsMappingType b, bool c)
	{
	}

	public static void jdn(List<Material> a, CutoutGeometricType b, bool c)
	{
	}

	public static void oze(Material a, out CutoutStandardSourceMapsMappingType b)
	{
		b = default(CutoutStandardSourceMapsMappingType);
	}

	public static void ozp(List<Material> a, EdgeBaseSource b, bool c)
	{
	}

	public static string exa(State a)
	{
		return null;
	}

	public static string paf(EdgeAdditionalColorSource a)
	{
		return null;
	}

	public static void euy(Material a)
	{
	}

	public static void ozl(Material a, CutoutGeometricCount b, bool c)
	{
	}

	public static void ozo(Material a, EdgeBaseSource b, bool c)
	{
	}

	public static void ozb(Material a, out CutoutStandardSource b)
	{
		b = default(CutoutStandardSource);
	}

	public static void ozk(Material a, out CutoutGeometricCount b)
	{
		b = default(CutoutGeometricCount);
	}

	public static string ntl(EdgeUVDistortionSource a)
	{
		return null;
	}

	public static void ozq(Material a, out EdgeAdditionalColorSource b)
	{
		b = default(EdgeAdditionalColorSource);
	}

	public static void dyo(Material a)
	{
	}

	public static string pac(CutoutGeometricType a)
	{
		return null;
	}

	public static void nmr(List<Material> a, State b, bool c)
	{
	}

	public static void jzd(Material a, EdgeUVDistortionSource b, bool c)
	{
	}

	public static string icn(CutoutGeometricCount a)
	{
		return null;
	}

	public static void hoa(List<Material> a, CutoutGeometricType b, bool c)
	{
	}

	public static void koj(Material a, out CutoutStandardSource b)
	{
		b = default(CutoutStandardSource);
	}

	public static void ozy(List<Material> a, GlobalControlID b, bool c)
	{
	}

	public static void opf(Material a, out CutoutStandardSourceMapsMappingType b)
	{
		b = default(CutoutStandardSourceMapsMappingType);
	}

	public static void dkh(List<Material> a, CutoutGeometricType b, bool c)
	{
	}

	public static void csf(List<Material> a, GlobalControlID b, bool c)
	{
	}

	public static void oyz(Material a, State b, bool c)
	{
	}

	public static void ozi(Material a, CutoutGeometricType b, bool c)
	{
	}

	public static string pae(EdgeBaseSource a)
	{
		return null;
	}

	public static void ozw(Material a, out GlobalControlID b)
	{
		b = default(GlobalControlID);
	}

	public static void oyy(Material a, out State b)
	{
		b = default(State);
	}

	public static void khd(Material a, out CutoutGeometricType b)
	{
		b = default(CutoutGeometricType);
	}

	private static int paj(Material a, int b)
	{
		return 0;
	}

	public static void ole(List<Material> a, GlobalControlID b, bool c)
	{
	}

	public static void iki(List<Material> a, CutoutStandardSourceMapsMappingType b, bool c)
	{
	}

	public static void okd(Material a, out GlobalControlID b)
	{
		b = default(GlobalControlID);
	}

	public static void cnc(Material a, bool b)
	{
	}

	public static string hod(State a)
	{
		return null;
	}

	public static void ozm(List<Material> a, CutoutGeometricCount b, bool c)
	{
	}

	public static void oyv(Material a, out State b, out CutoutStandardSource c, out CutoutStandardSourceMapsMappingType d, out CutoutGeometricType e, out CutoutGeometricCount f, out EdgeBaseSource g, out EdgeAdditionalColorSource h, out EdgeUVDistortionSource i, out GlobalControlID j)
	{
		b = default(State);
		c = default(CutoutStandardSource);
		d = default(CutoutStandardSourceMapsMappingType);
		e = default(CutoutGeometricType);
		f = default(CutoutGeometricCount);
		g = default(EdgeBaseSource);
		h = default(EdgeAdditionalColorSource);
		i = default(EdgeUVDistortionSource);
		j = default(GlobalControlID);
	}

	public static string bcc(EdgeBaseSource a)
	{
		return null;
	}

	public static void cml(Material a, out CutoutGeometricType b)
	{
		b = default(CutoutGeometricType);
	}

	public static void lve(Material a, CutoutStandardSourceMapsMappingType b, bool c)
	{
	}

	public static void dqp(Material a, State b, bool c)
	{
	}

	public static void iis(Material a, CutoutGeometricType b, bool c)
	{
	}

	public static string paa(CutoutStandardSource a)
	{
		return null;
	}

	public static void obm(List<Material> a, EdgeBaseSource b, bool c)
	{
	}

	public static string bpp(State a)
	{
		return null;
	}

	public static string guc(CutoutGeometricCount a)
	{
		return null;
	}

	public static void jag(Material a, out CutoutStandardSource b)
	{
		b = default(CutoutStandardSource);
	}

	public static void dpa(Material a)
	{
	}

	public static void ozd(List<Material> a, CutoutStandardSource b, bool c)
	{
	}

	public static void hyg(Material a, CutoutStandardSource b, bool c)
	{
	}

	public static void jda(Material a, CutoutGeometricCount b, bool c)
	{
	}

	public static void ozs(List<Material> a, EdgeAdditionalColorSource b, bool c)
	{
	}

	public static void cod(Material a)
	{
	}

	public static void ozc(Material a, CutoutStandardSource b, bool c)
	{
	}

	private static void ecj(Material a, int b, int c, bool d)
	{
	}

	public static void gti(List<Material> a, State b, bool c)
	{
	}

	public static void ozr(Material a, EdgeAdditionalColorSource b, bool c)
	{
	}

	public static void ium(Material a, bool b)
	{
	}

	public static void ozu(Material a, EdgeUVDistortionSource b, bool c)
	{
	}

	public static void iky(List<Material> a, CutoutStandardSource b, bool c)
	{
	}

	public static void qq(List<Material> a, EdgeUVDistortionSource b, bool c)
	{
	}

	public static void oef(Material a, CutoutGeometricType b, bool c)
	{
	}

	public static void dcz(Material a, out CutoutGeometricType b)
	{
		b = default(CutoutGeometricType);
	}

	public static string pag(EdgeUVDistortionSource a)
	{
		return null;
	}

	public static void nkb(Material a, CutoutGeometricType b, bool c)
	{
	}

	public static void ozn(Material a, out EdgeBaseSource b)
	{
		b = default(EdgeBaseSource);
	}

	public static string cpe(EdgeAdditionalColorSource a)
	{
		return null;
	}

	public static void iyy(Material a, CutoutGeometricType b, bool c)
	{
	}

	public static string pah(GlobalControlID a)
	{
		return null;
	}

	public static string gen(EdgeAdditionalColorSource a)
	{
		return null;
	}

	public static void eic(Material a, out CutoutStandardSourceMapsMappingType b)
	{
		b = default(CutoutStandardSourceMapsMappingType);
	}

	public static void jdk(Material a, CutoutGeometricCount b, bool c)
	{
	}

	public static void dqv(Material a, CutoutGeometricCount b, bool c)
	{
	}

	public static void nqv(Material a, CutoutStandardSource b, bool c)
	{
	}

	public static void lgi(List<Material> a, EdgeBaseSource b, bool c)
	{
	}

	public static void laj(List<Material> a, CutoutStandardSource b, bool c)
	{
	}

	public static string cft(EdgeAdditionalColorSource a)
	{
		return null;
	}

	public static void jyw(List<Material> a, EdgeAdditionalColorSource b, bool c)
	{
	}

	public static string bgr(EdgeUVDistortionSource a)
	{
		return null;
	}

	public static void bof(List<Material> a, EdgeUVDistortionSource b, bool c)
	{
	}

	public static string est(CutoutStandardSource a)
	{
		return null;
	}

	public static string pad(CutoutGeometricCount a)
	{
		return null;
	}

	private static void pai(Material a, int b, int c, bool d)
	{
	}

	public static void hr(Material a, out State b, out CutoutStandardSource c, out CutoutStandardSourceMapsMappingType d, out CutoutGeometricType e, out CutoutGeometricCount f, out EdgeBaseSource g, out EdgeAdditionalColorSource h, out EdgeUVDistortionSource i, out GlobalControlID j)
	{
		b = default(State);
		c = default(CutoutStandardSource);
		d = default(CutoutStandardSourceMapsMappingType);
		e = default(CutoutGeometricType);
		f = default(CutoutGeometricCount);
		g = default(EdgeBaseSource);
		h = default(EdgeAdditionalColorSource);
		i = default(EdgeUVDistortionSource);
		j = default(GlobalControlID);
	}

	public static void ieo(Material a, GlobalControlID b, bool c)
	{
	}

	public static void dvr(List<Material> a, CutoutGeometricType b, bool c)
	{
	}

	public static void oza(List<Material> a, State b, bool c)
	{
	}

	public static void otj(Material a, GlobalControlID b, bool c)
	{
	}

	public static void ixu(Material a, EdgeBaseSource b, bool c)
	{
	}

	public static void fgg(List<Material> a, GlobalControlID b, bool c)
	{
	}

	private static void lho(Material a, int b, int c, bool d)
	{
	}

	public static void hlk(List<Material> a, EdgeUVDistortionSource b, bool c)
	{
	}

	public static void lcm(Material a, CutoutStandardSource b, bool c)
	{
	}

	public static string irj(EdgeBaseSource a)
	{
		return null;
	}

	public static void lkt(Material a, bool b)
	{
	}

	public static string irw(CutoutStandardSource a)
	{
		return null;
	}

	public static void kvz(List<Material> a, State b, bool c)
	{
	}

	public static void ozt(Material a, out EdgeUVDistortionSource b)
	{
		b = default(EdgeUVDistortionSource);
	}

	public static void g(Material a, CutoutStandardSource b, bool c)
	{
	}

	public static void gnw(List<Material> a, EdgeUVDistortionSource b, bool c)
	{
	}

	public static void zp(Material a, CutoutGeometricCount b, bool c)
	{
	}

	public static void hqd(Material a, GlobalControlID b, bool c)
	{
	}

	public static string ozz(State a)
	{
		return null;
	}

	public static void fxf(List<Material> a, State b, bool c)
	{
	}

	public static void epi(Material a, GlobalControlID b, bool c)
	{
	}

	private static void eim(Material a, int b, int c, bool d)
	{
	}

	public static void oyw(Material a, bool b)
	{
	}

	public static void ksy(List<Material> a, CutoutStandardSourceMapsMappingType b, bool c)
	{
	}

	public static string clr(EdgeBaseSource a)
	{
		return null;
	}

	private static void zb(Material a, int b, int c, bool d)
	{
	}

	public static string izu(CutoutStandardSource a)
	{
		return null;
	}

	public static void ozx(Material a, GlobalControlID b, bool c)
	{
	}
}
