using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

namespace PugWorldGen
{
	public class DungeonReplaceObjectsAuthoring : MonoBehaviour
	{
		[ArrayElementTitle("replaceID, replaceWithID")]
		public List<Replacement> replacements = new List<Replacement>();
	}
}
