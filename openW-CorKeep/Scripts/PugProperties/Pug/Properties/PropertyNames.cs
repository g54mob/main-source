using System.Collections.Generic;
using UnityEngine;

namespace Pug.Properties
{
	[CreateAssetMenu(menuName = "Pug/DB/PropertyNames", fileName = "PropertyNames.asset")]
	public class PropertyNames : ScriptableObject
	{
		public List<string> names = new List<string>();
	}
}
