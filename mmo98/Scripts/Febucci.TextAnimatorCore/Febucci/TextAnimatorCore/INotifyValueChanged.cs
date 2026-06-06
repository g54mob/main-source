using System;

namespace Febucci.TextAnimatorCore
{
	public interface INotifyValueChanged
	{
		event Action OnValueChanged;
	}
}
