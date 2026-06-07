using DG.Tweening;

namespace Gh
{
	public static class DOTweenExtensions
	{
		public static T IgnorePause<T>(this T tween) where T : Tween
		{
			return null;
		}
	}
}
