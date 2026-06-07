using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public static class fo
{
	public enum TimerTimeType
	{
		DeltaTime = 0,
		UnscaledDeltaTime = 1
	}

	private sealed class fh : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pxi;

		private object pxj;

		public IEnumerator pxk;

		public Action pxl;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public fh(int a)
		{
		}

		[DebuggerHidden]
		private void dyn()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dyn
			this.dyn();
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private void dyp()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dyp
			this.dyp();
		}
	}

	private sealed class fi
	{
		public int pxm;

		public Action pxn;

		internal void dyu()
		{
		}

		internal void ell()
		{
		}

		internal void cbz()
		{
		}

		internal void kyq()
		{
		}
	}

	private sealed class fj : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pxo;

		private object pxp;

		public TimerTimeType pxq;

		public float pxr;

		public float pxs;

		public Action<float> pxt;

		public Action pxu;

		private Func<float> pxv;

		private float pxw;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public fj(int a)
		{
		}

		[DebuggerHidden]
		private void dyv()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dyv
			this.dyv();
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private void dyx()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dyx
			this.dyx();
		}
	}

	private sealed class fk : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pxx;

		private object pxy;

		public TimerTimeType pxz;

		public float pya;

		public float pyb;

		public Action<float> pyc;

		public Action pyd;

		private Func<float> pye;

		private float pyf;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public fk(int a)
		{
		}

		[DebuggerHidden]
		private void dyz()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dyz
			this.dyz();
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private void dzb()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dzb
			this.dzb();
		}
	}

	private sealed class fl : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pyg;

		private object pyh;

		public hv pyi;

		public float pyj;

		public float pyk;

		private float pyl;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public fl(int a)
		{
		}

		[DebuggerHidden]
		private void dzd()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dzd
			this.dzd();
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private void dzf()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dzf
			this.dzf();
		}
	}

	private sealed class fm : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pym;

		private object pyn;

		public List<IEnumerator> pyo;

		public MonoBehaviour pyp;

		public List<Coroutine> pyq;

		private fi pyr;

		private int pys;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public fm(int a)
		{
		}

		[DebuggerHidden]
		private void dzh()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dzh
			this.dzh();
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private void dzj()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dzj
			this.dzj();
		}
	}

	private sealed class fn : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int pyt;

		private object pyu;

		public float pyv;

		private float pyw;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public fn(int a)
		{
		}

		[DebuggerHidden]
		private void dzl()
		{
		}

		void IDisposable.Dispose()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dzl
			this.dzl();
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		private void dzn()
		{
		}

		void IEnumerator.Reset()
		{
			//ILSpy generated this explicit interface implementation from .override directive in dzn
			this.dzn();
		}
	}

	private const string pyx = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

	public static string dzp(int a)
	{
		return null;
	}

	public static bool guo(float3 a, float3 b, float c = 0.0001f)
	{
		return false;
	}

	public static bool ojl(Vector3 a, Vector3 b, float c = 0.0001f)
	{
		return false;
	}

	public static void ecg(ParticleSystem a, bool b)
	{
	}

	public static void dzu(Transform a)
	{
	}

	public static Quaternion niz(float a)
	{
		return default(Quaternion);
	}

	public static bool mji(float a, float b, float c = 0.0001f)
	{
		return false;
	}

	public static float bht(Quaternion a)
	{
		return 0f;
	}

	public static bool krp(Vector2Int a, int b, int c)
	{
		return false;
	}

	public static bool eab(int a, int b, int c, int d)
	{
		return false;
	}

	public static void dzx(Transform a)
	{
	}

	public static Vector3 ffe(Vector3 a)
	{
		return default(Vector3);
	}

	public static Quaternion hlr(Quaternion a, float b, float c)
	{
		return default(Quaternion);
	}

	public static float dds(int3 a, float b, float c)
	{
		return 0f;
	}

	public static float gvh(float a, float b)
	{
		return 0f;
	}

	public static bool eaf(int a, int b, int c, int d, int e, int f)
	{
		return false;
	}

	public static int @in(int3 a)
	{
		return 0;
	}

	public static bool eag<d>(int a, int b, int c, d[,,] d)
	{
		return false;
	}

	public static int3 jas(Vector3Int a)
	{
		return default(int3);
	}

	[IteratorStateMachine(typeof(fn))]
	public static IEnumerator ece(float a)
	{
		return null;
	}

	public static void fuz(AudioSource a)
	{
	}

	public static bool eak<g>(g[] a)
	{
		return false;
	}

	public static bool eah(Vector3Int a, int b, int c, int d)
	{
		return false;
	}

	public static float ebt(Quaternion a)
	{
		return 0f;
	}

	public static int3 iis(IEnumerable<int3> a, int3 b)
	{
		return default(int3);
	}

	public static Vector3Int eao(int3 a)
	{
		return default(Vector3Int);
	}

	public static float lkw(Vector2 a, float b, float c)
	{
		return 0f;
	}

	public static int eaq(int3 a)
	{
		return 0;
	}

	public static int3 ear(IEnumerable<int3> a, int3 b)
	{
		return default(int3);
	}

	public static void ecd(MonoBehaviour a, ref Coroutine b)
	{
	}

	public static float eat(float a, float b)
	{
		return 0f;
	}

	public static float eau(float a, float b)
	{
		return 0f;
	}

	public static bool dzt(this GameObject a)
	{
		return false;
	}

	public static bool dzz(int a, int b)
	{
		return false;
	}

	public static IEnumerator ebz(float a, float b, Action<float> c, bool d = true, Action e = null, TimerTimeType f = TimerTimeType.DeltaTime)
	{
		return null;
	}

	public static int kzr(int3 a)
	{
		return 0;
	}

	public static List<GameObject> dzs(GameObject a)
	{
		return null;
	}

	public static bool eav(float a, float b, float c = 0.0001f)
	{
		return false;
	}

	public static Vector3 ngq(Vector3 a)
	{
		return default(Vector3);
	}

	public static bool jvw(float a, float b, float c = 0.0001f)
	{
		return false;
	}

	public static Quaternion ebm(Quaternion a, float b)
	{
		return default(Quaternion);
	}

	public static bool eay(float a, float b, float c = 0.0001f)
	{
		return false;
	}

	public static bool ead(Vector2Int a, int b, int c)
	{
		return false;
	}

	public static float iwp(Vector3 a, Vector3 b)
	{
		return 0f;
	}

	public static Quaternion nev(Quaternion a, float b, float c)
	{
		return default(Quaternion);
	}

	public static bool ebi(Vector3 a, Vector3 b, float c = 0.0001f)
	{
		return false;
	}

	[IteratorStateMachine(typeof(fj))]
	public static IEnumerator ecb(float a, float b, Action<float> c, Action d = null, TimerTimeType e = TimerTimeType.DeltaTime)
	{
		return null;
	}

	public static Vector3Int kms(int3 a)
	{
		return default(Vector3Int);
	}

	public static float lmw(Quaternion a)
	{
		return 0f;
	}

	public static Quaternion cau(float a)
	{
		return default(Quaternion);
	}

	public static float coy(Quaternion a)
	{
		return 0f;
	}

	public static float ohx(float a)
	{
		return 0f;
	}

	public static float hgx(float a, float b, float c)
	{
		return 0f;
	}

	public static bool eeb(Vector2Int a, int b, int c)
	{
		return false;
	}

	public static float jng(Quaternion a)
	{
		return 0f;
	}

	public static Quaternion ebs(float a)
	{
		return default(Quaternion);
	}

	public static Quaternion myy(Quaternion a, float b, float c)
	{
		return default(Quaternion);
	}

	public static float bbu(float a, float b, float c)
	{
		return 0f;
	}

	[IteratorStateMachine(typeof(fh))]
	[CompilerGenerated]
	internal static IEnumerator ecr(IEnumerator a, Action b)
	{
		return null;
	}

	public static Vector3 ebl(Vector3 a, Vector3 b, ref Vector3 c, float d, float e)
	{
		return default(Vector3);
	}

	public static void hwn(Transform a)
	{
	}

	public static float mxq(float a, float b)
	{
		return 0f;
	}

	public static float oqz(Quaternion a)
	{
		return 0f;
	}

	public static MonoBehaviour[] dzr(GameObject a)
	{
		return null;
	}

	public static bool bed(Vector3 a, Vector3 b, float c = 0.0001f)
	{
		return false;
	}

	public static float eas(float a)
	{
		return 0f;
	}

	public static float bpz(Ease a, float b)
	{
		return 0f;
	}

	public static Vector3 kpd(Vector3 a)
	{
		return default(Vector3);
	}

	public static bool eac<b>(int a, int b, b[,] c)
	{
		return false;
	}

	public static bool dxl(float3 a, float3 b, float c = 0.0001f)
	{
		return false;
	}

	public static float btb(float a, float b, float c)
	{
		return 0f;
	}

	public static float lgo(float a, float b, float c)
	{
		return 0f;
	}

	public static void tp(AudioSource a)
	{
	}

	public static void eck<T>(IEnumerable<ig<T>> a) where T : struct, IEquatable<T>
	{
	}

	[IteratorStateMachine(typeof(fl))]
	public static IEnumerator ecf(hv a, float b, float c)
	{
		return null;
	}

	public static HashSet<T> ecm<T>(NativeList<T> a) where T : struct
	{
		return null;
	}

	public static void jsn(ParticleSystem a, bool b)
	{
	}

	public static void eco<j>(ICollection<j> a, IEnumerable<j> b)
	{
	}

	public static float ebv(Quaternion a)
	{
		return 0f;
	}

	public static float jlu(float a, float b, float c)
	{
		return 0f;
	}

	public static float jxg(Quaternion a)
	{
		return 0f;
	}

	public static void nri(Transform a)
	{
	}

	public static float hfi(Vector2 a, float b, float c)
	{
		return 0f;
	}

	public static void ecl<T>(IEnumerable<NativeList<T>> a) where T : struct, IEquatable<T>
	{
	}

	public static float ebf(Vector3 a, Vector3 b)
	{
		return 0f;
	}

	public static MonoBehaviour[] dok(GameObject a)
	{
		return null;
	}

	public static MonoBehaviour[] bxg(GameObject a)
	{
		return null;
	}

	public static void dzw(Transform a)
	{
	}

	public static void itj(Transform a)
	{
	}

	public static void ibf(ParticleSystem a, bool b)
	{
	}

	public static MonoBehaviour[] ors(GameObject a)
	{
		return null;
	}

	public static float ebe(Vector3 a, Vector3 b)
	{
		return 0f;
	}

	public static int3 eyu(Vector3Int a)
	{
		return default(int3);
	}

	public static float dch(Quaternion a)
	{
		return 0f;
	}

	public static void fdd(Transform a)
	{
	}

	public static NativeHashSet<T> ech<T>(NativeList<T> a, Allocator b) where T : struct, IEquatable<T>
	{
		return default(NativeHashSet<T>);
	}

	public static bool ota(Vector3 a, Vector3 b, float c = 0.0001f)
	{
		return false;
	}

	public static void jrv(Transform a)
	{
	}

	public static bool nza(Vector3Int a, int b, int c, int d)
	{
		return false;
	}

	public static List<Material> ipr(params MeshRenderer[] meshRenderers)
	{
		return null;
	}

	public static bool nge(float a, float b, float c = 0.0001f)
	{
		return false;
	}

	public static MonoBehaviour[] ktb(GameObject a)
	{
		return null;
	}

	public static string ghm(int a)
	{
		return null;
	}

	public static float lpj(Quaternion a)
	{
		return 0f;
	}

	public static void eci<TKey, TValue>(NativeHashMap<TKey, TValue>[] a) where TKey : struct, IEquatable<TKey> where TValue : struct
	{
	}

	public static bool ngi(int a, int b, int c, int d, int e, int f)
	{
		return false;
	}

	public static Vector3 ebg(Vector3 a, float b)
	{
		return default(Vector3);
	}

	public static bool kkg(Vector3Int a, int b, int c, int d)
	{
		return false;
	}

	public static Quaternion one(float a)
	{
		return default(Quaternion);
	}

	public static float dap(float a, float b, float c)
	{
		return 0f;
	}

	public static void ecp(AudioSource a)
	{
	}

	public static float kjk(Ease a, float b)
	{
		return 0f;
	}

	public static float mow(float a, float b)
	{
		return 0f;
	}

	public static int3 hnr(Vector3Int a)
	{
		return default(int3);
	}

	public static Quaternion cqh(float a)
	{
		return default(Quaternion);
	}

	public static float eaz(Vector2 a, float b, float c)
	{
		return 0f;
	}

	public static Quaternion ebx(float a)
	{
		return default(Quaternion);
	}

	public static bool ngf(Vector3Int a, int b, int c, int d)
	{
		return false;
	}

	public static void chp(Transform a)
	{
	}

	public static bool dgz(float a, float b, float c = 0.0001f)
	{
		return false;
	}

	public static bool ojf(int a, int b)
	{
		return false;
	}

	public static float ebw(Quaternion a)
	{
		return 0f;
	}

	public static Vector3 eap(int3 a)
	{
		return default(Vector3);
	}

	public static List<Material> dzy(params MeshRenderer[] meshRenderers)
	{
		return null;
	}

	public static float jfk(Vector3 a, Vector3 b)
	{
		return 0f;
	}

	public static float djr(float a, float b)
	{
		return 0f;
	}

	public static Quaternion ebn(Quaternion a, float b, float c)
	{
		return default(Quaternion);
	}

	public static float btq(float a, float b)
	{
		return 0f;
	}

	public static void ecn<i>(HashSet<i> a, IEnumerable<i> b)
	{
	}

	public static void mvm(Transform a)
	{
	}

	public static List<GameObject> jro(GameObject a)
	{
		return null;
	}

	public static IEnumerator jer(float a, float b, Action<float> c, bool d = true, Action e = null, TimerTimeType f = TimerTimeType.DeltaTime)
	{
		return null;
	}

	public static Quaternion mjn(float a)
	{
		return default(Quaternion);
	}

	public static void hpw(Transform a)
	{
	}

	public static float ofr(int3 a, float b, float c)
	{
		return 0f;
	}

	public static List<Collider> ebd(Vector3 a, Vector3 b, Quaternion c, int d = 10, int e = -5)
	{
		return null;
	}

	public static float bxd(Vector3 a, Vector3 b)
	{
		return 0f;
	}

	public static float ebc(float a, float b, float c)
	{
		return 0f;
	}

	public static bool kdm(Vector2Int a, int b, int c)
	{
		return false;
	}

	public static bool eaw(float3 a, float3 b, float c = 0.0001f)
	{
		return false;
	}

	public static List<Collider> cqx(Vector3 a, Vector3 b, Quaternion c, int d = 10, int e = -5)
	{
		return null;
	}

	public static List<Material> kfv(params MeshRenderer[] meshRenderers)
	{
		return null;
	}

	public static float ltf(Vector3 a, Vector3 b)
	{
		return 0f;
	}

	public static float ebb(float a, float b, float c)
	{
		return 0f;
	}

	public static Quaternion ebp(float a)
	{
		return default(Quaternion);
	}

	public static float not(Quaternion a)
	{
		return 0f;
	}

	public static string ggs(int a)
	{
		return null;
	}

	public static bool gmz(Vector3 a, Vector3 b, float c = 0.0001f)
	{
		return false;
	}

	public static void ers(Transform a)
	{
	}

	public static Quaternion ebq(Quaternion a)
	{
		return default(Quaternion);
	}

	public static bool eae<c>(Vector2Int a, c[,] b)
	{
		return false;
	}

	public static Quaternion ivv(float a)
	{
		return default(Quaternion);
	}

	public static float ose(Vector3 a, Vector3 b)
	{
		return 0f;
	}

	public static h[] eal<h>(params h[][] arraysToCombine)
	{
		return null;
	}

	public static bool ebh(Vector3 a)
	{
		return false;
	}

	public static Vector3 ebk(Vector3 a)
	{
		return default(Vector3);
	}

	public static float vi(Quaternion a)
	{
		return 0f;
	}

	public static Vector3 chu(Vector3 a)
	{
		return default(Vector3);
	}

	public static Quaternion kct(float a)
	{
		return default(Quaternion);
	}

	public static Quaternion izy(Quaternion a, float b)
	{
		return default(Quaternion);
	}

	public static Vector3Int noh(int3 a)
	{
		return default(Vector3Int);
	}

	public static int3 ean(Vector3Int a)
	{
		return default(int3);
	}

	public static Quaternion fwj(Quaternion a, float b, float c)
	{
		return default(Quaternion);
	}

	public static Vector3Int ggr(int3 a)
	{
		return default(Vector3Int);
	}

	public static float mep(Quaternion a)
	{
		return 0f;
	}

	public static float ebu(Quaternion a)
	{
		return 0f;
	}

	public static string dzq(string a, string b, bool c = true)
	{
		return null;
	}

	public static float ebr(Quaternion a)
	{
		return 0f;
	}

	public static float ebo(Quaternion a)
	{
		return 0f;
	}

	[IteratorStateMachine(typeof(fm))]
	public static IEnumerator eby(MonoBehaviour a, List<IEnumerator> b, List<Coroutine> c)
	{
		return null;
	}

	public static Quaternion cuj(Quaternion a)
	{
		return default(Quaternion);
	}

	public static float lnf(Quaternion a)
	{
		return 0f;
	}

	public static bool dz(int a, int b)
	{
		return false;
	}

	[CompilerGenerated]
	internal static void ecq(GameObject a, List<MonoBehaviour> b)
	{
	}

	public static Quaternion jgb(float a)
	{
		return default(Quaternion);
	}

	[IteratorStateMachine(typeof(fk))]
	public static IEnumerator eca(float a, float b, Action<float> c, Action d = null, TimerTimeType e = TimerTimeType.DeltaTime)
	{
		return null;
	}

	public static float cce(float a)
	{
		return 0f;
	}

	public static Vector3 ebj(Vector3 a, float b)
	{
		return default(Vector3);
	}

	public static Quaternion oqu(float a)
	{
		return default(Quaternion);
	}

	public static float lqu(Quaternion a)
	{
		return 0f;
	}

	public static bool eaa<a>(int a, a[] b)
	{
		return false;
	}

	public static void coo(Transform a)
	{
	}

	public static void efo(ParticleSystem a, bool b)
	{
	}

	public static float ibj(int3 a, float b, float c)
	{
		return 0f;
	}

	public static bool jio(Vector3Int a, int b, int c, int d)
	{
		return false;
	}

	public static bool eax(float a, float b, float c = 0.0001f)
	{
		return false;
	}

	private static Func<float> ecc(TimerTimeType a)
	{
		return null;
	}

	public static void dzv(Transform a)
	{
	}

	public static float eba(int3 a, float b, float c)
	{
		return 0f;
	}

	public static bool eai<e>(Vector3Int a, e[,,] b)
	{
		return false;
	}

	public static void ecj<T>(IEnumerable<NativeHashSet<T>> a) where T : struct, IEquatable<T>
	{
	}

	public static bool eaj<f>(f[] a)
	{
		return false;
	}

	public static float eam(Ease a, float b)
	{
		return 0f;
	}
}
