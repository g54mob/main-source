using UnityEngine;

namespace Assets.Scripts.Startup
{
	public class SingleInstanceServerScript : MonoBehaviour
	{
		private string _commandLineArguments;

		public void Initialize(string commandLineArguments)
		{
			_commandLineArguments = commandLineArguments;
		}
	}
}
