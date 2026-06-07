using haxe.lang;

namespace play.night
{
	public class FamilyMember : HxObject
	{
		public string id;

		public string statusName;

		public string messageName;

		public string budgetName;

		public bool male;

		public bool justDied;

		public Stat hungry;

		public Stat cold;

		public Stat sick;

		public Emotion moodEmotion;

		public FamilyMember(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FamilyMember(string id_, int sickMax, int hungryMax, int coldMax, string statusName_, string messageName_, string budgetName_, bool male_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_night_FamilyMember(FamilyMember __hx_this, string id_, int sickMax, int hungryMax, int coldMax, string statusName_, string messageName_, string budgetName_, bool male_)
		{
		}

		public virtual bool get_isAlive()
		{
			return false;
		}

		public virtual bool get_isSick()
		{
			return false;
		}

		public virtual bool get_isVerySick()
		{
			return false;
		}

		public virtual int get_emotionFlags()
		{
			return 0;
		}

		public virtual void updateSickness()
		{
		}

		public virtual void adjustStat(string statId, int delta)
		{
		}

		public virtual string toString()
		{
			return null;
		}

		public virtual void fromString(string str)
		{
		}

		public virtual string getDescription()
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
