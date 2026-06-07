using System.Collections.Generic;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class ValidationResult
	{
		private List<string> _messages = new List<string>();

		public int MessageCount => _messages.Count;

		public string Result => string.Join("\n", _messages);

		public void AddMessage(ContractRequirement requirement, string message)
		{
			AddMessage(requirement.GetType().Name + ": " + message);
		}

		public void AddMessage(string message)
		{
			_messages.Add(message);
		}
	}
}
