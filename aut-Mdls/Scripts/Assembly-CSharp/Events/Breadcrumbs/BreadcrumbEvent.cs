using Data.Breadcrumbs;
using UnityEngine;

namespace Events.Breadcrumbs
{
	[CreateAssetMenu(menuName = "Events/Breadcrumb", fileName = "BreadcrumbEvent", order = 0)]
	public class BreadcrumbEvent : BaseEvent<Breadcrumb>
	{
	}
}
