using System.Collections.Generic;
using UnityEngine;

namespace DV
{
	public class OverrideChecker : SceneSaveChecking.AComponentChecker
	{
		public enum Mode
		{
			Warn = 0,
			Ask = 1,
			AutoRevert = 2
		}

		public Component targetComponent;

		public Mode mode;

		[HideInInspector]
		public List<string> restrictedFields = new List<string>();

		public override bool Check(string scenePath, string objectPath)
		{
			return false;
		}
	}
}
