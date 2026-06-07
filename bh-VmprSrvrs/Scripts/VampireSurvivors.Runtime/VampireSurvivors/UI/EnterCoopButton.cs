using I2.Loc;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.UI
{
	public class EnterCoopButton : MonoBehaviour
	{
		public Button _button;

		private MultiplayerManager _multiplayerManager;

		[SerializeField]
		private Localize _titleLocalize;

		[FormerlySerializedAs("_partymodeHat")]
		[SerializeField]
		private GameObject _partymodeIcons;

		[Inject]
		private void Construct(MultiplayerManager multiplayerManager)
		{
		}

		private void Awake()
		{
		}

		public void SetPartyActive()
		{
		}

		private void EnterCoop()
		{
		}

		public void ShowButton()
		{
		}
	}
}
