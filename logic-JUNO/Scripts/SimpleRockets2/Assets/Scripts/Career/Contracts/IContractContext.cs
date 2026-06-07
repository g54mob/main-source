using System.Collections.Generic;
using Assets.Scripts.State;
using ModApi.State;

namespace Assets.Scripts.Career.Contracts
{
	public interface IContractContext
	{
		IReadOnlyList<Contract> Active { get; }

		IReadOnlyList<Contract> All { get; }

		ICareerState Career { get; }

		IReadOnlyList<Contract> Completed { get; }

		IFlightContext Flight { get; }

		List<Contract> Generated { get; }

		PayloadState Payloads { get; }

		string ResourcesPath { get; }

		event ContractCompletedDelgate ContractCompleted;

		void AddNewContract(Contract contract);

		ContractLocation GetContractLocation(string locationId);

		Customer GetCustomer(string id);

		int GetNextContractNumber();

		int GetNumberOfCompletions(string id);

		bool IsTechNodeResearched(string techNodeId);

		void OnFlightEnd();

		void OnFlightStart(IFlightContext flightContext);

		void OnFlightUpdate();

		void RemoveContract(Contract contract);
	}
}
