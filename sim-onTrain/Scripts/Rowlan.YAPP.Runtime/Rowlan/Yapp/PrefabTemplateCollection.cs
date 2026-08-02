using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rowlan.Yapp
{
	[Serializable]
	[CreateAssetMenu(fileName = "Prefab Template Collection", menuName = "Yapp/Templates/Prefabs/Collection")]
	public class PrefabTemplateCollection : ScriptableObject
	{
		[SerializeField]
		public List<PrefabSettingsTemplate> templates = new List<PrefabSettingsTemplate>();
	}
}
