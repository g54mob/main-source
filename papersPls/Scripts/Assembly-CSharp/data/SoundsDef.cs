using app.aud;
using haxe.lang;

namespace data
{
	public class SoundsDef : HxObject
	{
		public string id;

		public string dragStart;

		public string dragStop;

		public string drop;

		public string toTop;

		public string turnPage;

		public SoundsDef(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public SoundsDef(Xml soundsNode)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_SoundsDef(SoundsDef __hx_this, Xml soundsNode)
		{
		}

		public void play(Speaker speaker, string sound)
		{
		}

		public void playDragStart(Speaker speaker)
		{
		}

		public void playDragStop(Speaker speaker)
		{
		}

		public void playDrop(Speaker speaker)
		{
		}

		public void playToTop(Speaker speaker)
		{
		}

		public void playTurnPage(Speaker speaker)
		{
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
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
