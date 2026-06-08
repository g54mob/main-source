using UnityEngine;

namespace Controllers
{
	public static class InputSourceIdentifier
	{
		private static SourceIdentifier _Identifier;

		public static BaseInputSource DefaultInputSource;

		public static bool UseAlternateControllerLayout;

		public static SourceIdentifier Identifier
		{
			get
			{
				if (_Identifier.Value == 0)
				{
					ResetIdentifier();
				}
				return _Identifier;
			}
		}

		public static InputSource Default => DefaultInputSource as InputSource;

		public static void ResetIdentifier()
		{
			_Identifier = Random.Range(int.MinValue, int.MaxValue);
			Debug.LogWarning($"Resetting identifier {_Identifier.Value}");
		}
	}
}
