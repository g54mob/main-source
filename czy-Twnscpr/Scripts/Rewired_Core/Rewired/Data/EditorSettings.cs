using UnityEngine;

namespace Rewired.Data
{
	public class EditorSettings : ScriptableObject
	{
		[CustomObfuscation]
		public int programVersion1;

		[CustomObfuscation]
		public int programVersion2;

		[CustomObfuscation]
		public int programVersion3;

		[CustomObfuscation]
		public int programVersion4;

		[CustomObfuscation]
		public int dataVersion;
	}
}
