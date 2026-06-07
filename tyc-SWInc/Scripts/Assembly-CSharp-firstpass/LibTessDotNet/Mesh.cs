using System.Diagnostics;

namespace LibTessDotNet
{
	internal class Mesh : Pooled<Mesh>
	{
		internal MeshUtils.Vertex _vHead;

		internal MeshUtils.Face _fHead;

		internal MeshUtils.Edge _eHead;

		internal MeshUtils.Edge _eHeadSym;

		public void Init(IPool pool)
		{
			MeshUtils.Vertex vertex = (_vHead = pool.Get<MeshUtils.Vertex>());
			MeshUtils.Face face = (_fHead = pool.Get<MeshUtils.Face>());
			MeshUtils.EdgePair edgePair = MeshUtils.EdgePair.Create(pool);
			MeshUtils.Edge edge = (_eHead = edgePair._e);
			MeshUtils.Edge edge2 = (_eHeadSym = edgePair._eSym);
			vertex._next = (vertex._prev = vertex);
			vertex._anEdge = null;
			face._next = (face._prev = face);
			face._anEdge = null;
			face._trail = null;
			face._marked = false;
			face._inside = false;
			edge._next = edge;
			edge._Sym = edge2;
			edge._Onext = null;
			edge._Lnext = null;
			edge._Org = null;
			edge._Lface = null;
			edge._winding = 0;
			edge._activeRegion = null;
			edge2._next = edge2;
			edge2._Sym = edge;
			edge2._Onext = null;
			edge2._Lnext = null;
			edge2._Org = null;
			edge2._Lface = null;
			edge2._winding = 0;
			edge2._activeRegion = null;
		}

		public void Reset(IPool pool)
		{
			MeshUtils.Face face = _fHead;
			MeshUtils.Face fHead = _fHead;
			while (face._next != null)
			{
				fHead = face._next;
				pool.Return(face);
				face = fHead;
			}
			MeshUtils.Vertex vertex = _vHead;
			MeshUtils.Vertex vHead = _vHead;
			while (vertex._next != null)
			{
				vHead = vertex._next;
				pool.Return(vertex);
				vertex = vHead;
			}
			MeshUtils.Edge edge = _eHead;
			MeshUtils.Edge eHead = _eHead;
			while (edge._next != null)
			{
				eHead = edge._next;
				pool.Return(edge._Sym);
				pool.Return(edge);
				edge = eHead;
			}
			_vHead = null;
			_fHead = null;
			_eHead = (_eHeadSym = null);
		}

		public MeshUtils.Edge MakeEdge(IPool pool)
		{
			MeshUtils.Edge edge = MeshUtils.MakeEdge(pool, _eHead);
			MeshUtils.MakeVertex(pool, edge, _vHead);
			MeshUtils.MakeVertex(pool, edge._Sym, _vHead);
			MeshUtils.MakeFace(pool, edge, _fHead);
			return edge;
		}

		public void Splice(IPool pool, MeshUtils.Edge eOrg, MeshUtils.Edge eDst)
		{
			if (eOrg != eDst)
			{
				bool flag = false;
				if (eDst._Org != eOrg._Org)
				{
					flag = true;
					MeshUtils.KillVertex(pool, eDst._Org, eOrg._Org);
				}
				bool flag2 = false;
				if (eDst._Lface != eOrg._Lface)
				{
					flag2 = true;
					MeshUtils.KillFace(pool, eDst._Lface, eOrg._Lface);
				}
				MeshUtils.Splice(eDst, eOrg);
				if (!flag)
				{
					MeshUtils.MakeVertex(pool, eDst, eOrg._Org);
					eOrg._Org._anEdge = eOrg;
				}
				if (!flag2)
				{
					MeshUtils.MakeFace(pool, eDst, eOrg._Lface);
					eOrg._Lface._anEdge = eOrg;
				}
			}
		}

		public void Delete(IPool pool, MeshUtils.Edge eDel)
		{
			MeshUtils.Edge sym = eDel._Sym;
			bool flag = false;
			if (eDel._Lface != eDel._Rface)
			{
				flag = true;
				MeshUtils.KillFace(pool, eDel._Lface, eDel._Rface);
			}
			if (eDel._Onext == eDel)
			{
				MeshUtils.KillVertex(pool, eDel._Org, null);
			}
			else
			{
				eDel._Rface._anEdge = eDel._Oprev;
				eDel._Org._anEdge = eDel._Onext;
				MeshUtils.Splice(eDel, eDel._Oprev);
				if (!flag)
				{
					MeshUtils.MakeFace(pool, eDel, eDel._Lface);
				}
			}
			if (sym._Onext == sym)
			{
				MeshUtils.KillVertex(pool, sym._Org, null);
				MeshUtils.KillFace(pool, sym._Lface, null);
			}
			else
			{
				eDel._Lface._anEdge = sym._Oprev;
				sym._Org._anEdge = sym._Onext;
				MeshUtils.Splice(sym, sym._Oprev);
			}
			MeshUtils.KillEdge(pool, eDel);
		}

		public MeshUtils.Edge AddEdgeVertex(IPool pool, MeshUtils.Edge eOrg)
		{
			MeshUtils.Edge edge = MeshUtils.MakeEdge(pool, eOrg);
			MeshUtils.Edge sym = edge._Sym;
			MeshUtils.Splice(edge, eOrg._Lnext);
			edge._Org = eOrg._Dst;
			MeshUtils.MakeVertex(pool, sym, edge._Org);
			edge._Lface = (sym._Lface = eOrg._Lface);
			return edge;
		}

		public MeshUtils.Edge SplitEdge(IPool pool, MeshUtils.Edge eOrg)
		{
			MeshUtils.Edge sym = AddEdgeVertex(pool, eOrg)._Sym;
			MeshUtils.Splice(eOrg._Sym, eOrg._Sym._Oprev);
			MeshUtils.Splice(eOrg._Sym, sym);
			eOrg._Dst = sym._Org;
			sym._Dst._anEdge = sym._Sym;
			sym._Rface = eOrg._Rface;
			sym._winding = eOrg._winding;
			sym._Sym._winding = eOrg._Sym._winding;
			return sym;
		}

		public MeshUtils.Edge Connect(IPool pool, MeshUtils.Edge eOrg, MeshUtils.Edge eDst)
		{
			MeshUtils.Edge edge = MeshUtils.MakeEdge(pool, eOrg);
			MeshUtils.Edge sym = edge._Sym;
			bool flag = false;
			if (eDst._Lface != eOrg._Lface)
			{
				flag = true;
				MeshUtils.KillFace(pool, eDst._Lface, eOrg._Lface);
			}
			MeshUtils.Splice(edge, eOrg._Lnext);
			MeshUtils.Splice(sym, eDst);
			edge._Org = eOrg._Dst;
			sym._Org = eDst._Org;
			edge._Lface = (sym._Lface = eOrg._Lface);
			eOrg._Lface._anEdge = sym;
			if (!flag)
			{
				MeshUtils.MakeFace(pool, edge, eOrg._Lface);
			}
			return edge;
		}

		public void ZapFace(IPool pool, MeshUtils.Face fZap)
		{
			MeshUtils.Edge anEdge = fZap._anEdge;
			MeshUtils.Edge lnext = anEdge._Lnext;
			MeshUtils.Edge edge;
			do
			{
				edge = lnext;
				lnext = edge._Lnext;
				edge._Lface = null;
				if (edge._Rface == null)
				{
					if (edge._Onext == edge)
					{
						MeshUtils.KillVertex(pool, edge._Org, null);
					}
					else
					{
						edge._Org._anEdge = edge._Onext;
						MeshUtils.Splice(edge, edge._Oprev);
					}
					MeshUtils.Edge sym = edge._Sym;
					if (sym._Onext == sym)
					{
						MeshUtils.KillVertex(pool, sym._Org, null);
					}
					else
					{
						sym._Org._anEdge = sym._Onext;
						MeshUtils.Splice(sym, sym._Oprev);
					}
					MeshUtils.KillEdge(pool, edge);
				}
			}
			while (edge != anEdge);
			MeshUtils.Face prev = fZap._prev;
			MeshUtils.Face next = fZap._next;
			next._prev = prev;
			prev._next = next;
			pool.Return(fZap);
		}

		private static int CountFaceVerts(MeshUtils.Face f)
		{
			MeshUtils.Edge edge = f._anEdge;
			int num = 0;
			do
			{
				num++;
				edge = edge._Lnext;
			}
			while (edge != f._anEdge);
			return num;
		}

		public void MergeConvexFaces(IPool pool, int maxVertsPerFace)
		{
			MeshUtils.Edge eHead = _eHead;
			MeshUtils.Edge edge = eHead._next;
			while (edge != eHead)
			{
				MeshUtils.Edge next = edge._next;
				MeshUtils.Edge sym = edge._Sym;
				if (sym != null && edge._Lface != null && edge._Lface._inside && sym._Lface != null && sym._Lface._inside)
				{
					int num = CountFaceVerts(edge._Lface);
					int num2 = CountFaceVerts(sym._Lface);
					if (num + num2 - 2 <= maxVertsPerFace)
					{
						MeshUtils.Vertex org = edge._Lprev._Org;
						MeshUtils.Vertex org2 = edge._Org;
						MeshUtils.Vertex dst = edge._Sym._Lnext._Dst;
						MeshUtils.Vertex org3 = edge._Sym._Lprev._Org;
						MeshUtils.Vertex org4 = edge._Sym._Org;
						MeshUtils.Vertex dst2 = edge._Lnext._Dst;
						if (Geom.VertCCW(org, org2, dst) && Geom.VertCCW(org3, org4, dst2))
						{
							if (edge == next || edge == next._Sym)
							{
								next = next._next;
							}
							if (!DeleteMesh(pool, edge))
							{
								break;
							}
						}
					}
				}
				edge = next;
			}
		}

		public void MakeFace(MeshUtils.Face newFace, MeshUtils.Edge eOrig, MeshUtils.Face fNext)
		{
			(newFace._prev = fNext._prev)._next = newFace;
			newFace._next = fNext;
			fNext._prev = newFace;
			newFace._anEdge = eOrig;
			newFace._trail = null;
			newFace._marked = false;
			newFace._inside = fNext._inside;
			MeshUtils.Edge edge = eOrig;
			do
			{
				edge._Lface = newFace;
				edge = edge._Lnext;
			}
			while (edge != eOrig);
		}

		public void KillFace(IPool pool, MeshUtils.Face fDel, MeshUtils.Face newLface)
		{
			MeshUtils.Edge anEdge = fDel._anEdge;
			MeshUtils.Edge edge = anEdge;
			do
			{
				edge._Lface = newLface;
				edge = edge._Lnext;
			}
			while (edge != anEdge);
			MeshUtils.Face prev = fDel._prev;
			MeshUtils.Face next = fDel._next;
			next._prev = prev;
			prev._next = next;
			pool.Return(fDel);
		}

		public void KillVertex(IPool pool, MeshUtils.Vertex vDel, MeshUtils.Vertex newOrg)
		{
			MeshUtils.Edge anEdge = vDel._anEdge;
			MeshUtils.Edge edge = anEdge;
			do
			{
				edge._Org = newOrg;
				edge = edge._Onext;
			}
			while (edge != anEdge);
			MeshUtils.Vertex prev = vDel._prev;
			MeshUtils.Vertex next = vDel._next;
			next._prev = prev;
			prev._next = next;
			pool.Return(vDel);
		}

		private static void KillEdge(IPool pool, MeshUtils.Edge eDel)
		{
			MeshUtils.Edge.EnsureFirst(ref eDel);
			MeshUtils.Edge next = eDel._next;
			MeshUtils.Edge next2 = eDel._Sym._next;
			next._Sym._next = next2;
			next2._Sym._next = next;
			pool.Return(eDel);
		}

		public bool DeleteMesh(IPool pool, MeshUtils.Edge eDel)
		{
			MeshUtils.Edge sym = eDel._Sym;
			bool flag = false;
			if (eDel._Lface != eDel._Rface)
			{
				flag = true;
				KillFace(pool, eDel._Lface, eDel._Rface);
			}
			if (eDel._Onext == eDel)
			{
				KillVertex(pool, eDel._Org, null);
			}
			else
			{
				eDel._Rface._anEdge = eDel._Oprev;
				eDel._Org._anEdge = eDel._Onext;
				Splice(pool, eDel, eDel._Oprev);
				if (!flag)
				{
					MeshUtils.Face face = pool.Get<MeshUtils.Face>();
					if (face == null)
					{
						return false;
					}
					MakeFace(face, eDel, eDel._Lface);
				}
			}
			if (sym._Onext == sym)
			{
				KillVertex(pool, sym._Org, null);
				KillFace(pool, sym._Lface, null);
			}
			else
			{
				eDel._Lface._anEdge = sym._Oprev;
				sym._Org._anEdge = sym._Onext;
				Splice(pool, sym, sym._Oprev);
			}
			KillEdge(pool, eDel);
			return true;
		}

		public static void MeshFlipEdge(MeshUtils.Edge edge)
		{
			MeshUtils.Edge lnext = edge._Lnext;
			MeshUtils.Edge lnext2 = lnext._Lnext;
			MeshUtils.Edge sym = edge._Sym;
			MeshUtils.Edge lnext3 = sym._Lnext;
			MeshUtils.Edge lnext4 = lnext3._Lnext;
			MeshUtils.Vertex org = edge._Org;
			MeshUtils.Vertex org2 = lnext2._Org;
			MeshUtils.Vertex org3 = sym._Org;
			MeshUtils.Vertex org4 = lnext4._Org;
			MeshUtils.Face lface = edge._Lface;
			MeshUtils.Face lface2 = sym._Lface;
			edge._Org = org4;
			edge._Onext = lnext3._Sym;
			sym._Org = org2;
			sym._Onext = lnext._Sym;
			lnext2._Onext = sym;
			lnext4._Onext = edge;
			lnext3._Onext = lnext2._Sym;
			lnext._Onext = lnext4._Sym;
			edge._Lnext = lnext2;
			lnext2._Lnext = lnext3;
			lnext3._Lnext = edge;
			sym._Lnext = lnext4;
			lnext4._Lnext = lnext;
			lnext._Lnext = sym;
			lnext._Lface = lface2;
			lnext3._Lface = lface;
			lface._anEdge = edge;
			lface2._anEdge = sym;
			if (org._anEdge == edge)
			{
				org._anEdge = lnext3;
			}
			if (org3._anEdge == sym)
			{
				org3._anEdge = lnext;
			}
		}

		[Conditional("DEBUG")]
		public void Check()
		{
			MeshUtils.Face fHead = _fHead;
			fHead = _fHead;
			MeshUtils.Face next;
			MeshUtils.Edge edge;
			while ((next = fHead._next) != _fHead)
			{
				edge = next._anEdge;
				do
				{
					edge = edge._Lnext;
				}
				while (edge != next._anEdge);
				fHead = next;
			}
			MeshUtils.Vertex vHead = _vHead;
			vHead = _vHead;
			MeshUtils.Vertex next2;
			while ((next2 = vHead._next) != _vHead)
			{
				edge = next2._anEdge;
				do
				{
					edge = edge._Onext;
				}
				while (edge != next2._anEdge);
				vHead = next2;
			}
			MeshUtils.Edge eHead = _eHead;
			eHead = _eHead;
			while ((edge = eHead._next) != _eHead)
			{
				eHead = edge;
			}
		}
	}
}
