using System;

public interface ITrash
{
	event Action<ITrash> OnStatusChanged;
}
