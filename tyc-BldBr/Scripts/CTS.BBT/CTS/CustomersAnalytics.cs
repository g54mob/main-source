using System.Collections.Generic;
using CTS.BBT.AI;
using GameAnalyticsSDK;
using UnityEngine;

namespace CTS
{
	public class CustomersAnalytics : MonoBehaviour
	{
		private Dictionary<string, int> _customerTypes = new Dictionary<string, int>();

		private Dictionary<string, int> _capturedCustomerTypes = new Dictionary<string, int>();

		private int _deaths;

		private int _incidents;

		private void OnDisable()
		{
			AgentActionEnterBar.AgentEnteredBar -= OnAgentEnteredBar;
			PanickingBarAlert.IncidentTriggering -= OnIncidentTriggering;
			SendData();
		}

		private void OnEnable()
		{
			AgentActionEnterBar.AgentEnteredBar += OnAgentEnteredBar;
			PanickingBarAlert.IncidentTriggering += OnIncidentTriggering;
			Cell.AgentCaptured += OnAgentCaptured;
		}

		private void OnAgentCaptured(Cell cell, Agent agent)
		{
			if (agent is Customer customer)
			{
				if (_capturedCustomerTypes.ContainsKey(customer.CustomerStyleName))
				{
					_capturedCustomerTypes[customer.CustomerStyleName]++;
				}
				else
				{
					_capturedCustomerTypes.Add(customer.CustomerStyleName, 1);
				}
			}
		}

		private void OnIncidentTriggering()
		{
			_incidents++;
		}

		private void OnAgentEnteredBar(Agent agent)
		{
			if (agent is Customer customer)
			{
				if (_customerTypes.ContainsKey(customer.CustomerStyleName))
				{
					_customerTypes[customer.CustomerStyleName]++;
				}
				else
				{
					_customerTypes.Add(customer.CustomerStyleName, 1);
				}
			}
		}

		private void SendData()
		{
			foreach (KeyValuePair<string, int> customerType in _customerTypes)
			{
				GameAnalytics.NewDesignEvent("Customers:EnteredBar:" + customerType.Key, customerType.Value);
			}
			foreach (KeyValuePair<string, int> capturedCustomerType in _capturedCustomerTypes)
			{
				GameAnalytics.NewDesignEvent("Customers:Captured:" + capturedCustomerType.Key, capturedCustomerType.Value);
			}
			if (_incidents > 0)
			{
				GameAnalytics.NewDesignEvent("Customers:Incidents", _incidents);
			}
			if (_deaths > 0)
			{
				GameAnalytics.NewDesignEvent("Customers:Deaths", _deaths);
			}
		}
	}
}
