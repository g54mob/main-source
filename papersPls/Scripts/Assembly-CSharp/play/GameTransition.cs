using app.plat;
using data;
using haxe.lang;
using play.day;
using play.save;

namespace play
{
	public class GameTransition : HxObject
	{
		public Function whenCalled;

		public GameTransition(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public GameTransition()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_GameTransition(GameTransition __hx_this)
		{
		}

		public virtual void call(GameTransitionKind gameTransitionKind)
		{
		}

		public virtual void fadeToScreen(string name, object instant)
		{
		}

		public virtual void fadeToEndlessDay(EndlessId endlessId)
		{
		}

		public virtual void fadeToEndlessResult(EndlessResult endlessResult)
		{
		}

		public virtual void loadToScreen(SaveHeader saveHeader, string screenName)
		{
		}

		public virtual void fadeToEnd(string endId)
		{
		}

		public virtual void skipToDay(int dayId)
		{
		}

		public virtual void skipToTraveler(string travelerId, object forceDayId)
		{
		}

		public virtual void advanceToNextDay()
		{
		}

		public virtual void fadeToMainMenu()
		{
		}

		public virtual void setPause(bool pause)
		{
		}

		public virtual void flashToTitle(double duration)
		{
		}

		public virtual void openExternalLink(string url)
		{
		}

		public virtual void makeDayStash()
		{
		}

		public virtual void makeEndStash(string endId)
		{
		}

		public virtual void restoreFromStash()
		{
		}

		public virtual void startAutoSoak()
		{
		}

		public virtual void requestPlatformChange(PlatformKind newPlatformKind)
		{
		}

		public virtual void quit()
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
