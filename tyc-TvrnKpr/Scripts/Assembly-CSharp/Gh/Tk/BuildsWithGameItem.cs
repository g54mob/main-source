using System;
using Gh.Tk.Story;
using UnityEngine;

namespace Gh.Tk
{
	[RequireComponent(typeof(Buildable))]
	[RequireComponent(typeof(Larder_Tile))]
	public class BuildsWithGameItem : AttachedBehaviour
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllGameItemTemplateIds")]
		public string gameItemKey;

		public int amount;

		private Buildable _buildable;

		public override void Start()
		{
		}

		private void OnPostBuilt(object sender, EventArgs e)
		{
		}

		public void SpawnGameItems()
		{
		}
	}
}
