using System.Reflection;

namespace Namotion.Reflection
{
	public abstract class ContextualMemberInfo
	{
		public abstract MemberInfo MemberInfo { get; }

		public abstract string Name { get; }

		public override string ToString()
		{
			return Name + " (" + GetType().Name.Replace("Contextual", "").Replace("Info", "") + ") - " + base.ToString();
		}
	}
}
