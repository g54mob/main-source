using System.ComponentModel;

namespace R3
{
	internal static class ValueChangedEventArgs
	{
		internal static readonly PropertyChangedEventArgs PropertyChanged = new PropertyChangedEventArgs("Value");

		internal static readonly DataErrorsChangedEventArgs DataErrorsChanged = new DataErrorsChangedEventArgs("Value");
	}
}
