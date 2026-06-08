using Rhizomatic;
using Rhizomatic.MemberBinding;
using Rhizomatic.UI;
using UnityEngine;

namespace GRP.Pages.NSCampaign
{
	public class MissionPointView : MonoBehaviour
	{
		public MissionPoint mission;

		public TextMember title;

		public GameObjectMember completed;

		public GameObjectMember locked;

		public MissionItem missionItem;

		public NavigatorContext navigatorContext;

		public void Setup(Context context)
		{
		}

		[Member]
		public void Open()
		{
		}

		private void OnValidate()
		{
		}
	}
}
