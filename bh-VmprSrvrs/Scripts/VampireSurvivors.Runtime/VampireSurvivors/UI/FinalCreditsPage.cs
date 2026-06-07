using System.Collections.Generic;
using DarkTonic.MasterAudio;
using TMPro;
using Unity.Collections;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Characters;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class FinalCreditsPage : BaseUIPage
	{
		[SerializeField]
		private RectTransform _Container;

		[SerializeField]
		private GameObject _TextPrefab;

		[SerializeField]
		private TextMeshProUGUI _Title;

		[SerializeField]
		private RectTransform _CongaContainer;

		[SerializeField]
		private GameObject _CongaItem;

		[SerializeField]
		private RectTransform _BackButton;

		private PlayerOptions _playerOptions;

		private DataManager _data;

		private int switchCount;

		private List<WiggleTween> _movementTweens;

		private List<EnemyType> _enemyList;

		private List<CharacterType> _characterList;

		private Dictionary<EnemyType, List<EnemyData>> _enemyData;

		private Dictionary<CharacterType, List<CharacterData>> _characterData;

		private List<float> _switchTimes;

		private float _chickenTime;

		private List<UISpriteAnimation> _anims;

		private int _moveTweenIndex;

		[SerializeField]
		[ReadOnly]
		private float _congaSpeed;

		private bool _carrySkip;

		private int _congaLength;

		private float _widthCounter;

		private int _enemyCount;

		private int _characterCount;

		private Vector2 _JSDefaultScreenSize;

		private List<RectTransform> _spawnedConga;

		private PlaySoundResult _soundResult;

		[Inject]
		private void Construct(PlayerOptions player, DataManager data)
		{
		}

		public void Back()
		{
		}

		protected void FixedUpdate()
		{
		}

		protected override void OnShowStart(GameObject g)
		{
		}

		private void FadeInText()
		{
		}

		private void ScrollText()
		{
		}

		private void FadeOutText()
		{
		}

		private void CreateConga()
		{
		}

		private void CongaSwitch()
		{
		}

		private void CarryButton()
		{
		}

		private void CreateWiggleTweens()
		{
		}

		private void CreateEnemyList()
		{
		}

		private void GetNextCharacter()
		{
		}

		private GameObject CreateEnemyAnimation(EnemyType type, int frameIndex = 0)
		{
			return null;
		}

		private void CreateCharacterAnimation(CharacterType type, int frameIndex = 0)
		{
		}

		private GameObject CreatePawn(List<Sprite> sprites, bool flip = false)
		{
			return null;
		}

		private void CreateCharacterList()
		{
		}

		private void BuildCredits()
		{
		}
	}
}
