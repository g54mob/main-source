using Rhizomatic.MemberBinding;
using Rhizomatic.Reactive;
using UnityEngine.UI;

namespace Rhizomatic
{
	public class SelectableMember : Member<Selectable>, ICrewRenderer
	{
		public bool interactable
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void CrewRender(object value)
		{
		}
	}
}
