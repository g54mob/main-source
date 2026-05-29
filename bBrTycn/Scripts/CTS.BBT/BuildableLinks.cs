using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using Unity.AI.Navigation;

public class BuildableLinks : CTSBehaviour
{
	[InjectScope(EGetScope.Children)]
	[Inject(false)]
	private NavMeshLink[] _links;

	private static readonly HashSet<NavMeshLink> _allLinks = new HashSet<NavMeshLink>();

	public static ReadOnlyHashSet<NavMeshLink> AllLinks => _allLinks;

	public static void AddLink(NavMeshLink link)
	{
		_allLinks.Add(link);
	}

	public static void RemoveLink(NavMeshLink link)
	{
		_allLinks.Remove(link);
	}

	public static void UpdateAll()
	{
		foreach (NavMeshLink allLink in _allLinks)
		{
			if ((bool)allLink && allLink.isActiveAndEnabled)
			{
				allLink.UpdateLink();
			}
		}
	}

	protected override void OnEnabled()
	{
		base.OnEnabled();
		NavMeshLink[] links = _links;
		for (int i = 0; i < links.Length; i++)
		{
			AddLink(links[i]);
		}
	}

	protected override void OnDisabled()
	{
		base.OnDisabled();
		NavMeshLink[] links = _links;
		for (int i = 0; i < links.Length; i++)
		{
			RemoveLink(links[i]);
		}
	}
}
