using Rhizomatic.MemberBinding;
using Rhizomatic.Reactive;
using UnityEngine;

namespace Rhizomatic
{
	public class GameObjectMember : Member<GameObject>, ICrewRenderer
	{
		public bool activeSelf => false;

		protected override GameObject Cast(GameObject obj)
		{
			return null;
		}

		public void SetActive(bool value)
		{
		}

		public void CrewRender(object value)
		{
		}
	}
}
