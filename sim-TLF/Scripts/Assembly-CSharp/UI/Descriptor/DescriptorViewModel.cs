using Loxodon.Framework.ViewModels;

namespace UI.Descriptor
{
	public class DescriptorViewModel : ViewModelBase
	{
		private string _descriptorText;

		public string DescriptorText
		{
			get
			{
				return _descriptorText;
			}
			set
			{
				Set(ref _descriptorText, value, "DescriptorText");
			}
		}
	}
}
