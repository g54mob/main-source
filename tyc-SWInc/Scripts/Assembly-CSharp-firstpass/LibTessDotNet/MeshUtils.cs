namespace LibTessDotNet
{
	internal static class MeshUtils
	{
		internal class Vertex : Pooled<Vertex>
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

			public void Init(IPool pool)
			{
			}

			public void Reset(IPool pool)
			{
				_prev = (_next = null);
				_anEdge = null;
				_coords = Vec3.Zero;
				_s = 0f;
				_t = 0f;
				_pqHandle = default(PQHandle);
				_n = 0;
				_data = null;
			}
		}

		internal class Face : Pooled<Face>
		{
			internal Face _prev;

			internal Face _next;

			internal Edge _anEdge;

			internal Face _trail;

			internal int _n;

			internal bool _marked;

			internal bool _inside;

			internal int VertsCount
			{
				get
				{
					int num = 0;
					Edge edge = _anEdge;
					do
					{
						num++;
						edge = edge._Lnext;
					}
					while (edge != _anEdge);
					return num;
				}
			}

			public void Init(IPool pool)
			{
			}

			public void Reset(IPool pool)
			{
				_prev = (_next = null);
				_anEdge = null;
				_trail = null;
				_n = 0;
				_marked = false;
				_inside = false;
			}
		}

		internal struct EdgePair
		{
			internal Edge _e;

			internal Edge _eSym;

			public static EdgePair Create(IPool pool)
			{
				Edge edge = pool.Get<Edge>();
				Edge edge2 = pool.Get<Edge>();
				edge._pair._e = edge;
				edge._pair._eSym = edge2;
				edge2._pair = edge._pair;
				return edge._pair;
			}

			public void Reset(IPool pool)
			{
				_e = (_eSym = null);
			}
		}

		internal class Edge : Pooled<Edge>
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

			internal bool _mark;

			internal Face _Rface
			{
				get
				{
					return _Sym._Lface;
				}
				set
				{
					_Sym._Lface = value;
				}
			}

			internal Vertex _Dst
			{
				get
				{
					return _Sym._Org;
				}
				set
				{
					_Sym._Org = value;
				}
			}

			internal Edge _Oprev
			{
				get
				{
					return _Sym._Lnext;
				}
				set
				{
					_Sym._Lnext = value;
				}
			}

			internal Edge _Lprev
			{
				get
				{
					return _Onext._Sym;
				}
				set
				{
					_Onext._Sym = value;
				}
			}

			internal Edge _Dprev
			{
				get
				{
					return _Lnext._Sym;
				}
				set
				{
					_Lnext._Sym = value;
				}
			}

			internal Edge _Rprev
			{
				get
				{
					return _Sym._Onext;
				}
				set
				{
					_Sym._Onext = value;
				}
			}

			internal Edge _Dnext
			{
				get
				{
					return _Rprev._Sym;
				}
				set
				{
					_Rprev._Sym = value;
				}
			}

			internal Edge _Rnext
			{
				get
				{
					return _Oprev._Sym;
				}
				set
				{
					_Oprev._Sym = value;
				}
			}

			internal static void EnsureFirst(ref Edge e)
			{
				if (e == e._pair._eSym)
				{
					e = e._Sym;
				}
			}

			public void Init(IPool pool)
			{
			}

			public void Reset(IPool pool)
			{
				_pair.Reset(pool);
				_next = (_Sym = (_Onext = (_Lnext = null)));
				_Org = null;
				_Lface = null;
				_activeRegion = null;
				_winding = 0;
			}
		}

		public static void Splice(Edge a, Edge b)
		{
			Edge onext = a._Onext;
			Edge onext2 = b._Onext;
			onext._Sym._Lnext = b;
			onext2._Sym._Lnext = a;
			a._Onext = onext2;
			b._Onext = onext;
		}

		public static void MakeVertex(IPool pool, Edge eOrig, Vertex vNext)
		{
			Vertex vertex = pool.Get<Vertex>();
			(vertex._prev = vNext._prev)._next = vertex;
			vertex._next = vNext;
			vNext._prev = vertex;
			vertex._anEdge = eOrig;
			Edge edge = eOrig;
			do
			{
				edge._Org = vertex;
				edge = edge._Onext;
			}
			while (edge != eOrig);
		}

		public static void MakeFace(IPool pool, Edge eOrig, Face fNext)
		{
			Face face = pool.Get<Face>();
			(face._prev = fNext._prev)._next = face;
			face._next = fNext;
			fNext._prev = face;
			face._anEdge = eOrig;
			face._trail = null;
			face._marked = false;
			face._inside = fNext._inside;
			Edge edge = eOrig;
			do
			{
				edge._Lface = face;
				edge = edge._Lnext;
			}
			while (edge != eOrig);
		}

		public static Edge MakeEdge(IPool pool, Edge eNext)
		{
			EdgePair edgePair = EdgePair.Create(pool);
			Edge e = edgePair._e;
			Edge eSym = edgePair._eSym;
			Edge.EnsureFirst(ref eNext);
			(eSym._next = eNext._Sym._next)._Sym._next = e;
			e._next = eNext;
			eNext._Sym._next = eSym;
			e._Sym = eSym;
			e._Onext = e;
			e._Lnext = eSym;
			e._Org = null;
			e._Lface = null;
			e._winding = 0;
			e._activeRegion = null;
			eSym._Sym = e;
			eSym._Onext = eSym;
			eSym._Lnext = e;
			eSym._Org = null;
			eSym._Lface = null;
			eSym._winding = 0;
			eSym._activeRegion = null;
			eSym._mark = false;
			return e;
		}

		public static void KillEdge(IPool pool, Edge eDel)
		{
			Edge.EnsureFirst(ref eDel);
			Edge next = eDel._next;
			Edge next2 = eDel._Sym._next;
			next._Sym._next = next2;
			next2._Sym._next = next;
			pool.Return(eDel._Sym);
			pool.Return(eDel);
		}

		public static void KillVertex(IPool pool, Vertex vDel, Vertex newOrg)
		{
			Edge anEdge = vDel._anEdge;
			Edge edge = anEdge;
			do
			{
				edge._Org = newOrg;
				edge = edge._Onext;
			}
			while (edge != anEdge);
			Vertex prev = vDel._prev;
			Vertex next = vDel._next;
			next._prev = prev;
			prev._next = next;
			pool.Return(vDel);
		}

		public static void KillFace(IPool pool, Face fDel, Face newLFace)
		{
			Edge anEdge = fDel._anEdge;
			Edge edge = anEdge;
			do
			{
				edge._Lface = newLFace;
				edge = edge._Lnext;
			}
			while (edge != anEdge);
			Face prev = fDel._prev;
			Face next = fDel._next;
			next._prev = prev;
			prev._next = next;
			pool.Return(fDel);
		}

		public static float FaceArea(Face f)
		{
			float num = 0f;
			Edge edge = f._anEdge;
			do
			{
				num += (edge._Org._s - edge._Dst._s) * (edge._Org._t + edge._Dst._t);
				edge = edge._Lnext;
			}
			while (edge != f._anEdge);
			return num;
		}
	}
}
