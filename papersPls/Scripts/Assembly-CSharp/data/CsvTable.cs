using haxe.ds;
using haxe.lang;

namespace data
{
	public class CsvTable : HxObject
	{
		public StringMap rowIds;

		public StringMap colIds;

		public List colIdList;

		public Array rows;

		public CsvTable(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public CsvTable(string text)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_CsvTable(CsvTable __hx_this, string text)
		{
		}

		public static PoppedRow popRow(string text, int start)
		{
			return null;
		}

		public virtual int get_numRows()
		{
			return 0;
		}

		public virtual int get_numCols()
		{
			return 0;
		}

		public virtual string toString()
		{
			return null;
		}

		public virtual string getCell(string colId, string rowId)
		{
			return null;
		}

		public virtual void setCell(string colId, string rowId, string val)
		{
		}

		public virtual Col getCol(string colId)
		{
			return null;
		}

		public virtual Array getAccumulatedRow(string throughColId, string rowId)
		{
			return null;
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

		public override string ToString()
		{
			return null;
		}
	}
}
