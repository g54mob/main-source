using System;
using UnityEngine;

namespace Loxodon.Framework.Localizations
{
	[Serializable]
	public class Value
	{
		[SerializeField]
		public string dataValue;

		[SerializeField]
		public UnityEngine.Object objectValue;
	}
}
