using Loxodon.Framework.ViewModels;
using UnityEngine;

namespace Loxodon.Framework.Tutorials
{
	public class SpriteViewModel : ViewModelBase
	{
		private string spriteName = "EquipImages_1";

		public string SpriteName
		{
			get
			{
				return spriteName;
			}
			set
			{
				Set(ref spriteName, value, "SpriteName");
			}
		}

		public void ChangeSpriteName()
		{
			SpriteName = $"EquipImages_{Random.Range(1, 30)}";
		}
	}
}
