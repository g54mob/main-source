using Doozy.Engine.Nody;
using UnityEngine;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class TPForceGraphNode : MonoBehaviour
	{
		[SerializeField]
		private GraphController _Graph;

		private PlayerOptions _playerOptions;

		private bool _isSubscribed;

		[Inject]
		private void Construct(PlayerOptions po)
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void SetNode()
		{
		}
	}
}
