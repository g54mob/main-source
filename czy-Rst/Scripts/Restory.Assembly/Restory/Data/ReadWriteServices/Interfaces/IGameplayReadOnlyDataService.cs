using System;
using System.Threading.Tasks;
using Restory.Data.SaveLoad;

namespace Restory.Data.ReadWriteServices.Interfaces
{
	public interface IGameplayReadOnlyDataService : IReadDataService
	{
		Task<T> ReadLastGameProgressAsync<T>(SaveFileNameParameters parameters) where T : class;

		DateTime GetLastGameProgressCreationDate(SaveFileNameParameters parameters);
	}
}
