using System;

namespace ModApi.Flight.Sim
{
	public interface IStructureNode
	{
		Guid Id { get; }

		string Name { get; }
	}
}
