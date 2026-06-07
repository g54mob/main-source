using TMPro;
using UnityEngine;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class GameDebugInfo : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _DebugText;

		private Stage _stage;

		private DestructibleFactory _destructibleFactory;

		[Inject]
		private void Construct(Stage stage, DestructibleFactory destructibleFactory)
		{
		}

		private void Update()
		{
		}

		private void BuildDebugInfo()
		{
		}
	}
}
