using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Objects;
using VampireSurvivors.UI;
using Zenject;

namespace VampireSurvivors.App.Scripts.UI
{
	public class StageRandomPanel : MonoBehaviour
	{
		[SerializeField]
		private TickBoxUI _RandomEventsTickBox;

		[SerializeField]
		private TickBoxUI _RandomLevelsTickBox;

		private PlayerOptions _playerOptions;

		private StageData _stageData;

		private StageType _stageType;

		private string _pointlessString;

		public TickBoxUI RandomEventsTickBox => null;

		public TickBoxUI RandomLevelUpsTickBox => null;

		private bool HasRandomEvents { get; set; }

		private bool HasRandomLevels { get; set; }

		private bool IsStageUnlocked { get; set; }

		[Inject]
		private void Construct(PlayerOptions playerOptions)
		{
		}

		public void SetStage(StageData stageData, StageType stageType)
		{
		}

		public void OnRandomEventsToggled()
		{
		}

		public void MakeVisuallyDisabled()
		{
		}

		public void MakeVisuallyEnabled()
		{
		}

		public void OnRandomLevelsToggled()
		{
		}

		private void SetupRandomEventsToggle()
		{
		}

		private void SetupRandomLevelsToggle()
		{
		}
	}
}
