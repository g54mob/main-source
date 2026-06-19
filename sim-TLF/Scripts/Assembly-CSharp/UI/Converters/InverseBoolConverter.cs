using Loxodon.Framework.Binding.Converters;

namespace UI.Converters
{
	public class InverseBoolConverter : AbstractConverter<bool, bool>
	{
		public override bool Convert(bool value)
		{
			return !value;
		}
	}
}
