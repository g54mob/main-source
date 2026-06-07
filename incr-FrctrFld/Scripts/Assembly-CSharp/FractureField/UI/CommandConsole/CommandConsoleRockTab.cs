using FractureField.Rocks;
using UnityEngine;

namespace FractureField.UI.CommandConsole
{
	public class CommandConsoleRockTab : CommandConsoleTab
	{
		[Header("Variables")]
		[SerializeField]
		private RockLayerType _rockLayerType;

		protected override void Awake()
		{
		}

		private void Setup()
		{
		}
	}
}
