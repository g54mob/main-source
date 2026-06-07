using System.Collections.Generic;
using Gh.Tk.Story;
using UnityEngine;

namespace Gh.Tk
{
	public class UIDecorationSet : MonoBehaviour
	{
		[DropDownChoice(typeof(StoryHelper), "GetUIThemes")]
		public new string name;

		public List<GameObject> individualMeshes;

		public List<ParticleSystem> particles;
	}
}
