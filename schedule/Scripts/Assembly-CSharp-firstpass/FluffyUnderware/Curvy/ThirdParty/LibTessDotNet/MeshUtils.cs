using System.Collections.Generic;

namespace FluffyUnderware.Curvy.ThirdParty.LibTessDotNet
{
	internal static class MeshUtils
	{
		public abstract class Pooled<T> where T : Pooled<T>, new()
		{
			private static Stack<T> _stack;

			public abstract void Reset();

			public virtual void OnFree()
			{
			}

			public static T Create()
			{
				return null;
			}

			public void Free()
			{
			}
		}

		public class Vertex : Pooled<Vertex>
		{
			internal Vertex _prev;

			internal Vertex _next;

			internal Edge _anEdge;

			internal Vec3 _coords;

			internal float _s;

			internal float _t;

			internal PQHandle _pqHandle;

			internal int _n;

			internal object _data;

			public override void Reset()
			{
			}
		}

		public class Face : Pooled<Face>
		{
			internal Face _prev;

			internal Face _next;

			internal Edge _anEdge;

			internal Face _trail;

			internal int _n;

			internal bool _marked;

			internal bool _inside;

			internal int VertsCount => 0;

			public override void Reset()
			{
			}
		}

		public struct EdgePair
		{
			internal Edge _e;

			internal Edge _eSym;

			public static EdgePair Create()
			{
				return default(EdgePair);
			}

			public void Reset()
			{
			}
		}

		public class Edge : Pooled<Edge>
		{
			internal EdgePair _pair;

			internal Edge _next;

			internal Edge _Sym;

			internal Edge _Onext;

			internal Edge _Lnext;

			internal Vertex _Org;

			internal Face _Lface;

			internal Tess.ActiveRegion _activeRegion;

			internal int _winding;

			internal Face _Rface
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			internal Vertex _Dst
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			internal Edge _Oprev
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			internal Edge _Lprev
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			internal Edge _Dprev
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			internal Edge _Rprev
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			internal Edge _Dnext
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			internal Edge _Rnext
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			internal static void EnsureFirst(ref Edge e)
			{
			}

			public override void Reset()
			{
			}
		}

		public const int Undef = -1;

		public static Edge MakeEdge(Edge eNext)
		{
			return null;
		}

		public static void Splice(Edge a, Edge b)
		{
		}

		public static void MakeVertex(Edge eOrig, Vertex vNext)
		{
		}

		public static void MakeFace(Edge eOrig, Face fNext)
		{
		}

		public static void KillEdge(Edge eDel)
		{
		}

		public static void KillVertex(Vertex vDel, Vertex newOrg)
		{
		}

		public static void KillFace(Face fDel, Face newLFace)
		{
		}

		public static float FaceArea(Face f)
		{
			return 0f;
		}
	}
}
