using app;
using app.vis;
using haxe.ds;
using haxe.lang;

namespace data
{
	public class Path : HxObject
	{
		public string id;

		public double length;

		public string next;

		public int numStops;

		public double moveSpeed;

		public string endEvent;

		public string startEvent;

		public string dieEvent;

		public string sound;

		public Anim anim;

		public bool snap;

		public double delay;

		public double hold;

		public bool warp;

		public string face;

		public Array points;

		public PointData firstPoint;

		public Path(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Path(Rand rand, Xml pathNode, StringMap animHash)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_Path(Path __hx_this, Rand rand, Xml pathNode, StringMap animHash)
		{
		}

		public virtual bool get_hasPoints()
		{
			return false;
		}

		public virtual PointData get_firstPoint()
		{
			return null;
		}

		public virtual PointData _getOnPath(double dist, PointData result)
		{
			return null;
		}

		public virtual PointData getOnPath(double dist)
		{
			return null;
		}

		public virtual PointData fillFromOnPath(PointData result, double dist)
		{
			return null;
		}

		public virtual double getDistForStop(int stop)
		{
			return 0.0;
		}

		public override double __hx_setField_f(string field, int hash, double value, bool handleProperties)
		{
			return 0.0;
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public override double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties)
		{
			return 0.0;
		}

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
