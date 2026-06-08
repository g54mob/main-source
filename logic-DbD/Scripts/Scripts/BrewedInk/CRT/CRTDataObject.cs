using System;
using UnityEngine;

namespace BrewedInk.CRT
{
	[CreateAssetMenu(menuName = "BrewedInk/CRT-DataConfig")]
	public class CRTDataObject : ScriptableObject
	{
		public CRTData data;

		[HideInInspector]
		public string validationId;

		private void OnValidate()
		{
			validationId = Guid.NewGuid().ToString();
		}
	}
}
