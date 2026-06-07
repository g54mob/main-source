using LitJson;
using UnityEngine;

namespace Gh.Tk
{
	public class PirateTrait : PatronTrait
	{
		[JsonIgnore]
		private GameObject _eyePatch;

		protected PirateTrait()
		{
		}

		public PirateTrait(Patron owner)
		{
		}

		public override void Init()
		{
		}

		public override void OnRemoving()
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
