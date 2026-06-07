using System;
using UnityEngine;

namespace ModularOptions
{
	[Serializable]
	public class UIDataType<T> where T : struct
	{
		[Tooltip("Setting used if no saved setting exists. Can also be used externally to restore defaults.")]
		[SerializeField]
		public T value;
	}
}
