using Febucci.UI.Effects;

namespace Febucci.UI.Core.Parsing
{
	public class AnimationRegion : RegionBase
	{
		private readonly VisibilityMode visibilityMode;

		public readonly AnimationScriptableBase animation;

		public AnimationRegion(string tagId, VisibilityMode visibilityMode, AnimationScriptableBase animation)
			: base(null)
		{
		}

		public bool IsVisibilityPolicySatisfied(bool visible)
		{
			return false;
		}

		public void OpenNewRange(int startIndex)
		{
		}

		public void OpenNewRange(int startIndex, string[] tagWords)
		{
		}

		public void TryClosingRange(int endIndex)
		{
		}

		public void CloseAllOpenedRanges(int endIndex)
		{
		}

		public virtual void SetupContextFor(TAnimCore animator, ModifierInfo[] modifiers)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
