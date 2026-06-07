using System;

namespace __Project__.Scripts.Janitor.Interfaces
{
	public interface ICleanable
	{
		Action OnCleaned { get; set; }
	}
}
