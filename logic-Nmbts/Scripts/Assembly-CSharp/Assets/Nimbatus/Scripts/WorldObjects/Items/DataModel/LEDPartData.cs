using System;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class LEDPartData : BindableDronePartData
	{
		public Color Color { get; set; }
	}
}
