using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class CharacterDataSetup : CTSBehaviour
	{
		[SerializeField]
		private CharacterDataCollection[] _characterDataCollections;

		protected override void OnAwake()
		{
			base.OnAwake();
			CharacterDataCollection[] characterDataCollections = _characterDataCollections;
			for (int i = 0; i < characterDataCollections.Length; i++)
			{
				characterDataCollections[i].AddToManager();
			}
		}
	}
}
